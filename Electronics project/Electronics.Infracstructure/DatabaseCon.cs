using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Infracstructure
{
    public class DatabaseCon
    {
        public SqlConnection Connection()
        {
            string connection = "Server=mssqlstud.fhict.local;Database=dbi500462;User Id=dbi500462;Password=Kxl1K#pT37; Encrypt = False";
            SqlConnection con = new SqlConnection(connection);
            return con;
        }
    }
}
