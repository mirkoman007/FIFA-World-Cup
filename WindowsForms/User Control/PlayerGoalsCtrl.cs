using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.FileManager;
using ClassLibrary;

namespace WindowsForms.User_Control
{
    public partial class PlayerGoalsCtrl : UserControl
    {
        public PlayerGoalsCtrl(string name,int goals)
        {
            InitializeComponent();

            lblName.Text= name;
            lblNumb.Text = goals.ToString();

            if (ImagePlayersFM.HasCustomImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), name))
            {
                picPlayer.ImageLocation = ImagePlayersFM.GetImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), name);
            }
        }

        public int GetGoals()
        {
            return int.Parse(lblNumb.Text);
        }
    }
}
