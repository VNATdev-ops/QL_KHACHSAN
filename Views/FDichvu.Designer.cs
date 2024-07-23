namespace QL_KHACHSAN.Views
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
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvDanhSachDichVu
            // 
            this.lsvDanhSachDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDanhSachDichVu.HideSelection = false;
            this.lsvDanhSachDichVu.Location = new System.Drawing.Point(2, 23);
            this.lsvDanhSachDichVu.Margin = new System.Windows.Forms.Padding(2);
            this.lsvDanhSachDichVu.Name = "lsvDanhSachDichVu";
            this.lsvDanhSachDichVu.Size = new System.Drawing.Size(873, 240);
            this.lsvDanhSachDichVu.TabIndex = 0;
            this.lsvDanhSachDichVu.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDanhSachDichVu);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 279);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(877, 265);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách dịch vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá tiền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên dịch vụ : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Dịch vụ:";
            // 
            // txtGiatien
            // 
            this.txtGiatien.Location = new System.Drawing.Point(166, 131);
            this.txtGiatien.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiatien.Name = "txtGiatien";
            this.txtGiatien.Size = new System.Drawing.Size(185, 28);
            this.txtGiatien.TabIndex = 2;
            // 
            // txtTendichvu
            // 
            this.txtTendichvu.Location = new System.Drawing.Point(563, 63);
            this.txtTendichvu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTendichvu.Name = "txtTendichvu";
            this.txtTendichvu.Size = new System.Drawing.Size(185, 28);
            this.txtTendichvu.TabIndex = 1;
            // 
            // txtIDDichvu
            // 
            this.txtIDDichvu.Location = new System.Drawing.Point(166, 62);
            this.txtIDDichvu.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDDichvu.Name = "txtIDDichvu";
            this.txtIDDichvu.Size = new System.Drawing.Size(185, 28);
            this.txtIDDichvu.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGiatien);
            this.groupBox1.Controls.Add(this.txtTendichvu);
            this.groupBox1.Controls.Add(this.txtIDDichvu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(877, 198);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin dịch vụ";
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(32, 163);
            this.btnNhapMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(165, 35);
            this.btnNhapMoi.TabIndex = 3;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(32, 112);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(165, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(32, 61);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(165, 35);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(32, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(165, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnNhapMoi);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnCapNhat);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(890, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 531);
            this.panel2.TabIndex = 17;
            // 
            // FDichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FDichvu";
            this.Text = "FDichvu";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel2;
    }
}