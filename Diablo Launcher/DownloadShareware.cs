using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diablo_Launcher
{
    public partial class DownloadShareware : Form
    {
        bool Downloading = false;
        internal Form1 parForm;

        public DownloadShareware()
        {
            InitializeComponent();

            button1.Click += startDownload;
        }
        WebClient wc;
        private void startDownload(object sender, EventArgs e)
        {
            if (!File.Exists("spawn.mpq"))
            {
                button1.Enabled = false;

                using (wc = new WebClient())
                {
                    Downloading = true;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://"),
                        // Param2 = Path to save
                        "spawn.mpq"
                    );
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Downloading = false;

            try
            {
                progressBar1.Enabled = false;
                button1.Enabled = true;
                button1.Text = "Close";
                if (e.Cancelled)
                {
                    File.Delete("spawn.mpq");
                }
            }
            catch(Exception error)
            {
                File.Delete("spawn.mpq");
                label1.Text = "Error downloading file, please try again later.";
                Console.WriteLine(error.Message);
            }
            
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label1.Text = e.ProgressPercentage + " / 100%";
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadShareware_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Downloading)
            {
                var res = MessageBox.Show(this, "You really want to quit?", "Exit",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    wc.CancelAsync();
                    parForm.FailedDownload();
                }
            }
        }
    }
}
