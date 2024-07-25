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
    public partial class FKhachHang : Form
    {
        CtrlKhachHang ctrlKhachhang = new CtrlKhachHang();
        private List<CKhachHang> dsKhachHang = new List<CKhachHang>();
        public FKhachHang()
        {
            InitializeComponent();
            int width = lsvKhachHang.Width;
            lsvKhachHang.Columns.Add("Mã khách hàng", 150);
            lsvKhachHang.Columns.Add("Tên khách hàng", 220);
            lsvKhachHang.Columns.Add("Số Điện Thoại", 170);
            lsvKhachHang.Columns.Add("Địa Chỉ", 250);
            lsvKhachHang.Columns.Add("Email", 250);

            lsvKhachHang.View = View.Details;
            lsvKhachHang.FullRowSelect = true;
        }

        private void capNhatSoLuongKhach()
        {
            txtTongSo.Text = dsKhachHang.Count.ToString();
        }

        private void LoadDanhSachKhachHang()
        {
            List<CKhachHang> danhSachKhachHang = ctrlKhachhang.findall();
            lsvKhachHang.Items.Clear();
            foreach (var baoCao in danhSachKhachHang)
            {
                ListViewItem item = new ListViewItem(baoCao.KhachHangID1.ToString());
                item.SubItems.Add(baoCao.TenKhachHang1.ToString());
                item.SubItems.Add(baoCao.DiaChi1.ToString());
                item.SubItems.Add(baoCao.SoDienThoai1);
                item.SubItems.Add(baoCao.Email1);
                lsvKhachHang.Items.Add(item);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDdatphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                CKhachHang s = new CKhachHang();
                s.KhachHangID1 = int.Parse(txtIDkhachhang.Text);
                s.SoDienThoai1 = txtsdt.Text;
                s.TenKhachHang1 = txttenkhachhang.Text;
                s.DiaChi1 = txtdiachi.Text;
                s.Email1 = txtemail.Text;

                if (ctrlKhachhang.insert(s))
                {
                    string[] obj =
                    {
                        s.KhachHangID1.ToString(),
                        s.TenKhachHang1.ToString(),
                        s.SoDienThoai1.ToString(),
                        s.DiaChi1.ToString(),
                        s.Email1.ToString(),
                    };
                    ListViewItem item = new ListViewItem(obj);
                    lsvKhachHang.Items.Add(item);
                    dsKhachHang.Add(s);
                    txtTongSo.Text = lsvKhachHang.Items.Count.ToString();
                    MessageBox.Show("Thêm thành công");
                }
                capNhatSoLuongKhach();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvKhachHang.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvKhachHang.SelectedItems[0];
                    int KhachHangID = int.Parse(item.SubItems[0].Text);

                    CKhachHang khachhang = dsKhachHang.FirstOrDefault(p => p.KhachHangID1 == KhachHangID);

                    if (khachhang != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrlKhachhang.delete(khachhang))
                        {
                            MessageBox.Show("Xóa thành công");

                            dsKhachHang.Remove(khachhang);
                            lsvKhachHang.Items.Remove(item);

                            txtTongSo.Text = lsvKhachHang.Items.Count.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách để xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvKhachHang.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvKhachHang.SelectedItems[0];

                    // Assuming 'dsPhong' is a list of CPhong objects
                    int khachhangID = int.Parse(item.SubItems[0].Text);
                    CKhachHang khachhang = dsKhachHang.FirstOrDefault(p => p.KhachHangID1 == khachhangID);

                    if (khachhang != null)
                    {
                        txtIDkhachhang.Text = khachhang.KhachHangID1.ToString();
                        txtsdt.Text = khachhang.SoDienThoai1.ToString();
                        txttenkhachhang.Text = khachhang.TenKhachHang1.ToString();
                        txtdiachi.Text = khachhang.DiaChi1.ToString();
                        txtemail.Text = khachhang.Email1.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            dsKhachHang = ctrlKhachhang.findall();
            foreach (CKhachHang s in dsKhachHang)
            {
                string[] obj = {
                    s.KhachHangID1.ToString(),
                    s.TenKhachHang1.ToString(),
                    s.SoDienThoai1.ToString(),
                    s.DiaChi1.ToString(),
                    s.Email1.ToString(),
                };
                ListViewItem item = new ListViewItem(obj);
                lsvKhachHang.Items.Add(item);
            }
            capNhatSoLuongKhach();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDkhachhang.Text = string.Empty;
            txtsdt.Text = string.Empty;
            txttenkhachhang.Text = string.Empty;
            txtdiachi.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtIDkhachhang.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dkFind = txtTimKiem.Text;
                dsKhachHang = ctrlKhachhang.findCriteria(dkFind);

                lsvKhachHang.Items.Clear();
                foreach (CKhachHang s in dsKhachHang)
                {

                    string[] obj = {
                    s.KhachHangID1.ToString(),
                    s.TenKhachHang1.ToString(),
                    s.SoDienThoai1.ToString(),
                    s.DiaChi1.ToString(),
                    s.Email1.ToString(),
                };
                    ListViewItem item = new ListViewItem(obj);
                    lsvKhachHang.Items.Add(item);
                }
                txtTongSo.Text = lsvKhachHang.Items.Count.ToString();
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
                // Lấy thông tin khách hàng từ các TextBox
                int khachHangID = int.Parse(txtIDkhachhang.Text);
                string tenKhachHang = txttenkhachhang.Text;
                string soDienThoai = txtsdt.Text;
                string diaChi = txtdiachi.Text;
                string email = txtemail.Text;

                // Tạo đối tượng khách hàng với thông tin mới
                CKhachHang khachHang = new CKhachHang(khachHangID, tenKhachHang, soDienThoai, diaChi, email);

                // Gọi phương thức cập nhật từ lớp điều khiển
                if (ctrlKhachhang.Update(khachHang))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                    // Tải lại danh sách khách hàng để hiển thị thông tin mới nhất
                    LoadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
