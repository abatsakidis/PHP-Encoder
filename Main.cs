using System;
using System.Windows.Forms;
using IlluminationTools.Encrypt;
using IlluminationTools.FolderBrowser;
using System.IO;

namespace IlluminationTools
{
    public partial class Main : Form
    {
        public static Main _Main1;

        public Main()
        {
            InitializeComponent();
            _Main1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void update(string message)
        {
            txtResults.Text += message;
            txtResults.SelectionStart = txtResults.Text.Length;
            txtResults.ScrollToCaret();
        }

        private void btnEncodePath_Click(object sender, EventArgs e)
        {
            try
            {
                BrowseFlags flags = 0;

                Array arr = Enum.GetNames(typeof(BrowseFlags));

                for (int i = 0; i < arr.Length; i++)
                {
                    BrowseFlags flag = (BrowseFlags)Enum.Parse(typeof(BrowseFlags), arr.GetValue(i).ToString());
                    if ((flag & folderBrowser1.BrowseFlags) != 0)
                        flags |= (BrowseFlags)Enum.Parse(typeof(BrowseFlags), arr.GetValue(i).ToString());

                }

                folderBrowser1.BrowseFlags = flags;
                folderBrowser1.Title = "Please select source folder to encode ";
                Boolean dialogResult = folderBrowser1.ShowDialog();
                if (dialogResult)
                {
                    txtEncodePath.Text = folderBrowser1.FolderPath;
                }
                
            }
            catch (Exception ExceptionErr)
            {
                MessageBox.Show(ExceptionErr.Message);
            }
        }

        private void btnDecodePath_Click(object sender, EventArgs e)
        {
            try
            {

                BrowseFlags flags = 0;

                Array arr = Enum.GetNames(typeof(BrowseFlags));

                for (int i = 0; i < arr.Length; i++)
                {
                    BrowseFlags flag = (BrowseFlags)Enum.Parse(typeof(BrowseFlags), arr.GetValue(i).ToString());
                    if ((flag & folderBrowser1.BrowseFlags) != 0)
                        flags |= (BrowseFlags)Enum.Parse(typeof(BrowseFlags), arr.GetValue(i).ToString());

                }

                folderBrowser1.BrowseFlags = flags;
                folderBrowser1.Title = "Please select source folder to encode ";
                Boolean dialogResult = folderBrowser1.ShowDialog();
                if (dialogResult)
                {
                    txtDecodePath.Text = folderBrowser1.FolderPath;
                }


            }
            catch (Exception ExceptionErr)
            {
                MessageBox.Show(ExceptionErr.Message);
            }
        }

        private void folderBrowser1_SelChanged(object sender, FolderSelChangedEventArgs e)
        {
            try
            {
                string Sel = e.CurSelFolderPath;
                string Pidl = e.CurSelFolderPidl.ToString();

                if (Sel.Trim().Equals(String.Empty))
                {
                    folderBrowser1.EnableOkButton(false);
                }
                else
                {
                    folderBrowser1.EnableOkButton(true);
                }
            }
            catch
            {

            }
        }

        private void folderBrowser1_Initialized(object sender, EventArgs e)
        {
            folderBrowser1.EnableOkButton(false);
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (txtEncodePath.Text != "" && txtDecodePath.Text != "")
            {
                try
                {
                    txtResults.Text = "";
                    txtResults.Text += "Start PHP Encoding...\r\n";
                    txtResults.Text += "Source Directory " + txtEncodePath.Text + "\r\n";
                    txtResults.Text += "Target Directory " + txtDecodePath.Text + "\r\n";
                    txtResults.Text += "Encoding files...\r\n";

                    string LogFileName = "Log.txt";
                    FileInfo fi = new FileInfo(LogFileName);
                    FileStream fstr = fi.Create();
                    fstr.Close();

                    FileInfo f = new FileInfo(LogFileName);
                    StreamWriter writeLog = f.CreateText();

                    string encodePath = txtEncodePath.Text.Trim();
                    string decodePath = txtDecodePath.Text.Trim();

                    if (!String.IsNullOrEmpty(encodePath) && !String.IsNullOrEmpty(decodePath))
                    {
                        IEncodePHP iEncodePHP = new IEncodePHP(writeLog);
                        iEncodePHP.GetFileInDirectory(encodePath, 1, decodePath);
                        txtResults.Text += "Done!!\r\n";
                        txtResults.SelectionStart = txtResults.Text.Length;
                        txtResults.ScrollToCaret();

                        MessageBox.Show("Encode is completed!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Can not encode the source path!", "Warning");
                    }

                    writeLog.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not encode the source path: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else 
            {
                MessageBox.Show("Please, select source and target directory!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
