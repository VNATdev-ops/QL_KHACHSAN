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
    public partial class FHoaDon : Form
    {
        private List<CHoaDon> dsHoaDon;
        private List<CDatPhong> dsDatPhong;
        private CtrlHoaDon ctrlHoaDon = new CtrlHoaDon();
        private CtrlDatPhong ctrlDatPhong = new CtrlDatPhong();
        public FHoaDon()
        {
            InitializeComponent();
            
            int width = listViewHoaDon.Width;
            listViewHoaDon.Columns.Add("Mã hóa đơn", 25 * width / 100);
            listViewHoaDon.Columns.Add("Mã đặt phòng", 25 * width / 100);
            listViewHoaDon.Columns.Add("Ngày lập", 25 * width / 100);
            listViewHoaDon.Columns.Add("Tổng tiền", 25 * width / 100);
            

            listViewHoaDon.View = View.Details;
            listViewHoaDon.FullRowSelect = true;
            LoadDatPhong();
            LoadHoaDon();
        }

        private void LoadDatPhong()
        {
            dsDatPhong = ctrlDatPhong.findall(); // Sử dụng phương thức findall của CtrlDatPhong
        }

        private void LoadHoaDon()
        {
            dsHoaDon = ctrlHoaDon.FindAll();
            listViewHoaDon.Items.Clear();
            foreach (CHoaDon hoaDon in dsHoaDon)
            {
                string[] row = {
                    hoaDon.IDHoaDon.ToString(),
                    hoaDon.IdDatphong.DatPhongID.ToString(),
                    hoaDon.NgayLap.ToString("dd/MM/yyyy"),
                    hoaDon.TongTien.ToString("N2")
                };
                ListViewItem item = new ListViewItem(row);
                listViewHoaDon.Items.Add(item);
            }
            capNhatSoLuongPhong();
        }

        private void capNhatSoLuongPhong()
        {
            txtTongSo.Text = dsHoaDon.Count.ToString();
        }

        private void txtIDdatphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển nhập liệu
                int hoaDonID = int.Parse(txtIDHoaDon.Text);
                int datPhongID = int.Parse(txtIDdatphong.Text);
                DateTime ngayLap = dtpNgayLap.Value;
                decimal tongTien = decimal.Parse(txtTongTien.Text);

                // Tìm đặt phòng tương ứng
                CDatPhong datPhong = dsDatPhong.FirstOrDefault(dp => dp.DatPhongID == datPhongID);

                // Kiểm tra xem đặt phòng có tồn tại không
                if (datPhong == null)
                {
                    MessageBox.Show("Đặt phòng không tồn tại.");
                    return;
                }

                // Tạo đối tượng hóa đơn
                CHoaDon hoaDon = new CHoaDon(hoaDonID, datPhong, ngayLap, tongTien);

                // Thực hiện thêm vào cơ sở dữ liệu
                if (ctrlHoaDon.insert(hoaDon))
                {
                    // Cập nhật giao diện người dùng
                    string[] obj = {
                    hoaDon.IDHoaDon.ToString(),
                    hoaDon.IdDatphong.DatPhongID.ToString(),
                    hoaDon.NgayLap.ToString("dd/MM/yyyy"),
                    hoaDon.TongTien.ToString("N2")
                };
                    ListViewItem item = new ListViewItem(obj);
                    listViewHoaDon.Items.Add(item);

                    // Cập nhật số lượng hóa đơn
                    txtTongSo.Text = listViewHoaDon.Items.Count.ToString();
                    MessageBox.Show("Thêm hóa đơn thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewHoaDon.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để cập nhật");
                    return;
                }

                ListViewItem item = listViewHoaDon.SelectedItems[0];
                int hoaDonID = int.Parse(item.SubItems[0].Text);

                CHoaDon hoaDon = new CHoaDon();
                hoaDon.IDHoaDon = hoaDonID;
                hoaDon.IdDatphong = new CDatPhong() { DatPhongID = int.Parse(txtIDdatphong.Text) };
                hoaDon.NgayLap = dtpNgayLap.Value;
                hoaDon.TongTien = decimal.Parse(txtTongTien.Text);

                if (ctrlHoaDon.Update(hoaDon))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công");
                    LoadHoaDon();
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void listViewHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewHoaDon.SelectedItems[0];
                txtIDHoaDon.Text = item.SubItems[0].Text;
                txtIDdatphong.Text = item.SubItems[1].Text;
                dtpNgayLap.Value = DateTime.Parse(item.SubItems[2].Text);
                txtTongTien.Text = item.SubItems[3].Text;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox

                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                    return;
                }

                // Tìm kiếm hóa đơn
                dsHoaDon = ctrlHoaDon.FindByCriteria(keyword);

                // Cập nhật giao diện người dùng với kết quả tìm kiếm
                listViewHoaDon.Items.Clear();
                foreach (CHoaDon hoaDon in dsHoaDon)
                {
                    string[] row = {
                hoaDon.IDHoaDon.ToString(),
                hoaDon.IdDatphong.DatPhongID.ToString(),
                hoaDon.NgayLap.ToString("dd/MM/yyyy"),
                hoaDon.TongTien.ToString("N2")
            };
                    ListViewItem item = new ListViewItem(row);
                    listViewHoaDon.Items.Add(item);
                }
                txtTongSo.Text = listViewHoaDon.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void FHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewHoaDon.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa");
                    return;
                }

                ListViewItem item = listViewHoaDon.SelectedItems[0];
                int hoaDonID = int.Parse(item.SubItems[0].Text);

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa hóa đơn
                    if (ctrlHoaDon.Delete(hoaDonID))
                    {
                        MessageBox.Show("Xóa hóa đơn thành công");
                        LoadHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn thất bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
