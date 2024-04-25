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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaNV FROM NHANVIEN";
            string ssSQL = "SELECT MaTK FROM TAIKHOAN";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                SqlDataAdapter myDataAdapters = new SqlDataAdapter(ssSQL, myConnection);
                DataSet dss = new DataSet();
                myDataAdapters.Fill(dss);

                myConnection.Close();

                cbB_MaNV.DataSource = ds.Tables[0];
                cbB_MaNV.DisplayMember = "MaNV";
                cbB_MaNV.ValueMember = "MaNV";

                cbB_MaTK.DataSource = dss.Tables[0];
                cbB_MaTK .DisplayMember = "MaTK";
                cbB_MaTK.ValueMember = "MaTK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'NV0' + CAST(MaNV AS NVARCHAR(10)) AS MaNV, MaTK, TenNV, DiaChi, GioiTinh, SDT FROM NHANVIEN;";
            try
            {
                myConnection.Open();

                SqlDataAdapter daNhanVien = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsNhanVien = new DataSet();
                daNhanVien .Fill(dsNhanVien);

                myConnection.Close();
                dgv_NhanVien.DataSource = dsNhanVien.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            hienThi();
            XemDanhSach();
        }
        //THÊM NHÂN VIÊN
        public bool ThemNhanVien(string sTenNV, string sDiaChi, string sGioiTinh, string sSDT)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO NHANVIEN VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenNV, sDiaChi, sGioiTinh, sSDT);
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

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            string sTenNhanVien, sDiaChi, sGioiTinh, sSDT;

            sTenNhanVien = txt_TenNV .Text;
            sDiaChi = txt_DiaChiNV.Text;
            sSDT = txt_SDTNV.Text;
            sGioiTinh = rad_Nam.Checked ? "Nam" : "Nữ";

            bool kq = ThemNhanVien(sTenNhanVien, sDiaChi, sGioiTinh, sSDT);
            if (kq)
            {
                MessageBox.Show("Đã thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSach();
        }
        //XÓA NHÂN VIÊN
        public void XoaNhaCungCap()
        {
            int MaNV = (int)cbB_MaNV.SelectedValue;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM NHANVIEN WHERE MaNV = @manhanvien";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@manhanvien", MaNV);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên có mã: " + MaNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            XoaNhaCungCap();
            XemDanhSach();
        }

        private void rad_Nam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_Nu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_QuayLaiTrangNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangQuanLy ql = new TrangQuanLy();
            ql.Show();
        }
    }
}
