using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Controller
{
    internal class CtrlLichSu
    {
        SqlConnection cnn = null;

        public CtrlLichSu()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CLichSu> findall()
        {
            string sql = "select * from lichsukhachhang";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CLichSu> arrs = new List<CLichSu>();
            while (reader.Read())
            {
                CLichSu s = new CLichSu();
                s.LichSuID1 = reader.GetInt32(0);
                s.KhachHangID1 = reader.GetInt32(1);
                s.PhongID1 = reader.GetInt32(2);
                s.NgayNhan1 = reader.GetDateTime(3);
                s.NgayTra1 = reader.GetDateTime(4);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

        public bool insert(CLichSu obj)
        {
            try
            {
                string sql = "insert into lichsukhachhang values (@lichsuID, @khachhangID, @phongID, @ngaynhan, @ngaytra)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@lichsuID", obj.LichSuID1);
                cmd.Parameters.AddWithValue("@khachhangID", obj.KhachHangID1);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongID1);
                cmd.Parameters.AddWithValue("@ngaynhan", obj.NgayNhan1);
                cmd.Parameters.AddWithValue("@ngaytra", obj.NgayTra1);

                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }

        public bool delete(CLichSu obj)
        {
            try
            {
                string sql = "delete from lichsukhachhang where lichsuid = @lichsuid";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@lichsuid", obj.LichSuID1);
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa lịch sử khỏi cơ sở dữ liệu: " + ex.Message);
                return false;
            }
        }
    }
}
