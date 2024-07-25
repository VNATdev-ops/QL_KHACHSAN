using QL_KHACHSAN.Controller;
using QL_KHACHSAN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN.Views
{
    public partial class FLichSu : Form
    {
        CtrlLichSu ctrlLichSu = new CtrlLichSu();
        private List<CLichSu> dsLichSu = new List<CLichSu>();
        public FLichSu()
        {
            InitializeComponent();
            int width = lsvLichSu.Width;
            lsvLichSu.Columns.Add("Mã lịch sử", 150);
            lsvLichSu.Columns.Add("Mã khách hàng", 150);
            lsvLichSu.Columns.Add("Mã phòng", 150);
            lsvLichSu.Columns.Add("Ngày nhận", 250);
            lsvLichSu.Columns.Add("Ngày trả", 250);

            lsvLichSu.View = View.Details;
            lsvLichSu.FullRowSelect = true;
        }

        private void LoadLichSu()
        {
            // Phương thức để tải dữ liệu lịch sử từ cơ sở dữ liệu và hiển thị trên giao diện người dùng
            dsLichSu = ctrlLichSu.findall();
            // Cập nhật dữ liệu trên giao diện người dùng
        }

        private void capNhatSoLuongLS()
        {
            txtTongSo.Text = dsLichSu.Count.ToString();
        }
        private void FLichSu_Load(object sender, EventArgs e)
        {
            dsLichSu = ctrlLichSu.findall();
            foreach (CLichSu s in dsLichSu)
            {
                string[] obj = {
                    s.LichSuID1.ToString(),
                    s.KhachHangID1.ToString(),
                    s.PhongID1.ToString(),
                    s.NgayNhan1.ToShortDateString(),
                    s.NgayTra1.ToShortDateString(),
                };
                ListViewItem item = new ListViewItem(obj);
                lsvLichSu.Items.Add(item);
            }
            capNhatSoLuongLS();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvLichSu.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvLichSu.SelectedItems[0];
                    int lichSuID = int.Parse(item.SubItems[0].Text);

                    // Tìm đối tượng CPhong tương ứng trong danh sách dsPhong
                    CLichSu lichsu = dsLichSu.FirstOrDefault(p => p.LichSuID1 == lichSuID);

                    if (lichsu != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrlLichSu.delete(lichsu))
                        {
                            MessageBox.Show("Xóa thành công");

                            // Xóa khỏi danh sách dsPhong và ListView
                            dsLichSu.Remove(lichsu);
                            lsvLichSu.Items.Remove(item);

                            // Cập nhật số lượng phòng
                            txtTongSo.Text = lsvLichSu.Items.Count.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng để xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                CLichSu s = new CLichSu();
                s.LichSuID1 = int.Parse(txtIDLichSu.Text);
                s.KhachHangID1 = int.Parse(txtIDKhachHang.Text);
                s.PhongID1 = int.Parse(txtIDPhong.Text);
                s.NgayNhan1 = DateTime.Parse(txtNgayNhan.Text);
                s.NgayTra1 = DateTime.Parse(txtNgayTra.Text);

                if (ctrlLichSu.insert(s))
                {
                    string[] obj =
                    {
                        s.LichSuID1.ToString(),
                        s.KhachHangID1.ToString(),
                        s.PhongID1.ToString(),
                        s.NgayNhan1.Date.ToString(),
                        s.NgayTra1.Date.ToString(),
                    };
                    ListViewItem item = new ListViewItem(obj);
                    lsvLichSu.Items.Add(item);
                    dsLichSu.Add(s);
                    txtTongSo.Text = lsvLichSu.Items.Count.ToString();
                    MessageBox.Show("Thêm thành công");
                }
                capNhatSoLuongLS();

            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm");
            }
        }

        private void lsvLichSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvLichSu.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvLichSu.SelectedItems[0];

                    // Assuming 'dsPhong' is a list of CPhong objects
                    int lichsuId = int.Parse(item.SubItems[0].Text);
                    CLichSu lichsu = dsLichSu.FirstOrDefault(p => p.LichSuID1 == lichsuId);

                    if (lichsu != null)
                    {
                        txtIDLichSu.Text = lichsu.LichSuID1.ToString();
                        txtIDKhachHang.Text = lichsu.KhachHangID1.ToString();
                        txtIDPhong.Text = lichsu.PhongID1.ToString();
                        txtNgayNhan.Text = lichsu.NgayNhan1.Date.ToString();
                        txtNgayTra.Text = lichsu.NgayTra1.Date.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDLichSu.Text = string.Empty;
            txtIDKhachHang.Text = string.Empty;
            txtIDPhong.Text = string.Empty;
            txtNgayTra.Value = DateTime.Today;
            txtNgayNhan.Value = DateTime.Today;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dkFind = txtTimKiem.Text;
                dsLichSu = ctrlLichSu.findCriteria(dkFind);

                lsvLichSu.Items.Clear();
                foreach (CLichSu s in dsLichSu)
                {

                    string[] obj = {
                    s.LichSuID1.ToString(),
                    s.KhachHangID1.ToString(),
                    s.PhongID1.ToString(),
                    s.NgayNhan1.ToShortDateString(),
                    s.NgayTra1.ToShortDateString(),
                };
                    ListViewItem item = new ListViewItem(obj);
                    lsvLichSu.Items.Add(item);
                }
                txtTongSo.Text = lsvLichSu.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển nhập liệu
                int lichSuID = int.Parse(txtIDLichSu.Text);
                int khachHangID = int.Parse(txtIDKhachHang.Text);
                int phongID = int.Parse(txtIDPhong.Text);
                DateTime ngayNhan = txtNgayNhan.Value;
                DateTime ngayTra = txtNgayTra.Value;

                // Tạo đối tượng lịch sử
                CLichSu lichSu = new CLichSu(lichSuID, khachHangID, phongID, ngayNhan, ngayTra);

                // Thực hiện cập nhật vào cơ sở dữ liệu
                if (ctrlLichSu.update(lichSu))
                {
                    MessageBox.Show("Cập nhật lịch sử thành công.");
                    LoadLichSu(); // Cập nhật giao diện nếu cần
                }
                else
                {
                    MessageBox.Show("Cập nhật lịch sử thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lịch sử: " + ex.Message);
            }
        }
    }
}
