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
    public partial class ChiTietPhieuNhap : Form
    {
        public ChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaCTPN, MaSPN, GiaNhap, KhoiLuong, SoLuongNhap, ThanhTien FROM CHITIETPHIEUNHAP; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daChiTietPN = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsChiTietPN = new DataSet();
                daChiTietPN.Fill(dsChiTietPN);

                myConnection.Close();
                dgv_ChiTiet.DataSource = dsChiTietPN.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        
        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuNhap ql = new PhieuNhap();
            ql.Show();
        }
        
        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            txt_MaSPN.ReadOnly = true;
            XemDanhSach();
        }
        //THÊM CHI TIẾT PHIÊU NHẬP
        public bool ThemCTPN(string sTenKhachHang, string sDiaChi, string sSDT, string sGioiTinh)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO KHACHHANG VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenKhachHang, sDiaChi, sSDT, sGioiTinh);
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

        private void btn_Xuat_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string maSanPhamNhap = txt_MaSPN.Text;
            string tenSanPhamNhap = txt_TenSPN.Text;
            string soLuongNhap = txt_SLN.Text;
            string tenNhaCungCap = txt_NCC.Text;
            string khoiLuong = txt_KhoiLuong.Text;
            string thanhTien = txt_ThanhTien.Text;
            string giaNhap = txt_GiaNhap.Text;

            // Kiểm tra và xử lý nếu có thông tin bị thiếu
            if (string.IsNullOrWhiteSpace(maSanPhamNhap) || string.IsNullOrWhiteSpace(tenSanPhamNhap) || string.IsNullOrWhiteSpace(soLuongNhap) ||
                string.IsNullOrWhiteSpace(tenNhaCungCap) || string.IsNullOrWhiteSpace(khoiLuong) || string.IsNullOrWhiteSpace(thanhTien) ||
                string.IsNullOrWhiteSpace(giaNhap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string scon = "Chuỗi_Kết_Nối_CSDL_SQL_Server";

            // Câu truy vấn SQL để lấy dữ liệu chi tiết phiếu nhập từ cơ sở dữ liệu
            string sSQL = "SELECT 'PN0' + CAST(MaCTPN AS NVARCHAR(10)) AS MaCTPN, MaSPN, GiaNhap, KhoiLuong, SoLuongNhap, ThanhTien FROM KHACHHANG;";

            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();

                    SqlDataAdapter daChiTietPN = new SqlDataAdapter(sSQL, myConnection);
                    DataSet dsChiTietPN = new DataSet();
                    daChiTietPN.Fill(dsChiTietPN);

                    myConnection.Close();

                    // Xuất chi tiết phiếu nhập ra MessageBox
                    StringBuilder messageBuilder = new StringBuilder();
                    foreach (DataRow row in dsChiTietPN.Tables[0].Rows)
                    {
                        // Lấy thông tin từ cơ sở dữ liệu
                        string maCTPN = row["MaCTPN"].ToString();
                        string maSPN = row["MaSPN"].ToString();
                        string giaNhapDB = row["GiaNhap"].ToString();
                        string khoiLuongDB = row["KhoiLuong"].ToString();
                        string soLuongNhapDB = row["SoLuongNhap"].ToString();
                        string thanhTienDB = row["ThanhTien"].ToString();

                        // Thêm thông tin từ cơ sở dữ liệu vào chuỗi
                        messageBuilder.AppendLine("Mã Chi Tiết Phiếu Nhập (Từ DB): " + maCTPN);
                        messageBuilder.AppendLine("Mã Sản Phẩm Nhập (Từ DB): " + maSPN);
                        messageBuilder.AppendLine("Giá Nhập (Từ DB): " + giaNhapDB);
                        messageBuilder.AppendLine("Khối Lượng (Từ DB): " + khoiLuongDB);
                        messageBuilder.AppendLine("Số Lượng Nhập (Từ DB): " + soLuongNhapDB);
                        messageBuilder.AppendLine("Thành Tiền (Từ DB): " + thanhTienDB);

                        // Thêm thông tin từ TextBox vào chuỗi
                        messageBuilder.AppendLine("Mã Sản Phẩm Nhập (Từ TextBox): " + maSanPhamNhap);
                        messageBuilder.AppendLine("Tên Sản Phẩm Nhập (Từ TextBox): " + tenSanPhamNhap);
                        messageBuilder.AppendLine("Số Lượng Nhập (Từ TextBox): " + soLuongNhap);
                        messageBuilder.AppendLine("Tên Nhà Cung Cấp (Từ TextBox): " + tenNhaCungCap);
                        messageBuilder.AppendLine("Khối Lượng (Từ TextBox): " + khoiLuong);
                        messageBuilder.AppendLine("Thành Tiền (Từ TextBox): " + thanhTien);
                        messageBuilder.AppendLine("Giá Nhập (Từ TextBox): " + giaNhap);

                        messageBuilder.AppendLine(); // Dòng trống để phân tách giữa các chi tiết phiếu nhập
                    }

                    MessageBox.Show(messageBuilder.ToString(), "Chi Tiết Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }
    }
}
