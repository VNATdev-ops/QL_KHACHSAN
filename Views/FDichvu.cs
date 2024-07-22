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

namespace QL_KHACHSAN
{
    public partial class FDichvu : Form
    {
        CtrlDichvu ctrlDichVu = new CtrlDichvu();
        List<CDichvu> dsDichVu = new List<CDichvu>();
        public FDichvu()
        {
            InitializeComponent();
            int width = lsvDanhSachDichVu.Width;
            lsvDanhSachDichVu.Columns.Add("ID Dịch Vụ", 30 * width / 100);
            lsvDanhSachDichVu.Columns.Add("Dịch Vụ", 30 * width / 100);
            lsvDanhSachDichVu.Columns.Add("Giá Tiền", 30 * width / 100);
            lsvDanhSachDichVu.View = View.Details;
            lsvDanhSachDichVu.FullRowSelect = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIDDichvu.Text;
                string name = txtTendichvu.Text;
                string money = txtGiatien.Text;
                CDichvu dv = new CDichvu(int.Parse(id), name, double.Parse(money));
                if (ctrlDichVu.insert(dv))
                {
                    string[] objdv = { id, name, money };
                    ListViewItem item = new ListViewItem(objdv);
                    lsvDanhSachDichVu.Items.Add(item);
                    dsDichVu.Add(dv);
                    MessageBox.Show("Thêm Thành Công!");

                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại!!!");

                }
            }
            catch
            {

            }
        }

        private void FDichvu_Load(object sender, EventArgs e)
        {
            dsDichVu = ctrlDichVu.findall();
            foreach (CDichvu s in dsDichVu)
            {
                string[] obj = { s.DichVuID1 + "", s.TenDichVu1, s.GiaTien1 + "" };
                ListViewItem item = new ListViewItem(obj);
                lsvDanhSachDichVu.Items.Add(item);
            }
        }

        private void lsvDanhSachDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lsvDanhSachDichVu.SelectedItems[0];
                CDichvu dichVu = new CDichvu();
                dichVu.DichVuID1 = int.Parse(item.SubItems[0].Text);
                int index = dsDichVu.IndexOf(dichVu);
                if (index < 0)
                {
                    return;
                }
                {
                    dichVu = dsDichVu[index];
                    txtIDDichvu.Text = dichVu.DichVuID1 + "";
                    txtTendichvu.Text = dichVu.TenDichVu1;
                    txtGiatien.Text = dichVu.GiaTien1 + "";
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
                ListViewItem item = lsvDanhSachDichVu.SelectedItems[0];
                CDichvu dichVu = new CDichvu();
                dichVu.DichVuID1 = int.Parse(item.SubItems[0].Text);
                int index = dsDichVu.IndexOf(dichVu);
                if (index < 0)
                {
                    return;
                }
                dichVu = dsDichVu[index];
                dichVu.TenDichVu1 = txtTendichvu.Text;
                dichVu.GiaTien1 = int.Parse(txtGiatien.Text);
                dichVu.DichVuID1 = int.Parse(txtIDDichvu.Text);
                if (ctrlDichVu.update(dichVu))
                {
                    item.SubItems[1].Text = dichVu.TenDichVu1;
                    item.SubItems[2].Text = dichVu.GiaTien1 + "";
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                    MessageBox.Show("Cập nhật thất bại!!!");
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ListViewItem item = lsvDanhSachDichVu.SelectedItems[0];
                    CDichvu dichVu = new CDichvu();
                    dichVu.DichVuID1 = int.Parse(item.SubItems[0].Text);
                    int index = dsDichVu.IndexOf(dichVu);
                    if (index < 0)
                    {
                        return;
                    }
                    dichVu = dsDichVu[index];
                    if (ctrlDichVu.delete(dichVu))
                    {
                        dsDichVu.Remove(dichVu);
                        lsvDanhSachDichVu.Items.Remove(item);
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
            catch
            {

            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtGiatien.Text = string.Empty;
            txtIDDichvu.Text = string.Empty;
            txtTendichvu.Text = string.Empty;
            txtTendichvu.Focus();
            txtIDDichvu.Select();
        }
    }
}
