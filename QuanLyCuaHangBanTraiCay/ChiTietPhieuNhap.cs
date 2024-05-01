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
                StringBuilder messageBuilder = new StringBuilder();
                foreach (DataRow row in dsChiTietPN.Tables[0].Rows)
                {
                    foreach (DataColumn column in dsChiTietPN.Tables[0].Columns)
                    {
                        messageBuilder.Append(column.ColumnName + ": " + row[column.ColumnName].ToString() + "\n");
                    }
                    messageBuilder.Append("\n");
                }

                MessageBox.Show(messageBuilder.ToString(), "Chi Tiết Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            txt_MaSPN.ReadOnly = true;
        }

        private void btn_Xuat_Click(object sender, EventArgs e)
        {
            string scon = "Chuỗi_Kết_Nối_CSDL_SQL_Server";
            string sSQL = "SELECT 'PN0' + CAST(MaCTPN AS NVARCHAR(10)) AS MaCTPN, MaSPN, GiaNhap, KhoiLuong, SoLuongNhap, ThanhTien FROM KHACHHANG; ";

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
                        foreach (DataColumn column in dsChiTietPN.Tables[0].Columns)
                        {
                            messageBuilder.Append(column.ColumnName + ": " + row[column.ColumnName].ToString() + "\n");
                        }
                        messageBuilder.Append("\n");
                    }

                    MessageBox.Show(messageBuilder.ToString(), "Chi Tiết Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
    }
}
