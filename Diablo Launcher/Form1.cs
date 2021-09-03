using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diablo_Launcher
{
    public partial class Form1 : Form
    {
        bool ExpansionEnabled = false;
        bool MainGame = false;


        public Form1()
        {
            InitializeComponent();
        
            if(File.Exists("hellfire.mpq"))
            {
                ExpansionEnabled = true;
            }

            if(File.Exists("diabdat.mpq"))
            {
                MainGame = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if(ExpansionEnabled)
            {
                HellfireBox.Image = Properties.Resources._2_grey;
                toolTip1.SetToolTip(HellfireBox, "Click to Launch Hellfire");
            }

            if(MainGame)
            {
                DiabloBox.Image = Properties.Resources._1_grey;
                toolTip1.SetToolTip(DiabloBox, "Click to Launch Diablo");
            }

            if(!MainGame && !File.Exists("spawn.mpq"))
            {
                MessageBox.Show("Need either the diabdat.mdq or spawn.mdq in the current directory", "Missing Game Files");
                Application.Exit();
                //DownloadShareware dls = new DownloadShareware();
                //dls.parForm = this;
                //dls.ShowDialog();
            }
        }

        private void DiabloBox_MouseEnter(object sender, EventArgs e)
        {
            if(MainGame)
            {
                DiabloBox.Image = Properties.Resources._1;
            }
            else
            {
                DiabloBox.Image = Properties.Resources.demo;
            }
        }

        private void DiabloBox_MouseLeave(object sender, EventArgs e)
        {
            if (MainGame)
            {
                DiabloBox.Image = Properties.Resources._1_grey;
            }
            else
            {
                DiabloBox.Image = Properties.Resources.demo_grey;
            }
        }

        private void HellfireBox_MouseEnter(object sender, EventArgs e)
        {
            if(ExpansionEnabled)
            {
                HellfireBox.Image = Properties.Resources._2;
            }
        }

        private void HellfireBox_MouseLeave(object sender, EventArgs e)
        {
            if(ExpansionEnabled)
            {
                HellfireBox.Image = Properties.Resources._2_grey;
            }
        }

        public void FailedDownload()
        {
            Application.Exit();
        }

        private void DiabloBox_Click(object sender, EventArgs e)
        {
            if (File.Exists("devilutionx.exe"))
            {

                if (!ExpansionEnabled)
                {
                    Process startDiablo = new Process();
                    startDiablo.StartInfo.FileName = "devilutionx.exe";
                    startDiablo.Start();
                }
                else
                {
                    Process startDiablo = new Process();
                    startDiablo.StartInfo.FileName = "devilutionx.exe";
                    startDiablo.StartInfo.Arguments = "--diablo";
                    startDiablo.Start();
                }
            }
            else
            {
               var Response = MessageBox.Show("This must be place within the same directory as devilutionx.exe. \n If you don't have it, press yes to go to GitHub to download it.", "Missing devilutionx", MessageBoxButtons.YesNo);
               
                if(Response == DialogResult.Yes)
                {
                    Process.Start("https://github.com/diasurgical/devilutionX/releases");
                }
            }
        }

        private void HellfireBox_Click(object sender, EventArgs e)
        {
            if (File.Exists("devilutionx.exe"))
            {
                if (ExpansionEnabled)
                {
                    Process startDiablo = new Process();
                    startDiablo.StartInfo.FileName = "devilutionx.exe";
                    startDiablo.Start();
                }
            }
            else
            {
                var Response = MessageBox.Show("This must be place within the same directory as devilutionx.exe. \n If you don't have it, press yes to go to GitHub to download it.", "Missing devilutionx", MessageBoxButtons.YesNo);

                if (Response == DialogResult.Yes)
                {
                    Process.Start("https://github.com/diasurgical/devilutionX/releases");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
