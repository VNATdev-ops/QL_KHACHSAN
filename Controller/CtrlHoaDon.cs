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
    internal class CtrlHoaDon
    {
        SqlConnection cnn = null;

        public CtrlHoaDon()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public bool Insert(CHoaDon hoaDon)
        {
            try
            {
                string sql = "INSERT INTO HoaDon (DatPhongID, NgayLap, TongTien) VALUES (@DatPhongID, @NgayLap, @TongTien)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
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
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CHoaDon hoaDon = new CHoaDon();
                    hoaDon.IDHoaDon = reader.GetInt32(0);
                    hoaDon.IdDatphong = new CDatPhong() { DatPhongID = reader.GetInt32(1) }; // Giả sử bạn chỉ cần DatPhongID
                    hoaDon.NgayLap = reader.GetDateTime(2);
                    hoaDon.TongTien = reader.GetDecimal(3);
                    hoaDons.Add(hoaDon);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log error
            }
            return hoaDons;
        }

        public CHoaDon FindByID(int id)
        {
            CHoaDon hoaDon = null;
            try
            {
                string sql = "SELECT * FROM HoaDon WHERE HoaDonID = @HoaDonID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@HoaDonID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hoaDon = new CHoaDon();
                    hoaDon.IDHoaDon = reader.GetInt32(0);
                    hoaDon.IdDatphong = new CDatPhong() { DatPhongID = reader.GetInt32(1) }; // Giả sử bạn chỉ cần DatPhongID
                    hoaDon.NgayLap = reader.GetDateTime(2);
                    hoaDon.TongTien = reader.GetDecimal(3);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log error
            }
            return hoaDon;
        }
    }
}
