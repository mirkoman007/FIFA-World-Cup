using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ClassLibrary.BasicSettingsFM;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            GetLanguage();
            InitializeComponent();
            GetSettings();
        }

        private void GetSettings()
        {
            Competition competition = BasicSettingsFM.GetCompetition();
            Language language = BasicSettingsFM.GetLanguage();
            Resolution resolution = BasicSettingsFM.GetResolution();
            if (competition == Competition.Male)
                rbMale.IsChecked = true;
            else
                rbFemale.IsChecked = true;
            if (language == BasicSettingsFM.Language.EN)
                rbEN.IsChecked = true;
            else
                rbHR.IsChecked = true;

            if (resolution == BasicSettingsFM.Resolution.rFull)
            {
                rbFull.IsChecked = true;
            }
            else if (resolution == BasicSettingsFM.Resolution.r1080)
            {
                rb1080.IsChecked = true;
            }
            else if (resolution == BasicSettingsFM.Resolution.r720)
            {
                rb720.IsChecked = true;
            }
            else if (resolution == BasicSettingsFM.Resolution.r900)
            {
                rb900.IsChecked = true;
            }
        }

        private void GetLanguage()
        {
            if (BasicSettingsFM.IsExistSetting(SettingChoise.Language))
            {
                Language language = BasicSettingsFM.GetLanguage();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to save settings?", "Save settings", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                int sex = rbFemale.IsChecked == true ? 1 : 0;
                int lang = rbHR.IsChecked == true ? 1 : 0;


                int resol = 0;
                if (rbFull.IsChecked == true)
                {
                    resol = 1;
                }
                else if (rb1080.IsChecked == true)
                {
                    resol = 2;
                }
                else if (rb900.IsChecked == true)
                {
                    resol = 3;
                }

                BasicSettingsFM.SetSetting(SettingChoiseInt.Competition, sex);
                BasicSettingsFM.SetSetting(SettingChoiseInt.Language, lang);
                BasicSettingsFM.SetSetting(SettingChoiseInt.Resolution, resol);
            }


            this.Close();
        }

    }
}
