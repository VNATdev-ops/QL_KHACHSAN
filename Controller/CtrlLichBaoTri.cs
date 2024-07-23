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
                string sql = "INSERT INTO LichBaoTri (LichBaoTriID, PhongID, NhanVienID, NgayBaoTri, MoTa) VALUES (@LichBaoTriID, @PhongID, @NhanVienID, @NgayBaoTri, @MoTa)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@LichBaoTriID", obj.LichBaoTriID);
                cmd.Parameters.AddWithValue("@PhongID", obj.PhongID.PhongId);
                cmd.Parameters.AddWithValue("@NhanVienID", obj.NhanvienID.NhanvienID);
                cmd.Parameters.AddWithValue("@NgayBaoTri", obj.NgayBaoTri);
                cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);

                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(CLichBaoTri obj)
        {
            try
            {
                string sql = "UPDATE LichBaoTri SET PhongID = @PhongID, NhanVienID = @NhanVienID, NgayBaoTri = @NgayBaoTri, MoTa = @MoTa WHERE LichBaoTriID = @LichBaoTriID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@LichBaoTriID", obj.LichBaoTriID);
                cmd.Parameters.AddWithValue("@PhongID", obj.PhongID.PhongId);
                cmd.Parameters.AddWithValue("@NhanVienID", obj.NhanvienID.NhanvienID);
                cmd.Parameters.AddWithValue("@NgayBaoTri", obj.NgayBaoTri);
                cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);

                int n = cmd.ExecuteNonQuery();
                return (n > 0);
            }
            catch
            {
                return false;
            }
        }

        ////public List<CLichBaoTri> findCriteria(string DK)
        ////{
            
        ////}



    }
}
