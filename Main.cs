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
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            Calculation newCalc = new Calculation(modificationNameTxtBox.Text, Convert.ToDateTime(dateTimepickerOd.Text), Convert.ToDateTime(dateTimePickerDo.Text), Convert.ToDecimal(itemPriceTxtBox.Text), Convert.ToInt32(numericUpDownCycleTime.Text));


            try
            {
                if (newCalc.endDate >= newCalc.beginDate)
                {
                    textBoxDaysCount.Text = newCalc.endDate.Subtract(newCalc.beginDate).Days.ToString();
                    newCalc.daysCount = Convert.ToInt32(textBoxDaysCount.Text);

                    textBoxMachineWorkingTime.Text = newCalc.machineWorkingTime.ToString();

                }
                else
                {
                    MessageBox.Show("Data rozpoczęcia nie może byc mniesza od daty zakończenia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
