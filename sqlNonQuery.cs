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
        public static void PutDataToSql(string query, List<SqlParameter> listaPara)
        {
           
            {
                string connectionStrin = ConfigurationManager.ConnectionStrings["SafetyStockCalc.Properties.Settings.ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionStrin);
               

                using (con)
                {
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    foreach (var item in listaPara)
                    {
                        cmd.Parameters.Add(item);
                    }
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.UpdateCommand = con.CreateCommand();
                    adapter.UpdateCommand.CommandText = query;
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
            }

        }


    }

}
