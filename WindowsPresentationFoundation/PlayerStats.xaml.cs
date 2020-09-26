using ClassLibrary;
using ClassLibrary.FileManager;
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

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for PlayerStats.xaml
    /// </summary>
    public partial class PlayerStats : Window
    {
        public PlayerStats(Player player, string fifaCode, int countGoal, int countYellow)
        {
            InitializeComponent();

            if (ImagePlayersFM.HasCustomImage(BasicSettingsFM.GetCompetition().ToString(), fifaCode, player.Name))
            {
                var stringLocation = ImagePlayersFM.GetImage(BasicSettingsFM.GetCompetition().ToString(), fifaCode, player.Name);

                image.Source = new BitmapImage(new Uri(stringLocation));
            }

            lblPlayer.Content = $"{player.ShirtNumber} {player.Name}";
            lblPosition.Content = $"{Translate.Language.playerPosition} {player.Position}";
            lblIsCaptain.Content = $"{Translate.Language.captain} {(player.Captain?Translate.Language.yes:Translate.Language.no)}";
            lblGoals.Content = $"{Translate.Language.goalsScored} {countGoal}";
            lblYellowCards.Content = $"{Translate.Language.yellowCards} {countYellow}";
        }
    }
}
