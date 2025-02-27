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
    public partial class Faculty : Form
    {
        Functions Con;
        public Faculty()
        {
            InitializeComponent();
            Con = new Functions();
            ShowFaculty();
            FetchCourse();
        }

        private void ShowFaculty()
        {
            string Query = "select * from FacultyfTbl";
            FacultyList.DataSource = Con.GetData(Query);
        }

        private void FetchCourse()
        {
            string Query = "select * from coursetbl";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (FNameTb.Text == "" || CourseCb.SelectedIndex == -1 || GenderCb.SelectedIndex == -1 || MobileTb.Text == "" || EmailTb.Text == "" || EducationTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    string FName = FNameTb.Text;
                    string Mobile = MobileTb.Text;
                    string Email = EmailTb.Text;
                    string Education = EducationTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Designation = DesignationCb.SelectedItem.ToString();
                    int Course = Convert.ToInt32(CourseCb.SelectedValue ?? 0);

                    string Query = "INSERT INTO FacultyfTbl VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})";
                    Query = string.Format(Query, FName, Gender, Mobile, Email, Education, Designation, Course); 

                    Con.SetData(Query);
                    MessageBox.Show("Faculty Added!");
                    ShowFaculty();

                    
                    FNameTb.Text = "";
                    MobileTb.Text = "";
                    EmailTb.Text = "";
                    EducationTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void FacultyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FNameTb.Text = FacultyList.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.Text = FacultyList.SelectedRows[0].Cells[2].Value.ToString();
            MobileTb.Text = FacultyList.SelectedRows[0].Cells[3].Value.ToString();
            EmailTb.Text = FacultyList.SelectedRows[0].Cells[4].Value.ToString();
            EducationTb.Text = FacultyList.SelectedRows[0].Cells[5].Value.ToString();
            DesignationCb.Text = FacultyList.SelectedRows[0].Cells[6].Value.ToString();
            CourseCb.Text = FacultyList.SelectedRows[0].Cells[7].Value.ToString();



            if (FNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(FacultyList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (FNameTb.Text == "" || CourseCb.SelectedIndex == -1 || GenderCb.SelectedIndex == -1 || MobileTb.Text == "" || EmailTb.Text == "" || EducationTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    string FName = FNameTb.Text;
                    string Mobile = MobileTb.Text;
                    string Email = EmailTb.Text;
                    string Education = EducationTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Designation = DesignationCb.SelectedItem.ToString();

                    
                    int Course = Convert.ToInt32(CourseCb.SelectedValue ?? 0);

                    string Query = "UPDATE FacultyfTbl set FName = '{0}', Gender = '{1}', Mobile = '{2}', Education = '{3}', Designation = '{4}', Course = {5} where FId = {6}";
                    Query = string.Format(Query, FName, Gender, Mobile, Education, Designation, Course, Key);

                    Con.SetData(Query);
                    MessageBox.Show("Faculty Updated!");
                    ShowFaculty();

                    FNameTb.Text = "";
                    MobileTb.Text = "";
                    EmailTb.Text = "";
                    EducationTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Faculty!");
            }
            else
            {
                try
                {
                    string Query = "DELETE from FacultyfTbl where FId = {0}";
                    Query = string.Format(Query, Key);

                    Con.SetData(Query);
                    MessageBox.Show("Faculty Deleted!");
                    ShowFaculty();


                    FNameTb.Text = "";
                    MobileTb.Text = "";
                    EmailTb.Text = "";
                    EducationTb.Text = "";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Course Obj = new Course();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FacultyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
