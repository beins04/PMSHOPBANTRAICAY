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
    public partial class LoaiSP : Form
    {
        public LoaiSP()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaLSP FROM LOAISANPHAM";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbB_MaSP.DataSource = ds.Tables[0];
                cbB_MaSP.DisplayMember = "MaLSP";
                cbB_MaSP.ValueMember = "MaLSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'LSP0' + CAST(MaLSP AS NVARCHAR(10)) AS MaLSP, TenLSP, XuatXu FROM LOAISANPHAM; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daLoaiSanPham = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsLoaiSanPham = new DataSet();
                daLoaiSanPham.Fill(dsLoaiSanPham);

                myConnection.Close();
                dgv_LoaiSanPham.DataSource = dsLoaiSanPham.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        private void LoaiSP_Load(object sender, EventArgs e)
        {
            hienThi();
            XemDanhSach();
        }
        //THÊM LOẠI SẢN PHẨM
        public bool ThemLoaiSanPham(string sTenLoaiSanPham, string sXuatXu)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO LOAISANPHAM VALUES (N'{0}', N'{1}')", sTenLoaiSanPham, sXuatXu);
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

        private void btn_ThemLSP_Click(object sender, EventArgs e)
        {
            string sTenLoaiSanPham, sXuatXu;

            sTenLoaiSanPham = txt_TenLSP.Text;
            sXuatXu = txt_XuatXuLSP.Text;

            bool kq = ThemLoaiSanPham(sTenLoaiSanPham, sXuatXu);
            if (kq)
            {
                MessageBox.Show("Đã thêm loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSach();
        }
        //XÓA LOẠI SẢN PHẨM
        public void XoaLoaiSanPham()
        {
            int MaLSP = (int)cbB_MaSP.SelectedValue;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM LOAISANPHAM WHERE MaLSP = @maloaisanpham";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@maloaisanpham", MaLSP);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm có mã: " + MaLSP, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaLSP_Click(object sender, EventArgs e)
        {
            XoaLoaiSanPham();
            XemDanhSach();
        }

        private void dgv_LoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_QuayLaiLSP_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangQuanLy ql = new TrangQuanLy();
            ql.Show();
        }
    }
}
