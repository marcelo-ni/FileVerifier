namespace FileComparer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceButt = new System.Windows.Forms.Button();
            this.sourceDir = new System.Windows.Forms.TextBox();
            this.sourceInclude = new System.Windows.Forms.CheckBox();
            this.targetInclude = new System.Windows.Forms.CheckBox();
            this.targetDir = new System.Windows.Forms.TextBox();
            this.targetButt = new System.Windows.Forms.Button();
            this.goButt = new System.Windows.Forms.Button();
            this.resulList = new System.Windows.Forms.ListBox();
            this.qtyText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sourceButt
            // 
            this.sourceButt.Location = new System.Drawing.Point(48, 27);
            this.sourceButt.Name = "sourceButt";
            this.sourceButt.Size = new System.Drawing.Size(75, 23);
            this.sourceButt.TabIndex = 0;
            this.sourceButt.Text = "Source";
            this.sourceButt.UseVisualStyleBackColor = true;
            this.sourceButt.Click += new System.EventHandler(this.sourceButt_Click);
            // 
            // sourceDir
            // 
            this.sourceDir.Location = new System.Drawing.Point(152, 28);
            this.sourceDir.Name = "sourceDir";
            this.sourceDir.Size = new System.Drawing.Size(358, 20);
            this.sourceDir.TabIndex = 1;
            // 
            // sourceInclude
            // 
            this.sourceInclude.AutoSize = true;
            this.sourceInclude.Location = new System.Drawing.Point(531, 30);
            this.sourceInclude.Name = "sourceInclude";
            this.sourceInclude.Size = new System.Drawing.Size(97, 17);
            this.sourceInclude.TabIndex = 2;
            this.sourceInclude.Text = "Include subdirs";
            this.sourceInclude.UseVisualStyleBackColor = true;
            // 
            // targetInclude
            // 
            this.targetInclude.AutoSize = true;
            this.targetInclude.Location = new System.Drawing.Point(532, 64);
            this.targetInclude.Name = "targetInclude";
            this.targetInclude.Size = new System.Drawing.Size(97, 17);
            this.targetInclude.TabIndex = 5;
            this.targetInclude.Text = "Include subdirs";
            this.targetInclude.UseVisualStyleBackColor = true;
            // 
            // targetDir
            // 
            this.targetDir.Location = new System.Drawing.Point(152, 62);
            this.targetDir.Name = "targetDir";
            this.targetDir.Size = new System.Drawing.Size(358, 20);
            this.targetDir.TabIndex = 4;
            // 
            // targetButt
            // 
            this.targetButt.Location = new System.Drawing.Point(49, 61);
            this.targetButt.Name = "targetButt";
            this.targetButt.Size = new System.Drawing.Size(75, 23);
            this.targetButt.TabIndex = 3;
            this.targetButt.Text = "Target";
            this.targetButt.UseVisualStyleBackColor = true;
            this.targetButt.Click += new System.EventHandler(this.targetButt_Click);
            // 
            // goButt
            // 
            this.goButt.Location = new System.Drawing.Point(49, 105);
            this.goButt.Name = "goButt";
            this.goButt.Size = new System.Drawing.Size(75, 23);
            this.goButt.TabIndex = 6;
            this.goButt.Text = "Go";
            this.goButt.UseVisualStyleBackColor = true;
            this.goButt.Click += new System.EventHandler(this.goButt_Click);
            // 
            // resulList
            // 
            this.resulList.FormattingEnabled = true;
            this.resulList.Location = new System.Drawing.Point(152, 140);
            this.resulList.Name = "resulList";
            this.resulList.Size = new System.Drawing.Size(629, 173);
            this.resulList.TabIndex = 7;
            this.resulList.Click += new System.EventHandler(this.resulList_Click);
            // 
            // qtyText
            // 
            this.qtyText.Location = new System.Drawing.Point(152, 106);
            this.qtyText.Name = "qtyText";
            this.qtyText.Size = new System.Drawing.Size(157, 20);
            this.qtyText.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 338);
            this.Controls.Add(this.qtyText);
            this.Controls.Add(this.resulList);
            this.Controls.Add(this.goButt);
            this.Controls.Add(this.targetInclude);
            this.Controls.Add(this.targetDir);
            this.Controls.Add(this.targetButt);
            this.Controls.Add(this.sourceInclude);
            this.Controls.Add(this.sourceDir);
            this.Controls.Add(this.sourceButt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sourceButt;
        private System.Windows.Forms.TextBox sourceDir;
        private System.Windows.Forms.CheckBox sourceInclude;
        private System.Windows.Forms.CheckBox targetInclude;
        private System.Windows.Forms.TextBox targetDir;
        private System.Windows.Forms.Button targetButt;
        private System.Windows.Forms.Button goButt;
        private System.Windows.Forms.ListBox resulList;
        private System.Windows.Forms.TextBox qtyText;
    }
}

