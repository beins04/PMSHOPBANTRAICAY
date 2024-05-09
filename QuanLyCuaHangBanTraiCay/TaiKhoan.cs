using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }
        //khai báo chuoi ket noi CSDL
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaTK,TenDangNhap,MatKhau,TrangThai,ChucVu FROM TAIKHOAN;";
            try
            {
                myConnection.Open();

                SqlDataAdapter daSanPham = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsSanPham = new DataSet();
                daSanPham.Fill(dsSanPham);

                myConnection.Close();
                dgv_TaiKhoan.DataSource = dsSanPham.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            txt_MaTK.ReadOnly = true;
            XemDanhSach();
        }
        //THÊM TÀI KHOẢN
        public bool ThemTaiKhoan(string sTenDangNhap, string sMatKhau, string sTrangThai, string sChucVu)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO TAIKHOAN VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenDangNhap, sMatKhau, sTrangThai, sChucVu);
            MessageBox.Show(sSql);

            try
            {
                //mở kết nối CSDL
                myConnection.Open();
                //thực thi CSDL
                SqlCommand myCommand = new SqlCommand(sSql, myConnection);
                myCommand.ExecuteNonQuery();
                //đóng kết nối CSDL
                myConnection.Close();
            }
            catch (Exception ex)
            {
                kq = false; //Thêm KHÔNG thành công
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
            return kq;
        }

        private void btn_ThemTK_Click(object sender, EventArgs e)
        {
            string sTenDangNhap, sMatKhau, sTrangThai, sChucVu;

            sTenDangNhap = txt_TenDN.Text;
            sMatKhau = txt_MK.Text;
            sChucVu = rad_Admin.Checked ? "Quản Lý" : "Nhân Viên";
            sTrangThai = chk_TrangThai.Checked ? "1" : "0";

            bool kq = ThemTaiKhoan(sTenDangNhap, sMatKhau, sTrangThai, sChucVu);
            if (kq)
            {
                MessageBox.Show("Đã thêm Ntài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSach();
        }

        //XÓA TÀI KHOẢN
        public void XoaTaiKhoan()
        {
            string MaTK = txt_MaTK.Text;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM TAIKHOAN WHERE MaTK = @mataikhoan";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@mataikhoan", MaTK);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản có mã: " + MaTK, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaTK_Click(object sender, EventArgs e)
        {
            XoaTaiKhoan();
            XemDanhSach();
        }

        //SỬA TÀI KHOẢN
        public void SuaTaiKhoan()
        {
            string MaTK = txt_MaTK.Text;
            int TrangThai;
            if (chk_TrangThai.Checked == false)
            {
                TrangThai = 0;
            }
            else
            {
                TrangThai = 1;
            }

            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn cập nhật
                string sSQL = "UPDATE TAIKHOAN SET TenDangNhap = @TenDN, MatKhau = @MatKhau, TrangThai = @TrangThai, ChucVu = @ChucVu WHERE MaTK = @MaTK";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@TenDN", txt_TenDN.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txt_MK.Text);
                        cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                        cmd.Parameters.AddWithValue("@MaTK", MaTK);
                        if (rad_Admin.Checked)
                        {
                            cmd.Parameters.AddWithValue("@ChucVu", "Quản Lý");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ChucVu", "Nhân Viên");
                        }

                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công tài khoản có mã sản phẩm là : " + MaTK, "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không có tài khoản nào được cập nhật.", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
                }
            }

        }

        private void btn_SuaTK_Click(object sender, EventArgs e)
        {
            SuaTaiKhoan();
            XemDanhSach();
        }

        private void btn_QuayLaiTK_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaiKhoan ql = new TaiKhoan();
            ql.Show();
        }

        private void dgv_TaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_TaiKhoan.CurrentRow.Index;
            txt_MaTK.Text = dgv_TaiKhoan.Rows[i].Cells[0].Value.ToString();
            txt_TenDN.Text = dgv_TaiKhoan.Rows[i].Cells[1].Value.ToString();
            txt_MK.Text = dgv_TaiKhoan.Rows[i].Cells[2].Value.ToString();
            string chucvuValue = (string)dgv_TaiKhoan.Rows[i].Cells[4].Value;
            if (chucvuValue == "Quản lý")
            {
                rad_Admin.Checked = true;
            }
            else
            {
                rad_Staff.Checked = true;
            }
            if ((bool)dgv_TaiKhoan.Rows[i].Cells[3].Value == false)
            {
                chk_TrangThai.Checked = false;
            }
            else
            {
                chk_TrangThai.Checked = true;
            }
        }
    }
}
