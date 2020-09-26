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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for PlayerCtrl.xaml
    /// </summary>
    public partial class PlayerCtrl : UserControl
    {
        int goals, yellows;
        string fifaCode;
        Player player;

        public PlayerCtrl(Player player,string playerColor,string fifaCode,int countGoal,int countYellow)
        {
            InitializeComponent();

            lblNumb.Content = player.ShirtNumber.ToString();
            lblName.Content = player.Name;
            backColor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(playerColor));

            goals = countGoal;
            yellows = countYellow;
            this.fifaCode = fifaCode;
            this.player = player;

            if (ImagePlayersFM.HasCustomImage(BasicSettingsFM.GetCompetition().ToString(), fifaCode, player.Name))
            {
                var stringLocation = ImagePlayersFM.GetImage(BasicSettingsFM.GetCompetition().ToString(), fifaCode, player.Name);

                image.Source = new BitmapImage(new Uri(stringLocation));
            }
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)=> new PlayerStats(player,fifaCode, goals, yellows).Show();
        
    }
}
