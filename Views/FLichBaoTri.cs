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
                CPhong phong = new CPhong { PhongId = int.Parse(txtIDPhong.Text) };
                CNhanVien nhanVien = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) };
                CLichBaoTri lichBaoTri = new CLichBaoTri
                {
                    LichBaoTriID = int.Parse(txtIDLichBaoTri.Text),
                    PhongID = phong,
                    NhanvienID = nhanVien,
                    NgayBaoTri = dtpNgayBaoTri.Value,
                    MoTa = txtMoTa.Text
                };

                if (ctrLichBaoTri.insert(lichBaoTri))
                {
                    MessageBox.Show("Thêm thành công");
                    dsLichBaoTri.Add(lichBaoTri);
                    string[] obj = { lichBaoTri.LichBaoTriID.ToString(), lichBaoTri.PhongID.PhongId.ToString(), lichBaoTri.NhanvienID.NhanvienID.ToString(), lichBaoTri.NgayBaoTri.ToString(), lichBaoTri.MoTa };
                    ListViewItem item = new ListViewItem(obj);
                    lsvLichBaoTri.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
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
            if (lsvLichBaoTri.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = lsvLichBaoTri.SelectedItems[0];
                    CLichBaoTri lichBaoTri = dsLichBaoTri.Find(x => x.LichBaoTriID == int.Parse(item.SubItems[0].Text));
                    lichBaoTri.PhongID = new CPhong { PhongId = int.Parse(txtIDPhong.Text) };
                    lichBaoTri.NhanvienID = new CNhanVien { NhanvienID = int.Parse(txtIDNhanVien.Text) };
                    lichBaoTri.NgayBaoTri = dtpNgayBaoTri.Value;
                    lichBaoTri.MoTa = txtMoTa.Text;

                    if (ctrLichBaoTri.Update(lichBaoTri))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        item.SubItems[1].Text = lichBaoTri.LichBaoTriID.ToString();
                        item.SubItems[2].Text = lichBaoTri.PhongID.ToString();
                        item.SubItems[3].Text = lichBaoTri.NhanvienID.ToString();
                        item.SubItems[4].Text = lichBaoTri.NgayBaoTri.ToString();
                        item.SubItems[5].Text = lichBaoTri.MoTa.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDLichBaoTri.Clear();
            txtIDPhong.Clear();
            txtIDNhanVien.Clear();
            txtMoTa.Clear();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string dkFind = txtTimKiem.Text;
            //    dsLichBaoTri = dsLichBaoTri.findCriteria(dkFind);

            //    lsvLichBaoTri.Items.Clear();
            //    foreach (CLichBaoTri s in dsLichBaoTri)
            //    {
            //        string[] obj = { s.LichBaoTriID.ToString(), s.PhongID.PhongId.ToString(), s.NhanvienID.NhanvienID.ToString(), s.NgayBaoTri.ToString(), s.MoTa };
            //        ListViewItem item = new ListViewItem(obj);
            //        lsvLichBaoTri.Items.Add(item);
            //    }
            //    txtTongSo.Text = lsvLichBaoTri.Items.Count.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
        }
    }
}
