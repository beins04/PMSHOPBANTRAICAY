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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaNCC FROM NHACUNGCAP";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbB_MaNCC.DataSource = ds.Tables[0];
                cbB_MaNCC.DisplayMember = "MaNCC";
                cbB_MaNCC.ValueMember = "MaNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'NCC0' + CAST(MaNCC AS NVARCHAR(10)) AS MaNCC, TenNCC, DiaChi, SDT, TrangThai FROM NHACUNGCAP; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daNhaCungCap = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsNhaCungCap = new DataSet();
                daNhaCungCap.Fill(dsNhaCungCap);

                myConnection.Close();
                dgv_NhaCungCap.DataSource = dsNhaCungCap.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            hienThi();
            XemDanhSach();
        }

        //THÊM NHÀ CUNG CẤP
        public bool ThemNhaCungCap(string sTenNhaCungCap, string sDiaChi, string sSDT, string sTrangThai)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO NHACUNGCAP VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenNhaCungCap, sDiaChi, sSDT, sTrangThai);
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
        private void btn_ThemNCCcc_Click(object sender, EventArgs e)
        {
            string sTenNhaCungCap, sDiaChi, sSDT, sTrangThai;

            sTenNhaCungCap = txt_TenNhaCungCap.Text;
            sDiaChi = txt_DiaChi.Text;
            sSDT = txt_SDT.Text;
            sTrangThai = ck_TrangThai.Checked ? "Hoạt động" : "Ngưng hoạt động";

            bool kq = ThemNhaCungCap(sTenNhaCungCap, sDiaChi, sSDT, sTrangThai);
            if (kq)
            {
                MessageBox.Show("Đã thêm Nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSach();
        }

        //XÓA SẢN PHẨM
        public void XoaNhaCungCap()
        {
            int MaNCC = (int)cbB_MaNCC.SelectedValue;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM NHACUNGCAP WHERE MaNCC = @manhacungcap";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@manhacungcap", MaNCC);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có mã: " + MaNCC, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaNCCcc_Click(object sender, EventArgs e)
        {
            XoaNhaCungCap();
            XemDanhSach();
        }
    }
}
