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
    public partial class Fees : Form
    {
        Functions Con;
        public Fees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowFees();
            FetchStudent();
            FetchCourse();
        }

        private void ShowFees()
        {
            string Query = "select * from FeesTbl";
            FeeList.DataSource = Con.GetData(Query);
        }

        private void FetchStudent()
        {
            string Query = "SELECT * FROM StudentTbl";
            StudentNameCb.ValueMember = Con.GetData(Query).Columns["RollNumber"].ToString();
            StudentNameCb.DisplayMember = Con.GetData(Query).Columns["SName"].ToString();
            StudentNameCb.DataSource = Con.GetData(Query);
        }

        private void FetchCourse()
        {
            string Query = "SELECT * FROM CourseTbl";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);
        }



        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StudentNameCb.SelectedIndex == -1 || CourseCb.SelectedIndex == -1 || YearCb.SelectedIndex == -1 || TotalFeestb.Text == "" || PaidFeesTb.Text == "" || BalanceTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    int StudentName = Convert.ToInt32(StudentNameCb.SelectedValue ?? 0);
                    int Course = Convert.ToInt32(CourseCb.SelectedValue ?? 0);
                    string Year = YearCb.SelectedItem.ToString();
                    int TotalFees = Convert.ToInt32(TotalFeestb.Text);
                    int PaidFees = Convert.ToInt32(PaidFeesTb.Text);
                    int Balance = Convert.ToInt32(BalanceTb.Text);

                    string Query = "UPDATE FeesTbl SET Student = '{0}', Course = {1}, AcademicYear = '{2}', TotalFees = {3}, PaidFees = {4}, Balance = {5} WHERE FCode = {6}";
                    Query = string.Format(Query, StudentName, Course, Year, TotalFees, PaidFees, Balance, Key);

                    Con.SetData(Query);
                    MessageBox.Show("Fees Updated!");
                    ShowFees();

                    StudentNameCb.SelectedIndex = -1;
                    CourseCb.SelectedIndex = -1;
                    YearCb.SelectedIndex = -1;
                    TotalFeestb.Text = "";
                    PaidFeesTb.Text = "";
                    BalanceTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (StudentNameCb.SelectedIndex == -1 || CourseCb.SelectedIndex == -1 || YearCb.SelectedIndex == -1 || TotalFeestb.Text == "" || PaidFeesTb.Text == "" || BalanceTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    int StudentName = Convert.ToInt32(StudentNameCb.SelectedValue ?? 0);
                    int Course = Convert.ToInt32(CourseCb.SelectedValue ?? 0);
                    string Year = YearCb.SelectedItem.ToString();
                    int TotalFees = Convert.ToInt32(TotalFeestb.Text);
                    int PaidFees = Convert.ToInt32(PaidFeesTb.Text);
                    int Balance = Convert.ToInt32(BalanceTb.Text);


                    string Query = "INSERT INTO FeesTbl VALUES('{0}', {1}, '{2}', {3}, {4}, {5})";
                    Query = string.Format(Query, StudentName, Course, Year, TotalFees, PaidFees, Balance);

                    Con.SetData(Query);
                    MessageBox.Show("Fees Added!");
                    ShowFees();

                    StudentNameCb.SelectedIndex = -1;
                    CourseCb.SelectedIndex = -1;
                    YearCb.SelectedIndex = -1;
                    TotalFeestb.Text = "";
                    PaidFeesTb.Text = "";
                    BalanceTb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        int Key = 0;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Fee Record!");
            }
            else
            {
                try
                {
                    string Query = "DELETE from FeesTbl where FCode = {0}";
                    Query = string.Format(Query, Key);

                    Con.SetData(Query);
                    MessageBox.Show("Fee Record Deleted!");
                    ShowFees();

                    StudentNameCb.SelectedIndex = -1;
                    CourseCb.SelectedIndex = -1;
                    YearCb.SelectedIndex = -1;
                    TotalFeestb.Text = "";
                    PaidFeesTb.Text = "";
                    BalanceTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void FeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FeeList.SelectedRows.Count > 0)
            {

                if (FeeList.SelectedRows[0].Cells[1].Value != null)
                    StudentNameCb.SelectedValue = FeeList.SelectedRows[0].Cells[1].Value;

                if (FeeList.SelectedRows[0].Cells[2].Value != null)
                    CourseCb.SelectedValue = FeeList.SelectedRows[0].Cells[2].Value;

                YearCb.Text = FeeList.SelectedRows[0].Cells[3].Value?.ToString();
                TotalFeestb.Text = FeeList.SelectedRows[0].Cells[4].Value?.ToString();
                PaidFeesTb.Text = FeeList.SelectedRows[0].Cells[5].Value?.ToString();
                BalanceTb.Text = FeeList.SelectedRows[0].Cells[6].Value?.ToString();

                if (StudentNameCb.SelectedValue == null)
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(FeeList.SelectedRows[0].Cells[0].Value);
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Faculty Obj = new Faculty();
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

        private void Fees_Load(object sender, EventArgs e)
        {

        }

        private void StudentNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
