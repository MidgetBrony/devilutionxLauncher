
namespace Diablo_Launcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HellfireBox = new System.Windows.Forms.PictureBox();
            this.DiabloBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HellfireBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiabloBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(488, 74);
            this.button3.TabIndex = 2;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // HellfireBox
            // 
            this.HellfireBox.Image = global::Diablo_Launcher.Properties.Resources.ep_notinstalled;
            this.HellfireBox.Location = new System.Drawing.Point(259, 12);
            this.HellfireBox.Name = "HellfireBox";
            this.HellfireBox.Size = new System.Drawing.Size(241, 363);
            this.HellfireBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HellfireBox.TabIndex = 4;
            this.HellfireBox.TabStop = false;
            this.toolTip1.SetToolTip(this.HellfireBox, "Hellfire Expansion is Missing.");
            this.HellfireBox.Click += new System.EventHandler(this.HellfireBox_Click);
            this.HellfireBox.MouseEnter += new System.EventHandler(this.HellfireBox_MouseEnter);
            this.HellfireBox.MouseLeave += new System.EventHandler(this.HellfireBox_MouseLeave);
            // 
            // DiabloBox
            // 
            this.DiabloBox.Image = global::Diablo_Launcher.Properties.Resources.demo_grey;
            this.DiabloBox.Location = new System.Drawing.Point(12, 12);
            this.DiabloBox.Name = "DiabloBox";
            this.DiabloBox.Size = new System.Drawing.Size(241, 363);
            this.DiabloBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DiabloBox.TabIndex = 3;
            this.DiabloBox.TabStop = false;
            this.toolTip1.SetToolTip(this.DiabloBox, "Launch Diablo Shareware");
            this.DiabloBox.Click += new System.EventHandler(this.DiabloBox_Click);
            this.DiabloBox.MouseEnter += new System.EventHandler(this.DiabloBox_MouseEnter);
            this.DiabloBox.MouseLeave += new System.EventHandler(this.DiabloBox_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 465);
            this.Controls.Add(this.HellfireBox);
            this.Controls.Add(this.DiabloBox);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevilutionX Launcher";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HellfireBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiabloBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox DiabloBox;
        private System.Windows.Forms.PictureBox HellfireBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

