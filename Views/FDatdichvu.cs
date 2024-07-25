using QL_KHACHSAN.Controller;
using QL_KHACHSAN.Models;
using QL_KHACHSAN.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACHSAN
{
    public partial class FDatdichvu : Form
    {
        CtrlDatDichVu ctrlDDV = new CtrlDatDichVu();
        List<CDatDichVu> dsDDV = new List<CDatDichVu>();
        CtrlDichvu ctrlDV = new CtrlDichvu();
        List<CDichvu> dsdv = new List<CDichvu>();
        public FDatdichvu()
        {
            InitializeComponent();
            int width = lsvDSDVDaDat.Width;
            lsvDSDVDaDat.Columns.Add("ID Đặt Dịch Vụ", 25 * width / 100);
            lsvDSDVDaDat.Columns.Add("ID Dịch Vụ", 25 * width / 100);
            lsvDSDVDaDat.Columns.Add("Số Phòng", 25 * width / 100);
            lsvDSDVDaDat.Columns.Add("Ngày Đặt", 25 * width / 100);
            lsvDSDVDaDat.View = View.Details;
            lsvDSDVDaDat.FullRowSelect = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FDatdichvu_Load(object sender, EventArgs e)
        {
            dsDDV = ctrlDDV.findall();
            foreach (CDatDichVu s in dsDDV)
            {
                string[] obj = { s.DatDichVuID + "", s.DichVuID.DichVuID1 + "", s.DatPhongID.PhongId + "", s.NgayDat + "" };
                ListViewItem item = new ListViewItem(obj);
                lsvDSDVDaDat.Items.Add(item);
            }
            dsdv = ctrlDV.findall();
            cmbDV.DataSource = dsdv;
            List<CPhong> dsPhong = new List<CPhong>();
            CtrlPhong ctrlPhong = new CtrlPhong();
            dsPhong = ctrlPhong.findall();
            cmbPhong.DataSource = dsPhong;

            txtTongSo.Text = lsvDSDVDaDat.Items.Count.ToString();
        }

        private void lsvDSDV_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ListViewItem item = lsvDSDVDaDat.SelectedItems[0];
                CDatDichVu dichVu = new CDatDichVu();
                dichVu.DatDichVuID = int.Parse(item.SubItems[0].Text);
                int index = dsDDV.IndexOf(dichVu);
                if (index < 0)
                {
                    return;
                }
                {
                    dichVu = dsDDV[index];
                    cmbDV.Text = dichVu.DichVuID.DichVuID1 + "";
                    txtIDDatDichVu.Text = dichVu.DatDichVuID + " ";
                    cmbPhong.Text = dichVu.DatPhongID.PhongId + "";
                    dtpTimeDV.Text = dichVu.NgayDat + "";
                }
            }
            catch
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CDatDichVu DDV = new CDatDichVu();
            DDV.DatDichVuID = int.Parse(txtIDDatDichVu.Text);
            CDichvu dichVu = (CDichvu)cmbDV.SelectedItem;
            DDV.DichVuID = new CDichvu();
            DDV.DichVuID = dichVu;
            CPhong Phong = (CPhong)cmbPhong.SelectedItem;
            DDV.DatPhongID = new CPhong();
            DDV.DatPhongID = Phong;
            DDV.NgayDat = dtpTimeDV.Value;

            if (ctrlDDV.insert(DDV))
            {
                string[] obj = { DDV.DatDichVuID + "", DDV.DatPhongID.PhongId + "", DDV.DichVuID.DichVuID1 + "", DDV.NgayDat + "" };
                ListViewItem item = new ListViewItem(obj);
                lsvDSDVDaDat.Items.Add(item);
                MessageBox.Show("Đặt thành công");

                txtTongSo.Text = lsvDSDVDaDat.Items.Count.ToString();
            }
            else
            {

                MessageBox.Show("Đặt Thất Bại");
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void lstDSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn đặt này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ListViewItem item = lsvDSDVDaDat.SelectedItems[0];
                    CDatDichVu dichVuDaDat = new CDatDichVu();
                    dichVuDaDat.DatDichVuID = int.Parse(item.SubItems[0].Text);
                    int index = dsDDV.IndexOf(dichVuDaDat);
                    if (index < 0)
                    {
                        return;
                    }
                    dichVuDaDat = dsDDV[index];
                    if (ctrlDDV.delete(dichVuDaDat))
                    {
                        dsDDV.Remove(dichVuDaDat);
                        lsvDSDVDaDat.Items.Remove(item);
                        MessageBox.Show("Xóa thành công");
                        txtTongSo.Text = lsvDSDVDaDat.Items.Count.ToString();
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
            catch
            {

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lsvDSDVDaDat.SelectedItems[0];
                CDatDichVu dichVuDaDat = new CDatDichVu();
                dichVuDaDat.DatDichVuID = int.Parse(item.SubItems[0].Text);
                int index = dsDDV.IndexOf(dichVuDaDat);
                if (index < 0)
                {
                    return;
                }

                CDichvu dichVu = (CDichvu)cmbDV.SelectedItem;
                dichVuDaDat = dsDDV[index];
                dichVuDaDat.DatDichVuID = int.Parse(txtIDDatDichVu.Text);

                dichVuDaDat.DichVuID = new CDichvu();
                dichVuDaDat.DichVuID = dichVu;
                CPhong Phong = (CPhong)cmbPhong.SelectedItem;
                dichVuDaDat.DatPhongID = new CPhong();
                dichVuDaDat.DatPhongID = Phong;
                dichVuDaDat.NgayDat = dtpTimeDV.Value;
                if (ctrlDDV.update(dichVuDaDat))
                {
                    item.SubItems[1].Text = dichVuDaDat.DichVuID + "";
                    item.SubItems[2].Text = dichVuDaDat.DatPhongID + "";
                    item.SubItems[3].Text = dichVuDaDat.NgayDat + "";
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                    MessageBox.Show("Cập nhật thất bại!!!");
            }
            catch
            {

            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDDatDichVu.Text = string.Empty;
            cmbDV.SelectedIndex = 0;
            cmbPhong.SelectedIndex = 0;
        }

        private void txtIDDatDichVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void FDatdichvu_Load_1(object sender, EventArgs e)
        {
            dsDDV = ctrlDDV.findall();
            foreach (CDatDichVu s in dsDDV)
            {
                string[] obj = { s.DatDichVuID + "", s.DichVuID.DichVuID1 + "", s.DatPhongID.PhongId + "", s.NgayDat + "" };
                ListViewItem item = new ListViewItem(obj);
                lsvDSDVDaDat.Items.Add(item);
            }
            dsdv = ctrlDV.findall();
            cmbDV.DataSource = dsdv;
            List<CPhong> dsPhong = new List<CPhong>();
            CtrlPhong ctrlPhong = new CtrlPhong();
            dsPhong = ctrlPhong.findall();
            cmbPhong.DataSource = dsPhong;

            txtTongSo.Text = lsvDSDVDaDat.Items.Count.ToString();
        }

        private void lsvDSDVDaDat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDSDVDaDat.SelectedItems.Count > 0)
            {
                cmbDV.Text = lsvDSDVDaDat.SelectedItems[0].SubItems[0].Text;
                txtIDDatDichVu.Text = lsvDSDVDaDat.SelectedItems[0].SubItems[1].Text;
                cmbPhong.Text = lsvDSDVDaDat.SelectedItems[0].SubItems[2].Text;
                dtpTimeDV.Text = lsvDSDVDaDat.SelectedItems[0].SubItems[3].Text;

            }
        }

        private void cmbDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpTimeDV_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IDDatDichVu_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTongSo_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dkFind = txtTimKiem.Text;
                dsDDV = ctrlDDV.findCriteria(dkFind);

                lsvDSDVDaDat.Items.Clear();
                foreach (CDatDichVu s in dsDDV)
                {

                    string[] obj = { s.DatDichVuID.ToString(), s.DichVuID.ToString() };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDSDVDaDat.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnNhapMoi_Click_1(object sender, EventArgs e)
        {
            txtIDDatDichVu.Text = string.Empty;
            cmbDV.Text = string.Empty;
            txtIDDatDichVu.Focus();
            cmbPhong.Text = string.Empty;
            dtpTimeDV.Value = DateTime.Today;
        }

        private void txtNgayNhan_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            // Giả sử bạn có các điều khiển cho các thuộc tính
            int datDichVuID = Convert.ToInt32(cmbDV.Text);
            int dichVuID = Convert.ToInt32(txtIDDatDichVu.Text);
            int phongID = Convert.ToInt32(cmbPhong.Text);
            DateTime ngayDat = dtpTimeDV.Value;

            // Tạo đối tượng CDatDichVu với các thuộc tính đã được nhập
            CDatDichVu datDichVu = new CDatDichVu
            {
                DatDichVuID = datDichVuID,
                DichVuID = new CDichvu { DichVuID1 = dichVuID }, // Giả sử bạn đã có cách khởi tạo CDichvu
                DatPhongID = new CPhong { PhongId = phongID }, // Giả sử bạn đã có cách khởi tạo CPhong
                NgayDat = ngayDat
            };

            // Tạo đối tượng điều khiển
            CtrlDatDichVu ctrl = new CtrlDatDichVu();

            // Cập nhật dữ liệu
            bool result = ctrl.update(datDichVu);

            // Thông báo kết quả
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
        }
    }
}
