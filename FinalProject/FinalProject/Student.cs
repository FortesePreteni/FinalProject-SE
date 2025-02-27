using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            Con = new Functions();
            FetchCourse();
            ShowStudents();
        }
        Functions Con;

        private void ShowStudents()
        {
            string Query = "select * from StudentTbl";
            StudentsList.DataSource = Con.GetData(Query);
        }

        private void FetchCourse() 
        {
            string Query = "select * from coursetbl";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || CourseCb.SelectedIndex == -1 || GenderCb.SelectedIndex == -1 || MobileTb.Text == "" || EmailTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    string SName = SNameTb.Text;
                    string Mobile = MobileTb.Text;
                    string Email = EmailTb.Text;
                    string Address = AddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    int Course = Convert.ToInt32(CourseCb.SelectedValue ?? 0);

                    string Query = "UPDATE StudentTbl SET SName = '{0}', Course = {1}, Gender = '{2}', Mobile = '{3}', EmailId = '{4}', Address = '{5}' WHERE RollNumber = {6}";
                    Query = string.Format(Query, SName, Course, Gender, Mobile, Email, Address, Key);

                    Con.SetData(Query); 

                    MessageBox.Show("Student Updated!");
                    ShowStudents();

                    
                    SNameTb.Text = "";
                    MobileTb.Text = "";
                    EmailTb.Text = "";
                    AddressTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || CourseCb.SelectedIndex==-1 || GenderCb.SelectedIndex == -1 || MobileTb.Text == "" || EmailTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    string SName = SNameTb.Text;
                    string Mobile = MobileTb.Text;
                    string Email = EmailTb.Text;
                    string Address = AddressTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    int Course = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    
                    string Query = "insert into StudentTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                    Query = string.Format(Query, SName, Gender, Course, Mobile, Email, Address);
                    Con.SetData(Query);
                    MessageBox.Show("Student Added!");
                    ShowStudents();
                    SNameTb.Text = "";
                    MobileTb.Text = "";
                    AddressTb.Text = "";
                    EmailTb.Text = "";



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void StudentsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = StudentsList.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.Text = StudentsList.SelectedRows[0].Cells[2].Value.ToString();
            CourseCb.Text = StudentsList.SelectedRows[0].Cells[3].Value.ToString();
            MobileTb.Text = StudentsList.SelectedRows[0].Cells[4].Value.ToString();
            EmailTb.Text = StudentsList.SelectedRows[0].Cells[5].Value.ToString();
            AddressTb.Text = StudentsList.SelectedRows[0].Cells[6].Value.ToString();

            if (SNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StudentsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a row!");
            }
            else
            {
                try
                {
                    string Query = "DELETE from StudentTbl WHERE RollNumber = {0}";
                    Query = string.Format(Query, Key);

                    Con.SetData(Query);

                    MessageBox.Show("Student Deleted!");
                    ShowStudents();


                    SNameTb.Text = "";
                    MobileTb.Text = "";
                    EmailTb.Text = "";
                    AddressTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Faculty Obj = new Faculty();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Course Obj = new Course();
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
