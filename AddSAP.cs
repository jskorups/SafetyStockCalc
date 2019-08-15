using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyStockCalc
{
    public partial class AddSAP : Form
    {
        public AddSAP()
        {
            InitializeComponent();
            projectLoad();
           
        }

        private void cancelSAPBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void projectLoad ()
        {
            
            DataSet dP = sqlQuery.GetDataFromSql("select  * from Project;");
            addSAPprojectCmb.DataSource = dP.Tables[0];
            addSAPprojectCmb.ValueMember = "id";
            addSAPprojectCmb.DisplayMember = "Project";
            addSAPprojectCmb.SelectedIndex = -1;
        }


        private void addSapBtn_Click(object sender, EventArgs e)
        {
   
            try
            {

                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "insert into SAP(SAP, idProject)" +
                    "values (@SAP, @idProject)";
                cmd.Parameters.AddWithValue("@SAP", sapTxt.Text);
                cmd.Parameters.AddWithValue("@idProject", addSAPprojectCmb.SelectedValue);

                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Dodano do bazy danych pod nazwą");
                this.Close();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message + "Nie można dodać do bazdy danych.");
            }
        }
    }
}
