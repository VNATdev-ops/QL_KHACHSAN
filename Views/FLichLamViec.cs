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
                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(txtIDlichlamviec.Text) || string.IsNullOrEmpty(txtIDNhanVien.Text) || string.IsNullOrEmpty(txtCaLam.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                CNhanVien nhanVien = new CNhanVien
                {
                    NhanvienID = int.Parse(txtIDNhanVien.Text)
                };

                CLichLamViec lichLamViec = new CLichLamViec
                {
                    LichLamViecID = int.Parse(txtIDlichlamviec.Text),
                    NhanVienID = nhanVien,
                    NgayLam = dtpNgayLam.Value,
                    CaLam = txtCaLam.Text
                };

                if (ctrLichLamViec.insert(lichLamViec))
                {
                    MessageBox.Show("Thêm thành công");
                    dsLichLamViec.Add(lichLamViec);
                    // Refresh ListView or other control
                    string[] obj = {
                lichLamViec.LichLamViecID.ToString(),
                lichLamViec.NhanVienID.NhanvienID.ToString(),
                lichLamViec.NgayLam.ToString(),
                lichLamViec.CaLam
            };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDsLichLamViec.Items.Add(item);
                    txtTongSo.Text = lsvDsLichLamViec.Items.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                // Ghi lại chi tiết lỗi vào log hoặc file text để kiểm tra sau này
                System.IO.File.AppendAllText("error_log.txt", DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
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
            

        }
    }
}
