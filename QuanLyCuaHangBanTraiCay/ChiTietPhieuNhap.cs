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
            string sSQL = "SELECT 'PN0' + CAST(MaCTPN AS NVARCHAR(10)) AS MaCTPN, MaSPN, GiaNhap, KhoiLuong, SoLuongNhap, ThanhTien FROM KHACHHANG; ";
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

        private void dgv_ChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            XemDanhSach();
        }
    }
}
