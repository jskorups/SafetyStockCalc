using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyStockCalc
{
    public class fillCombos
    {
        

        public static void fillComboWithProject(ComboBox cbx)
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql("select * from Project");
                cbx.DataSource = dP.Tables[0];
                cbx.ValueMember = "id";
                cbx.DisplayMember = "Project";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac projektów z bazdy danych");
            }
        }

        public static void fillComboWithSAPbyProject(ComboBox cbx, ComboBox cbxProj)
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql("select * from SAP where idProject = (select id from Project where Project = '" + cbxProj.Text + "')");
                cbx.DataSource = dP.Tables[0];

                //combSapNewMod.DataSource = dP2.Tables[0];
                cbx.ValueMember = "id";
                cbx.DisplayMember = "SAP";
                //combSapNewMod.ValueMember = "SAP";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac SAP z bazdy danych");

            }
        }

        public static void fillComboWithMODbySAP(ComboBox cbx, ComboBox cbxSAP)
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql("select * from Modifications where SAPid = (select id from SAP where SAP = '" + cbxSAP.Text + "')");
                cbx.DataSource = dP.Tables[0];

                //combSapNewMod.DataSource = dP2.Tables[0];
                cbx.ValueMember = "id";
                cbx.DisplayMember = "modName";
                //combSapNewMod.ValueMember = "SAP";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac modyfikacji z bazy z bazdy danych");

            }
        }


    }
}
