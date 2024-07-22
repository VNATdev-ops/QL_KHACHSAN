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
    internal class CtrlBaoCaoSuCo
    {
        SqlConnection cnn = null;

        public CtrlBaoCaoSuCo()
        {
            ConnectDB cnnDB = new ConnectDB();
            cnn = cnnDB.getConnection();
        }

        public List<CBaoCaoSuCo> FindAll()
        {
            string sql = "SELECT * FROM BaoCaoSuCo";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();
            List<CBaoCaoSuCo> baoCaoSuCoList = new List<CBaoCaoSuCo>();
            while (reader.Read())
            {
                CBaoCaoSuCo s = new CBaoCaoSuCo
                {
                    SuCoID = reader.GetInt32(0),
                    PhongID = new CPhong { PhongId = reader.GetInt32(1) },
                    NhanVienID = new CNhanVien { NhanvienID = reader.GetInt32(2) },
                    MoTa = reader.GetString(3),
                    NgayBaoCao = reader.GetDateTime(4)
                };
                // thêm vào ds
                baoCaoSuCoList.Add(s);
            }
            reader.Close();
            return baoCaoSuCoList;
        }

        public bool Insert(CBaoCaoSuCo baoCaoSuCo)
        {
            try
            {
                string sql = "INSERT INTO BaoCaoSuCo (PhongID, NhanVienID, MoTa, NgayBaoCao) VALUES (@PhongID, @NhanVienID, @MoTa, @NgayBaoCao)";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@PhongID", baoCaoSuCo.PhongID.PhongId);
                cmd.Parameters.AddWithValue("@NhanVienID", baoCaoSuCo.NhanVienID.NhanvienID);
                cmd.Parameters.AddWithValue("@MoTa", baoCaoSuCo.MoTa);
                cmd.Parameters.AddWithValue("@NgayBaoCao", baoCaoSuCo.NgayBaoCao);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                return false;
            }
        }

        public bool Update(CBaoCaoSuCo baoCaoSuCo)
        {
            try
            {
                string sql = "UPDATE BaoCaoSuCo SET PhongID = @PhongID, NhanVienID = @NhanVienID, MoTa = @MoTa, NgayBaoCao = @NgayBaoCao WHERE SuCoID = @SuCoID";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@SuCoID", baoCaoSuCo.SuCoID);
                cmd.Parameters.AddWithValue("@PhongID", baoCaoSuCo.PhongID.PhongId);
                cmd.Parameters.AddWithValue("@NhanVienID", baoCaoSuCo.NhanVienID.NhanvienID);
                cmd.Parameters.AddWithValue("@MoTa", baoCaoSuCo.MoTa);
                cmd.Parameters.AddWithValue("@NgayBaoCao", baoCaoSuCo.NgayBaoCao);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                return false;
            }
        }

        public bool Delete(CBaoCaoSuCo obj)
        {
            try
            {
                string sql = "delete from baocaosuco where sucoid = @sucoid";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@sucoid", obj.SuCoID);
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phòng khỏi cơ sở dữ liệu: " + ex.Message);
                return false;
            }
        }

    }
}
