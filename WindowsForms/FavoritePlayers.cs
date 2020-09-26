using ClassLibrary;
using ClassLibrary.API;
using ClassLibrary.FileManager;
using ClassLibrary.Models.Match;
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
    public partial class FavoritePlayers : Form
    {
        private PlayerCtrl oznacenaCtrl;
        private string fifaCode = BasicSettingsFM.GetFifaCode();
        private Competition competition = BasicSettingsFM.GetCompetition();
        

        private PlayerCtrl dndPlayerCtrl;

        public FavoritePlayers()
        {
            InitializeComponent();
        }

        private void FavoritePlayers_Load(object sender, EventArgs e)
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
                List<Match> matches = await Get.GetMatch(fifaCode, competition);
                List<Player> startingEleven;
                List<Player> substitutes;
                if (matches[0].HomeTeam.Code==fifaCode)
                {
                    startingEleven = matches[0].HomeTeamStatistics.StartingEleven;
                    substitutes = matches[0].HomeTeamStatistics.Substitutes;
                }
                else
                {
                    startingEleven = matches[0].AwayTeamStatistics.StartingEleven;
                    substitutes = matches[0].AwayTeamStatistics.Substitutes;
                }    

                startingEleven.ForEach(p => FillFlp(p));
                substitutes.ForEach(p => FillFlp(p));

            }
            catch (Exception)
            {

                MessageBox.Show(Properties.Resources.ErrorInternetConnectionMessage);
            }

        }

        private void FillFlp(Player p)
        {
            List<int> favoritePlayers = FavoritePlayersFM.LoadFavoritePlayersData(competition.ToString(), fifaCode);
            PlayerCtrl ctrl = new PlayerCtrl(new Player
            {
                Name = p.Name,
                ShirtNumber = p.ShirtNumber,
                Position = p.Position,
                Captain = p.Captain
            });

            ctrl.MouseDown += Ctrl_MouseDown;

            if (favoritePlayers.Contains(p.ShirtNumber))
            {
                ctrl.IsFavorite=true;
                ctrl.ContextMenuStrip = cmToOthers;
                flpFavoritePlayers.Controls.Add(ctrl);
            }
            else
            {
                ctrl.IsFavorite=false;
                ctrl.ContextMenuStrip = cmToFavorites;
                flpOtherPlayers.Controls.Add(ctrl);
            }
        }
        private void Ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            StartDnD(sender as PlayerCtrl);
        }

        private void StartDnD(PlayerCtrl playerCtrl)
        {
            dndPlayerCtrl = playerCtrl;
            playerCtrl.DoDragDrop(playerCtrl, DragDropEffects.Move);
        }

        private void flpPlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flpOtherPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (dndPlayerCtrl.IsFavorite)
            {
                dndPlayerCtrl.IsFavorite = false;

                int num = dndPlayerCtrl.GetShirtNumber();
                try
                {
                    FavoritePlayersFM.RemoveFavoritePlayersData(competition.ToString(),fifaCode, num);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Properties.Resources.Error}\n{ex.Message}");
                }
                flpOtherPlayers.Controls.Add(dndPlayerCtrl);
                flpFavoritePlayers.Controls.Remove(dndPlayerCtrl);
                dndPlayerCtrl.ContextMenuStrip = cmToFavorites;
            }

        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (dndPlayerCtrl.IsFavorite)
                return;
            List<int> favoritePlayers = FavoritePlayersFM.LoadFavoritePlayersData(competition.ToString(), fifaCode);
            if (favoritePlayers.Count >= 3)
            {
                MessageBox.Show(Properties.Resources.MaxPlayersMessage);
                return;
            }




            dndPlayerCtrl.IsFavorite = true;

            int num = dndPlayerCtrl.GetShirtNumber();
            try
            {
                FavoritePlayersFM.AddFavoritePlayersData(competition.ToString(), fifaCode, num);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.Error}\n{ex.Message}");
            }
            flpFavoritePlayers.Controls.Add(dndPlayerCtrl);
            flpOtherPlayers.Controls.Remove(dndPlayerCtrl);
            dndPlayerCtrl.ContextMenuStrip = cmToOthers;

        }


        private void cmPlayer_Opened(object sender, EventArgs e)
        {
            oznacenaCtrl = (sender as ContextMenuStrip).SourceControl as PlayerCtrl; 
        }

        private void addToFavorites_Click(object sender, EventArgs e)
        {
            List<int> favoritePlayers = FavoritePlayersFM.LoadFavoritePlayersData(competition.ToString(), fifaCode);
            if (favoritePlayers.Count >= 3)
            {
                MessageBox.Show(Properties.Resources.MaxPlayersMessage);
                return;
            }

            oznacenaCtrl.IsFavorite=true;

            int num=oznacenaCtrl.GetShirtNumber();
            try
            {
                FavoritePlayersFM.AddFavoritePlayersData(competition.ToString(), fifaCode, num);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.Error}\n{ex.Message}");
            }
            flpFavoritePlayers.Controls.Add(oznacenaCtrl);
            flpOtherPlayers.Controls.Remove(oznacenaCtrl);
            oznacenaCtrl.ContextMenuStrip = cmToOthers;
        }

        private void addToOthers_Click(object sender, EventArgs e)
        {
            oznacenaCtrl.IsFavorite=false;

            int num = oznacenaCtrl.GetShirtNumber();
            try
            {
                FavoritePlayersFM.RemoveFavoritePlayersData(competition.ToString(), fifaCode, num);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.Error}\n{ex.Message}");
            }
            flpOtherPlayers.Controls.Add(oznacenaCtrl);
            flpFavoritePlayers.Controls.Remove(oznacenaCtrl);
            oznacenaCtrl.ContextMenuStrip = cmToFavorites;
        }

        private void FavoritePlayers_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeamStats form = new TeamStats();
            form.ShowDialog();
            this.Close();
        }
    }
}
