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
        public fillCombos()
        {

        }

        public static void fillCombo(string sqlQ, ComboBox cbx)
        {
            try
            {
                DataSet dP = sqlQuery.GetDataFromSql(sqlQ);
                cbx.DataSource = dP.Tables[0];
                cbx.ValueMember = "id";
                cbx.DisplayMember = "Project";
            }
            catch (Exception)
            {

                MessageBox.Show("Nie mozna pobrac projektów z bazdy danych");
            }
        }
    }
}
