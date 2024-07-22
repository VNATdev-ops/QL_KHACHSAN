using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using QL_KHACHSAN.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Controller
{
    internal class CtrlDichvu
    {
        SqlConnection cnn = null;

        public CtrlDichvu() 
        {
        ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }
        public List<CDichvu> findall() 
        {
            string sql = "select * from DichVu";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CDichvu> arrs = new List<CDichvu>();
            while (reader.Read())
            {
                CDichvu s = new CDichvu();
                s.DichVuID1 = reader.GetInt32(0);
                s.TenDichVu1 = reader.GetString(1);
                s.GiaTien1 = (double)reader.GetDecimal(2);
                // thêm vào ds
                arrs.Add(s);
            }
            
            reader.Close();
            return arrs;
        }
        public bool insert(CDichvu obj)
        {
            try
            {
                string sql = "insert into dichvu values (@ID,@Name,@Money)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@ID", obj.DichVuID1);
                cmd.Parameters.AddWithValue("@Name", obj.TenDichVu1);
                cmd.Parameters.AddWithValue("@Money", obj.GiaTien1);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch { return false; }

        }
        public bool update(CDichvu obj)
        {
            try
            {
                string sql = "update dichvu set TenDichVu=@Name,GiaTien=@Money where DichVuID=@ID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@ID", obj.DichVuID1);
                cmd.Parameters.AddWithValue("@Name", obj.TenDichVu1);
                cmd.Parameters.AddWithValue("@Money", obj.GiaTien1);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);

            }
            catch
            {
                return false;
            }
        }
        public bool delete(CDichvu obj)
        {
            try
            {
                string sql = "delete from dichvu where DIchVuID=@ID";
                SqlCommand cmd = new SqlCommand(sql);

                cmd.Parameters.AddWithValue("@ID", obj.DichVuID1);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);

            }
            catch
            {
                return false;
            }
        }

    }
}
