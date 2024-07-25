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

    public partial class FLichLamViec : Form
    {
        CtrlLichLamViec ctrLichLamViec = new CtrlLichLamViec();
        private List<CLichLamViec> dsLichLamViec = new List<CLichLamViec>();

        CtrlNhanVien ctrlNhanVien = new CtrlNhanVien();
        private List<CNhanVien> dsNhanvien = new List<CNhanVien>();

        public FLichLamViec()
        {
            InitializeComponent();
            int width = lsvDsLichLamViec.Width;
            lsvDsLichLamViec.Columns.Add("Mã lịch làm việc", 25 * width / 100);
            lsvDsLichLamViec.Columns.Add("Mã nhân viên", 25 * width / 100);
            lsvDsLichLamViec.Columns.Add("Ngày làm", 25 * width / 100);
            lsvDsLichLamViec.Columns.Add("Ca làm", 25 * width / 100);

            lsvDsLichLamViec.View = View.Details;
            lsvDsLichLamViec.FullRowSelect = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCaLam_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDlichlamviec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayLam_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng CLichLamViec và gán giá trị từ các điều khiển đầu vào
                CLichLamViec lichLamViec = new CLichLamViec
                {
                    LichLamViecID = int.Parse(txtIDlichlamviec.Text),
                    NhanVienID = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) }, // Giả sử bạn có trường nhập liệu cho ID nhân viên
                    NgayLam = DateTime.Parse(dtpNgayLam.Text),
                    CaLam = txtCaLam.Text
                };

                // Thêm đối tượng vào cơ sở dữ liệu thông qua phương thức insert
                if (ctrLichLamViec.insert(lichLamViec))
                {
                    // Thêm đối tượng vào ListView
                    string[] obj =
                    {
                lichLamViec.LichLamViecID.ToString(),
                lichLamViec.NhanVienID.NhanvienID.ToString(),
                lichLamViec.NgayLam.ToShortDateString(), // Sử dụng ToShortDateString() để dễ đọc hơn
                lichLamViec.CaLam
            };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDsLichLamViec.Items.Add(item);

                    // Thêm đối tượng vào danh sách dữ liệu
                    dsLichLamViec.Add(lichLamViec);

                    // Cập nhật số lượng mục trong ListView
                    txtTongSo.Text = lsvDsLichLamViec.Items.Count.ToString();

                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void FLichLamViec_Load(object sender, EventArgs e)
        {
            txtIDlichlamviec.Focus();
            // Load danh sách lịch làm việc từ cơ sở dữ liệu
            dsLichLamViec = ctrLichLamViec.findall();
            foreach (CLichLamViec s in dsLichLamViec)
            {
                string[] obj = {
                    s.LichLamViecID.ToString(),
                    s.NhanVienID.NhanvienID.ToString(),  // Truy cập thuộc tính NhanvienID của đối tượng CNhanVien
                    s.NgayLam.ToString(),
                    s.CaLam
                };
                ListViewItem item = new ListViewItem(obj);
                lsvDsLichLamViec.Items.Add(item);
            }
            txtTongSo.Text = lsvDsLichLamViec.Items.Count.ToString();
        }

        private void lsvDsLichLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDsLichLamViec.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvDsLichLamViec.SelectedItems[0];
                txtIDlichlamviec.Text = item.SubItems[0].Text;
                txtIDNhanVien.Text = item.SubItems[1].Text;
                dtpNgayLam.Value = DateTime.Parse(item.SubItems[2].Text);
                txtCaLam.Text = item.SubItems[3].Text;
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDlichlamviec.Clear();
            txtIDNhanVien.Clear();
            txtCaLam.Clear();
            dtpNgayLam.Value = DateTime.Today;


        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dkFind = txtTimKiem.Text;
                dsLichLamViec = ctrLichLamViec.findCriteria(dkFind);

                lsvDsLichLamViec.Items.Clear();
                foreach (CLichLamViec s in dsLichLamViec)
                {

                    string[] obj = {
                    s.LichLamViecID.ToString(),
                    s.NhanVienID.NhanvienID.ToString(),  // Truy cập thuộc tính NhanvienID của đối tượng CNhanVien
                    s.NgayLam.ToString(),
                    s.CaLam
                    };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDsLichLamViec.Items.Add(item);
                }
                txtTongSo.Text = lsvDsLichLamViec.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dtpNgayLam_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có mục nào được chọn không
                if (lsvDsLichLamViec.SelectedItems.Count > 0)
                {
                    // Lấy mục được chọn từ ListView
                    ListViewItem item = lsvDsLichLamViec.SelectedItems[0];
                    int lichLamViecID = int.Parse(item.SubItems[0].Text);

                    // Tìm đối tượng CLichLamViec tương ứng trong danh sách dsLichLamViec
                    CLichLamViec lichLamViec = dsLichLamViec.FirstOrDefault(v => v.LichLamViecID == lichLamViecID);

                    if (lichLamViec != null)
                    {
                        // Cập nhật thông tin đối tượng
                        lichLamViec.LichLamViecID = int.Parse(txtIDlichlamviec.Text);
                        lichLamViec.NhanVienID = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) }; // Tạo đối tượng CNhanVien
                        lichLamViec.NgayLam = DateTime.Parse(dtpNgayLam.Text);
                        lichLamViec.CaLam = txtCaLam.Text;

                        // Cập nhật cơ sở dữ liệu
                        if (ctrLichLamViec.update(lichLamViec))
                        {
                            // Cập nhật ListView
                            item.SubItems[0].Text = lichLamViec.LichLamViecID.ToString();
                            item.SubItems[1].Text = lichLamViec.NhanVienID.NhanvienID.ToString();
                            item.SubItems[2].Text = lichLamViec.NgayLam.ToShortDateString();
                            item.SubItems[3].Text = lichLamViec.CaLam;

                            MessageBox.Show("Cập nhật thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin lịch làm việc.");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có mục nào được chọn không
                if (lsvDsLichLamViec.SelectedItems.Count > 0)
                {
                    // Lấy mục được chọn từ ListView
                    ListViewItem item = lsvDsLichLamViec.SelectedItems[0];
                    int lichLamViecID = int.Parse(item.SubItems[0].Text);

                    // Tạo đối tượng CLichLamViec với ID đã chọn
                    CLichLamViec lichLamViec = dsLichLamViec.FirstOrDefault(v => v.LichLamViecID == lichLamViecID);

                    if (lichLamViec != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrLichLamViec.delete(lichLamViec))
                        {
                            // Xóa khỏi danh sách dsLichLamViec và ListView
                            dsLichLamViec.Remove(lichLamViec);
                            lsvDsLichLamViec.Items.Remove(item);

                            // Cập nhật số lượng lịch làm việc
                            txtTongSo.Text = lsvDsLichLamViec.Items.Count.ToString();

                            MessageBox.Show("Xóa thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin lịch làm việc.");
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
