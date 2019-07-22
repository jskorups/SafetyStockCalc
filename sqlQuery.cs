﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SafetyStockCalc
{
    public class sqlQuery
    {
        public static DataSet GetDataFromSql (string query)
        {
            DataSet ds = new DataSet();
            string conString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SqlConnection con = new SqlConnection(conString);

            using (con)
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(ds);
            }
            return ds;

        }
      
    }
}
