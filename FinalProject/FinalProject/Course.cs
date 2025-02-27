using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Course : Form
    {
        Functions Con;
        public Course()
        {
            InitializeComponent();
            Con=new Functions();
            ShowCourse();
        }

        private void ShowCourse()
        {
            string Query = "select * from CourseTbl";
            CoursesList.DataSource = Con.GetData(Query);
        }
        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || DurationTb.Text == "" || LanguageTb.Text == "" || CourseTypeTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else 
            {
                try
                {
                    string CName = CNameTb.Text;
                    string Duration = DurationTb.Text;
                    string Language = LanguageTb.Text;
                    string CType = CourseTypeTb.Text;
                    string Query = "insert into CourseTbl values('{0}', '{1}', '{2}', '{3}')";
                    Query = string.Format(Query, CName, Duration, Language, CType);
                    Con.SetData(Query);
                    MessageBox.Show("Course Added!");
                    ShowCourse();
                    CNameTb.Text = "";
                    DurationTb.Text ="";
                    LanguageTb.Text = "";
                    CourseTypeTb.Text = "";



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void CoursesList_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            CNameTb.Text = CoursesList.SelectedRows[0].Cells[1].Value.ToString();
            DurationTb.Text = CoursesList.SelectedRows[0].Cells[2].Value.ToString();
            LanguageTb.Text = CoursesList.SelectedRows[0].Cells[3].Value.ToString();
            CourseTypeTb.Text = CoursesList.SelectedRows[0].Cells[4].Value.ToString();
            if (CNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CoursesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || DurationTb.Text == "" || LanguageTb.Text == "" || CourseTypeTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    string CName = CNameTb.Text;
                    string Duration = DurationTb.Text;
                    string Language = LanguageTb.Text;
                    string CType = CourseTypeTb.Text;
                    string Query = "update CourseTbl set CName = '{0}',CDuration = '{1}',Language = '{2}',CourseType = '{3}'where CId ='{4}'";
                    Query = string.Format(Query, CName, Duration, Language, CType, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Course Updated!");
                    ShowCourse();
                    CNameTb.Text = "";
                    DurationTb.Text = "";
                    LanguageTb.Text = "";
                    CourseTypeTb.Text = "";



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key ==0)
            {
                MessageBox.Show("Select a course!");
            }
            else
            {
                try
                {
                    string Query = "Delete from CourseTbl where CId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Course Deleted!");
                    ShowCourse();
                    CNameTb.Text = "";
                    DurationTb.Text = "";
                    LanguageTb.Text = "";
                    CourseTypeTb.Text = "";



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Faculty Obj = new Faculty();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Fees Obj = new Fees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
