using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using QL_KHACHSAN.Controller;


namespace QL_KHACHSAN.Views
{
    public partial class Fdashboard : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreaterRoundRectRgn")]
        private static extern IntPtr CreaterRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeighEllipse
        );
        public Fdashboard()
        {
            InitializeComponent();
            pnlNav.Height = btnPhong.Height;

            

        }

        private Form currentFormChild;
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                
            }
        }
        private void btnPhong_Click(object sender, EventArgs e)
        {
            btnPhong.BackColor = Color.FromArgb(46, 51, 73);
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

       

        private void Fdashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fdashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPhong_Leave(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPhong_Click_1(object sender, EventArgs e)
        {

            btnPhong.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new FPhong());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý phòng";
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            btnDatPhong.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new FDatPhong());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý đặt phòng";
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            btnKhachHang.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FKhachHang());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý phòng";
        }

        private void btnLichSuKhachHang_Click(object sender, EventArgs e)
        {
            btnLichSuKhachHang.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FLichSu());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch sử khách hàng";
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            btnDichVu.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FDichvu());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch sử khách hàng";
            //OpenChildForm(new FKhachHang());
            //Tittle.Visible = true;
            //Tittle.Text = "Quản lý phòng";
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            btnDatDichVu.BackColor = Color.FromArgb(46, 51, 73);
            OpenChildForm(new FDatdichvu());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch sử khách hàng";
            ////OpenChildForm(new ());
            ////Tittle.Visible = true;
            ////Tittle.Text = "Quản lý phòng";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            btnNhanVien.BackColor = Color.FromArgb(46, 51, 73);


            OpenChildForm(new FNhanVien());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý nhân viên";
        }

        private void btnLichLamViec_Click(object sender, EventArgs e)
        {
            btnLichLamViec.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FLichLamViec());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý phòng";
        }

        private void btnLichBaoTri_Click(object sender, EventArgs e)
        {
            btnLichBaoTri.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FLichBaoTri());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý lịch bảo trì";
        }

        private void btnBaoCaoSuCo_Click(object sender, EventArgs e)
        {
            btnBaoCaoSuCo.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FBaoCaoSuCo());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý báo cáo sự cố";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(46, 51, 73);

            OpenChildForm(new FHoaDon());
            Tittle.Visible = true;
            Tittle.Text = "Quản lý phòng";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPhong_Leave_1(object sender, EventArgs e)
        {
            btnPhong.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnPhong_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btnDatPhong_Leave(object sender, EventArgs e)
        {
            btnDatPhong.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnKhachHang_Leave(object sender, EventArgs e)
        {
            btnKhachHang.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnLichSuKhachHang_Leave(object sender, EventArgs e)
        {
            btnLichSuKhachHang.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnDichVu_Leave(object sender, EventArgs e)
        {
            btnDichVu.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnDatDichVu_Leave(object sender, EventArgs e)
        {
            btnDatDichVu.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnNhanVien_Leave(object sender, EventArgs e)
        {
            btnNhanVien.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnLichLamViec_Leave(object sender, EventArgs e)
        {
            btnLichLamViec.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnLichBaoTri_Leave(object sender, EventArgs e)
        {
            btnLichBaoTri.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnBaoCaoSuCo_Leave(object sender, EventArgs e)
        {
            btnBaoCaoSuCo.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnHoaDon_Leave(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(24, 30, 54);

        }
    }
}
