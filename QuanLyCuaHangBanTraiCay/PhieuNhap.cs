using System;
using System.CodeDom.Compiler;
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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";
        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaNCC, TenNCC FROM NHACUNGCAP";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbo_TenNCC.DataSource = ds.Tables[0];
                cbo_TenNCC.DisplayMember = "TenNCC";
                cbo_TenNCC.ValueMember = "MaNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            txt_MaSPN.ReadOnly = true;
            hienThi();
        }

        //THÊM PHIẾU NHẬP
        public bool ThemPhieuNhap(string sTenSPN, int iMaNCC, int iSLNhap)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO PHIEUNHAP VALUES (N'{0}','{1}','{2}')", sTenSPN, iMaNCC, iSLNhap);
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

        private void btn_ThemChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            string sTenSPN;
            int iMaNCC, iSLNhap;

            sTenSPN = txt_TenSPN.Text;
            iMaNCC = (int)cbo_TenNCC.SelectedValue;
            iSLNhap = int.Parse(txt_SLN.Text);


            bool kq = ThemPhieuNhap(sTenSPN, iMaNCC,iSLNhap);
            if (kq)
            {
                MessageBox.Show("Đã thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XemChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuNhap ql = new ChiTietPhieuNhap();
            ql.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txt_MaSPN.ReadOnly = true;
        }
    }
}
