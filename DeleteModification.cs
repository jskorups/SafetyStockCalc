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
    public partial class DeleteModification : Form
    {
        public DeleteModification()
        {
            InitializeComponent();
            delModProjComb.SelectedIndex = -1;
            fillCombos.fillComboWithProject(delModProjComb);
        }


        private void delModProjComb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (delModProjComb.SelectedIndex > -1)
            {
                fillCombos.fillComboWithSAPbyProject(delModSapComb, delModProjComb);
                fillCombos.fillComboWithMODbySAP(delModModComb, delModSapComb);
            }
            return;

        }

        private void delModSapComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCombos.fillComboWithMODbySAP(delModModComb, delModSapComb);

        }

        private void CancelDelModBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelModFromDbBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from Modifications WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", delModModComb.SelectedValue);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Skasowano z bazy danych");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś poszło nie tak " + System.Environment.NewLine + "Sprawdz dane lub skontaktuj się z administratorem");
            }
        }
    }
}
