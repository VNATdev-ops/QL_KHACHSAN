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
    public partial class FDatPhong : Form
    {
        CtrlDatPhong ctrlDatPhong = new CtrlDatPhong();
        private List<CDatPhong> dsDatPhong = new List<CDatPhong> ();
        public FDatPhong()
        {
            InitializeComponent();
            int width = lsvDatPhong.Width;
            lsvDatPhong.Columns.Add("Mã đặt phòng", 90);
            lsvDatPhong.Columns.Add("Mã phòng", 90);
            lsvDatPhong.Columns.Add("Ngày đặt", 150);
            lsvDatPhong.Columns.Add("Ngày nhận", 150);
            lsvDatPhong.Columns.Add("Ngày trả", 150);
            lsvDatPhong.Columns.Add("Mã khách hàng", 90);
            lsvDatPhong.Columns.Add("Tình trạng", 130);

            lsvDatPhong.View = View.Details;
            lsvDatPhong.FullRowSelect = true;
        }

        private void capNhatSoLuongPhong()
        {
            txtTongSo.Text = dsDatPhong.Count.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try 
            {
                CDatPhong s = new CDatPhong();
                s.DatPhongID = int.Parse(txtIDdatphong.Text);
                s.PhongID = int.Parse(txtIDphong.Text);
                s.KhachHangID = int.Parse(txtIDkhachhang.Text);
                s.NgayDat1 = DateTime.Parse(txtNgayDat.Text);
                s.NgayNhan1 = DateTime.Parse(txtNgayNhan.Text);
                s.NgayTra1 = DateTime.Parse(txtNgayTra.Text);
                s.TinhTrang1 = txtTinhtrang.Text;

                if (ctrlDatPhong.insert(s))
                {
                    string[] obj =
                    {
                        s.DatPhongID.ToString(),
                        s.PhongID.ToString(),
                        s.KhachHangID.ToString(),
                        s.NgayDat1.ToString(),
                        s.NgayNhan1.ToString(),
                        s.NgayTra1.ToString(),
                        s.TinhTrang1
                    };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDatPhong.Items.Add(item);
                    dsDatPhong.Add(s);
                    txtTongSo.Text = lsvDatPhong.Items.Count.ToString();
                    MessageBox.Show("Thêm thành công");
                }
                capNhatSoLuongPhong();
            }
            catch 
            {
                MessageBox.Show("Lỗi khi thêm");
            }

        }

        private void lsvDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvDatPhong.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDatPhong.SelectedItems[0];

                    // Assuming 'dsPhong' is a list of CPhong objects
                    int datphongId = int.Parse(item.SubItems[0].Text);
                    CDatPhong datphong = dsDatPhong.FirstOrDefault(p => p.DatPhongID == datphongId);

                    if (datphong != null)
                    {
                        txtIDdatphong.Text = datphong.DatPhongID.ToString();
                        txtIDphong.Text = datphong.KhachHangID.ToString();
                        txtIDkhachhang.Text = datphong.KhachHangID.ToString();
                        txtNgayDat.Text = datphong.NgayDat1.Date.ToString();
                        txtNgayNhan.Text = datphong.NgayNhan1.Date.ToString();
                        txtNgayTra.Text = datphong.NgayTra1.Date.ToString();
                        txtTinhtrang.Text = datphong.TinhTrang1.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FDatPhong_Load(object sender, EventArgs e)
        {
            dsDatPhong = ctrlDatPhong.findall();
            foreach (CDatPhong s in dsDatPhong)
            {
                string[] obj = {
                    s.DatPhongID.ToString(),
                    s.PhongID.ToString(),
                    s.KhachHangID.ToString(),
                    s.NgayDat1.ToShortDateString(),
                    s.NgayNhan1.ToShortDateString(),
                    s.NgayTra1.ToShortTimeString(),
                    s.TinhTrang1.ToString(),
                };
                ListViewItem item = new ListViewItem(obj);
                lsvDatPhong.Items.Add(item);
            }
            capNhatSoLuongPhong();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDdatphong.Text = string.Empty;
            txtIDphong.Text = string.Empty;
            txtIDkhachhang.Text = string.Empty;
            txtNgayDat.Text = string.Empty;
            txtNgayNhan.Text = string.Empty;
            txtNgayTra.Text = string.Empty;
            txtTinhtrang.Text = string.Empty;
            txtIDphong.Focus();
        }
    }
}
