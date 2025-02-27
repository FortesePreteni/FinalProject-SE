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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter Both Username and Password!");
            }
            else if (UserNameTb.Text == "Admin" && PasswordTb.Text == "Password")
            {
                Student Obj = new Student();
                Obj.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Wron UserName or Password!");
                UserNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserNameTb.Text = "";
            PasswordTb.Text = "";
        }
    }
}
