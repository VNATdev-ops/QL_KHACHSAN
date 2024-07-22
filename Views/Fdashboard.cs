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
    public partial class Fdashboard : Form
    {
        public Fdashboard()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private void btnPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FPhong());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý phòng";

        }

        private void OpenChildForm(Form childFrom)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;

            splitContainer_Body.Controls.Add(childFrom);
            splitContainer_Body.Tag = childFrom;
            childFrom.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fdashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FDatPhong());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý đặt phòng";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FNhanVien());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý nhân viên";
        }

        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FLichLamViec());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch làm việc";
        }

        private void btnBaoCaoSuCo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FBaoCaoSuCo());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch làm việc";
        }

        private void btnLichSuBaoTri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FLichBaoTri());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch làm việc";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FHoaDon());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch làm việc";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FDichvu());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý Dịch vụ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FDatdichvu());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý Dịch vụ";
        }
    }
}
