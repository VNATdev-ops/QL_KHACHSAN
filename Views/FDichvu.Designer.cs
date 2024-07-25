namespace QL_KHACHSAN
{
    partial class FDichvu
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
            this.lsvDanhSachDichVu = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiatien = new System.Windows.Forms.TextBox();
            this.txtTendichvu = new System.Windows.Forms.TextBox();
            this.txtIDDichvu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvDanhSachDichVu
            // 
            this.lsvDanhSachDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDanhSachDichVu.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.lsvDanhSachDichVu.HideSelection = false;
            this.lsvDanhSachDichVu.Location = new System.Drawing.Point(2, 25);
            this.lsvDanhSachDichVu.Margin = new System.Windows.Forms.Padding(2);
            this.lsvDanhSachDichVu.Name = "lsvDanhSachDichVu";
            this.lsvDanhSachDichVu.Size = new System.Drawing.Size(873, 248);
            this.lsvDanhSachDichVu.TabIndex = 0;
            this.lsvDanhSachDichVu.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSachDichVu.SelectedIndexChanged += new System.EventHandler(this.lsvDanhSachDichVu_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDanhSachDichVu);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Location = new System.Drawing.Point(81, 316);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(877, 275);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách dịch vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label4.Location = new System.Drawing.Point(79, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label3.Location = new System.Drawing.Point(485, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên dịch vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label2.Location = new System.Drawing.Point(62, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Dịch vụ";
            // 
            // txtGiatien
            // 
            this.txtGiatien.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtGiatien.Location = new System.Drawing.Point(178, 158);
            this.txtGiatien.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiatien.Name = "txtGiatien";
            this.txtGiatien.Size = new System.Drawing.Size(218, 30);
            this.txtGiatien.TabIndex = 2;
            this.txtGiatien.TextChanged += new System.EventHandler(this.txtGiatien_TextChanged);
            // 
            // txtTendichvu
            // 
            this.txtTendichvu.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtTendichvu.Location = new System.Drawing.Point(614, 92);
            this.txtTendichvu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTendichvu.Name = "txtTendichvu";
            this.txtTendichvu.Size = new System.Drawing.Size(185, 30);
            this.txtTendichvu.TabIndex = 1;
            this.txtTendichvu.TextChanged += new System.EventHandler(this.txtTendichvu_TextChanged);
            // 
            // txtIDDichvu
            // 
            this.txtIDDichvu.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtIDDichvu.Location = new System.Drawing.Point(178, 89);
            this.txtIDDichvu.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDDichvu.Name = "txtIDDichvu";
            this.txtIDDichvu.Size = new System.Drawing.Size(218, 30);
            this.txtIDDichvu.TabIndex = 0;
            this.txtIDDichvu.TextChanged += new System.EventHandler(this.txtIDDichvu_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGiatien);
            this.groupBox1.Controls.Add(this.txtTendichvu);
            this.groupBox1.Controls.Add(this.txtIDDichvu);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(83, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(877, 266);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin dịch vụ";
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnNhapMoi.Location = new System.Drawing.Point(36, 152);
            this.btnNhapMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(165, 35);
            this.btnNhapMoi.TabIndex = 3;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnXoa.Location = new System.Drawing.Point(36, 84);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.btnThem.Location = new System.Drawing.Point(36, 17);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(165, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnNhapMoi);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.panel2.Location = new System.Drawing.Point(1080, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 317);
            this.panel2.TabIndex = 17;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Window;
            this.btnExit.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(36, 222);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 35);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.txtTimKiem);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.groupBox4.Location = new System.Drawing.Point(1080, 403);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(230, 130);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.txtTimKiem.Location = new System.Drawing.Point(8, 56);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(216, 30);
            this.txtTimKiem.TabIndex = 11;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label9.Location = new System.Drawing.Point(18, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tìm kiếm khách hàng";
            // 
            // FDichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1364, 628);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FDichvu";
            this.Text = "FDichvu";
            this.Load += new System.EventHandler(this.FDichvu_Load_2);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvDanhSachDichVu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiatien;
        private System.Windows.Forms.TextBox txtTendichvu;
        private System.Windows.Forms.TextBox txtIDDichvu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label9;
    }
}