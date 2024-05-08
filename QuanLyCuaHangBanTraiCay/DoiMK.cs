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
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {

            // Kiểm tra tài khoản
            string username = txt_NhapTaiKhoan.Text;
            if (username != username)
            {
                MessageBox.Show("Tài khoản không hợp lệ.");
                return;
            }

            // Kiểm tra mật khẩu cũ
            string oldPassword = txt_NhapMKCu.Text;
            if (oldPassword != oldPassword)
            {
                MessageBox.Show("Mật khẩu cũ không đúng.");
                return;
            }

            // Kiểm tra xem mật khẩu mới và nhập lại mật khẩu mới có khớp nhau không
            string newPassword = txt_NhapMKMoi.Text;
            string confirmPassword = txt_NhapLaiMK.Text;
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp nhau.", "Thông Báo");
                return;
            }

            // Kiểm tra xem mật khẩu mới có chỉ chứa số không
            if (!IsPasswordNumeric(newPassword))
            {
                MessageBox.Show("Mật khẩu mới phải chỉ chứa số.","Thông Báo");
                return;
            }

            // Thực hiện đổi mật khẩu thành công
            MessageBox.Show("Bạn đã đổi mật khẩu thành công!","Thông Báo");

            // Quay lại form đăng nhập
            DangNhap loginForm = new DangNhap();
            loginForm.Show();

            // Đóng form đổi mật khẩu
            this.Close();
        }

        // Hàm kiểm tra mật khẩu chỉ chứa số
        private bool IsPasswordNumeric(string password)
        {
            return password.All(char.IsDigit);
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            // Quay lại trang chủ
            //TrangQuanLy homePageForm = new TrangQuanLy();
            //homePageForm.Show();

            // Đóng form đổi mật khẩu
            this.Close();
        }
    }
}


