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
        CtrlPhong ctrPhong = new CtrlPhong();
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

        private void capNhatSoLuongPhong()
        {
            txtTongSo.Text = dsPhong.Count.ToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FPhong_Load(object sender, EventArgs e)
        {
            dsPhong = ctrPhong.findall();
            foreach (CPhong s in dsPhong)
            {
                string[] obj = { 
                    s.PhongId.ToString(), 
                    s.SoPhong, 
                    s.LoaiPhong, 
                    s.GiaTien.ToString(), 
                    s.TinhTrang 
                };
                ListViewItem item = new ListViewItem(obj);
                lsvDSPhong.Items.Add(item);
            }
            capNhatSoLuongPhong();
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
            try
            {
                CPhong s = new CPhong();
                s.PhongId = int.Parse(txtMaPhong.Text);
                s.SoPhong = txtSoPhong.Text;
                s.LoaiPhong = txtLoaiPhong.Text;
                s.GiaTien = decimal.Parse(txtGiaTien.Text);
                s.TinhTrang = txtTinhTrang.Text;

                if (ctrPhong.insert(s))
                {
                    string[] objPhong =
                    {
                        s.PhongId.ToString(),
                        s.SoPhong,
                        s.LoaiPhong,
                        s.GiaTien.ToString(),
                        s.TinhTrang
                    };
                    ListViewItem item = new ListViewItem(objPhong);
                    lsvDSPhong.Items.Add(item);
                    dsPhong.Add(s);
                    txtTongSo.Text = lsvDSPhong.Items.Count.ToString();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtGiaTien.Text = string.Empty;
            txtLoaiPhong.Text = string.Empty;
            txtMaPhong.Text = string.Empty;
            txtSoPhong.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            txtMaPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvDSPhong.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDSPhong.SelectedItems[0];
                    int phongId = int.Parse(item.SubItems[0].Text);

                    // Tìm đối tượng CPhong tương ứng trong danh sách dsPhong
                    CPhong phong = dsPhong.FirstOrDefault(p => p.PhongId == phongId);

                    if (phong != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrPhong.delete(phong))
                        {
                            MessageBox.Show("Xóa thành công");

                            // Xóa khỏi danh sách dsPhong và ListView
                            dsPhong.Remove(phong);
                            lsvDSPhong.Items.Remove(item);

                            // Cập nhật số lượng phòng
                            txtTongSo.Text = lsvDSPhong.Items.Count.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng để xóa");
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
                ListViewItem item = lsvDSPhong.SelectedItems[0];
                int phongId = int.Parse(item.SubItems[0].Text);
                CPhong phong = dsPhong.FirstOrDefault(p => p.PhongId == phongId);

                if (phong != null)
                {
                    phong.LoaiPhong = txtLoaiPhong.Text;
                    phong.SoPhong = txtSoPhong.Text;
                    phong.GiaTien = decimal.Parse(txtGiaTien.Text);
                    phong.TinhTrang = txtTinhTrang.Text;

                    if (ctrPhong.update(phong))
                    {
                        MessageBox.Show("Cập nhật thông tin phòng thành công.");
                        item.SubItems[1].Text = phong.SoPhong;
                        item.SubItems[2].Text = phong.LoaiPhong;
                        item.SubItems[3].Text = phong.GiaTien.ToString();
                        item.SubItems[4].Text = phong.TinhTrang;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin phòng thất bại.");
                    }
                    capNhatSoLuongPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dkFind = txtTimKiem.Text;
                dsPhong = ctrPhong.findCriteria(dkFind);

                lsvDSPhong.Items.Clear();
                foreach (CPhong s in dsPhong)
                {
                    
                    string[] obj = { s.PhongId.ToString(), s.SoPhong, s.LoaiPhong, s.GiaTien.ToString(), s.TinhTrang };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDSPhong.Items.Add(item);
                }
                txtTongSo.Text = lsvDSPhong.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
