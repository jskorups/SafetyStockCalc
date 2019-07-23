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

        }
        public void sapLoad()
        {
            DataSet dP = sqlQuery.GetDataFromSql("select SAP from Modifications;");
            combSap.DataSource = dP.Tables[0];
            combSap.ValueMember = "SAP";
       
        }

    
        private void calcBtn_Click(object sender, EventArgs e)
        {
          
                Calculation newCalc = new Calculation(sapTxt.Text, modTxt.Text, Convert.ToDateTime(dateTimePickerOd.Text), Convert.ToDateTime(dateTimePickerDo.Text), Convert.ToDecimal(itemPriceNumeric.Value), Convert.ToInt32(cycleTimeNumeric.Text),
                Convert.ToInt32(week1Numeric.Value), Convert.ToInt32(week1Numeric.Value), Convert.ToInt32(week1Numeric.Value), Convert.ToInt32(week1Numeric.Value), Convert.ToInt32(week1Numeric.Value));

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
        private void disableChoice(object sender, EventArgs e)
        {
            string str1 = sapTxt.Text;
            string str2 = modTxt.Text;

            if (str1.Length > 0  ||  str2.Length > 0) {

                combSap.Enabled = false;
                combMod.Enabled = false;
            }
            else 
            {
                combSap.Enabled = true;
                combMod.Enabled = true;
            }
        }
        #endregion

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
                cmd.Parameters.AddWithValue("@week1", week1Numeric.Value);
                cmd.Parameters.AddWithValue("@week2", week2Numeric.Value);
                cmd.Parameters.AddWithValue("@week3", week3Numeric.Value);
                cmd.Parameters.AddWithValue("@week4", week4Numeric.Value);
                cmd.Parameters.AddWithValue("@week5", week5Numeric.Value);
                // dates
                cmd.Parameters.AddWithValue("@dateOd", dateTimePickerOd.Value);
                cmd.Parameters.AddWithValue("@dateDo", dateTimePickerDo.Value);
                // priceItem && cycleTime
                cmd.Parameters.AddWithValue("@itemPrice", itemPriceNumeric.Value);
                cmd.Parameters.AddWithValue("@cycleTime", cycleTimeNumeric.Value);
                // qtyItems


                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                MessageBox.Show("Dodano do bazy danych pod nazwą:  " + modTxt.Text + " dla numeru SAP: "+ sapTxt.Text + "");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
