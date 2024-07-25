using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACHSAN.Controller
{

    internal class CtrlNhanVien
    {
        SqlConnection cnn = null;
        public CtrlNhanVien()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        
        public List<CNhanVien> findall()
        {
            string sql = "select * from nhanvien";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CNhanVien> arrs = new List<CNhanVien>();
            while (reader.Read())
            {
                CNhanVien s = new CNhanVien();
                s.NhanvienID = reader.GetInt32(0);
                s.TenNhanVien = reader.GetString(1);
                s.ViTri = reader.GetString(2);
                s.Luong = reader.GetDecimal(3);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

        public bool insert(CNhanVien obj)
        {
            try
            {
                string sql = "insert into nhanvien values (@NhanVienID, @tenNhanVien, @ViTri, @Luong)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@NhanVienID", obj.NhanvienID);
                cmd.Parameters.AddWithValue("@tenNhanVien", obj.TenNhanVien);
                cmd.Parameters.AddWithValue("@ViTri", obj.ViTri);
                cmd.Parameters.AddWithValue("@Luong", obj.Luong);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }

        public bool delete(CNhanVien obj)
        {
            try
            {
                // Giả sử 'cnn' là SqlConnection đã được khởi tạo và mở trước đó
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                string sql = "DELETE FROM nhanvien WHERE nhanvienid = @nhanvienid";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nhanvienid", obj.NhanvienID);

                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên khỏi cơ sở dữ liệu: " + ex.Message);
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

        public bool update(CNhanVien obj)
        {
            try
            {
                string sql = "UPDATE nhanvien SET tennhanvien = @tennhanvien, vitri = @vitri, luong = @luong WHERE nhanvienid = @nhanvienid";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@tennhanvien", obj.TenNhanVien);
                cmd.Parameters.AddWithValue("@vitri", obj.ViTri);
                cmd.Parameters.AddWithValue("@luong", obj.Luong);
                cmd.Parameters.AddWithValue("@nhanvienid", obj.NhanvienID);

                // Đảm bảo kết nối mở trước khi thực hiện lệnh
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nhân viên trong cơ sở dữ liệu: " + ex.Message);
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

        public List<CNhanVien> findCriteria(string DK)
        {
            string sql = "select * from nhanvien where nhanvienid like @dk " +
                "or tennhanvien like @dk " +
                "or vitri like @dk " +
                "or luong like @dk ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dk", "%" + DK + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            List<CNhanVien> arrs = new List<CNhanVien>();
            while (reader.Read())
            {
                CNhanVien s = new CNhanVien();
                s.NhanvienID = reader.GetInt32(0);
                s.TenNhanVien = reader.GetString(1);
                s.ViTri = reader.GetString(2);
                s.Luong = reader.GetDecimal(3);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

    }
}
