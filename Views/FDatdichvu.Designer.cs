namespace QL_KHACHSAN
{
    partial class FDatdichvu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTongSo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvDSDVDaDat = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPhong = new System.Windows.Forms.ComboBox();
            this.cmbDV = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpTimeDV = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.IDDatDichVu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDDatDichVu = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtTongSo);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(888, 413);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(230, 131);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống kê";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tổng số ";
            // 
            // txtTongSo
            // 
            this.txtTongSo.Location = new System.Drawing.Point(4, 63);
            this.txtTongSo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTongSo.Name = "txtTongSo";
            this.txtTongSo.Size = new System.Drawing.Size(215, 29);
            this.txtTongSo.TabIndex = 0;
            this.txtTongSo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDSDVDaDat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 224);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(877, 203);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách dịch vụ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lsvDSDVDaDat
            // 
            this.lsvDSDVDaDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDSDVDaDat.HideSelection = false;
            this.lsvDSDVDaDat.Location = new System.Drawing.Point(2, 23);
            this.lsvDSDVDaDat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsvDSDVDaDat.Name = "lsvDSDVDaDat";
            this.lsvDSDVDaDat.Size = new System.Drawing.Size(873, 178);
            this.lsvDSDVDaDat.TabIndex = 0;
            this.lsvDSDVDaDat.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPhong);
            this.groupBox1.Controls.Add(this.cmbDV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpTimeDV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.IDDatDichVu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDDatDichVu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(877, 198);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin dịch vụ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbPhong
            // 
            this.cmbPhong.FormattingEnabled = true;
            this.cmbPhong.Location = new System.Drawing.Point(562, 131);
            this.cmbPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(229, 30);
            this.cmbPhong.TabIndex = 16;
            // 
            // cmbDV
            // 
            this.cmbDV.FormattingEnabled = true;
            this.cmbDV.Location = new System.Drawing.Point(118, 63);
            this.cmbDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDV.Name = "cmbDV";
            this.cmbDV.Size = new System.Drawing.Size(229, 30);
            this.cmbDV.TabIndex = 15;
            this.cmbDV.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ngày :";
            // 
            // dtpTimeDV
            // 
            this.dtpTimeDV.Location = new System.Drawing.Point(138, 126);
            this.dtpTimeDV.Name = "dtpTimeDV";
            this.dtpTimeDV.Size = new System.Drawing.Size(222, 28);
            this.dtpTimeDV.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "ID phòng : ";
            // 
            // IDDatDichVu
            // 
            this.IDDatDichVu.AutoSize = true;
            this.IDDatDichVu.Location = new System.Drawing.Point(421, 65);
            this.IDDatDichVu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IDDatDichVu.Name = "IDDatDichVu";
            this.IDDatDichVu.Size = new System.Drawing.Size(131, 24);
            this.IDDatDichVu.TabIndex = 5;
            this.IDDatDichVu.Text = "ID Đặt Dịch Vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Dịch vụ:";
            // 
            // txtIDDatDichVu
            // 
            this.txtIDDatDichVu.Location = new System.Drawing.Point(569, 61);
            this.txtIDDatDichVu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIDDatDichVu.Name = "txtIDDatDichVu";
            this.txtIDDatDichVu.Size = new System.Drawing.Size(185, 28);
            this.txtIDDatDichVu.TabIndex = 1;
            this.txtIDDatDichVu.TextChanged += new System.EventHandler(this.txtIDDatDichVu_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnNhapMoi);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(890, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 400);
            this.panel2.TabIndex = 18;
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(32, 119);
            this.btnNhapMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(165, 35);
            this.btnNhapMoi.TabIndex = 3;
            this.btnNhapMoi.Text = "Nhập Mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(32, 60);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(32, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(165, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FDatdichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FDatdichvu";
            this.Text = "Datdichvu";
            this.Load += new System.EventHandler(this.FDatdichvu_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button txtTongSo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label IDDatDichVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDDatDichVu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTimeDV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lsvDSDVDaDat;
        private System.Windows.Forms.ComboBox cmbDV;
        private System.Windows.Forms.ComboBox cmbPhong;
        private System.Windows.Forms.Button btnNhapMoi;
    }
}