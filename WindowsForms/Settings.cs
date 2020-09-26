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
    public partial class Settings : Form
    {
        private Competition competition = BasicSettingsFM.GetCompetition();
        private Language language =BasicSettingsFM.GetLanguage();
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            Save form = new Save();
            dialogResult=form.ShowDialog();


            if (dialogResult == DialogResult.Yes)
            {
                int sex, lang;
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

                form.Close();
            }
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GetSettings();
            if (competition == Competition.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            if (language == Language.EN)
                rbEN.Checked = true;
            else
                rbHR.Checked = true;

        }

        private void GetSettings()
        {
            if (BasicSettingsFM.GetLanguage() == Language.EN)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Controls.Clear();
                InitializeComponent();
            }
            else if (BasicSettingsFM.GetLanguage() == Language.HR)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                Controls.Clear();
                InitializeComponent();
            }
        }
    }
}
