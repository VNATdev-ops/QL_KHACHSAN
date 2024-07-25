using QL_KHACHSAN.Controller;
using QL_KHACHSAN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN.Views
{
    public partial class FBaoCaoSuCo : Form
    {
        CtrlBaoCaoSuCo ctrlBaoCaoSuCo = new CtrlBaoCaoSuCo();
        private List<CBaoCaoSuCo> dsBaoCaoSuCo = new List<CBaoCaoSuCo>();
        public FBaoCaoSuCo()
        {
            InitializeComponent();
            int width = lsvDsBaoCaoSuCo.Width;
            lsvDsBaoCaoSuCo.Columns.Add("Mã sự cố", 20 * width / 100);
            lsvDsBaoCaoSuCo.Columns.Add("Mã phòng", 20 * width / 100);
            lsvDsBaoCaoSuCo.Columns.Add("Mã nhân viên", 20 * width / 100);
            lsvDsBaoCaoSuCo.Columns.Add("Mô tả", 20 * width / 100);
            lsvDsBaoCaoSuCo.Columns.Add("Ngày báo cáo", 20 * width / 100);

            lsvDsBaoCaoSuCo.View = View.Details;
            lsvDsBaoCaoSuCo.FullRowSelect = true;
        }

        private void LoadBaoCaoSuCo()
        {
            List<CBaoCaoSuCo> danhSachBaoCaoSuCo = ctrlBaoCaoSuCo.FindAll();
            lsvDsBaoCaoSuCo.Items.Clear();
            foreach (var baoCao in danhSachBaoCaoSuCo)
            {
                ListViewItem item = new ListViewItem(baoCao.SuCoID.ToString());
                item.SubItems.Add(baoCao.PhongID.PhongId.ToString());
                item.SubItems.Add(baoCao.NhanVienID.NhanvienID.ToString());
                item.SubItems.Add(baoCao.MoTa);
                item.SubItems.Add(baoCao.NgayBaoCao.ToString("dd/MM/yyyy"));
                lsvDsBaoCaoSuCo.Items.Add(item);
            }
        }
        private void capNhatSoLuongPhong()
        {
            txtTongSo.Text = dsBaoCaoSuCo.Count.ToString();
        }

        private void FBaoCaoSuCo_Load(object sender, EventArgs e)
        {
            lsvDsBaoCaoSuCo.Items.Clear();
            dsBaoCaoSuCo = ctrlBaoCaoSuCo.FindAll();
            foreach (CBaoCaoSuCo s in dsBaoCaoSuCo)
            {
                string[] obj = { s.SuCoID.ToString(), s.PhongID.PhongId.ToString(), s.NhanVienID.NhanvienID.ToString(), s.MoTa, s.NgayBaoCao.ToString() };
                ListViewItem item = new ListViewItem(obj);
                lsvDsBaoCaoSuCo.Items.Add(item);
            }
            capNhatSoLuongPhong();
        }

        private void lsvDsBaoCaoSuCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDsBaoCaoSuCo.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvDsBaoCaoSuCo.SelectedItems[0];
                txtIDSuCo.Text = item.SubItems[0].Text;
                txtIDPhong.Text = item.SubItems[1].Text;
                txtIDNhanVien.Text = item.SubItems[2].Text;
                txtMoTa.Text = item.SubItems[3].Text;
                dtpNgayBaoCao.Value = DateTime.Parse(item.SubItems[4].Text);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển nhập liệu
                int suCoID = int.Parse(txtIDSuCo.Text);
                int phongID = int.Parse(txtIDPhong.Text);
                int nhanVienID = int.Parse(txtIDNhanVien.Text);
                string moTa = txtMoTa.Text;
                DateTime ngayBaoCao = dtpNgayBaoCao.Value;

                // Tạo đối tượng CBaoCaoSuCo
                CBaoCaoSuCo baoCaoSuCo = new CBaoCaoSuCo(suCoID, new CPhong { PhongId = phongID }, new CNhanVien { NhanvienID = nhanVienID }, moTa, ngayBaoCao);

                // Gọi phương thức thêm từ lớp điều khiển
                if (ctrlBaoCaoSuCo.Insert(baoCaoSuCo))
                {
                    MessageBox.Show("Thêm báo cáo sự cố thành công");
                    LoadBaoCaoSuCo(); // Tải lại danh sách báo cáo sự cố sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm báo cáo sự cố thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                CNhanVien nhanVien = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) };
                CPhong phong = new CPhong { PhongId = int.Parse(txtIDPhong.Text) };
                CBaoCaoSuCo baoCaoSuCo = new CBaoCaoSuCo
                {
                    SuCoID = int.Parse(txtIDSuCo.Text),
                    PhongID = phong,
                    NhanVienID = nhanVien,
                    MoTa = txtMoTa.Text,
                    NgayBaoCao = dtpNgayBaoCao.Value
                };

                CtrlBaoCaoSuCo ctrlBaoCaoSuCo = new CtrlBaoCaoSuCo();

                if (ctrlBaoCaoSuCo.Update(baoCaoSuCo))
                {
                    MessageBox.Show("Cập nhật thành công");
                    LoadBaoCaoSuCo();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
                capNhatSoLuongPhong();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDNhanVien.Text = string.Empty;
            txtIDPhong.Text = string.Empty;
            txtIDSuCo.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            dtpNgayBaoCao.Value = DateTime.Today;
            
        }

        private void dtpNgayBaoCao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có mục nào được chọn trong danh sách hay không
                if (lsvDsBaoCaoSuCo.SelectedItems.Count > 0)
                {
                    // Lấy SuCoID từ mục được chọn
                    int suCoID = int.Parse(lsvDsBaoCaoSuCo.SelectedItems[0].SubItems[0].Text);

                    // Xác nhận việc xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa báo cáo sự cố này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ lớp điều khiển
                        if (ctrlBaoCaoSuCo.Delete(suCoID))
                        {
                            MessageBox.Show("Xóa báo cáo sự cố thành công");
                            LoadBaoCaoSuCo(); // Tải lại danh sách báo cáo sự cố sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Xóa báo cáo sự cố thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một báo cáo sự cố để xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox
                string tuKhoa = txtTimKiem.Text.Trim();

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    // Gọi phương thức tìm kiếm từ lớp điều khiển
                    List<CBaoCaoSuCo> ketQuaTimKiem = ctrlBaoCaoSuCo.FindCriteria(tuKhoa);

                    // Hiển thị kết quả tìm kiếm
                    lsvDsBaoCaoSuCo.Items.Clear();
                    foreach (var baoCao in ketQuaTimKiem)
                    {
                        ListViewItem item = new ListViewItem(baoCao.SuCoID.ToString());
                        item.SubItems.Add(baoCao.PhongID.PhongId.ToString());
                        item.SubItems.Add(baoCao.NhanVienID.NhanvienID.ToString());
                        item.SubItems.Add(baoCao.MoTa);
                        item.SubItems.Add(baoCao.NgayBaoCao.ToString("dd/MM/yyyy"));
                        lsvDsBaoCaoSuCo.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }
    }
}
