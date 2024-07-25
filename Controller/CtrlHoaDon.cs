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
    internal class CtrlHoaDon
    {
        SqlConnection cnn = null;

        public CtrlHoaDon()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public bool insert(CHoaDon obj)
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }

                string sql = "INSERT INTO HoaDon (HoaDonID, DatPhongID, NgayLap, TongTien) VALUES (@HoaDonID, @DatPhongID, @NgayLap, @TongTien)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@HoaDonID", obj.IDHoaDon);
                cmd.Parameters.AddWithValue("@DatPhongID", obj.IdDatphong.DatPhongID);
                cmd.Parameters.AddWithValue("@NgayLap", obj.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", obj.TongTien);

                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
            finally
            {
                // Đóng kết nối sau khi thao tác xong
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }



        public bool Update(CHoaDon hoaDon)
        {
            try
            {
                string sql = "UPDATE HoaDon SET DatPhongID = @DatPhongID, NgayLap = @NgayLap, TongTien = @TongTien WHERE HoaDonID = @HoaDonID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@HoaDonID", hoaDon.IDHoaDon);
                cmd.Parameters.AddWithValue("@DatPhongID", hoaDon.IdDatphong.DatPhongID);
                cmd.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }

        public List<CHoaDon> FindAll()
        {
            List<CHoaDon> hoaDons = new List<CHoaDon>();
            try
            {
                string sql = "SELECT * FROM HoaDon";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CHoaDon hoaDon = new CHoaDon();
                    hoaDon.IDHoaDon = reader.GetInt32(reader.GetOrdinal("HoaDonID"));
                    hoaDon.IdDatphong = new CDatPhong() { DatPhongID = reader.GetInt32(reader.GetOrdinal("DatPhongID")) };
                    hoaDon.NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"));
                    hoaDon.TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien"));
                    hoaDons.Add(hoaDon);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            return hoaDons;
        }

        public List<CHoaDon> FindByCriteria(string criteria)
        {
            List<CHoaDon> hoaDons = new List<CHoaDon>();
            try
            {
                string sql = "SELECT * FROM HoaDon WHERE HoaDonID = @criteria";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@criteria", int.Parse(criteria)); // Đảm bảo bạn truyền đúng kiểu dữ liệu

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CHoaDon hoaDon = new CHoaDon();
                    hoaDon.IDHoaDon = reader.GetInt32(reader.GetOrdinal("HoaDonID"));
                    hoaDon.IdDatphong = new CDatPhong() { DatPhongID = reader.GetInt32(reader.GetOrdinal("DatPhongID")) };
                    hoaDon.NgayLap = reader.GetDateTime(reader.GetOrdinal("NgayLap"));
                    hoaDon.TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien"));
                    hoaDons.Add(hoaDon);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            return hoaDons;
        }

        public bool Delete(int hoaDonID)
        {
            try
            {
                string sql = "DELETE FROM HoaDon WHERE HoaDonID = @HoaDonID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID);
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                return false;
            }
        }



    }
}
