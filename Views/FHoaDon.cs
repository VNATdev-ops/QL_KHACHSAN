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
        private CtrlHoaDon ctrlHoaDon = new CtrlHoaDon();
        private List<CHoaDon> dsHoaDon = new List<CHoaDon>();
        public FHoaDon()
        {
            InitializeComponent();
            
            int width = listViewHoaDon.Width;
            listViewHoaDon.Columns.Add("Mã sự cố", 25 * width / 100);
            listViewHoaDon.Columns.Add("Mã phòng", 25 * width / 100);
            listViewHoaDon.Columns.Add("Mã nhân viên", 25 * width / 100);
            listViewHoaDon.Columns.Add("Mô tả", 25 * width / 100);
            

            listViewHoaDon.View = View.Details;
            listViewHoaDon.FullRowSelect = true;
            LoadHoaDon();
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
                CHoaDon hoaDon = new CHoaDon();
                hoaDon.IdDatphong = new CDatPhong() { DatPhongID = int.Parse(txtIDdatphong.Text) };
                hoaDon.NgayLap = dtpNgayLap.Value;
                hoaDon.TongTien = decimal.Parse(txtTongTien.Text);

                if (ctrlHoaDon.Insert(hoaDon))
                {
                    MessageBox.Show("Thêm hóa đơn thành công");
                    LoadHoaDon();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại");
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
                int hoaDonID = int.Parse(txtIDdatphong.Text);
                CHoaDon hoaDon = ctrlHoaDon.FindByID(hoaDonID);
                if (hoaDon != null)
                {
                    txtIDdatphong.Text = hoaDon.IdDatphong.DatPhongID.ToString();
                    dtpNgayLap.Value = hoaDon.NgayLap;
                    txtTongTien.Text = hoaDon.TongTien.ToString("N2");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với ID đã nhập");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
