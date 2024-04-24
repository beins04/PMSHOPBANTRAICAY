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

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaCTPN FROM CHITIETPHIEUNHAP";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbB_MaSPN.DataSource = ds.Tables[0];
                cbB_MaSPN.DisplayMember = "MaCTPN";
                cbB_MaSPN.ValueMember = "MaCTPN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'PN0' + CAST(MaCTPN AS NVARCHAR(10)) AS MaCTPN, MaSPN, GiaNhap, KhoiLuong, SoLuongNhap, ThanhTien FROM KHACHHANG; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daKhachHang = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsKhachHang = new DataSet();
                daKhachHang.Fill(dsKhachHang);

                myConnection.Close();
                dgv_KhachHang.DataSource = dsKhachHang.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
