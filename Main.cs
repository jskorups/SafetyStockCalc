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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            listDividers.DataSource = new BindingSource(Calculation.dividingVars, null);
            listDividers.DisplayMember = "Key";
            listDividers.ValueMember = "Value";

        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
          
                Calculation newCalc = new Calculation(SapTxtBox.Text, modName.Text, Convert.ToDateTime(dateTimepickerOd.Text), Convert.ToDateTime(dateTimePickerDo.Text), Convert.ToDecimal(itemPriceTxtBox.Text), Convert.ToInt32(numericUpDownCycleTime.Text),
                Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value));

            try
            {
                if (newCalc.endDate >= newCalc.beginDate)
                {

                    newCalc.SAP = SapTxtBox.Text;
                    qtyItems.Text = newCalc.qtyOfItems.ToString();
                    newCalc.daysCount = newCalc.endDate.Subtract(newCalc.beginDate).Days;
                    textBoxDaysCount.Text = newCalc.daysCount.ToString();
                    itemsPerDay.Text = newCalc.itemsPerDay.ToString();
                    newCalc.daysCount = Convert.ToInt32(textBoxDaysCount.Text);
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


        //walidacja weeks
        public bool weeksIntValidation()
        {
            foreach (Control ctrl in tableLayoutPanelWeek.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "week")
                {

                    foreach (Control ctrInPanel in ((TableLayoutPanel)ctrl).Controls)
                    {
                        if (ctrInPanel is TextBox)
                        {
                            int i;
                            bool success = Int32.TryParse(ctrInPanel.Text, out i);
                            if (success == true)
                            {
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
        }

    }
}
