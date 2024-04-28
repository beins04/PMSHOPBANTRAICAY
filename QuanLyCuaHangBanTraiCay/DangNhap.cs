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
        private void DangNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();
            string username = txt_TenDN.Text;
            string password = txt_MatKhau.Text;

            bool isAuthenticated = dangNhapBLL.KiemTraDangNhap(username, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Đăng nhập thành công!");
                DangNhapBLL PhanQuyenBLL = new DangNhapBLL();
                int MaTK = PhanQuyenBLL.PhanQuyen(username, password);
                string quyen = QuyenHang(MaTK); // Lấy quyền từ cơ sở dữ liệu

                if (quyen == "Admin")
                {
                    TrangQuanLy admin = new TrangQuanLy();
                    admin.MaTK = MaTK;
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    TrangQuanLyChoNhanVien staff = new TrangQuanLyChoNhanVien();
                    staff.MaTK = MaTK;
                    staff.Show();
                    this.Hide();
                }
            }
        }
    }

}
