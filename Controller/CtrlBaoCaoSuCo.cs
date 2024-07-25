using QL_KHACHSAN.Models;
using QL_KHACHSAN.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public List<CBaoCaoSuCo> FindCriteria(string keyword)
        {
            try
            {
                string sql = "SELECT * FROM BaoCaoSuCo WHERE SuCoID LIKE @keyword OR MoTa LIKE @keyword OR NgayBaoCao LIKE @keyword";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                List<CBaoCaoSuCo> list = new List<CBaoCaoSuCo>();

                while (reader.Read())
                {
                    CBaoCaoSuCo baoCao = new CBaoCaoSuCo();
                    baoCao.SuCoID = reader.GetInt32(0);
                    baoCao.PhongID = new CPhong { PhongId = reader.GetInt32(1) };  // Giả định rằng bạn có CPhong.PhongID
                    baoCao.NhanVienID = new CNhanVien { NhanvienID = reader.GetInt32(2) };  // Giả định rằng bạn có CNhanVien.NhanVienID
                    baoCao.MoTa = reader.GetString(3);
                    baoCao.NgayBaoCao = reader.GetDateTime(4);

                    list.Add(baoCao);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm báo cáo sự cố: " + ex.Message);
                return new List<CBaoCaoSuCo>();
            }
        }


        public bool Insert(CBaoCaoSuCo obj)
        {
            try
            {
                string sql = "INSERT INTO BaoCaoSuCo (SuCoID, PhongID, NhanVienID, MoTa, NgayBaoCao) VALUES (@SuCoID, @PhongID, @NhanVienID, @MoTa, @NgayBaoCao)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@SuCoID", obj.SuCoID);
                cmd.Parameters.AddWithValue("@PhongID", obj.PhongID.PhongId);
                cmd.Parameters.AddWithValue("@NhanVienID", obj.NhanVienID.NhanvienID);
                cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);
                cmd.Parameters.AddWithValue("@NgayBaoCao", obj.NgayBaoCao);

                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm báo cáo sự cố: " + ex.Message);
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

        public bool Delete(int suCoID)
        {
            try
            {
                string sql = "DELETE FROM BaoCaoSuCo WHERE SuCoID = @SuCoID";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@SuCoID", suCoID);

                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa báo cáo sự cố: " + ex.Message);
                return false;
            }
        }


    }
}
