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
    public partial class FNhanVien : Form
    {
        CtrlNhanVien ctrNhanVien = new CtrlNhanVien();
        List<CNhanVien> dsNhanVien = new List<CNhanVien>();
        public FNhanVien()
        {
            InitializeComponent();
            int width = lsvDsNhanVien.Width;
            lsvDsNhanVien.Columns.Add("Mã nhân viên", 25 * width / 100);
            lsvDsNhanVien.Columns.Add("Tên nhân viên", 25 * width / 100);
            lsvDsNhanVien.Columns.Add("Vị trí", 25 * width / 100);
            lsvDsNhanVien.Columns.Add("Lương", 25 * width / 100);

            lsvDsNhanVien.View = View.Details;
            lsvDsNhanVien.FullRowSelect = true;
        }

        private void capNhatDSNhanVien()
        {
            txtTongSo.Text = dsNhanVien.Count.ToString();
        }

        private void lsvDsNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvDsNhanVien.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDsNhanVien.SelectedItems[0];

                    // Assuming 'dsPhong' is a list of CPhong objects
                    int nhanVienId = int.Parse(item.SubItems[0].Text);
                    CNhanVien nhanVien = dsNhanVien.FirstOrDefault(p => p.NhanvienID == nhanVienId);

                    if (nhanVien != null)
                    {
                        txtIDNhanVien.Text = nhanVien.NhanvienID.ToString();
                        txtTenNhanVien.Text = nhanVien.TenNhanVien.ToString();
                        txtViTri.Text = nhanVien.ViTri.ToString();
                        txtLuong.Text = nhanVien.Luong.ToString();

                    }
                }
            }
            catch { }
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            txtIDNhanVien.Focus();          
                dsNhanVien = ctrNhanVien.findall();
            foreach (CNhanVien s in dsNhanVien)
            {
                string[] obj = { s.NhanvienID.ToString(), s.TenNhanVien, s.ViTri, s.Luong.ToString() };
                ListViewItem item = new ListViewItem(obj);
                lsvDsNhanVien.Items.Add(item);
            }

            capNhatDSNhanVien();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtIDNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtViTri.Clear();
            txtLuong.Clear();
            txtIDNhanVien.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CNhanVien s = new CNhanVien();
                s.NhanvienID = int.Parse(txtIDNhanVien.Text);
                s.TenNhanVien = txtTenNhanVien.Text;
                s.ViTri = txtViTri.Text;
                s.Luong = decimal.Parse(txtLuong.Text);
               

                if (ctrNhanVien.insert(s))
                {
                    string[] obj =
                    {
                        s.NhanvienID.ToString(),
                        s.TenNhanVien.ToString(),
                        s.ViTri.ToString(),
                        s.Luong.ToString(),
                        
                    };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDsNhanVien.Items.Add(item);
                    dsNhanVien.Add(s);
                    txtTongSo.Text = lsvDsNhanVien.Items.Count.ToString();
                    MessageBox.Show("Thêm nhân viên thành công");
                }
                capNhatDSNhanVien();
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvDsNhanVien.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDsNhanVien.SelectedItems[0];
                    int nhanVienID = int.Parse(item.SubItems[0].Text);

                    // Tìm đối tượng CPhong tương ứng trong danh sách dsPhong
                    CNhanVien datphong = dsNhanVien.FirstOrDefault(p => p.NhanvienID == nhanVienID);

                    if (datphong != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrNhanVien.delete(datphong))
                        {
                            MessageBox.Show("Xóa nhân viên thành công");

                            // Xóa khỏi danh sách dsPhong và ListView
                            dsNhanVien.Remove(datphong);
                            lsvDsNhanVien.Items.Remove(item);

                            // Cập nhật số lượng phòng
                            txtTongSo.Text = lsvDsNhanVien.Items.Count.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại");
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
                ListViewItem item = lsvDsNhanVien.SelectedItems[0];
                int nhanvienid = int.Parse(item.SubItems[0].Text);
                CNhanVien nhanVien = dsNhanVien.FirstOrDefault(p => p.NhanvienID == nhanvienid);

                if (nhanVien != null)
                {
                    nhanVien.NhanvienID = int.Parse(txtIDNhanVien.Text);
                    nhanVien.TenNhanVien = txtTenNhanVien.Text;
                    nhanVien.ViTri = txtViTri.Text;
                    nhanVien.Luong = decimal.Parse(txtLuong.Text);

                    if (ctrNhanVien.update(nhanVien))
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                        item.SubItems[1].Text = nhanVien.NhanvienID.ToString();
                        item.SubItems[2].Text = nhanVien.TenNhanVien;
                        item.SubItems[4].Text = nhanVien.ViTri;
                        item.SubItems[3].Text = nhanVien.Luong.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thất bại.");
                    }
                    capNhatDSNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
