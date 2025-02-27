using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
            timer1.Start();
        }

        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            MyProgress.Value = startP;
            PercentageLbl.Text = startP + "%";
            if (MyProgress.Value == 100) 
            {
                MyProgress.Value = 0;
                Login Object = new Login();
                Object.Show();
                this.Hide();
                timer1.Stop();
            }


        }
    }
}
