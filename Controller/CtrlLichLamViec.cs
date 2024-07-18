using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN.Controller
{
    internal class CtrlLichLamViec
    {
        SqlConnection cnn = null;

        public CtrlLichLamViec() 
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CLichLamViec> findall()
        {
            List<CLichLamViec> dsLichLamViec = new List<CLichLamViec>();

            try
            {
                // Sử dụng phương thức kết nối của bạn
                SqlConnection connection = cnn;

                string query = "SELECT LichLamViecID, NhanVienID, NgayLam, CaLam FROM LichLamViec";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CLichLamViec lichLamViec = new CLichLamViec();
                    lichLamViec.LichLamViecID = reader.GetInt32(0);

                    int nhanVienId = reader.GetInt32(1); // Assuming NhanVienID is an int
                    CNhanVien nhanVien = new CNhanVien { NhanvienID = nhanVienId };
                    lichLamViec.NhanVienID = nhanVien;

                    lichLamViec.NgayLam = reader.GetDateTime(2);
                    lichLamViec.CaLam = reader.GetString(3);

                    dsLichLamViec.Add(lichLamViec);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lấy dữ liệu: " + ex.Message);
            }

            return dsLichLamViec;
        }

        public bool insert(CLichLamViec obj)
        {
            try
            {
                string sql = "insert into lichlamviec values (@lichlamviecID, @nhanVienID, @ngayLam, @caLam)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@lichlamviecID", obj.LichLamViecID);
                cmd.Parameters.AddWithValue("@nhanVienID", obj.NhanVienID);
                cmd.Parameters.AddWithValue("@ngayLam", obj.NgayLam);
                cmd.Parameters.AddWithValue("@caLam", obj.CaLam);
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
