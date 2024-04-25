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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaKH FROM KHACHHANG";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbB_MaKhachHang.DataSource = ds.Tables[0];
                cbB_MaKhachHang.DisplayMember = "MaKH";
                cbB_MaKhachHang.ValueMember = "MaKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'KH0' + CAST(MaKH AS NVARCHAR(10)) AS MaKH, TenKH, DiaChi, SDT, GioiTinh FROM KHACHHANG; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daKhachHang = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsKhachHang= new DataSet();
                daKhachHang.Fill(dsKhachHang);

                myConnection.Close();
                dgv_KhachHang.DataSource = dsKhachHang.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {                                       
            hienThi();
            XemDanhSach();
        }

        //THÊM KHÁCH HÀNG
        public bool ThemKhachHang(string sTenKhachHang, string sDiaChi, string sSDT, string sGioiTinh)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO KHACHHANG VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenKhachHang, sDiaChi, sSDT, sGioiTinh        );
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

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            string sTenKhachHang, sDiaChi, sSDT, sGioiTinh;

            sTenKhachHang = txt_TenKH.Text;
            sDiaChi = txt_DiaChiKH.Text;
            sSDT = txt_DiaChiKH .Text;
            sGioiTinh = rad_Nam.Checked ? "Nam" : "Nữ";

            bool kq = ThemKhachHang(sTenKhachHang, sDiaChi, sSDT, sGioiTinh);
            if (kq)
            {
                MessageBox.Show("Đã thêm Khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSach();

        }
        //XÓA KHÁCH HÀNG
        public void XoaKhachHang()
        {
            int MaKH = (int)cbB_MaKhachHang.SelectedValue;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM KHACHHANG WHERE MaKH = @makhachhang";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@makhachhang", MaKH);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + MaKH, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            XoaKhachHang();
            XemDanhSach();
        }

        private void dgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_QuayLaiTrangKH_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangQuanLy ql = new TrangQuanLy();
            ql.Show();
        }
    }
}
