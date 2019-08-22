using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyStockCalc
{
    public partial class EditDeleteModification : Form
    {
        public EditDeleteModification()
        {
            InitializeComponent();
            editModProj.SelectedIndex = -1;
            projectLoad();
        }

        public void projectLoad()
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql("select  * from Project;");
                editModProj.DataSource = dP.Tables[0];
                editModProj.ValueMember = "id";
                editModProj.DisplayMember = "Project";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac projektów z bazdy danych");
            }
        }

        public void sapLoad()
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql("select * from SAP where idProject = (select id from Project where Project = '" + editModProj.Text + "')");
                editModSap.DataSource = dP.Tables[0];

                //combSapNewMod.DataSource = dP2.Tables[0];
                editModSap.ValueMember = "id";
                editModSap.DisplayMember = "SAP";
                //combSapNewMod.ValueMember = "SAP";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac SAP z bazdy danych");
            }


        }
        public void modLoad()
        {
            DataSet dP = sqlQuery.GetDataFromSql("select * from Modifications where SAPid = (select id from SAP where SAP = '" + editModSap.Text + "')");
            editModMod.DataSource = dP.Tables[0];

            //combSapNewMod.DataSource = dP2.Tables[0];
            editModMod.ValueMember = "id";
            editModMod.DisplayMember = "modName";
            //combSapNewMod.ValueMember = "SAP";
        }

        private void editSapPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editModProj.SelectedIndex > -1)
            {
                sapLoad();
                modLoad();
            }
            return;
        }

        private void editModSap_SelectedIndexChanged(object sender, EventArgs e)
        {
            modLoad();
        }

        private void CancelAddSapBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSapToDbBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
