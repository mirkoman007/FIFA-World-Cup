using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassLibrary.BasicSettingsFM;

namespace WindowsForms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void GetSettings()
        {
            if (BasicSettingsFM.IsExistSetting(SettingChoise.Competition) && BasicSettingsFM.IsExistSetting(SettingChoise.Language))
            {
                this.Hide();
                NationalTeam form = new NationalTeam();
                form.ShowDialog();
                this.Close();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int sex,lang;
            if (rbFemale.Checked)
                sex = 1;
            else
                sex = 0;

            if (rbHR.Checked)
                lang = 1;
            else
                lang = 0;

            BasicSettingsFM.SetSetting(SettingChoiseInt.Competition, sex);
            BasicSettingsFM.SetSetting(SettingChoiseInt.Language, lang);


            this.Hide();
            NationalTeam form = new NationalTeam();
            form.ShowDialog();
            this.Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = new DialogResult();
                Exit form = new Exit();
                dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
