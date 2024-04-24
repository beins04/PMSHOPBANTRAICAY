using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string username = txt_TaiKhoan.Text;
            string password = txt_MatKhau.Text;

            // Kiểm tra mật khẩu có chứa số không
            if (!password.All(char.IsDigit))
            {
                MessageBox.Show("Mật khẩu phải chứa số.", "Thông Báo");
                return;
            }

            // Kiểm tra xem tên người dùng và mật khẩu có trùng nhau không
            if (username == password)
            {
                MessageBox.Show("Tên người dùng và mật khẩu không được trùng nhau.", "Thông Báo");
                return;
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông Báo");
                this.Hide();

                // Hiển thị form trang chủ
                TrangQuanLy homePageForm = new TrangQuanLy();
                homePageForm.ShowDialog();

            }
            else
            {

                MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu.");
            }
        }

    }

} 
