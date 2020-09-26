using ClassLibrary;
using ClassLibrary.API;
using ClassLibrary.Models.Match;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.User_Control;
using static ClassLibrary.BasicSettingsFM;

namespace WindowsForms
{
    public partial class TeamStats : Form
    {
        private string fifaCode = BasicSettingsFM.GetFifaCode();
        private Competition competition = BasicSettingsFM.GetCompetition();
        private int frmHeight;
        public TeamStats()
        {
            InitializeComponent();
        }

        private void TeamStats_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TeamStats_Load(object sender, EventArgs e)
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
                List<TeamEvent> events = GetEvents(matches);
                List<string> players = GetPlayers(matches);

                List<PlayerGoalsCtrl> goals = new List<PlayerGoalsCtrl>();
                List<PlayerYellowCtrl> yellowCards = new List<PlayerYellowCtrl>();
                List<MatchCtrl> visitors = new List<MatchCtrl>();

                players.ForEach(p =>
                {
                    int countGoal = 0;
                    int countYellow = 0;
                    events.ForEach(e =>
                    {
                        if (e.Player == p)
                        {
                            if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                                countGoal++;
                            if (e.TypeOfEvent == "yellow-card")
                                countYellow++;
                        }
                    });
                    goals.Add(new PlayerGoalsCtrl(p, countGoal));
                    yellowCards.Add(new PlayerYellowCtrl(p, countYellow));
                });

                matches.ForEach(m =>
                {
                    visitors.Add(new MatchCtrl($"{m.HomeTeamCountry} VS {m.AwayTeamCountry}", m.Location, m.Attendance));
                });


                goals.Sort((x, y) => -x.GetGoals().CompareTo(y.GetGoals()));
                yellowCards.Sort((x, y) => -x.GetYellowCards().CompareTo(y.GetYellowCards()));
                visitors.Sort((x, y) => -x.GetAttendance().CompareTo(y.GetAttendance()));



                flpGoals.Controls.AddRange(goals.ToArray());
                flpYellowCards.Controls.AddRange(yellowCards.ToArray());
                flpVisitors.Controls.AddRange(visitors.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.ErrorInternetConnectionMessage);
            }
        }

        private List<string> GetPlayers(List<Match> matches)
        {
            List<string> players = new List<string>();

            List<Player> startingEleven;
            List<Player> substitutes;
            if (matches[0].HomeTeam.Code == fifaCode)
            {
                startingEleven = matches[0].HomeTeamStatistics.StartingEleven;
                substitutes = matches[0].HomeTeamStatistics.Substitutes;
            }
            else
            {
                startingEleven = matches[0].AwayTeamStatistics.StartingEleven;
                substitutes = matches[0].AwayTeamStatistics.Substitutes;
            }

            startingEleven.ForEach(p => players.Add(p.Name));
            substitutes.ForEach(p => players.Add(p.Name));

            return players;
        }

        private List<TeamEvent> GetEvents(List<Match> matches)
        {
            List<TeamEvent> events = new List<TeamEvent>();

            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                    match.HomeTeamEvents.ForEach(e => events.Add(e));
                else
                    match.AwayTeamEvents.ForEach(e => events.Add(e));
            }

            return events;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            Exit form = new Exit();
            dialogResult = form.ShowDialog();


            if (dialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form frm = this;
            frmHeight = frm.Height;
            frm.Height = Screen.PrimaryScreen.Bounds.Height;
            using (Bitmap bm = GetFormImageWithoutBorders(frm))
            {
                PrintImage(bm);
            }

        }



        private Image ImageToPrint;
        private void PrintImage(Image image)
        {
            ImageToPrint = image;

            printPreviewDialog.ShowDialog();
        }



        private Bitmap GetFormImageWithoutBorders(Form frm)
        {
            using (Bitmap whole_form = GetControlImage(frm))
            {
                Point origin = frm.PointToScreen(new Point(0, 0));
                int dx = origin.X - frm.Left;
                int dy = origin.Y - frm.Top;

                int wid = frm.ClientSize.Width;
                int hgt = frm.ClientSize.Height;
                Bitmap bm = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(whole_form, 0, 0,
                        new Rectangle(dx, dy, wid, hgt),
                        GraphicsUnit.Pixel);
                }
                return bm;
            }
        }

        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }



        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int cx = e.MarginBounds.X + e.MarginBounds.Width / 2;
            int cy = e.MarginBounds.Y + e.MarginBounds.Height / 2;
            Rectangle rect = new Rectangle(cx - ImageToPrint.Width / 2, cy - ImageToPrint.Height / 2,ImageToPrint.Width, ImageToPrint.Height);

            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.DrawImage(ImageToPrint, rect);

            this.Height = frmHeight;

        }
    }
}
