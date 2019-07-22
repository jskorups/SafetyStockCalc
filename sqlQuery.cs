using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SafetyStockCalc
{
    class sqlQuery
    {
        DataSet ds = new DataSet();
        string conString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
    }
}
