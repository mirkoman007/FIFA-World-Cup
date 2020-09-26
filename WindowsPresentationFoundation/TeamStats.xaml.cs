using ClassLibrary.API;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for TeamStats.xaml
    /// </summary>
    public partial class TeamStats : Window
    {
        public TeamStats(string fifaCode)
        {
            InitializeComponent();

            RetrievingDataAsync(fifaCode);

        }

        private async void RetrievingDataAsync(string fifaCode)
        {
            try
            {
                foreach (var team in await Get.GetTeams())
                {
                    if (team.FifaCode == fifaCode)
                    {
                        lblCountry.Content = $"{team.Country} ({team.FifaCode})";

                        lblGamesPlayed.Content = lblGamesPlayed.Content + " " + team.GamesPlayed;
                        lblWins.Content = lblWins.Content + " " + team.Wins;
                        lblLosses.Content = lblLosses.Content + " " + team.Losses;
                        lblDraws.Content = lblDraws.Content + " " + team.Draws;

                        lblGoalsFor.Content = lblGoalsFor.Content + " " + team.GoalsFor;
                        lblGoalsAgainst.Content = lblGoalsAgainst.Content + " " + team.GoalsAgainst;
                        lblGoalDifferential.Content = lblGoalDifferential.Content + " " + team.GoalDifferential;


                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Translate.Language.internetConnectionWarning);
            }
        }

    }
}
