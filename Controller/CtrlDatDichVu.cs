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
    internal class CtrlDatDichVu
    {
        SqlConnection cnn = null;

        public CtrlDatDichVu()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }
        public List<CDatDichVu> findall()
        {
            string sql = "select * from DatDichVu";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CDatDichVu> arrs = new List<CDatDichVu>();
            while (reader.Read())
            {
                CDatDichVu s = new CDatDichVu();
                s.DatDichVuID = (int)reader.GetInt32(0);
                s.DichVuID = new CDichvu();
                s.DichVuID.DichVuID1 = (int)reader.GetInt32(1);
                s.DatPhongID = new CPhong();
                s.DatPhongID.PhongId = (int)reader.GetInt32(2);
                s.NgayDat = reader.GetDateTime(3);
                // thêm vào ds
                arrs.Add(s);
            }

            reader.Close();
            return arrs;
        }
        public bool insert(CDatDichVu obj)
        {
            try
            {
                string sql = "insert into DatDichVU values (@IDDat,@IDDV,@IDPhong,@ngayDat)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@IDDat", obj.DatDichVuID);
                cmd.Parameters.AddWithValue("@IDDV", obj.DichVuID.DichVuID1);
                cmd.Parameters.AddWithValue("@IDPhong", obj.DatPhongID.PhongId);
                cmd.Parameters.AddWithValue("@ngayDat", obj.NgayDat);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch { return false; }

        }
        public bool update(CDatDichVu obj)
        {
            try
            {
                string sql = "update datdichvu set DichVuID=@IDDV,DatPhongID=@IDPhong,NgayDat=@time where DatDichVuID=@ID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@ID", obj.DatDichVuID);
                cmd.Parameters.AddWithValue("@IDDV", obj.DichVuID.DichVuID1);
                cmd.Parameters.AddWithValue("@IDPhong", obj.DatPhongID.PhongId);
                cmd.Parameters.AddWithValue("@time", obj.NgayDat);
                cmd.Connection = cnn;
                int n = cmd.ExecuteNonQuery();
                return (n > 0);

            }
            catch
            {
                return false;
            }
        }
        public bool delete(CDatDichVu obj)
        {
            try
            {
                string sql = "delete from datdichvu where DatDIchVuID=@ID";
                SqlCommand cmd = new SqlCommand(sql);

                cmd.Parameters.AddWithValue("@ID", obj.DatDichVuID);
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
