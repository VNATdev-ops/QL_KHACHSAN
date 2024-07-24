using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Utils
{
    internal class ConnectDB
    {
        private SqlConnection connection;

        public ConnectDB() 
        {
            connection = null;
        }

        public SqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection("Data Source = DESKTOP-H769H47\\SQLEXPRESS; " +
                   "Initial Catalog = QL_KHACH_SAN ; Integrated Security = true");

                //connection = new SqlConnection("Data Source = ANHTUAN; " +
                //   "Initial Catalog = QL_KHACH_SAN ; Integrated Security = true");
                //ktra kết nối
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            return connection;
        }
    }
}
