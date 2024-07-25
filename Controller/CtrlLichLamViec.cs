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
                string sql = "INSERT INTO lichlamviec (lichlamviecID, nhanvienID, ngaylam, calam) " +
                             "VALUES (@lichlamviecID, @nhanvienID, @ngaylam, @calam)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@lichlamviecID", obj.LichLamViecID);
                cmd.Parameters.AddWithValue("@nhanvienID", obj.NhanVienID.NhanvienID);
                cmd.Parameters.AddWithValue("@ngaylam", obj.NgayLam);
                cmd.Parameters.AddWithValue("@calam", obj.CaLam);

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lịch làm việc vào cơ sở dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi hoàn tất
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public bool update(CLichLamViec obj)
        {
            try
            {
                string sql = "UPDATE lichlamviec SET nhanvienID = @nhanvienID, ngaylam = @ngaylam, calam = @calam " +
                             "WHERE lichlamviecID = @lichlamviecID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nhanvienID", obj.NhanVienID.NhanvienID); // Gán giá trị ID của nhân viên
                cmd.Parameters.AddWithValue("@ngaylam", obj.NgayLam);
                cmd.Parameters.AddWithValue("@calam", obj.CaLam);
                cmd.Parameters.AddWithValue("@lichlamviecID", obj.LichLamViecID);

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật lịch làm việc vào cơ sở dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi hoàn tất
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public bool delete(CLichLamViec obj)
        {
            try
            {
                string sql = "DELETE FROM lichlamviec WHERE lichlamviecID = @lichlamviecID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@lichlamviecID", obj.LichLamViecID);

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa lịch làm việc khỏi cơ sở dữ liệu: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi hoàn tất
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }


        public List<CLichLamViec> findCriteria(string DK)
        {
            string sql = "select * from lichlamviec where lichlamviecid like @dk " +
                "or nhanvienid like @dk " +
                "or ngaylam like @dk " +
                "or calam like @dk ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dk", "%" + DK + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            List<CLichLamViec> arrs = new List<CLichLamViec>();
            while (reader.Read())
            {
                
                CLichLamViec lichLamViec = new CLichLamViec();
                lichLamViec.LichLamViecID = reader.GetInt32(0);

                int nhanVienId = reader.GetInt32(1); // Assuming NhanVienID is an int
                CNhanVien nhanVien = new CNhanVien { NhanvienID = nhanVienId };
                lichLamViec.NhanVienID = nhanVien;

                lichLamViec.NgayLam = reader.GetDateTime(2);
                lichLamViec.CaLam = reader.GetString(3);
                // thêm vào ds
                arrs.Add(lichLamViec);
            }
            reader.Close();
            return arrs;
        }
    }
}
