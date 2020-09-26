using ClassLibrary;
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
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void Exit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        private void Exit_Load(object sender, EventArgs e)
        {
            GetSettings();
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
    }
}
