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
    public partial class FPhong : Form
    {
        CtrlPhong ctrlPhong = new CtrlPhong();
        private List<CPhong> dsPhong = new List<CPhong>();
        public FPhong()
        {
            InitializeComponent();
            int width = lsvDSPhong.Width;
            lsvDSPhong.Columns.Add("Mã phòng", 15 * width / 100);
            lsvDSPhong.Columns.Add("Số phòng", 20 * width / 100);
            lsvDSPhong.Columns.Add("Loại phòng", 25 * width / 100);
            lsvDSPhong.Columns.Add("Giá tiền", 20 * width / 100);
            lsvDSPhong.Columns.Add("Tình trạng", 20 * width / 100);

            lsvDSPhong.View = View.Details;
            lsvDSPhong.FullRowSelect = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FPhong_Load(object sender, EventArgs e)
        {
            dsPhong = ctrlPhong.findall();
            foreach (CPhong s in dsPhong)
            {
                string[] obj = { 
                    s.PhongId.ToString(), 
                    s.SoPhong, 
                    s.LoaiPhong, 
                    s.GiaTien.ToString(), 
                    s.TinhTrang };
                ListViewItem item = new ListViewItem(obj);
                lsvDSPhong.Items.Add(item);
            }
        }

        private void lsvDSPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvDSPhong.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDSPhong.SelectedItems[0];

                    // Assuming 'dsPhong' is a list of CPhong objects
                    int phongId = int.Parse(item.SubItems[0].Text);
                    CPhong phong = dsPhong.FirstOrDefault(p => p.PhongId == phongId);

                    if (phong != null)
                    {
                        txtMaPhong.Text = phong.PhongId.ToString();
                        txtGiaTien.Text = phong.GiaTien.ToString();
                        txtLoaiPhong.Text = phong.LoaiPhong;
                        txtSoPhong.Text = phong.SoPhong;
                        txtTinhTrang.Text = phong.TinhTrang;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string phongID = txtMaPhong.Text;
            //    string soPhong = txtSoPhong.Text;
            //    string loaiPhong = txtLoaiPhong.Text;
            //    string giaTien = txtGiaTien.Text;
            //    string tinhTrang = txtTinhTrang.Text;

                

            //    CPhong phong = new CPhong(phongID, soPhong, loaiPhong, giaTien, tinhTrang);
            //}
            //catch { }
        }
    }
}
