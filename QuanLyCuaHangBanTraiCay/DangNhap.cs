using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class DangNhap : Form
    {
        int count = 0;
        string Quyen;
        int MaTaiKhoan;
        public DangNhap()
        {
            InitializeComponent();
        }
        public string QuyenHang(int MaTK)
        {
            string quyen = null;
            string connectionString = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";
            string query = "SELECT ChucVu FROM TAIKHOAN WHERE MaTK = @MaTK";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaTK", MaTK);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                quyen = reader["ChucVu"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc báo cáo lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return quyen;
        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();
            string username = txt_TenDN.Text;
            string password = txt_MatKhau.Text;

            string role = dangNhapBLL.KiemTraDangNhap(username, password);

            if (role != "")
            {
                if (role == "Quản Lý")
                {
                    MessageBox.Show("Đăng nhập thành công");
;                    //Truyền role qua form để xác định role khi sử dụng chức năng khác.
                    TrangQuanLy admin = new TrangQuanLy(role);
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    //Truyền role qua form để xác định role khi sử dụng chức năng khác.
                    TrangQuanLyChoNhanVien staff = new TrangQuanLyChoNhanVien(role);
                    staff.Show();
                    this.Hide();
                }
            }
        }

        private void btn_eyeclose_Click(object sender, EventArgs e)
        {
            if ((count % 2) == 0)
            {
                txt_MatKhau.PasswordChar = '\0';
                btn_eyeopen.Visible = true;
                btn_eyeclose.Visible = false;
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
                btn_eyeclose.Visible = true;
                btn_eyeopen.Visible = false;
            }
            count += 1;
        }
    }

}
