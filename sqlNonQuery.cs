using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace SafetyStockCalc
{
    class sqlNonQuery
    {
        public static void PutDataToSql(string query)
        {

            {
                string connectionStrin = ConfigurationManager.ConnectionStrings["MoldTracker.Properties.Settings.ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionStrin);


                using (con)
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.UpdateCommand = con.CreateCommand();
                    adapter.UpdateCommand.CommandText = query;
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
            }

        }


    }

}
