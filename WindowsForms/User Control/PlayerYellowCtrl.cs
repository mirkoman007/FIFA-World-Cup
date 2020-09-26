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
    public partial class PlayerYellowCtrl : UserControl
    {
        public PlayerYellowCtrl(string name, int yellowCards)
        {
            InitializeComponent(); 
            
            
            lblName.Text = name;
            lblNumb.Text = yellowCards.ToString();

            if (ImagePlayersFM.HasCustomImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), name))
            {
                picPlayer.ImageLocation = ImagePlayersFM.GetImage(BasicSettingsFM.GetCompetition().ToString(), BasicSettingsFM.GetFifaCode(), name);
            }
        }

        public int GetYellowCards()
        {
            return int.Parse(lblNumb.Text);
        }
    }
}
