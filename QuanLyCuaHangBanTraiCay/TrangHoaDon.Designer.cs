namespace QuanLyCuaHangBanTraiCay
{
    partial class TrangHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangHoaDon));
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_MaKH = new System.Windows.Forms.TextBox();
            this.txt_MaHD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grb_ThanhToan = new System.Windows.Forms.GroupBox();
            this.cbo_MaNV = new System.Windows.Forms.ComboBox();
            this.btn_QuayLai = new System.Windows.Forms.Button();
            this.btn_XemChiTiet = new System.Windows.Forms.Button();
            this.btn_TaoHoaDon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_XemKhachHang = new System.Windows.Forms.Button();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.cbo_Tim = new System.Windows.Forms.ComboBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dt_Ngay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            this.grb_ThanhToan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDon.Location = new System.Drawing.Point(6, 121);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.RowHeadersWidth = 51;
            this.dgv_HoaDon.RowTemplate.Height = 24;
            this.dgv_HoaDon.Size = new System.Drawing.Size(615, 289);
            this.dgv_HoaDon.TabIndex = 10;
            this.dgv_HoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HoaDon_CellContentClick);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(118, 21);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(245, 22);
            this.txt_TimKiem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm:";
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Location = new System.Drawing.Point(177, 179);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.Size = new System.Drawing.Size(304, 30);
            this.txt_MaKH.TabIndex = 11;
            // 
            // txt_MaHD
            // 
            this.txt_MaHD.Location = new System.Drawing.Point(177, 43);
            this.txt_MaHD.Name = "txt_MaHD";
            this.txt_MaHD.ReadOnly = true;
            this.txt_MaHD.Size = new System.Drawing.Size(304, 30);
            this.txt_MaHD.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ngày Lập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã Khách Hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã Nhân Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Hóa Đơn";
            // 
            // grb_ThanhToan
            // 
            this.grb_ThanhToan.Controls.Add(this.dt_Ngay);
            this.grb_ThanhToan.Controls.Add(this.cbo_MaNV);
            this.grb_ThanhToan.Controls.Add(this.btn_QuayLai);
            this.grb_ThanhToan.Controls.Add(this.btn_XemChiTiet);
            this.grb_ThanhToan.Controls.Add(this.txt_MaKH);
            this.grb_ThanhToan.Controls.Add(this.txt_MaHD);
            this.grb_ThanhToan.Controls.Add(this.label6);
            this.grb_ThanhToan.Controls.Add(this.btn_TaoHoaDon);
            this.grb_ThanhToan.Controls.Add(this.label5);
            this.grb_ThanhToan.Controls.Add(this.label4);
            this.grb_ThanhToan.Controls.Add(this.label3);
            this.grb_ThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_ThanhToan.Location = new System.Drawing.Point(643, 12);
            this.grb_ThanhToan.Name = "grb_ThanhToan";
            this.grb_ThanhToan.Size = new System.Drawing.Size(560, 444);
            this.grb_ThanhToan.TabIndex = 2;
            this.grb_ThanhToan.TabStop = false;
            // 
            // cbo_MaNV
            // 
            this.cbo_MaNV.FormattingEnabled = true;
            this.cbo_MaNV.Location = new System.Drawing.Point(177, 108);
            this.cbo_MaNV.Name = "cbo_MaNV";
            this.cbo_MaNV.Size = new System.Drawing.Size(304, 31);
            this.cbo_MaNV.TabIndex = 32;
            // 
            // btn_QuayLai
            // 
            this.btn_QuayLai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuayLai.Image = ((System.Drawing.Image)(resources.GetObject("btn_QuayLai.Image")));
            this.btn_QuayLai.Location = new System.Drawing.Point(406, 354);
            this.btn_QuayLai.Name = "btn_QuayLai";
            this.btn_QuayLai.Size = new System.Drawing.Size(148, 47);
            this.btn_QuayLai.TabIndex = 31;
            this.btn_QuayLai.Text = "Quay Lại";
            this.btn_QuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_QuayLai.UseVisualStyleBackColor = true;
            // 
            // btn_XemChiTiet
            // 
            this.btn_XemChiTiet.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.list__1_;
            this.btn_XemChiTiet.Location = new System.Drawing.Point(215, 354);
            this.btn_XemChiTiet.Name = "btn_XemChiTiet";
            this.btn_XemChiTiet.Size = new System.Drawing.Size(171, 45);
            this.btn_XemChiTiet.TabIndex = 14;
            this.btn_XemChiTiet.Text = "Xem Chi Tiết";
            this.btn_XemChiTiet.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_XemChiTiet.UseVisualStyleBackColor = true;
            this.btn_XemChiTiet.Click += new System.EventHandler(this.btn_XemChiTiet_Click);
            // 
            // btn_TaoHoaDon
            // 
            this.btn_TaoHoaDon.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.counting;
            this.btn_TaoHoaDon.Location = new System.Drawing.Point(13, 354);
            this.btn_TaoHoaDon.Name = "btn_TaoHoaDon";
            this.btn_TaoHoaDon.Size = new System.Drawing.Size(170, 45);
            this.btn_TaoHoaDon.TabIndex = 9;
            this.btn_TaoHoaDon.Text = "Tạo Hóa Đơn";
            this.btn_TaoHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_TaoHoaDon.UseVisualStyleBackColor = true;
            this.btn_TaoHoaDon.Click += new System.EventHandler(this.btn_TaoHoaDon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Reset);
            this.groupBox1.Controls.Add(this.btn_Sua);
            this.groupBox1.Controls.Add(this.btn_XemKhachHang);
            this.groupBox1.Controls.Add(this.btn_Tim);
            this.groupBox1.Controls.Add(this.cbo_Tim);
            this.groupBox1.Controls.Add(this.btn_Xoa);
            this.groupBox1.Controls.Add(this.dgv_HoaDon);
            this.groupBox1.Controls.Add(this.txt_TimKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 494);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reset.Image")));
            this.btn_Reset.Location = new System.Drawing.Point(468, 441);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(144, 44);
            this.btn_Reset.TabIndex = 30;
            this.btn_Reset.Text = "Làm mới";
            this.btn_Reset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.Location = new System.Drawing.Point(16, 441);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(108, 47);
            this.btn_Sua.TabIndex = 29;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_XemKhachHang
            // 
            this.btn_XemKhachHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btn_XemKhachHang.Image")));
            this.btn_XemKhachHang.Location = new System.Drawing.Point(468, 67);
            this.btn_XemKhachHang.Name = "btn_XemKhachHang";
            this.btn_XemKhachHang.Size = new System.Drawing.Size(144, 45);
            this.btn_XemKhachHang.TabIndex = 13;
            this.btn_XemKhachHang.Text = "Khách Hàng";
            this.btn_XemKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_XemKhachHang.UseVisualStyleBackColor = true;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tim.Image")));
            this.btn_Tim.Location = new System.Drawing.Point(16, 67);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(144, 45);
            this.btn_Tim.TabIndex = 12;
            this.btn_Tim.Text = "Tìm Kiếm";
            this.btn_Tim.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // cbo_Tim
            // 
            this.cbo_Tim.FormattingEnabled = true;
            this.cbo_Tim.Location = new System.Drawing.Point(385, 21);
            this.cbo_Tim.Name = "cbo_Tim";
            this.cbo_Tim.Size = new System.Drawing.Size(128, 23);
            this.cbo_Tim.TabIndex = 11;
            this.cbo_Tim.SelectedIndexChanged += new System.EventHandler(this.cbo_Tim_SelectedIndexChanged);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.xoa;
            this.btn_Xoa.Location = new System.Drawing.Point(155, 441);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(115, 48);
            this.btn_Xoa.TabIndex = 8;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHangBanTraiCay.Properties.Resources.tải_xuống__3__jpg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1165, 496);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 78);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // dt_Ngay
            // 
            this.dt_Ngay.Location = new System.Drawing.Point(177, 245);
            this.dt_Ngay.Name = "dt_Ngay";
            this.dt_Ngay.Size = new System.Drawing.Size(304, 30);
            this.dt_Ngay.TabIndex = 33;
            // 
            // TrangHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1244, 576);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grb_ThanhToan);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TrangHoaDon";
            this.Text = "Hóa Đơn Bán Hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrangHoaDon_FormClosing);
            this.Load += new System.EventHandler(this.TrangHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            this.grb_ThanhToan.ResumeLayout(false);
            this.grb_ThanhToan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaKH;
        private System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.Button btn_TaoHoaDon;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.Button btn_XemChiTiet;
        private System.Windows.Forms.GroupBox grb_ThanhToan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbo_Tim;
        private System.Windows.Forms.Button btn_XemKhachHang;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_QuayLai;
        private System.Windows.Forms.ComboBox cbo_MaNV;
        private System.Windows.Forms.DateTimePicker dt_Ngay;
    }
}