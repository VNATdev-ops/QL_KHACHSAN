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
    internal class CtrlKhachHang
    {
        SqlConnection cnn = null;

        public CtrlKhachHang()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CKhachHang> findall()
        {
            string sql = "select * from khachhang";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CKhachHang> arrs = new List<CKhachHang>();
            while (reader.Read())
            {
                CKhachHang s = new CKhachHang();
                s.KhachHangID1 = reader.GetInt32(0);
                s.TenKhachHang1 = reader.GetString(1);
                s.SoDienThoai1 = reader.GetString(2);
                s.DiaChi1 = reader.GetString(3);
                s.Email1 = reader.GetString(4);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

        public bool insert(CKhachHang obj)
        {
            try
            {
                string sql = "insert into khachhang values (@KhachHangID, @TenKhachHang, @SoDienThoai, @DiaChi, @Email)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@KhachHangID", obj.KhachHangID1);
                cmd.Parameters.AddWithValue("@TenKhachHang", obj.TenKhachHang1);
                cmd.Parameters.AddWithValue("@SoDienThoai", obj.SoDienThoai1);
                cmd.Parameters.AddWithValue("@DiaChi", obj.DiaChi1);
                cmd.Parameters.AddWithValue("@Email", obj.Email1);

                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }

        public bool delete(CKhachHang obj)
        {
            try
            {
                string sql = "delete from khachhang where khachhangid = @khachhangid";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@khachhangid", obj.KhachHangID1);
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách khỏi cơ sở dữ liệu: " + ex.Message);
                return false;
            }
        }
        public List<CKhachHang> findCriteria(string DK)
        {
            string sql = "select * from khachhang where khachhangid like @dk " +
                "or tenkhachhang like @dk " +
                "or sodienthoai like @dk " +
                "or diachi like @dk " +
                "or email like @dk ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dk", "%" + DK + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            List<CKhachHang> arrs = new List<CKhachHang>();
            while (reader.Read())
            {
                CKhachHang s = new CKhachHang();
                s.KhachHangID1 = reader.GetInt32(0);
                s.TenKhachHang1 = reader.GetString(1);
                s.SoDienThoai1 = reader.GetString(2);
                s.DiaChi1 = reader.GetString(3);
                s.Email1 = reader.GetString(4);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }
        public bool update(CKhachHang obj)
        {
            try
            {
                string sql = "update khach set khachhangid=@khachhangid, tenkhachhang=@tenkhachhang, sodienthoai=@sodienthoai, diachi=@diachi, where email=@email";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@khachhangid", obj.KhachHangID1);
                cmd.Parameters.AddWithValue("@tenkhachhang", obj.TenKhachHang1);
                cmd.Parameters.AddWithValue("@sodienthoai", obj.SoDienThoai1);
                cmd.Parameters.AddWithValue("@diachi", obj.DiaChi1);
                cmd.Parameters.AddWithValue("@email", obj.Email1);

                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch { return false; }

        }
    }
}
