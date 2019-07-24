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
using System.Configuration;

namespace SafetyStockCalc
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            sapLoad();

            listDividers.DataSource = new BindingSource(Calculation.dividingVars, null);
            listDividers.DisplayMember = "Key";
            listDividers.ValueMember = "Value";
            combSapNewMod.SelectedIndex = -1;
  
        }
        public void sapLoad()
        {
            DataSet dP = sqlQuery.GetDataFromSql("select SAP from Modifications;");
            DataSet dP2 = sqlQuery.GetDataFromSql("select SAP from Modifications;");
            combSap.DataSource = dP.Tables[0];


            combSapNewMod.DataSource = dP2.Tables[0];
            combSap.ValueMember = "SAP";
            combSapNewMod.ValueMember = "SAP";

        }
        #region validacja z MT

        //public void validationControls()
        //{
        //    foreach (Control ctr in tableLayoutPanel5.Controls)
        //    {
        //        if (ctr.Tag != null && ctr.Tag.ToString() == "detal")
        //        {

        //            foreach (Control ctrInPanel in ((TableLayoutPanel)ctr).Controls)
        //            {
        //                if (ctrInPanel is NumericUpDown)
        //                {
        //                    ((NumericUpDown)ctrInPanel).TextChanged += detailNameTextChanged;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void detailNameTextChanged(object sender, EventArgs e)
        //{
        //    BtnDetailsAddd.Enabled = BtnDetailsAdd_validation();
        //    if (BtnDetailsAdd_validation() == false)
        //    {
        //        BtnDetailsAddd.BackColor = Color.Red;
        //    }
        //    else if (BtnDetailsAdd_validation() == true)
        //    {
        //        BtnDetailsAddd.BackColor = Color.Green;
        //    }
        //}

        //private bool BtnDetailsAdd_validation()
        //{
        //    foreach (Control ctr in tableLayoutPanel5.Controls)
        //    {
        //        if (ctr.Tag != null && ctr.Tag.ToString() == "detal")
        //        {
        //            int wypelnione = 0;
        //            foreach (Control ctrInPanel in ((TableLayoutPanel)ctr).Controls)
        //            {
        //                if (ctrInPanel is TextBox)
        //                {
        //                    if (ctrInPanel.Text.Length > 0) wypelnione++;
        //                }
        //            }
        //            if (wypelnione != 0 && wypelnione != 4)
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        #endregion
        private void calcBtn_Click(object sender, EventArgs e)
        {

            Calculation newCalc = new Calculation(sapTxt.Text, modTxt.Text, Convert.ToDateTime(dateTimePickerOd.Text), Convert.ToDateTime(dateTimePickerDo.Text), Convert.ToInt32(itemPricetxt.Text), Convert.ToInt32(cycleTimeTxt.Text),
            Convert.ToInt32(week1Txt.Text), Convert.ToInt32(week2Txt.Text), Convert.ToInt32(week3Txt.Text), Convert.ToInt32(week4Txt.Text), Convert.ToInt32(week5Txt.Text));

            try
            {
                if (newCalc.endDate >= newCalc.beginDate)
                {

                    newCalc.SAP = sapTxt.Text;
                    qtyItems.Text = newCalc.qtyOfItems.ToString();
                    newCalc.qtyDays = newCalc.endDate.Subtract(newCalc.beginDate).Days;
                    textBoxDaysCount.Text = newCalc.qtyDays.ToString();
                    itemsPerDay.Text = newCalc.qtyPerDay.ToString();
                    newCalc.qtyDays = Convert.ToInt32(textBoxDaysCount.Text);
                    textBoxMachineWorkingTime.Text = newCalc.machineWorkingTime.ToString();
                    periodicTxt.Text = newCalc.getQtyPeriodical(Convert.ToInt32(listDividers.SelectedValue)).ToString();
                    itemsPrice.Text = newCalc.priceOfItems.ToString();

                }
                else
                {
                    MessageBox.Show("Data rozpoczęcia nie może byc mniejsza od daty zakończenia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Load mod when Sap chosen
        private void combSap_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT modName FROM Modifications  where SAP =  '" + combSap.Text + "'";

            // sap
            cmd.Parameters.AddWithValue("@sap", combSap.SelectedValue.ToString());

            DataSet dF = sqlQuery.GetDataFromSql(cmd.CommandText);

            combMod.DataSource = dF.Tables[0];
            combMod.ValueMember = "modName";
        }
        #endregion
        #region sapTxt and modTxt  - block combos

 
        #endregion

        void ClearTextboxes(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)

                    ((TextBox)ctrl).Text = string.Empty;

                ClearTextboxes(ctrl.Controls);
            }
        }
        private void save_Click(object sender, EventArgs e)
        {


            try
            {

                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionStrin);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;


                cmd.CommandText = "insert into Modifications (SAP, modName, week1, week2, week3, week4, week5, dateBegin, dateEnd, priceItem, cycleTime)" +
                    "values (@sap, @modName, @week1, @week2, @week3, @week4, @week5, @dateOd, @dateDo, @itemPrice, @cycleTime)";

                // sap % mod name

                cmd.Parameters.AddWithValue("@sap", sapTxt.Text);
                cmd.Parameters.AddWithValue("@modName", modTxt.Text);
                // weeks
                cmd.Parameters.AddWithValue("@week1", week1Txt.Text);
                cmd.Parameters.AddWithValue("@week2", week1Txt.Text);
                cmd.Parameters.AddWithValue("@week3", week1Txt.Text);
                cmd.Parameters.AddWithValue("@week4", week1Txt.Text);
                cmd.Parameters.AddWithValue("@week5", week1Txt.Text);
                // dates
                cmd.Parameters.AddWithValue("@dateOd", dateTimePickerOd.Value);
                cmd.Parameters.AddWithValue("@dateDo", dateTimePickerDo.Value);
                // priceItem && cycleTime
                cmd.Parameters.AddWithValue("@itemPrice", itemPricetxt.Text);
                cmd.Parameters.AddWithValue("@cycleTime", cycleTimeTxt.Text);
                // qtyItems


                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Dodano do bazy danych pod nazwą:  " + modTxt.Text + " dla numeru SAP: " + sapTxt.Text + "");

                ClearTextboxes(this.Controls);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void blokowanie()
        {
            string str1 = sapTxt.Text;
            string str2 = modTxt.Text;
            string str3 = combSapNewMod.Text;
            

            if (str1.Length > 0 || str2.Length > 0 )
            {

                loadDataBtn.Enabled = false;
                loadDataBtn.BackColor = Color.IndianRed;
                combSapNewMod.Enabled = false;
            }
            else if (str1.Length == 0 || str2.Length == 0)
            {
                loadDataBtn.Enabled = true;
                combSapNewMod.Enabled = true;
                loadDataBtn.BackColor = Color.FromArgb(192, 255, 192);
            }
            else if (str3.Length > 0)
            {
                sapTxt.Clear();
                sapTxt.Enabled = false;
            }
            else
            {
                loadDataBtn.BackColor = Color.FromArgb(192, 255, 192);
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextboxes(this.Controls);
        }

        private void blokowanie(object sender, EventArgs e)
        {
            blokowanie();
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Modifications where modName =  '" + combMod.Text + "'";

            // sap
            cmd.Parameters.AddWithValue("@mod", combMod.SelectedValue.ToString());

            DataSet dF = sqlQuery.GetDataFromSql(cmd.CommandText);

            combMod.DataSource = dF.Tables[0];
            combMod.ValueMember = "modName";
            week1Txt.Text = dF.Tables[0].Rows[0]["week1"].ToString();
            week2Txt.Text = dF.Tables[0].Rows[0]["week2"].ToString();
            week3Txt.Text = dF.Tables[0].Rows[0]["week3"].ToString();
            week4Txt.Text = dF.Tables[0].Rows[0]["week4"].ToString();
            week5Txt.Text = dF.Tables[0].Rows[0]["week5"].ToString();
            dateTimePickerOd.Text = dF.Tables[0].Rows[0]["dateBegin"].ToString();
            dateTimePickerDo.Text = dF.Tables[0].Rows[0]["dateEnd"].ToString();
            itemPricetxt.Text = dF.Tables[0].Rows[0]["priceItem"].ToString();
            cycleTimeTxt.Text = dF.Tables[0].Rows[0]["cycleTime"].ToString();
        }
    }
}

