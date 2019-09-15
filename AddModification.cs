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
    public partial class AddModification : Form
    {
        public AddModification()
        {
            InitializeComponent();
            fillCombos.fillComboWithProject(ProjektComb);
            //projectLoad();
            fillCombos.fillComboWithSAPbyProject(SAPcomb, ProjektComb);
            //sapLoad();
            AddModBtn.Enabled = false;
            DelModBtn.Enabled = false;
        }

        private void AddModBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "insert into Modifications (modName, SAPid, ProjectId)" +
                    "values (@modName, @SAP, @projectId)";
                cmd.Parameters.AddWithValue("@modName", modTxt.Text );
                cmd.Parameters.AddWithValue("@SAP", SAPcomb.SelectedValue);
                cmd.Parameters.AddWithValue("@projectId", ProjektComb.SelectedValue);

                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Dodano do bazy danych pod nazwą");
                this.Close();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message + "Nie można dodać do bazy danych");
            }
        }
        private void ProjektComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCombos.fillComboWithSAPbyProject(SAPcomb, ProjektComb);
        }

        private void modTxt_TextChanged(object sender, EventArgs e)
        {
            if (ProjektComb.Text.Length > 2 && SAPcomb.Text.Length > 2 && !string.IsNullOrEmpty(modTxt.Text))
            {
                AddModBtn.Enabled = true;
                DelModBtn.Enabled = true;
            }
            else
            {
                AddModBtn.Enabled = false;
                DelModBtn.Enabled = false;
            }
        }
    }
}
