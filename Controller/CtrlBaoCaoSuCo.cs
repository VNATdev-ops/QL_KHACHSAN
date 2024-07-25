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

        public bool insert(CBaoCaoSuCo obj)
        {
            try
            {
                // Xây dựng câu lệnh SQL để thêm dữ liệu
                string sql = "INSERT INTO baocaosuco (suCoID, phongID, nhanVienID, moTa, ngayBaoCao) " +
                             "VALUES (@suCoID, @phongID, @nhanVienID, @moTa, @ngayBaoCao)";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@suCoID", obj.SuCoID);
                cmd.Parameters.AddWithValue("@phongID", obj.PhongID.PhongId); // 
                cmd.Parameters.AddWithValue("@nhanVienID", obj.NhanVienID.NhanvienID);
                cmd.Parameters.AddWithValue("@moTa", obj.MoTa);
                cmd.Parameters.AddWithValue("@ngayBaoCao", obj.NgayBaoCao);

                // Mở kết nối nếu chưa mở
                if (cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }

                // Thực thi lệnh SQL
                int n = cmd.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception ex)
            {
                // In lỗi ra console để kiểm tra
                Console.WriteLine("Lỗi khi thêm báo cáo sự cố: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo kết nối được đóng
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
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
