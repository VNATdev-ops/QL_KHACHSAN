﻿namespace QL_KHACHSAN.Views
{
    partial class FLichLamViec
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaLam = new System.Windows.Forms.TextBox();
            this.txtIDNhanVien = new System.Windows.Forms.TextBox();
            this.txtIDlichlamviec = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvDsLichLamViec = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTongSo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnNhapMoi);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnCapNhat);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.panel2.Location = new System.Drawing.Point(1255, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 326);
            this.panel2.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Window;
            this.btnExit.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnExit.Location = new System.Drawing.Point(43, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(220, 43);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.BackColor = System.Drawing.SystemColors.Window;
            this.btnNhapMoi.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnNhapMoi.Location = new System.Drawing.Point(43, 201);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(220, 43);
            this.btnNhapMoi.TabIndex = 3;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = false;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.Window;
            this.btnXoa.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnXoa.Location = new System.Drawing.Point(43, 138);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(220, 43);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.SystemColors.Window;
            this.btnCapNhat.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnCapNhat.Location = new System.Drawing.Point(43, 75);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(220, 43);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Window;
            this.btnThem.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnThem.Location = new System.Drawing.Point(43, 13);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(220, 43);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.groupBox1.Controls.Add(this.dtpNgayLam);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCaLam);
            this.groupBox1.Controls.Add(this.txtIDNhanVien);
            this.groupBox1.Controls.Add(this.txtIDlichlamviec);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1169, 326);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lịch làm việc";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLam.Location = new System.Drawing.Point(274, 207);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size = new System.Drawing.Size(329, 35);
            this.dtpNgayLam.TabIndex = 8;
            this.dtpNgayLam.ValueChanged += new System.EventHandler(this.dtpNgayLam_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label5.Location = new System.Drawing.Point(732, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ca làm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label4.Location = new System.Drawing.Point(79, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày làm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label3.Location = new System.Drawing.Point(732, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label2.Location = new System.Drawing.Point(79, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Lịch làm việc";
            // 
            // txtCaLam
            // 
            this.txtCaLam.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtCaLam.Location = new System.Drawing.Point(906, 204);
            this.txtCaLam.Name = "txtCaLam";
            this.txtCaLam.Size = new System.Drawing.Size(176, 35);
            this.txtCaLam.TabIndex = 3;
            this.txtCaLam.TextChanged += new System.EventHandler(this.txtCaLam_TextChanged);
            // 
            // txtIDNhanVien
            // 
            this.txtIDNhanVien.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtIDNhanVien.Location = new System.Drawing.Point(906, 115);
            this.txtIDNhanVien.Name = "txtIDNhanVien";
            this.txtIDNhanVien.Size = new System.Drawing.Size(176, 35);
            this.txtIDNhanVien.TabIndex = 1;
            this.txtIDNhanVien.TextChanged += new System.EventHandler(this.txtIDNhanVien_TextChanged);
            // 
            // txtIDlichlamviec
            // 
            this.txtIDlichlamviec.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtIDlichlamviec.Location = new System.Drawing.Point(274, 113);
            this.txtIDlichlamviec.Name = "txtIDlichlamviec";
            this.txtIDlichlamviec.Size = new System.Drawing.Size(329, 35);
            this.txtIDlichlamviec.TabIndex = 0;
            this.txtIDlichlamviec.TextChanged += new System.EventHandler(this.txtIDlichlamviec_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDsLichLamViec);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Location = new System.Drawing.Point(12, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1169, 326);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách lịch làm việc";
            // 
            // lsvDsLichLamViec
            // 
            this.lsvDsLichLamViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDsLichLamViec.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.lsvDsLichLamViec.HideSelection = false;
            this.lsvDsLichLamViec.Location = new System.Drawing.Point(3, 31);
            this.lsvDsLichLamViec.Name = "lsvDsLichLamViec";
            this.lsvDsLichLamViec.Size = new System.Drawing.Size(1163, 292);
            this.lsvDsLichLamViec.TabIndex = 0;
            this.lsvDsLichLamViec.UseCompatibleStateImageBehavior = false;
            this.lsvDsLichLamViec.SelectedIndexChanged += new System.EventHandler(this.lsvDsLichLamViec_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtTongSo);
            this.groupBox3.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox3.Location = new System.Drawing.Point(1255, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 135);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống kê";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label7.Location = new System.Drawing.Point(92, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 28);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tổng số ";
            // 
            // txtTongSo
            // 
            this.txtTongSo.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtTongSo.Location = new System.Drawing.Point(10, 77);
            this.txtTongSo.Name = "txtTongSo";
            this.txtTongSo.Size = new System.Drawing.Size(287, 36);
            this.txtTongSo.TabIndex = 0;
            this.txtTongSo.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtTimKiem);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox4.Location = new System.Drawing.Point(1255, 574);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 142);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label1.Location = new System.Drawing.Point(52, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tìm kiếm nhân viên";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtTimKiem.Location = new System.Drawing.Point(10, 87);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(287, 35);
            this.txtTimKiem.TabIndex = 11;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // FLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1819, 773);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FLichLamViec";
            this.Text = "FLichLamViec";
            this.Load += new System.EventHandler(this.FLichLamViec_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button txtTongSo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtCaLam;
        private System.Windows.Forms.TextBox txtIDNhanVien;
        private System.Windows.Forms.TextBox txtIDlichlamviec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvDsLichLamViec;
        private System.Windows.Forms.DateTimePicker dtpNgayLam;
    }
}