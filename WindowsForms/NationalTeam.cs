using ClassLibrary;
using ClassLibrary.API;
using ClassLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class NationalTeam : Form
    {
        List<string> fifaCodes = new List<string>();

        public NationalTeam()
        {
            InitializeComponent();
        }


        private void NationalTeam_Load(object sender, EventArgs e)
        {
            GetSettings();
            RetrievingDataAsync();
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

        private async void RetrievingDataAsync()
        {
            try
            {
                foreach (var team in await Get.GetTeams())
                {
                    cbTeams.Items.Add($"{team.Country} ({team.FifaCode})");
                    fifaCodes.Add(team.FifaCode);

                    if (team.FifaCode == BasicSettingsFM.GetFifaCode())
                        cbTeams.SelectedIndex = cbTeams.Items.Count - 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.ErrorInternetConnectionMessage);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string fifaCode = fifaCodes[cbTeams.SelectedIndex];
                BasicSettingsFM.SetFifaCode(fifaCode);
                this.Hide();
                FavoritePlayers form = new FavoritePlayers();
                form.ShowDialog();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.ErrorSelectCountryMessage);
            }        
        }

        private void NationalTeam_FormClosing(object sender, FormClosingEventArgs e)
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
