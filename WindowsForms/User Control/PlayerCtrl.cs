using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Models.Match;
using ClassLibrary;
using ClassLibrary.FileManager;
using static ClassLibrary.BasicSettingsFM;
using System.Threading;
using System.Globalization;

namespace WindowsForms
{
    public partial class PlayerCtrl : UserControl
    {
        public PlayerCtrl(Player p)
        {
            InitializeComponent();

            GetSettings();

            lblName.Text = p.Name;
            lblNumb.Text = p.ShirtNumber.ToString();
            lblPosition.Text = $"{Properties.Resources.Position}: {p.Position}";
            lblCaptain.Text = $"{Properties.Resources.Captain}: {(p.Captain ? Properties.Resources.Yes : Properties.Resources.No)}";


            if (ImagePlayersFM.HasCustomImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), p.Name))
            {
                picPlayer.ImageLocation = ImagePlayersFM.GetImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), p.Name);
            }


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

        private bool isFavorite;
        internal bool IsFavorite
        {
            get => isFavorite;
            set
            {
                isFavorite = value;
                if(value)
                    picFavorite.Image = WindowsForms.Properties.Resources.star_solid;
                else
                    picFavorite.Image = WindowsForms.Properties.Resources.star_regular;
            }
        }



        internal int GetShirtNumber()
        {
            return int.Parse(lblNumb.Text);
        }


        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = $"{Properties.Resources.ImageData}|*.bmp;*.jpg;*.jpeg;*.png|{Properties.Resources.OthersData}| *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string destFile = ImagePlayersFM.UploadImage(ofd.FileName, BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), lblName.Text);
                picPlayer.ImageLocation = destFile;
            }
        }

        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePlayersFM.DeleteImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), lblName.Text);
            picPlayer.Image = Properties.Resources.player;
        }

    }
}
