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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClassLibrary.BasicSettingsFM;

namespace WindowsPresentationFoundation
{
    public partial class MainWindow : Window
    {
        bool userClosing = true;
        public MainWindow()
        {
            GetLanguage();
            InitializeComponent();
            GetSettings();
        }

        private void GetSettings()
        {
            if (BasicSettingsFM.IsExistSetting(SettingChoise.Competition) && BasicSettingsFM.IsExistSetting(SettingChoise.Language) && BasicSettingsFM.IsExistSetting(SettingChoise.Resolution))
            {

                userClosing = false;
                new FootballStadium().Show();
                this.Close();
            }
            if (BasicSettingsFM.IsExistSetting(SettingChoise.Competition) && BasicSettingsFM.IsExistSetting(SettingChoise.Language))
            {
                Competition competition = BasicSettingsFM.GetCompetition();
                Language language = BasicSettingsFM.GetLanguage();
                if (competition == Competition.Male)
                    rbMale.IsChecked = true;
                else
                    rbFemale.IsChecked = true;
                if (language == BasicSettingsFM.Language.EN)
                    rbEN.IsChecked = true;
                else
                    rbHR.IsChecked = true;
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int sex = rbFemale.IsChecked==true ? 1 : 0;
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

            userClosing = false;
            new FootballStadium().Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (userClosing)
            {
                MessageBoxResult result = MessageBox.Show(Translate.Language.exitWarning, Translate.Language.exit, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }

            }
        }
    }
}
