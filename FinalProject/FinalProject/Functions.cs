﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter Sda;
        private string ConStr;

        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NB\Documents\CollegeDB-01.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            Sda = new SqlDataAdapter(Query, ConStr);
            Sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int Cnt=0;
            if(Con.State == ConnectionState.Closed)

            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt=Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
