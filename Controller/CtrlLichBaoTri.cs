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
    internal class CtrlLichBaoTri
    {
        SqlConnection cnn = null;
        public CtrlLichBaoTri()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CLichBaoTri> findall()
        {
            try
            {
                List<CLichBaoTri> list = new List<CLichBaoTri>();
                string sql = "SELECT * FROM LichBaoTri";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                SqlDataReader reader = cmd.ExecuteReader();
      
                while (reader.Read())
                {
                    CLichBaoTri obj = new CLichBaoTri
                    {
                        LichBaoTriID = (int)reader["LichBaoTriID"],
                        PhongID = new CPhong { PhongId = (int)reader["PhongID"] },
                        NhanvienID = new CNhanVien { NhanvienID = (int)reader["NhanVienID"] },
                        NgayBaoTri = (DateTime)reader["NgayBaoTri"],
                        MoTa = reader["MoTa"].ToString()
                    };
                    list.Add(obj);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CLichBaoTri>();
            }
        }

        public bool insert(CLichBaoTri obj)
        {
            try
            {
                string sql = "INSERT INTO lichbaotri (lichbaotriID, phongID, nhanvienID, ngaybaotri, mota) " +
                             "VALUES (@lichbaotriID, @phongID, @nhanvienID, @ngaybaotri, @mota)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@lichbaotriID", obj.LichBaoTriID);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongID.PhongId); 
                cmd.Parameters.AddWithValue("@nhanvienID", obj.NhanvienID.NhanvienID);
                cmd.Parameters.AddWithValue("@ngaybaotri", obj.NgayBaoTri);
                cmd.Parameters.AddWithValue("@mota", obj.MoTa);

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
                Console.WriteLine("Lỗi khi thêm lịch bảo trì vào cơ sở dữ liệu: " + ex.Message);
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

        public bool update(CLichBaoTri obj)
        {
            try
            {
                string sql = "UPDATE lichbaotri SET phongID = @phongID, nhanvienID = @nhanvienID, ngaybaotri = @ngaybaotri, mota = @mota " +
                             "WHERE lichbaotriID = @lichbaotriID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongID.PhongId); // Giả sử bạn lưu ID phòng
                cmd.Parameters.AddWithValue("@nhanvienID", obj.NhanvienID.NhanvienID); // Giả sử bạn lưu ID nhân viên
                cmd.Parameters.AddWithValue("@ngaybaotri", obj.NgayBaoTri);
                cmd.Parameters.AddWithValue("@mota", obj.MoTa);
                cmd.Parameters.AddWithValue("@lichbaotriID", obj.LichBaoTriID);

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
                Console.WriteLine("Lỗi khi cập nhật lịch bảo trì vào cơ sở dữ liệu: " + ex.Message);
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


        public bool delete(CLichBaoTri obj)
        {
            try
            {
                string sql = "DELETE FROM lichbaotri WHERE lichbaotriID = @lichbaotriID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@lichbaotriID", obj.LichBaoTriID);

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
                Console.WriteLine("Lỗi khi xóa lịch bảo trì khỏi cơ sở dữ liệu: " + ex.Message);
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

        public List<CLichBaoTri> findCriteria(string keyword)
        {
            List<CLichBaoTri> ketQua = new List<CLichBaoTri>();
            try
            {
                string sql = "SELECT * FROM lichbaotri WHERE moTa LIKE @keyword";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CLichBaoTri lichBaoTri = new CLichBaoTri
                        {
                            LichBaoTriID = reader.GetInt32(reader.GetOrdinal("lichbaotriID")),
                            PhongID = new CPhong { /* Tạo đối tượng CPhong và thiết lập giá trị từ reader nếu cần */ },
                            NhanvienID = new CNhanVien { /* Tạo đối tượng CNhanVien và thiết lập giá trị từ reader nếu cần */ },
                            NgayBaoTri = reader.GetDateTime(reader.GetOrdinal("ngayBaoTri")),
                            MoTa = reader.GetString(reader.GetOrdinal("moTa"))
                        };
                        ketQua.Add(lichBaoTri);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm lịch bảo trì: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng sau khi hoàn tất
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return ketQua;
        }




    }
}
