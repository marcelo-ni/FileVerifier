using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileComparer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            goButt.Enabled = false;
        }

        bool selectedSource = false;
        bool selectedTarget = false;

        private void sourceButt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sourceBrowser = new FolderBrowserDialog();
            if (!String.IsNullOrEmpty(sourceDir.Text))
                sourceBrowser.SelectedPath = sourceDir.Text;
            DialogResult res = sourceBrowser.ShowDialog();
            if (res == DialogResult.OK) {
                sourceDir.Text = sourceBrowser.SelectedPath;
                selectedSource = true;
                checkCanGo();
            }
            sourceBrowser.Dispose();
        }



        private void targetButt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog targetBrowser = new FolderBrowserDialog();
            if (!String.IsNullOrEmpty(targetDir.Text))
                targetBrowser.SelectedPath = targetDir.Text;
            DialogResult res = targetBrowser.ShowDialog();
            if (res == DialogResult.OK) {
                targetDir.Text = targetBrowser.SelectedPath;
                selectedTarget = true;
                checkCanGo();
            }
            targetBrowser.Dispose();
        }

        void checkCanGo()
        {
            if (selectedSource && selectedTarget) {
                if (sourceDir.Text != targetDir.Text)
                    goButt.Enabled = true;
            }
        }
        
        List<string> getFiles( string path )
        {
            return new List<string>(Directory.EnumerateFiles(path));
        }

        List<string> getDirs( string path )
        {
            return new List<string>(Directory.EnumerateDirectories(path));
        }

        List<string> getDirectoryContent( string path, bool incsubdirs)
        {
            List<string> result = new List<string>();

            if (!incsubdirs) { 
                return getFiles(path);
            }
            else {
                List<string> filelist = getFiles(path);
                if (filelist.Count > 0)
                    result.AddRange(filelist);
                List<string> dirlist = getDirs(path);
                if (dirlist.Count > 0) { 
                    foreach (string dir in dirlist) {
                        result.AddRange(getDirectoryContent(dir, incsubdirs));
                    }
                }
            }
       
            return result;
        }

        List<string> reduce( string path, List<string> target )
        {
            List<string> result = new List<string>();
            string testname = Path.GetFileName(path);
            foreach (string now in target) {
                string namenow = Path.GetFileName(now);
                if (namenow == testname)
                    result.Add(now);
            }
            return result;
        }

        enum SearchResult
        {
            Found = 1,
            NameNotFound = 2,
            FilesDiffer,
        }

        bool equalDates( DateTime l, DateTime r)
        {
            if (l.Year == r.Year && l.Month == r.Month && l.Day == r.Day)
                return true;
            return false;
        }

        SearchResult checkFile( string path, List<string> target, out FileInfo testinfo, out int count)
        {
            string testname = Path.GetFileName(path);
            count = 0;
            testinfo = new FileInfo(path);
            List<string> reduced = reduce(path, target);
            count = reduced.Count;
            if (reduced.Count == 0)
                return SearchResult.NameNotFound;
            foreach (string now in reduced) {
                //string namenow = Path.GetFileName(now);
                //if (namenow != testname)
                //    continue;
                FileInfo infonow = new FileInfo(now);
                if ( equalDates( infonow.LastWriteTime, testinfo.LastWriteTime) && infonow.Length == testinfo.Length)
                    return SearchResult.Found;                
            }
            return SearchResult.FilesDiffer;
        }

        List<string> sourceList;
        List<string> targetList;

        private void goButt_Click(object sender, EventArgs e)
        {
            sourceList = getDirectoryContent(sourceDir.Text, sourceInclude.Checked);
            targetList = getDirectoryContent(targetDir.Text, targetInclude.Checked);

            int notfound = 0;
            resulList.Items.Clear();
            FileInfo info;
            int count = 0;
            foreach (string path in sourceList) {
                SearchResult res = checkFile(path, targetList, out info, out count);
                if ( res == SearchResult.Found )
                    continue;
                string brief = res == SearchResult.NameNotFound? "N" : "D";
                string toadd = String.Format("{3} {4} {0:yyyy-MM-dd} {1,15} {2}", info.CreationTime, info.Length, path, brief, count);
                resulList.Items.Add(toadd);
                notfound++;
                
            }

            qtyText.Text = String.Format("{0} / {1}", notfound, sourceList.Count);
            
        }

        private void resulList_Click(object sender, EventArgs e)
        {
            string item = resulList.Items[resulList.SelectedIndex].ToString();
            string[] parts = item.Split(new char[] { ' ' });
            string path = parts[parts.Length - 1];
            List<string> reduced = reduce(path, targetList);
            StringBuilder sb = new StringBuilder();
            foreach (string tgt in reduced) {
                FileInfo info = new FileInfo( tgt );
                sb.AppendFormat("{0:yyyy-MM-dd} {1,15} {2}{3}", info.LastWriteTime, info.Length, tgt, Environment.NewLine);
            }
            MessageBox.Show( sb.ToString());
        }


    }
}
