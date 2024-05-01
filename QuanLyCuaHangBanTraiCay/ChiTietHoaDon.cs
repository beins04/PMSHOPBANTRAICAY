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
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void btn_TaoMoiHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangHoaDon ql = new TrangHoaDon();
            ql.Show();
        }
        //khai báo chuoi ket noi CSDL
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaHD,MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien FROM TAIKHOAN;";
            try
            {
                myConnection.Open();

                SqlDataAdapter daChiTetHoaDon = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsChiTietHoaDon = new DataSet();
                daChiTetHoaDon.Fill(dsChiTietHoaDon);

                myConnection.Close();
                dgv_ChiTietHoaDon.DataSource = dsChiTietHoaDon.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox tương ứng
            string maHoaDon = txt_MaHoaDon.Text;
            string maNhanVien = txt_MaNVHoaDon.Text;
            string ngayLap = dateTimePicker1.Text;

            // Kiểm tra và xử lý nếu có thông tin bị thiếu
            if (string.IsNullOrWhiteSpace(maHoaDon) || string.IsNullOrWhiteSpace(maNhanVien) || string.IsNullOrWhiteSpace(ngayLap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã hóa đơn, mã nhân viên và ngày lập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

            // Câu truy vấn SQL để lấy dữ liệu hóa đơn từ cơ sở dữ liệu
            string sSQL = "SELECT MaHD,MaSP,SoLuong,DonGia,KhuyenMai,ThanhTien FROM TAIKHOAN;";

            try
            {
                // Tạo và mở kết nối đến cơ sở dữ liệu
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();

                    // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
                    SqlDataAdapter daChiTetHoaDon = new SqlDataAdapter(sSQL, myConnection);

                    // Tạo và điền dữ liệu vào DataSet
                    DataSet dsChiTietHoaDon = new DataSet();
                    daChiTetHoaDon.Fill(dsChiTietHoaDon);

                    // Đóng kết nối đến cơ sở dữ liệu
                    myConnection.Close();

                    // Gán dữ liệu từ DataSet vào DataGridView
                    dgv_ChiTietHoaDon.DataSource = dsChiTietHoaDon.Tables[0];

                    // Xuất hóa đơn ra MessageBox
                    StringBuilder messageBuilder = new StringBuilder();
                    foreach (DataRow row in dsChiTietHoaDon.Tables[0].Rows)
                    {
                        foreach (DataColumn column in dsChiTietHoaDon.Tables[0].Columns)
                        {
                            messageBuilder.Append(column.ColumnName + ": " + row[column.ColumnName].ToString() + "\n");
                        }
                        messageBuilder.Append("\n");
                    }

                    // Thêm thông tin mã hóa đơn, mã nhân viên và ngày lập từ TextBox vào MessageBox
                    messageBuilder.Insert(0, "Ngày Lập: " + ngayLap + "\n");
                    messageBuilder.Insert(0, "Mã Nhân Viên: " + maNhanVien + "\n");
                    messageBuilder.Insert(0, "Mã Hóa Đơn: " + maHoaDon + "\n");

                    MessageBox.Show(messageBuilder.ToString(), "Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

