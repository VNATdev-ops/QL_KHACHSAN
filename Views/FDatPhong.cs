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
        public FDatPhong()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FDatPhong_Load(object sender, EventArgs e)
        {
            //InitializeComponent();

            //int width = lsvDatPhong.Width;
            //lsvDatPhong.Columns.Add("Mã đặt phòng", 100);
            //lsvDatPhong.Columns.Add("Mã phòng", 100);
            //lsvDatPhong.Columns.Add("Ngày đặt", 150);
            //lsvDatPhong.Columns.Add("Ngày nhận", 150);
            //lsvDatPhong.Columns.Add("Ngày trả", 150);
            //lsvDatPhong.Columns.Add("Mã khách hàng", 100);
            //lsvDatPhong.Columns.Add("Tình trạng", 100);

            //lsvDatPhong.View = View.Details;
            //lsvDatPhong.FullRowSelect = true;

            InitializeListView();
            LoadData();
        }

        private void InitializeListView()
        {
            lsvDatPhong.View = View.Details;
            lsvDatPhong.Columns.Add("DatPhongID", 100);
            lsvDatPhong.Columns.Add("PhongID", 100);
            lsvDatPhong.Columns.Add("KhachHangID", 100);
            lsvDatPhong.Columns.Add("NgayDat", 150);
            lsvDatPhong.Columns.Add("NgayNhan", 150);
            lsvDatPhong.Columns.Add("NgayTra", 150);
            lsvDatPhong.Columns.Add("TinhTrang", 100);
        }

        private void LoadData()
        {
            lsvDatPhong.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source = DESKTOP-45GKJAU\\SQLEXPRESS; " +
                   "Initial Catalog = QL_KHACH_SAN ; Integrated Security = true"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DatPhong", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["DatPhongID"].ToString());
                    item.SubItems.Add(reader["PhongID"].ToString());
                    item.SubItems.Add(reader["KhachHangID"].ToString());
                    item.SubItems.Add(reader["NgayDat"].ToString());
                    item.SubItems.Add(reader["NgayNhan"].ToString());
                    item.SubItems.Add(reader["NgayTra"].ToString());
                    item.SubItems.Add(reader["TinhTrang"].ToString());
                    lsvDatPhong.Items.Add(item);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
