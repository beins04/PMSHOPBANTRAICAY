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
            this.txt_MaSPN = new System.Windows.Forms.TextBox();
            this.btn_ThemChiTietPhieuNhap = new System.Windows.Forms.Button();
            this.btn_XemChiTietPhieuNhap = new System.Windows.Forms.Button();
            this.txt_SLN = new System.Windows.Forms.TextBox();
            this.txt_TenSPN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbo_TenNCC = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_TenNCC);
            this.groupBox1.Controls.Add(this.txt_MaSPN);
            this.groupBox1.Controls.Add(this.btn_ThemChiTietPhieuNhap);
            this.groupBox1.Controls.Add(this.btn_XemChiTietPhieuNhap);
            this.groupBox1.Controls.Add(this.txt_SLN);
            this.groupBox1.Controls.Add(this.txt_TenSPN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Sản Phẩm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt_MaSPN
            // 
            this.txt_MaSPN.Location = new System.Drawing.Point(254, 46);
            this.txt_MaSPN.Name = "txt_MaSPN";
            this.txt_MaSPN.Size = new System.Drawing.Size(286, 30);
            this.txt_MaSPN.TabIndex = 20;
            // 
            // btn_ThemChiTietPhieuNhap
            // 
            this.btn_ThemChiTietPhieuNhap.Image = global::QuanLyCuaHangBanTraiCay.Properties.Resources.them1;
            this.btn_ThemChiTietPhieuNhap.Location = new System.Drawing.Point(172, 274);
            this.btn_ThemChiTietPhieuNhap.Name = "btn_ThemChiTietPhieuNhap";
            this.btn_ThemChiTietPhieuNhap.Size = new System.Drawing.Size(138, 44);
            this.btn_ThemChiTietPhieuNhap.TabIndex = 10;
            this.btn_ThemChiTietPhieuNhap.Text = "Thêm";
            this.btn_ThemChiTietPhieuNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_ThemChiTietPhieuNhap.UseVisualStyleBackColor = true;
            this.btn_ThemChiTietPhieuNhap.Click += new System.EventHandler(this.btn_ThemChiTietPhieuNhap_Click);
            // 
            // btn_XemChiTietPhieuNhap
            // 
            this.btn_XemChiTietPhieuNhap.Image = ((System.Drawing.Image)(resources.GetObject("btn_XemChiTietPhieuNhap.Image")));
            this.btn_XemChiTietPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XemChiTietPhieuNhap.Location = new System.Drawing.Point(392, 274);
            this.btn_XemChiTietPhieuNhap.Name = "btn_XemChiTietPhieuNhap";
            this.btn_XemChiTietPhieuNhap.Size = new System.Drawing.Size(167, 44);
            this.btn_XemChiTietPhieuNhap.TabIndex = 8;
            this.btn_XemChiTietPhieuNhap.Text = "Xem Chi Tiết";
            this.btn_XemChiTietPhieuNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_XemChiTietPhieuNhap.UseVisualStyleBackColor = true;
            this.btn_XemChiTietPhieuNhap.Click += new System.EventHandler(this.btn_XemChiTietPhieuNhap_Click);
            // 
            // txt_SLN
            // 
            this.txt_SLN.Location = new System.Drawing.Point(254, 213);
            this.txt_SLN.Name = "txt_SLN";
            this.txt_SLN.Size = new System.Drawing.Size(286, 30);
            this.txt_SLN.TabIndex = 7;
            // 
            // txt_TenSPN
            // 
            this.txt_TenSPN.Location = new System.Drawing.Point(254, 103);
            this.txt_TenSPN.Name = "txt_TenSPN";
            this.txt_TenSPN.Size = new System.Drawing.Size(286, 30);
            this.txt_TenSPN.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số Lượng Nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Nhà Cung Cấp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Sản Phẩm Nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Sản Phẩm Nhập:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyCuaHangBanTraiCay.Properties.Resources.tải_xuống__3__jpg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(664, 360);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 78);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // cbo_TenNCC
            // 
            this.cbo_TenNCC.FormattingEnabled = true;
            this.cbo_TenNCC.Location = new System.Drawing.Point(254, 160);
            this.cbo_TenNCC.Name = "cbo_TenNCC";
            this.cbo_TenNCC.Size = new System.Drawing.Size(286, 31);
            this.cbo_TenNCC.TabIndex = 21;
            // 
            // PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(743, 439);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhieuNhap";
            this.Text = "PhieuNhap";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_XemChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txt_SLN;
        private System.Windows.Forms.TextBox txt_TenSPN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ThemChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txt_MaSPN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbo_TenNCC;
    }
}