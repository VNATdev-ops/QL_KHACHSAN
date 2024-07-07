using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
    }
}
