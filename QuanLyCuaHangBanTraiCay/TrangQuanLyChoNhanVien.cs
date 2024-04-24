using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class TrangQuanLyChoNhanVien : Form
    {
        public TrangQuanLyChoNhanVien()
        {
            InitializeComponent();
        }

        private void btn_KhoHang_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form quản lý kho hàng
            QuanLyKhoHang Management = new QuanLyKhoHang();

            // Hiển thị form quản lý kho hàng
            Management.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form thống kê
            ThongKe Statistical = new ThongKe();

            // Hiển thị form thống kê
            Statistical.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form đổi mật khẩu
            DoiMK ChangePassword = new DoiMK();

            // Hiển thị form đổi mật khẩu
            ChangePassword.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form khách hàng
            KhachHang Guest = new KhachHang();

            // Hiển thị form khách hàng
            Guest.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form đăng nhập
            DangNhap loginForm = new DangNhap();

            // Hiển thị form đăng nhập
            loginForm.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form hóa đơn
            TrangHoaDon Bill = new TrangHoaDon();

            // Hiển thị form hóa đơn
            Bill.Show();

            // Đóng form trang chủ
            this.Close();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form sản phẩm
            SanPham Product = new SanPham();

            // Hiển thị form sản phẩm
            Product.Show();

            // Đóng form trang chủ
            this.Close();
        }
    }
}
