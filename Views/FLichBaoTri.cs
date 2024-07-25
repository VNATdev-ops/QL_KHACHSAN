using QL_KHACHSAN.Controller;
using QL_KHACHSAN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN.Views
{
    public partial class FLichBaoTri : Form
    {
        CtrlLichBaoTri ctrLichBaoTri = new CtrlLichBaoTri();
        List<CLichBaoTri> dsLichBaoTri = new List<CLichBaoTri>();
        public FLichBaoTri()
        {
            InitializeComponent();
            int width = lsvLichBaoTri.Width;
            lsvLichBaoTri.Columns.Add("Mã lịch bảo trì", 20 * width / 100);
            lsvLichBaoTri.Columns.Add("Mã phòng", 20 * width / 100);
            lsvLichBaoTri.Columns.Add("Mã nhân viên", 20 * width / 100);
            lsvLichBaoTri.Columns.Add("Ngày bảo trì", 20 * width / 100);
            lsvLichBaoTri.Columns.Add("Mô tả", 20 * width / 100);


            lsvLichBaoTri.View = View.Details;
            lsvLichBaoTri.FullRowSelect = true;
        }

        private void capNhatDSLichBaoTri()
        {
            txtTongSo.Text = dsLichBaoTri.Count.ToString();
        }

        private void FLichBaoTri_Load(object sender, EventArgs e)
        {
            txtIDLichBaoTri.Focus();
            dsLichBaoTri = ctrLichBaoTri.findall();
            foreach (CLichBaoTri s in dsLichBaoTri)
            {
                string[] obj = { s.LichBaoTriID.ToString(), s.PhongID.PhongId.ToString(), s.NhanvienID.NhanvienID.ToString(), s.NgayBaoTri.ToString(), s.MoTa };
                ListViewItem item = new ListViewItem(obj);
                lsvLichBaoTri.Items.Add(item);
            }
            capNhatDSLichBaoTri();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng CLichBaoTri từ thông tin nhập vào
                CLichBaoTri lichBaoTri = new CLichBaoTri();
                lichBaoTri.LichBaoTriID = int.Parse(txtIDLichBaoTri.Text);
                lichBaoTri.PhongID = new CPhong { PhongId = int.Parse(txtIDPhong.Text) }; 
                lichBaoTri.NhanvienID = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) }; // 
                lichBaoTri.NgayBaoTri = DateTime.Parse(dtpNgayBaoTri.Text);
                lichBaoTri.MoTa = txtMoTa.Text;

                // Thêm đối tượng vào cơ sở dữ liệu
                if (ctrLichBaoTri.insert(lichBaoTri))
                {
                    // Tạo một mảng chuỗi chứa thông tin để thêm vào ListView
                    string[] obj =
                    {
                lichBaoTri.LichBaoTriID.ToString(),
                lichBaoTri.PhongID.PhongId.ToString(), 
                lichBaoTri.NhanvienID.NhanvienID.ToString(), 
                lichBaoTri.NgayBaoTri.ToString("dd/MM/yyyy"),
                lichBaoTri.MoTa
            };
                    ListViewItem item = new ListViewItem(obj);
                    lsvLichBaoTri.Items.Add(item);
                    dsLichBaoTri.Add(lichBaoTri); 
                    txtTongSo.Text = lsvLichBaoTri.Items.Count.ToString();
                    MessageBox.Show("Thêm thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void lsvLichBaoTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvLichBaoTri.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvLichBaoTri.SelectedItems[0];
                    txtIDLichBaoTri.Text = item.SubItems[0].Text;
                    txtIDPhong.Text = item.SubItems[1].Text;
                    txtIDNhanVien.Text = item.SubItems[2].Text;
                    dtpNgayBaoTri.Value = DateTime.Parse(item.SubItems[3].Text);
                    txtMoTa.Text = item.SubItems[4].Text;
                }
            }
            catch { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvLichBaoTri.SelectedItems.Count > 0)
                {
                    // Lấy đối tượng CLichBaoTri từ thông tin nhập vào
                    CLichBaoTri lichBaoTri = new CLichBaoTri();
                    lichBaoTri.LichBaoTriID = int.Parse(txtIDLichBaoTri.Text);
                    lichBaoTri.PhongID = new CPhong { PhongId = int.Parse(txtIDPhong.Text) }; 
                    lichBaoTri.NhanvienID = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) };
                    lichBaoTri.NgayBaoTri = DateTime.Parse(dtpNgayBaoTri.Text);
                    lichBaoTri.MoTa = txtMoTa.Text;

                    // Cập nhật đối tượng vào cơ sở dữ liệu
                    if (ctrLichBaoTri.update(lichBaoTri))
                    {
                        MessageBox.Show("Cập nhật thành công.");

                        // Cập nhật thông tin trong ListView
                        ListViewItem item = lsvLichBaoTri.SelectedItems[0];
                        item.SubItems[1].Text = lichBaoTri.PhongID.PhongId.ToString(); // Cập nhật ID phòng
                        item.SubItems[2].Text = lichBaoTri.NhanvienID.NhanvienID.ToString(); // Cập nhật ID nhân viên
                        item.SubItems[3].Text = lichBaoTri.NgayBaoTri.ToString("dd/MM/yyyy");
                        item.SubItems[4].Text = lichBaoTri.MoTa;

                        // Cập nhật số lượng
                        txtTongSo.Text = lsvLichBaoTri.Items.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một mục để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDLichBaoTri.Clear();
            txtIDPhong.Clear();
            txtIDNhanVien.Clear();
            txtMoTa.Clear();
            dtpNgayBaoTri.Value = DateTime.Today;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                // Kiểm tra từ khóa tìm kiếm
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                    return;
                }

                // Tìm kiếm trong cơ sở dữ liệu
                List<CLichBaoTri> ketQuaTimKiem = ctrLichBaoTri.findCriteria(keyword);

                // Cập nhật ListView với kết quả tìm kiếm
                lsvLichBaoTri.Items.Clear();
                foreach (var lichBaoTri in ketQuaTimKiem)
                {
                    string[] obj =
                    {
                lichBaoTri.LichBaoTriID.ToString(),
                lichBaoTri.PhongID.ToString(),  // Giả sử bạn đã cài đặt đúng việc chuyển đổi để lấy thông tin từ đối tượng
                lichBaoTri.NhanvienID.ToString(),  // Giả sử bạn đã cài đặt đúng việc chuyển đổi để lấy thông tin từ đối tượng
                lichBaoTri.NgayBaoTri.ToString("dd/MM/yyyy"),
                lichBaoTri.MoTa
            };
                    ListViewItem item = new ListViewItem(obj);
                    lsvLichBaoTri.Items.Add(item);
                }

                // Cập nhật số lượng kết quả
                txtTongSo.Text = lsvLichBaoTri.Items.Count.ToString();

                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvLichBaoTri.SelectedItems.Count > 0)
                {
                    // Lấy ID từ mục được chọn trong ListView
                    ListViewItem item = lsvLichBaoTri.SelectedItems[0];
                    int lichBaoTriID = int.Parse(item.SubItems[0].Text);

                    // Tạo đối tượng CLichBaoTri với ID cần xóa
                    CLichBaoTri lichBaoTri = new CLichBaoTri { LichBaoTriID = lichBaoTriID };

                    // Xóa đối tượng khỏi cơ sở dữ liệu
                    if (ctrLichBaoTri.delete(lichBaoTri))
                    {
                        MessageBox.Show("Xóa thành công.");

                        // Xóa khỏi danh sách và ListView
                        lsvLichBaoTri.Items.Remove(item);
                        dsLichBaoTri.Remove(lichBaoTri);

                        // Cập nhật số lượng
                        txtTongSo.Text = lsvLichBaoTri.Items.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một mục để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }
    }
}
