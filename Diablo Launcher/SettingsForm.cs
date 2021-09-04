using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IniParser;
//using IniParser.Model;

namespace Diablo_Launcher
{

    public partial class SettingsForm : Form
    {
        public ScreenResolutions screens = new ScreenResolutions();

        public string IniLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "/diasurgical/devilution/diablo.ini";

        //FileIniDataParser parser = new FileIniDataParser();
        //IniData data;

        IniFile ini = new IniFile();

        public string BoolToInt(bool value)
        {
            int val = 0;
            if(value)
            {
                val = 1;
            }

            return val.ToString();
        }

        public bool IntToBool(string value)
        {
            bool val = false;

            int check = Convert.ToInt32(value);
            if(check == 1)
            {
                val = true;
            }

            return val;
        }

        public SettingsForm()
        {
            InitializeComponent();
            ini.Load(IniLocation);

            ResolutionBox.DataSource = screens.resolutions;

            GetData(ini);
        }

        private void GetData(IniFile ini)
        {
            //Intro Videos
            DiabloIntro.Checked = IntToBool(ini["Diablo"]["Intro"].Value);
            HellIntro.Checked = IntToBool(ini["Hellfire"]["Intro"].Value);
            
            //Audio Settings
            SoundBar.Value = ini["Audio"]["Sound Volume"].ToInt();
            MusicBar.Value = ini["Audio"]["Music Volume"].ToInt();
            AudioWSBox.Checked = IntToBool(ini["Audio"]["Walking Sound"].Value);
            AutoESBox.Checked = IntToBool(ini["Audio"]["Auto Equip Sound"].Value);


            //Graphic Settings
            ResolutionBox.Text = string.Format("{0}X{1}", ini["Graphics"]["Width"].Value, ini["Graphics"]["Height"].Value);
            FullscreenBox.Checked = IntToBool(ini["Graphics"]["Fullscreen"].Value);
            UpscaleBox.Checked = IntToBool(ini["Graphics"]["Upscale"].Value);
            FTSBox.Checked = IntToBool(ini["Graphics"]["Fit to Screen"].Value);
            ScaleQBox.SelectedIndex = ini["Graphics"]["Scaling Quality"].ToInt();
            IntScalingBox.Checked = IntToBool(ini["Graphics"]["Integer Scaling"].Value);
            VSyncBox.Checked = IntToBool(ini["Graphics"]["Vertical Sync"].Value);
            BlendedTBox.Checked = IntToBool(ini["Graphics"]["Blended Transparency"].Value);
            CCycleBox.Checked = IntToBool(ini["Graphics"]["Color Cycling"].Value);
            FPSLimitBox.Checked = IntToBool(ini["Graphics"]["FPS Limiter"].Value);
            GammeBar.Value = ini["Graphics"]["Gamma Correction"].ToInt();


            //Game Settings
            GameSpeedBox.Value = ini["Game"]["Speed"].ToInt();
            RITBox.Checked = IntToBool(ini["Game"]["Run in Town"].Value);
            GrabInBox.Checked = IntToBool(ini["Game"]["Grab Input"].Value);
            TheoQuestBox.Checked = IntToBool(ini["Game"]["Theo Quest"].Value);
            CowQuestBox.Checked = IntToBool(ini["Game"]["Cow Quest"].Value);
            FFBox.Checked = IntToBool(ini["Game"]["Friendly Fire"].Value);
            TBardBox.Checked = IntToBool(ini["Game"]["Test Bard"].Value);
            TBarbBox.Checked = IntToBool(ini["Game"]["Test Barbarian"].Value);

            //QOL Settings
            XPBarBox.Checked = IntToBool(ini["Game"]["Experience Bar"].Value);
            EnHealthBarBox.Checked  = IntToBool(ini["Game"]["Enemy Health Bar"].Value);
            ATGoldBox.Checked  = IntToBool(ini["Game"]["Auto Gold Pickup"].Value);
            ATEWBox.Checked = IntToBool(ini["Game"]["Auto Equip Weapons"].Value);
            ATEABox.Checked = IntToBool(ini["Game"]["Auto Equip Armor"].Value);
            ATEHBox.Checked = IntToBool(ini["Game"]["Auto Equip Helms"].Value);
            ATESBox.Checked = IntToBool(ini["Game"]["Auto Equip Shields"].Value);
            ATEJBox.Checked = IntToBool(ini["Game"]["Auto Equip Jewelry"].Value);
            RanQBox.Checked = IntToBool(ini["Game"]["Randomize Quests"].Value);
            DisCripBox.Checked = IntToBool(ini["Game"]["Disable Crippling Shrines"].Value);
            ShowMonBox.Checked = IntToBool(ini["Game"]["Show Monster Type"].Value);
            AdFillsMana.Checked = IntToBool(ini["Game"]["Adria Refills Mana"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Intro
            ini["Diablo"]["Intro"] = BoolToInt(DiabloIntro.Checked);
            ini["Hellfire"]["Intro"] = BoolToInt(HellIntro.Checked);
            
            //Audio
            ini["Audio"]["Sound Volume"] = SoundBar.Value;
            ini["Audio"]["Music Volume"] = MusicBar.Value;
            ini["Audio"]["Walking Sound"] = BoolToInt(AudioWSBox.Checked);
            ini["Audio"]["Auto Equip Sound"] = BoolToInt(AutoESBox.Checked);

            //Graphics
            string[] resolution = ResolutionBox.Text.Split('X');
            ini["Graphics"]["Width"] = resolution[0];
            ini["Graphics"]["Height"] = resolution[1];
            ini["Graphics"]["Fullscreen"] = BoolToInt(FullscreenBox.Checked);
            ini["Graphics"]["Upscale"] = BoolToInt(UpscaleBox.Checked);
            ini["Graphics"]["Fit to Screen"] = BoolToInt(FTSBox.Checked);
            ini["Graphics"]["Scaling Quality"] = ScaleQBox.SelectedIndex;
            ini["Graphics"]["Integer Scaling"] = BoolToInt(IntScalingBox.Checked);
            ini["Graphics"]["Vertical Sync"] = BoolToInt(VSyncBox.Checked);
            ini["Graphics"]["Blended Transparency"] = BoolToInt(BlendedTBox.Checked);
            ini["Graphics"]["Color Cycling"] = BoolToInt(CCycleBox.Checked);
            ini["Graphics"]["FPS Limiter"] = BoolToInt(FPSLimitBox.Checked);
            ini["Graphics"]["Gamma Correction"] = GammeBar.Value;

            //Game Settings
            ini["Game"]["Speed"] = GameSpeedBox.Value.ToString();
            ini["Game"]["Run in Town"] = BoolToInt(RITBox.Checked);
            ini["Game"]["Grab Input"] = BoolToInt(GrabInBox.Checked);
            ini["Game"]["Theo Quest"] = BoolToInt(TheoQuestBox.Checked);
            ini["Game"]["Cow Quest"] = BoolToInt(CowQuestBox.Checked);
            ini["Game"]["Friendly Fire"] = BoolToInt(FFBox.Checked);
            ini["Game"]["Test Bard"] = BoolToInt(TBardBox.Checked);
            ini["Game"]["Test Barbarian"] = BoolToInt(TBarbBox.Checked);

            //QOL Settings
            ini["Game"]["Experience Bar"] = BoolToInt(XPBarBox.Checked);
            ini["Game"]["Enemy Health Bar"] = BoolToInt(EnHealthBarBox.Checked);
            ini["Game"]["Auto Gold Pickup"] = BoolToInt(ATGoldBox.Checked);
            ini["Game"]["Auto Equip Weapons"] = BoolToInt(ATEWBox.Checked);
            ini["Game"]["Auto Equip Armor"] = BoolToInt(ATEABox.Checked);
            ini["Game"]["Auto Equip Helms"] = BoolToInt(ATEHBox.Checked);
            ini["Game"]["Auto Equip Shields"] = BoolToInt(ATESBox.Checked);
            ini["Game"]["Auto Equip Jewelry"] = BoolToInt(ATEJBox.Checked);
            ini["Game"]["Randomize Quests"] = BoolToInt(RanQBox.Checked);
            ini["Game"]["Disable Crippling Shrines"] = BoolToInt(DisCripBox.Checked);
            ini["Game"]["Show Monster Type"] = BoolToInt(ShowMonBox.Checked);
            ini["Game"]["Adria Refills Mana"] = BoolToInt(AdFillsMana.Checked);

            File.Delete(IniLocation);

            ini.Save(IniLocation);

            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {

            ///Reset Defaults

            //Intro
            ini["Diablo"]["Intro"] = 1;
            ini["Hellfire"]["Intro"] = 1;

            //Audio
            ini["Audio"]["Sound Volume"] = 0;
            ini["Audio"]["Music Volume"] = 0;
            ini["Audio"]["Walking Sound"] = 1;
            ini["Audio"]["Auto Equip Sound"] = 0;

            //Graphics
            ini["Graphics"]["Width"] = 640;
            ini["Graphics"]["Height"] = 480;
            ini["Graphics"]["Fullscreen"] = 1;
            ini["Graphics"]["Upscale"] = 1;
            ini["Graphics"]["Fit to Screen"] = 1;
            ini["Graphics"]["Scaling Quality"] = 2;
            ini["Graphics"]["Integer Scaling"] = 0;
            ini["Graphics"]["Vertical Sync"] = 1;
            ini["Graphics"]["Blended Transparency"] = 1;
            ini["Graphics"]["Color Cycling"] = 1;
            ini["Graphics"]["FPS Limiter"] = 1;
            ini["Graphics"]["Gamma Correction"] = 100;

            //Game Settings
            ini["Game"]["Speed"] = 20;
            ini["Game"]["Run in Town"] = 1;
            ini["Game"]["Grab Input"] = 0;
            ini["Game"]["Theo Quest"] = 0;
            ini["Game"]["Cow Quest"] = 0;
            ini["Game"]["Friendly Fire"] = 1;
            ini["Game"]["Test Bard"] = 0;
            ini["Game"]["Test Barbarian"] = 0;

            //QOL Settings
            ini["Game"]["Experience Bar"] = 0;
            ini["Game"]["Enemy Health Bar"] = 0;
            ini["Game"]["Auto Gold Pickup"] = 0;
            ini["Game"]["Auto Equip Weapons"] = 1;
            ini["Game"]["Auto Equip Armor"] = 0;
            ini["Game"]["Auto Equip Helms"] = 0;
            ini["Game"]["Auto Equip Shields"] = 0;
            ini["Game"]["Auto Equip Jewelry"] = 0;
            ini["Game"]["Randomize Quests"] = 1;
            ini["Game"]["Disable Crippling Shrines"] = 0;
            ini["Game"]["Show Monster Type"] = 0;
            ini["Game"]["Adria Refills Mana"] = 0;

            File.Delete(IniLocation);

            ini.Save(IniLocation);

            this.Close();
        }
    }
}
