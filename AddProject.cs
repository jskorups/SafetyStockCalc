﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SafetyStockCalc
{
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

     

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                //cmd.CommandType = System.Data.CommandType.Text;

                //cmd.CommandText = "insert into Project (Project)" +
                //    "values (@ProjectName)";
                //cmd.Parameters.AddWithValue("@ProjectName", addProjTxt.Text);

                //cmd.Connection = sqlConnection1;
                //sqlConnection1.Open();
                //cmd.ExecuteNonQuery();
                //sqlConnection1.Close();
                List<SqlParameter> listaPar = new List<SqlParameter>();
                listaPar.Add(new SqlParameter("@ProjectName", addProjTxt.Text));

                sqlNonQuery.PutDataToSql("insert into Project(Project) values(@ProjectName)", listaPar);           
                MessageBox.Show("Dodano do bazy danych pod nazwą");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
