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

                    // Tìm đối tượng CNhanVien tương ứng trong danh sách dsNhanVien
                    CNhanVien nhanVien = dsNhanVien.FirstOrDefault(p => p.NhanvienID == nhanVienID);

                    if (nhanVien != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        if (ctrNhanVien.delete(nhanVien))
                        {
                            MessageBox.Show("Xóa nhân viên thành công");

                            // Xóa khỏi danh sách dsNhanVien và ListView
                            dsNhanVien.Remove(nhanVien);
                            lsvDsNhanVien.Items.Remove(item);

                            // Cập nhật số lượng nhân viên
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
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa");
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
                // Kiểm tra xem có mục nào được chọn trong ListView hay không
                if (lsvDsNhanVien.SelectedItems.Count > 0)
                {
                    ListViewItem item = lsvDsNhanVien.SelectedItems[0];
                    int nhanvienid = int.Parse(item.SubItems[0].Text);

                    // Tìm đối tượng CNhanVien tương ứng trong danh sách dsNhanVien
                    CNhanVien nhanVien = dsNhanVien.FirstOrDefault(p => p.NhanvienID == nhanvienid);

                    if (nhanVien != null)
                    {
                        // Cập nhật thông tin nhân viên từ các điều khiển đầu vào
                        nhanVien.NhanvienID = int.Parse(txtIDNhanVien.Text); // Bạn nên kiểm tra trước để đảm bảo ID không bị thay đổi hoặc trùng lặp
                        nhanVien.TenNhanVien = txtTenNhanVien.Text;
                        nhanVien.ViTri = txtViTri.Text;
                        nhanVien.Luong = decimal.Parse(txtLuong.Text);

                        // Gọi phương thức update để cập nhật thông tin trong cơ sở dữ liệu
                        if (ctrNhanVien.update(nhanVien))
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công.");

                            // Cập nhật thông tin trong ListView
                            item.SubItems[1].Text = nhanVien.TenNhanVien;
                            item.SubItems[2].Text = nhanVien.ViTri;
                            item.SubItems[3].Text = nhanVien.Luong.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thất bại.");
                        }

                        // Cập nhật danh sách hiển thị trong ListView
                        capNhatDSNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên với ID đã chọn.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.");
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
                dsNhanVien = ctrNhanVien.findCriteria(dkFind);

                lsvDsNhanVien.Items.Clear();
                foreach (CNhanVien s in dsNhanVien)
                {

                    string[] obj = { s.NhanvienID.ToString(), s.TenNhanVien, s.ViTri, s.Luong.ToString() };
                    ListViewItem item = new ListViewItem(obj);
                    lsvDsNhanVien.Items.Add(item);
                }
                txtTongSo.Text = lsvDsNhanVien.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
