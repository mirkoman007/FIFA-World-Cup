using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.User_Control
{
    public partial class MatchCtrl : UserControl
    {
        public MatchCtrl(string teams,string location,int attendance)
        {
            InitializeComponent();
            lblTeams.Text = teams;
            lblLocation.Text = location;
            lblNumb.Text = attendance.ToString();

        }

        public int GetAttendance()
        {
            return int.Parse(lblNumb.Text);
        }
    }
}
