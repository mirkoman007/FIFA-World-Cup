using ClassLibrary;
using ClassLibrary.API;
using ClassLibrary.Models.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class FootballStadium : Window
    {
        private Competition competition = BasicSettingsFM.GetCompetition();

        public FootballStadium()
        {
            InitializeComponent();
        }

        private void GetSettings()
        {
            var res=BasicSettingsFM.GetResolution();

            if (res == BasicSettingsFM.Resolution.rFull)
            {
                WindowState = WindowState.Maximized;
            }
            else if (res == BasicSettingsFM.Resolution.r1080)
            {
                this.Width = 1920;
                this.Height = 1080;
            }
            else if (res == BasicSettingsFM.Resolution.r720)
            {
                this.Width = 1280;
                this.Height = 720;
            }
            else if (res == BasicSettingsFM.Resolution.r900)
            {
                this.Width = 1200;
                this.Height = 900;
            }
        }

        private void cbHomeTeam_Loaded(object sender, RoutedEventArgs e)
        {
            HomeRetrievingDataAsync();
        }

        private async void HomeRetrievingDataAsync()
        {
            try
            {
                foreach (var team in await Get.GetTeams())
                {
                    cbHomeTeam.Items.Add($"{team.Country} ({team.FifaCode})");

                    if (team.FifaCode == BasicSettingsFM.GetFifaCode())
                    {
                        cbHomeTeam.SelectedIndex = cbHomeTeam.Items.Count - 1;
                        lblMatch.Content = $"{cbHomeTeam.SelectedItem.ToString()} vs {Translate.Language.away}";
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show(Translate.Language.internetConnectionWarning);
            }
        }


        private void btnSettings_Click(object sender, RoutedEventArgs e) => new Settings().Show();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetSettings();
        }

        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedHomeTeam = cbHomeTeam.SelectedItem.ToString();
            string fifaCode = GetFifaCode(selectedHomeTeam);

            BasicSettingsFM.SetFifaCode(fifaCode);

            cbAwayTeam.Items.Clear();

            AwayRetrievingDataAsync(fifaCode);

        }

        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearPlayers();
            if (cbAwayTeam.SelectedIndex == -1)
            {
                lblMatch.Content = $"{cbHomeTeam.SelectedItem.ToString()} vs {Translate.Language.away}";
            }
            else
            {
                lblMatch.Content = $"{cbHomeTeam.SelectedItem.ToString()} vs {cbAwayTeam.SelectedItem.ToString()}";
                GetPlayers();
            }
        }

        private async void GetPlayers()
        {

            string homeFifaCode =GetFifaCode(cbHomeTeam.SelectedItem.ToString());
            string awayFifaCode =GetFifaCode(cbAwayTeam.SelectedItem.ToString());

            try
            {
                List<Match> matches = await Get.GetMatch(homeFifaCode, competition);
                List<Player> homeStartingEleven = new List<Player>();
                List<Player> awayStartingEleven = new List<Player>();
                List<TeamEvent> homeTeamEvents = new List<TeamEvent>();
                List<TeamEvent> awayTeamEvents = new List<TeamEvent>();


                matches.ForEach(m =>
                {
                    if (m.AwayTeam.Code == awayFifaCode)
                    {
                        homeStartingEleven = m.HomeTeamStatistics.StartingEleven;
                        homeTeamEvents = m.HomeTeamEvents;
                        awayStartingEleven = m.AwayTeamStatistics.StartingEleven;
                        awayTeamEvents = m.AwayTeamEvents;

                    }
                    else if (m.HomeTeam.Code == awayFifaCode)
                    {
                        awayStartingEleven = m.HomeTeamStatistics.StartingEleven;
                        awayTeamEvents = m.HomeTeamEvents;
                        homeStartingEleven = m.AwayTeamStatistics.StartingEleven;
                        homeTeamEvents = m.AwayTeamEvents;
                    }
                });


                homeStartingEleven.ForEach(p =>
                {
                    int countGoal = 0;
                    int countYellow = 0;
                    homeTeamEvents.ForEach(e =>
                    {
                        if (e.Player == p.Name)
                        {
                            if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                                countGoal++;
                            if (e.TypeOfEvent == "yellow-card")
                                countYellow++;
                        }
                    });

                    if (p.Position == Position.Goalie)
                    {
                        pnlHomeGK.Children.Add(new PlayerCtrl(p, "#00bcd4", homeFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Defender)
                    {
                        pnlHomeDef.Children.Add(new PlayerCtrl(p, "#00bcd4", homeFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Midfield)
                    {
                        pnlHomeMid.Children.Add(new PlayerCtrl(p, "#00bcd4", homeFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Forward)
                    {
                        pnlHomeAttack.Children.Add(new PlayerCtrl(p, "#00bcd4", homeFifaCode, countGoal, countYellow));
                    }
                });

                awayStartingEleven.ForEach(p =>
                {
                    int countGoal = 0;
                    int countYellow = 0;
                    awayTeamEvents.ForEach(e =>
                    {
                        if (e.Player == p.Name)
                        {
                            if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                                countGoal++;
                            if (e.TypeOfEvent == "yellow-card")
                                countYellow++;
                        }
                    });

                    if (p.Position == Position.Goalie)
                    {
                        pnlAwayGK.Children.Add(new PlayerCtrl(p, "#e05942", awayFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Defender)
                    {
                        pnlAwayDef.Children.Add(new PlayerCtrl(p, "#e05942", awayFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Midfield)
                    {
                        pnlAwayMid.Children.Add(new PlayerCtrl(p, "#e05942", awayFifaCode, countGoal, countYellow));
                    }
                    else if (p.Position == Position.Forward)
                    {
                        pnlAwayAttack.Children.Add(new PlayerCtrl(p, "#e05942", awayFifaCode, countGoal, countYellow));
                    }
                });
            }
            catch (Exception)
            {

                MessageBox.Show(Translate.Language.internetConnectionWarning);
            }

        }

        private void ClearPlayers()
        {
            pnlHomeGK.Children.Clear();
            pnlHomeDef.Children.Clear();
            pnlHomeMid.Children.Clear();
            pnlHomeAttack.Children.Clear();

            pnlAwayGK.Children.Clear();
            pnlAwayDef.Children.Clear();
            pnlAwayMid.Children.Clear();
            pnlAwayAttack.Children.Clear();
        }

        private async void AwayRetrievingDataAsync(string fifaCode)
        {
            try
            {
                List<Match> matches = await Get.GetMatch(fifaCode, competition);


                matches.ForEach(m =>
                {
                    if (m.HomeTeam.Code != fifaCode)
                        cbAwayTeam.Items.Add($"{m.HomeTeam.Country} ({m.HomeTeam.Code})");
                    else
                        cbAwayTeam.Items.Add($"{m.AwayTeam.Country} ({m.AwayTeam.Code})");
                });
            }
            catch (Exception)
            {
                MessageBox.Show(Translate.Language.chooseTeamWarning);
            }
        }

        private string GetFifaCode(string selectedText)
        {
            return selectedText.Substring(selectedText.IndexOf("(") + 1, selectedText.IndexOf(")") - selectedText.IndexOf("(") - 1);
        }

        private void btnHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            if (cbHomeTeam.SelectedItem == null)
            {
                MessageBox.Show(Translate.Language.chooseTeamWarning);
            }
            else
            {
                new TeamStats(GetFifaCode(cbHomeTeam.SelectedItem.ToString())).Show();
            }
        }

        private void btnAwayTeam_Click(object sender, RoutedEventArgs e)
        {
            if (cbAwayTeam.SelectedItem == null)
            {
                MessageBox.Show(Translate.Language.chooseTeamWarning);
            }
            else
            {
                new TeamStats(GetFifaCode(cbAwayTeam.SelectedItem.ToString())).Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(Translate.Language.exitWarning, Translate.Language.exit, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }
    }
}
