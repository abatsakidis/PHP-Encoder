using IlluminationTools.FolderBrowser;

namespace IlluminationTools
{
    partial class Main
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtEncodePath = new System.Windows.Forms.TextBox();
            this.btnEncodePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDecodePath = new System.Windows.Forms.TextBox();
            this.btnDecodePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEncode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.folderBrowser1 = new IlluminationTools.FolderBrowser.ShellFolderBrowser();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEncodePath
            // 
            this.txtEncodePath.Location = new System.Drawing.Point(99, 19);
            this.txtEncodePath.Name = "txtEncodePath";
            this.txtEncodePath.Size = new System.Drawing.Size(290, 20);
            this.txtEncodePath.TabIndex = 0;
            // 
            // btnEncodePath
            // 
            this.btnEncodePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncodePath.Location = new System.Drawing.Point(395, 19);
            this.btnEncodePath.Name = "btnEncodePath";
            this.btnEncodePath.Size = new System.Drawing.Size(75, 23);
            this.btnEncodePath.TabIndex = 1;
            this.btnEncodePath.Text = "Browse...";
            this.btnEncodePath.UseVisualStyleBackColor = true;
            this.btnEncodePath.Click += new System.EventHandler(this.btnEncodePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Directory:";
            // 
            // txtDecodePath
            // 
            this.txtDecodePath.Location = new System.Drawing.Point(99, 50);
            this.txtDecodePath.Name = "txtDecodePath";
            this.txtDecodePath.Size = new System.Drawing.Size(290, 20);
            this.txtDecodePath.TabIndex = 2;
            // 
            // btnDecodePath
            // 
            this.btnDecodePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecodePath.Location = new System.Drawing.Point(395, 48);
            this.btnDecodePath.Name = "btnDecodePath";
            this.btnDecodePath.Size = new System.Drawing.Size(75, 23);
            this.btnDecodePath.TabIndex = 3;
            this.btnDecodePath.Text = "Browse...";
            this.btnDecodePath.UseVisualStyleBackColor = true;
            this.btnDecodePath.Click += new System.EventHandler(this.btnDecodePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Directory:";
            // 
            // btnEncode
            // 
            this.btnEncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncode.Location = new System.Drawing.Point(395, 229);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(97, 23);
            this.btnEncode.TabIndex = 4;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEncodePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnEncodePath);
            this.groupBox1.Controls.Add(this.txtDecodePath);
            this.groupBox1.Controls.Add(this.btnDecodePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(12, 108);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(480, 115);
            this.txtResults.TabIndex = 6;
            // 
            // folderBrowser1
            // 
            this.folderBrowser1.Title = null;
            this.folderBrowser1.Initialized += new System.EventHandler(this.folderBrowser1_Initialized);
            this.folderBrowser1.SelChanged += new IlluminationTools.FolderBrowser.FolderSelChangedEventHandler(this.folderBrowser1_SelChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 261);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEncode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHP Encoder - Version 1.0 - Batsakidis Athanasios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEncodePath;
        private System.Windows.Forms.Button btnEncodePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDecodePath;
        private System.Windows.Forms.Button btnDecodePath;
        private System.Windows.Forms.Label label2;
        private ShellFolderBrowser folderBrowser1;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResults;
    }
}

