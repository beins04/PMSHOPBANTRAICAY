namespace QuanLyCuaHangBanTraiCay
{
    partial class PhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuNhap));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MaSPN = new System.Windows.Forms.TextBox();
            this.chk_TrangThai = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_TimKiem = new System.Windows.Forms.ComboBox();
            this.txt_ThanhTien = new System.Windows.Forms.TextBox();
            this.btn_TimSP = new System.Windows.Forms.Button();
            this.txt_TimKiemSP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_XemChiTietPhieuNhap = new System.Windows.Forms.Button();
            this.cbo_TenNCC = new System.Windows.Forms.ComboBox();
            this.dt_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SLN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgv_PhieuNhap = new System.Windows.Forms.DataGridView();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_ThemPN = new System.Windows.Forms.Button();
            this.btn_SuaPN = new System.Windows.Forms.Button();
            this.btn_XoaPN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_MaSPN);
            this.groupBox1.Controls.Add(this.chk_TrangThai);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_TimKiem);
            this.groupBox1.Controls.Add(this.txt_ThanhTien);
            this.groupBox1.Controls.Add(this.btn_TimSP);
            this.groupBox1.Controls.Add(this.txt_TimKiemSP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_XemChiTietPhieuNhap);
            this.groupBox1.Controls.Add(this.cbo_TenNCC);
            this.groupBox1.Controls.Add(this.dt_NgayNhap);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_SLN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Sản Phẩm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 23);
            this.label7.TabIndex = 32;
            this.label7.Text = "Mã Sản Phẩm Nhập:";
            // 
            // txt_MaSPN
            // 
            this.txt_MaSPN.Location = new System.Drawing.Point(254, 39);
            this.txt_MaSPN.Name = "txt_MaSPN";
            this.txt_MaSPN.ReadOnly = true;
            this.txt_MaSPN.Size = new System.Drawing.Size(317, 30);
            this.txt_MaSPN.TabIndex = 31;
            // 
            // chk_TrangThai
            // 
            this.chk_TrangThai.AutoSize = true;
            this.chk_TrangThai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_TrangThai.Location = new System.Drawing.Point(793, 135);
            this.chk_TrangThai.Name = "chk_TrangThai";
            this.chk_TrangThai.Size = new System.Drawing.Size(18, 17);
            this.chk_TrangThai.TabIndex = 29;
            this.chk_TrangThai.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Trạng Thái:";
            // 
            // cbo_TimKiem
            // 
            this.cbo_TimKiem.FormattingEnabled = true;
            this.cbo_TimKiem.Items.AddRange(new object[] {
            "MaSP",
            "TenSP",
            "MaNCC",
            "MaLSP",
            "XuatXu",
            ""});
            this.cbo_TimKiem.Location = new System.Drawing.Point(427, 244);
            this.cbo_TimKiem.Name = "cbo_TimKiem";
            this.cbo_TimKiem.Size = new System.Drawing.Size(169, 31);
            this.cbo_TimKiem.TabIndex = 23;
            // 
            // txt_ThanhTien
            // 
            this.txt_ThanhTien.Location = new System.Drawing.Point(793, 84);
            this.txt_ThanhTien.Name = "txt_ThanhTien";
            this.txt_ThanhTien.Size = new System.Drawing.Size(313, 30);
            this.txt_ThanhTien.TabIndex = 23;
            // 
            // btn_TimSP
            // 
            this.btn_TimSP.Image = ((System.Drawing.Image)(resources.GetObject("btn_TimSP.Image")));
            this.btn_TimSP.Location = new System.Drawing.Point(659, 231);
            this.btn_TimSP.Name = "btn_TimSP";
            this.btn_TimSP.Size = new System.Drawing.Size(149, 49);
            this.btn_TimSP.TabIndex = 22;
            this.btn_TimSP.Text = "Tìm Kiếm";
            this.btn_TimSP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_TimSP.UseVisualStyleBackColor = true;
            // 
            // txt_TimKiemSP
            // 
            this.txt_TimKiemSP.Location = new System.Drawing.Point(79, 245);
            this.txt_TimKiemSP.Name = "txt_TimKiemSP";
            this.txt_TimKiemSP.Size = new System.Drawing.Size(326, 30);
            this.txt_TimKiemSP.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(626, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "Tổng Thành Tiền:";
            // 
            // btn_XemChiTietPhieuNhap
            // 
            this.btn_XemChiTietPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemChiTietPhieuNhap.Image = ((System.Drawing.Image)(resources.GetObject("btn_XemChiTietPhieuNhap.Image")));
            this.btn_XemChiTietPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XemChiTietPhieuNhap.Location = new System.Drawing.Point(871, 231);
            this.btn_XemChiTietPhieuNhap.Name = "btn_XemChiTietPhieuNhap";
            this.btn_XemChiTietPhieuNhap.Size = new System.Drawing.Size(219, 48);
            this.btn_XemChiTietPhieuNhap.TabIndex = 8;
            this.btn_XemChiTietPhieuNhap.Text = "Xem Chi Tiết";
            this.btn_XemChiTietPhieuNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_XemChiTietPhieuNhap.UseVisualStyleBackColor = true;
            this.btn_XemChiTietPhieuNhap.Click += new System.EventHandler(this.btn_XemChiTietPhieuNhap_Click);
            // 
            // cbo_TenNCC
            // 
            this.cbo_TenNCC.FormattingEnabled = true;
            this.cbo_TenNCC.Location = new System.Drawing.Point(254, 84);
            this.cbo_TenNCC.Name = "cbo_TenNCC";
            this.cbo_TenNCC.Size = new System.Drawing.Size(317, 31);
            this.cbo_TenNCC.TabIndex = 21;
            // 
            // dt_NgayNhap
            // 
            this.dt_NgayNhap.Location = new System.Drawing.Point(254, 135);
            this.dt_NgayNhap.Name = "dt_NgayNhap";
            this.dt_NgayNhap.Size = new System.Drawing.Size(317, 30);
            this.dt_NgayNhap.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày Nhập:";
            // 
            // txt_SLN
            // 
            this.txt_SLN.Location = new System.Drawing.Point(793, 39);
            this.txt_SLN.Name = "txt_SLN";
            this.txt_SLN.Size = new System.Drawing.Size(313, 30);
            this.txt_SLN.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng Số Lượng Nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Nhà Cung Cấp:";
            // 
            // dgv_PhieuNhap
            // 
            this.dgv_PhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PhieuNhap.Location = new System.Drawing.Point(60, 298);
            this.dgv_PhieuNhap.Name = "dgv_PhieuNhap";
            this.dgv_PhieuNhap.RowHeadersWidth = 51;
            this.dgv_PhieuNhap.RowTemplate.Height = 24;
            this.dgv_PhieuNhap.Size = new System.Drawing.Size(990, 317);
            this.dgv_PhieuNhap.TabIndex = 19;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.reset;
            this.btn_Reset.Location = new System.Drawing.Point(1080, 525);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(136, 50);
            this.btn_Reset.TabIndex = 27;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Reset.UseVisualStyleBackColor = true;
            // 
            // btn_ThemPN
            // 
            this.btn_ThemPN.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemPN.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.them;
            this.btn_ThemPN.Location = new System.Drawing.Point(1080, 320);
            this.btn_ThemPN.Name = "btn_ThemPN";
            this.btn_ThemPN.Size = new System.Drawing.Size(136, 50);
            this.btn_ThemPN.TabIndex = 26;
            this.btn_ThemPN.Text = "Thêm";
            this.btn_ThemPN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_ThemPN.UseVisualStyleBackColor = true;
            this.btn_ThemPN.Click += new System.EventHandler(this.btn_ThemPN_Click);
            // 
            // btn_SuaPN
            // 
            this.btn_SuaPN.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SuaPN.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.suaall;
            this.btn_SuaPN.Location = new System.Drawing.Point(1080, 456);
            this.btn_SuaPN.Name = "btn_SuaPN";
            this.btn_SuaPN.Size = new System.Drawing.Size(136, 50);
            this.btn_SuaPN.TabIndex = 25;
            this.btn_SuaPN.Text = "Sửa";
            this.btn_SuaPN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_SuaPN.UseVisualStyleBackColor = true;
            this.btn_SuaPN.Click += new System.EventHandler(this.btn_SuaPN_Click);
            // 
            // btn_XoaPN
            // 
            this.btn_XoaPN.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaPN.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.xoa;
            this.btn_XoaPN.Location = new System.Drawing.Point(1080, 387);
            this.btn_XoaPN.Name = "btn_XoaPN";
            this.btn_XoaPN.Size = new System.Drawing.Size(136, 50);
            this.btn_XoaPN.TabIndex = 24;
            this.btn_XoaPN.Text = "Xóa";
            this.btn_XoaPN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_XoaPN.UseVisualStyleBackColor = true;
            this.btn_XoaPN.Click += new System.EventHandler(this.btn_XoaPN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHangBanTraiCay.Properties.Resources.tải_xuống__3__jpg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1262, 537);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 78);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1341, 627);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_ThemPN);
            this.Controls.Add(this.btn_SuaPN);
            this.Controls.Add(this.btn_XoaPN);
            this.Controls.Add(this.dgv_PhieuNhap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhieuNhap";
            this.Text = "PhieuNhap";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_XemChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txt_SLN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbo_TenNCC;
        private System.Windows.Forms.DataGridView dgv_PhieuNhap;
        private System.Windows.Forms.DateTimePicker dt_NgayNhap;
        private System.Windows.Forms.TextBox txt_ThanhTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_TimKiem;
        private System.Windows.Forms.Button btn_TimSP;
        private System.Windows.Forms.TextBox txt_TimKiemSP;
        private System.Windows.Forms.Button btn_SuaPN;
        private System.Windows.Forms.Button btn_XoaPN;
        private System.Windows.Forms.Button btn_ThemPN;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.CheckBox chk_TrangThai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MaSPN;
    }
}