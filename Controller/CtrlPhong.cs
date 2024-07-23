using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN.Controller
{
    internal class CtrlPhong
    {
        SqlConnection cnn = null;

        public CtrlPhong()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CPhong> findall()
        {
            string sql = "select * from phong";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CPhong> arrs = new List<CPhong>();
            while (reader.Read())
            {
                CPhong s = new CPhong();
                s.PhongId = reader.GetInt32(0);
                s.SoPhong = reader.GetString(1);
                s.LoaiPhong = reader.GetString(2);
                s.GiaTien = reader.GetDecimal(3);
                s.TinhTrang = reader.GetString(4);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

        public bool insert(CPhong obj)
        {
            try
            {
                string sql = "insert into phong values (@phongID, @soPhong, @loaiPhong, @giaTien, @tinhTrang)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongId);
                cmd.Parameters.AddWithValue("@soPhong", obj.SoPhong);
                cmd.Parameters.AddWithValue("@loaiPhong", obj.LoaiPhong);
                cmd.Parameters.AddWithValue("@giaTien", obj.GiaTien);
                cmd.Parameters.AddWithValue("@tinhTrang", obj.TinhTrang);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool delete(CPhong obj)
        {
            try
            {
                using (SqlConnection connection = new ConnectDB().getConnection())
                {
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Xóa các bản ghi liên quan trong bảng DatDichVu
                        string deleteDatDichVuSql = "DELETE FROM DatDichVu WHERE DatPhongID IN (SELECT DatPhongID FROM DatPhong WHERE PhongID = @PhongId)";
                        using (SqlCommand cmd = new SqlCommand(deleteDatDichVuSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongId", obj.PhongId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa các bản ghi liên quan trong bảng HoaDon
                        string deleteHoaDonSql = "DELETE FROM HoaDon WHERE DatPhongID IN (SELECT DatPhongID FROM DatPhong WHERE PhongID = @PhongId)";
                        using (SqlCommand cmd = new SqlCommand(deleteHoaDonSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongId", obj.PhongId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa các bản ghi liên quan trong bảng DatPhong
                        string deleteDatPhongSql = "DELETE FROM DatPhong WHERE PhongID = @PhongId";
                        using (SqlCommand cmd = new SqlCommand(deleteDatPhongSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongId", obj.PhongId);
                            cmd.ExecuteNonQuery();
                        }

                        // Xóa bản ghi trong bảng Phong
                        string deletePhongSql = "DELETE FROM Phong WHERE PhongId = @PhongId";
                        using (SqlCommand cmd = new SqlCommand(deletePhongSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongId", obj.PhongId);
                            int n = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return (n > 0);
                        }

                        // Xóa bản ghi trong bảng Phong
                        string deleteLichSuKhachHangSql = "DELETE FROM LichSuKhachHang WHERE PhongId = @PhongId";
                        using (SqlCommand cmd = new SqlCommand(deleteLichSuKhachHangSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@PhongId", obj.PhongId);
                            int n = cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return (n > 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết
                Console.WriteLine("Error in delete method: " + ex.Message);
                MessageBox.Show("Error in delete method: " + ex.Message);
                return false;
            }
        }
       

        public bool update(CPhong obj)
        {
            try
            {
                string sql = "update phong set sophong=@sophong, loaiphong=@loaiphong, giatien=@giatien, tinhtrang=@tinhtrang, where phongid=@phongid";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@sophong", obj.SoPhong);
                cmd.Parameters.AddWithValue("@loaiphong", obj.LoaiPhong);
                cmd.Parameters.AddWithValue("@giatien", obj.GiaTien);
                cmd.Parameters.AddWithValue("@tinhtrang", obj.TinhTrang);
                cmd.Parameters.AddWithValue("@phongid", obj.PhongId);

                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch { return false; }

        }

        public List<CPhong> findCriteria(string DK)
        {
            string sql = "select * from phong where phongid like @dk or sophong like @dk or loaiphong like @dk or giatien like @dk or tinhtrang like @dk";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dk", "%" + DK + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            List<CPhong> arrs = new List<CPhong>();
            while (reader.Read())
            {
                CPhong s = new CPhong();
                s.PhongId = reader.GetInt32(0);
                s.SoPhong = reader.GetString(1);
                s.LoaiPhong = reader.GetString(2);
                s.GiaTien = reader.GetDecimal(3);
                s.TinhTrang = reader.GetString(4);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }
    }
}
