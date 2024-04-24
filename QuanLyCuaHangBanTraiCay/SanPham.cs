using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class SanPham : Form
    {
        private string connectionString;

        public SanPham()
        {
            InitializeComponent();
        }
        //khai báo chuoi ket noi CSDL
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaNCC, TenNCC FROM NHACUNGCAP";
            string ssSQL = "SELECT MaLSP, TenLSP FROM LOAISANPHAM";
            string idspSQL = "SELECT MaSP FROM SANPHAM";

            try
            {
                myConnection.Open();
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                SqlDataAdapter myDataAdaptersql = new SqlDataAdapter(ssSQL, myConnection);
                DataSet dss = new DataSet();
                myDataAdaptersql.Fill(dss);

                SqlDataAdapter myDataAdapterid = new SqlDataAdapter(idspSQL, myConnection);
                DataSet dssp = new DataSet();
                myDataAdapterid.Fill(dssp);

                myConnection.Close();

                cbB_NCC.DataSource = ds.Tables[0];
                cbB_NCC.DisplayMember = "TenNCC";
                cbB_NCC.ValueMember = "MaNCC";

                cbo_LoaiSP.DataSource = dss.Tables[0];
                cbo_LoaiSP.DisplayMember = "TenLSP";
                cbo_LoaiSP.ValueMember = "MaLSP";

                cbB_Masp.DataSource = dssp.Tables[0];
                cbB_Masp.DisplayMember = "MaSP";
                cbB_Masp.ValueMember = "MaSP";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            hienThi();
            XemDanhSachSanPham();
        }
        public void XemDanhSachSanPham()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT 'SP0' + CAST(MaSP AS NVARCHAR(10)) AS MaSP,TenSP,MaNCC,MaLSP,KhoiLuongNhap,GiaNhap,GiaBan,NgayNhap,XuatXu,TrangThai,Khuyenmai FROM SANPHAM; ";
            try
            {
                myConnection.Open();

                SqlDataAdapter daSanPham = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsSanPham = new DataSet();
                daSanPham.Fill(dsSanPham);

                myConnection.Close();
                dgv_SanPham.DataSource = dsSanPham.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
       
        //THÊM SẢN PHẨM
        public bool ThemSanPham(string sTenSanPham, int iMaNCC, int iMaLSP, float fKhoiLuongNhap, decimal dGiaNhap, decimal dGiaBan, string sNgayNhap, string sXuatXu, string sTrangThai, int iKhuyenMai)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO SanPham VALUES (N'{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}', N'{7}', N'{8}','{9}')", sTenSanPham, iMaNCC, iMaLSP, fKhoiLuongNhap, dGiaNhap, dGiaBan, sNgayNhap, sXuatXu, sTrangThai, iKhuyenMai);
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

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            string sNgay, sTenSP, sXuatXu, sTrangThai;
            int  iKhuyenmai, iMaNCC, iMaLSP;
            float fKhoiLuongNhap;
            decimal dGiaNhap, dGiaBan;

            sTenSP = txt_TenSP.Text;
            sXuatXu = txt_XuatXu.Text;
            sTrangThai = rad_ConHang.Checked ? "Còn hàng" : "Hết hàng";



            iMaNCC = (int)cbB_NCC.SelectedValue;
            iMaLSP = (int)cbo_LoaiSP.SelectedValue;
            iKhuyenmai = int.Parse(txt_KhuyenMai.Text);
            fKhoiLuongNhap = float.Parse(txt_KhoiLuongNhap.Text);
            dGiaNhap = decimal.Parse(txt_GiaNhap.Text);
            dGiaBan = decimal.Parse(txt_GiaBan.Text);
            //yyyy-MM-dd
            sNgay = dt_Ngay.Value.ToString("yyyy-MM-dd");
            bool kq = ThemSanPham(sTenSP, iMaNCC, iMaLSP, fKhoiLuongNhap, dGiaNhap, dGiaBan, sNgay, sXuatXu, sTrangThai, iKhuyenmai);
            if (kq)
            {
                MessageBox.Show("Đã thêm Sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            XemDanhSachSanPham();
        }


        //XÓA SẢN PHẨM
        public void XoaSanPham()
        {
            int MaSP = (int)cbB_Masp.SelectedValue;
            
            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM SANPHAM WHERE MaSP = @masanpham";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@masanpham", MaSP);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã: " + MaSP, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            XoaSanPham();
            XemDanhSachSanPham();
        }

        private void cbB_Masp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //SỬA SẢN PHẨM
        //    public void SuaSanPham()
        //    {
        //        int TrangThai;
        //        int MaSP = (int)cbB_Masp.SelectedValue;
        //        if (rad_ConHang.Checked == false)
        //        {
        //            TrangThai = 0;
        //        }
        //        else
        //        {
        //            TrangThai = 1;
        //        }

        //        // Khởi tạo kết nối
        //        using (SqlConnection myConnection = new SqlConnection(scon))
        //        {
        //            // Chuỗi truy vấn cập nhật
        //            string sSQL = "UPDATE SANPHAM SET TenSP = @TenSP, MaNCC = @MaNCC, MaLSP = @MaLSP, KhoiLuongNhap = @KhoiLuong, GiaNhap = @GiaNhap, GiaBan = @GiaBan,NgayNhap = @Ngay, XuatXu = @XuatXu, TrangThai = @TrangThai, KhuyenMai = @KhuyenMai WHERE MaSP = @MaSP";

        //            try
        //            {
        //                myConnection.Open();
        //                // Khởi tạo đối tượng SqlCommand
        //                using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
        //                {
        //                    // Thêm các tham số vào truy vấn
        //                    cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text);
        //                    cmd.Parameters.AddWithValue("@MaNCC", cbB_NCC.Text);
        //                    cmd.Parameters.AddWithValue("@MaLSP", cbo_LoaiSP.Text);
        //                    cmd.Parameters.AddWithValue("@KhoiLuong", txt_KhoiLuongNhap.Text);
        //                    cmd.Parameters.AddWithValue("@GiaNhap", txt_GiaNhap.Text);
        //                    cmd.Parameters.AddWithValue("@GiaBan", txt_GiaBan.Text);
        //                    cmd.Parameters.AddWithValue("@NgayNhap", dt_Ngay.Text);
        //                    cmd.Parameters.AddWithValue("@XuatXu", txt_XuatXu.Text);
        //                    cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
        //                    cmd.Parameters.AddWithValue("@KhuyenMai", txt_KhuyenMai.Text);
        //                    cmd.Parameters.AddWithValue("@MaSP", MaSP);

        //                    // Thực thi truy vấn cập nhật
        //                    int rowsAffected = cmd.ExecuteNonQuery();
        //                    if (rowsAffected > 0)
        //                    {
        //                        MessageBox.Show("Bạn đã thay đổi thành công sản phẩm có mã sản phẩm là : " + MaSP, "Thông báo");
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Không có sản phẩm nào được cập nhật.", "Thông báo");
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
        //            }
        //        }

        //    }
        //    private void btn_SuaSP_Click(object sender, EventArgs e)
        //    {
        //        SuaSanPham();
        //        XemDanhSachSanPham();
        //    }
    }
}
