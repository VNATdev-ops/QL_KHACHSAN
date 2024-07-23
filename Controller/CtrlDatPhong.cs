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
    internal class CtrlDatPhong
    {
        SqlConnection cnn = null;

        public CtrlDatPhong()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CDatPhong> findall()
        {
            string sql = "select * from datphong";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CDatPhong> arrs = new List<CDatPhong>();
            while (reader.Read())
            {
                CDatPhong s = new CDatPhong();
                s.DatPhongID = reader.GetInt32(0);
                s.PhongID = reader.GetInt32(1);
                s.KhachHangID = reader.GetInt32(2);
                s.NgayDat1 = reader.GetDateTime(3);
                s.NgayNhan1 = reader.GetDateTime(4);
                s.NgayTra1 = reader.GetDateTime(5);
                s.TinhTrang1 = reader.GetString(6);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }

        public bool insert(CDatPhong obj)
        {
            try
            {
                string sql = "insert into datphong values (@datphongID, @phongID, @KhachHangID, @ngaydat, @ngaynhan, @ngaytra, @tinhTrang)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@datphongID", obj.DatPhongID);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongID);
                cmd.Parameters.AddWithValue("@KhachHangID", obj.KhachHangID);
                cmd.Parameters.AddWithValue("@ngaydat", obj.NgayDat1);
                cmd.Parameters.AddWithValue("@ngaynhan", obj.NgayNhan1);
                cmd.Parameters.AddWithValue("@ngaytra", obj.NgayTra1);
                cmd.Parameters.AddWithValue("@tinhtrang", obj.TinhTrang1);

                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }

        public bool delete(CDatPhong obj)
        {
            try
            {
                string sql = "delete from datphong where datphongid = @datphongid";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@datphongid", obj.DatPhongID);
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phòng khỏi cơ sở dữ liệu: " + ex.Message);
                return false;
            }
        }
        public List<CDatPhong> findCriteria(string DK)
        {
            string sql = "select * from datphong where datphongid like @dk " +
                "or phongid like @dk " +
                "or ngaydat like @dk " +
                "or ngaynhan like @dk " +
                "or ngaynhan like @dk " +
                "or ngaytra like @dk " +
                "or tinhtrang like @dk";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@dk", "%" + DK + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            List<CDatPhong> arrs = new List<CDatPhong>();
            while (reader.Read())
            {
                CDatPhong s = new CDatPhong();
                s.DatPhongID = reader.GetInt32(0);
                s.PhongID = reader.GetInt32(1);
                s.KhachHangID = reader.GetInt32(2);
                s.NgayDat1 = reader.GetDateTime(3);
                s.NgayNhan1 = reader.GetDateTime(4);
                s.NgayTra1 = reader.GetDateTime(5);
                s.TinhTrang1 = reader.GetString(6);
                // thêm vào ds
                arrs.Add(s);
            }
            reader.Close();
            return arrs;
        }
    }
}
