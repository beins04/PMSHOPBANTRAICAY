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
        private string scon = "Data Source=DESKTOP-HL6447C\\SQLEXPRESS;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        private void hienThi()
        {
            SqlConnection myConnection = new SqlConnection(scon);

            string sSQL = "SELECT MaNCC, TenNCC FROM NHACUNGCAP";
            string ssSQL = "SELECT MaLSP, TenLSP FROM LOAISANPHAM";

            try
            {
                myConnection.Open();
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                SqlDataAdapter myDataAdaptersql = new SqlDataAdapter(ssSQL, myConnection);
                DataSet dss = new DataSet();
                myDataAdaptersql.Fill(dss);

                myConnection.Close();

                cbB_NCC.DataSource = ds.Tables[0];
                cbB_NCC.DisplayMember = "TenNCC";
                cbB_NCC.ValueMember = "MaNCC";

                cbo_LoaiSP.DataSource = dss.Tables[0];
                cbo_LoaiSP.DisplayMember = "TenLSP";
                cbo_LoaiSP.ValueMember = "MaLSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            txt_MaSP.ReadOnly = true;
            chk_TrangThai.Checked = true;
            hienThi();
            XemDanhSachSanPham();
        }
        public void XemDanhSachSanPham()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaSP,TenSP,MaNCC,MaLSP,KhoiLuongNhap,GiaNhap,GiaBan,NgayNhap,XuatXu,TrangThai,Khuyenmai, KhoiLuongTon FROM SANPHAM; ";
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
        public bool ThemSanPham(string sTenSanPham, int iMaNCC, int iMaLSP, float fKhoiLuongNhap, decimal dGiaNhap, decimal dGiaBan, string sNgayNhap, string sXuatXu, int iTrangThai, int iKhuyenMai, float fKhoiLuongTon)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO SanPham VALUES (N'{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}', N'{7}', N'{8}','{9}', '{10}')", sTenSanPham, iMaNCC, iMaLSP, fKhoiLuongNhap, dGiaNhap, dGiaBan, sNgayNhap, sXuatXu, iTrangThai, iKhuyenMai, fKhoiLuongTon);
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
            
            string Ngay, TenSP, XuatXu;
            int Khuyenmai, MaNCC, MaLSP, TrangThai;
            float KhoiLuongNhap, KhoiLuongTon;
            decimal GiaNhap, GiaBan;

            TenSP = txt_TenSP.Text;
            XuatXu = txt_XuatXu.Text;
            if (chk_TrangThai.Checked == true)
            {
                TrangThai = 1;
            }
            else
            {
                TrangThai = 0;
            }

            MaNCC = (int)cbB_NCC.SelectedValue;
            MaLSP = (int)cbo_LoaiSP.SelectedValue;
            Khuyenmai = int.Parse(txt_KhuyenMai.Text);
            KhoiLuongNhap = float.Parse(txt_KhoiLuongNhap.Text);
            KhoiLuongTon = float.Parse(txt_KLTon.Text);
            GiaNhap = decimal.Parse(txt_GiaNhap.Text);
            GiaBan = decimal.Parse(txt_GiaBan.Text);
            //yyyy-MM-dd
            Ngay = dt_Ngay.Value.ToString("yyyy-MM-dd");
            bool kq = ThemSanPham(TenSP, MaNCC, MaLSP, KhoiLuongNhap, GiaNhap, GiaBan, Ngay, XuatXu, TrangThai, Khuyenmai, KhoiLuongTon);
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
            string MaSP = txt_MaSP.Text;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM SANPHAM WHERE MaSP like '" + MaSP.ToString() + "'";
            try
            {
                myConnection.Open();

                SqlDataAdapter daSanPham = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsSanPham = new DataSet();
                daSanPham.Fill(dsSanPham);
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

        //SỬA SẢN PHẨM
        public void SuaSanPham()
        {
            int TrangThai;
            string MaSP = txt_MaSP.Text;
            string MaNCC = cbB_NCC.Text;
            string MaLSP = cbo_LoaiSP.Text;
            if (chk_TrangThai.Checked == false)
            {
                TrangThai = 0;
            }
            else
            {
                TrangThai = 1;
            }

            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn cập nhật
                string sSQL = "UPDATE SANPHAM SET TenSP = @TenSP, MaNCC = @MaNCC, MaLSP = @MaLSP, KhoiLuongNhap = @KhoiLuong, GiaNhap = @GiaNhap, GiaBan = @GiaBan,NgayNhap = @Ngay, XuatXu = @XuatXu, TrangThai = @TrangThai, KhuyenMai = @KhuyenMai, KhoiLuongTon = @KhoiLuongTon WHERE MaSP = @MaSP";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text);
                        cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                        cmd.Parameters.AddWithValue("@MaLSP", MaLSP);
                        cmd.Parameters.AddWithValue("@KhoiLuong", txt_KhoiLuongNhap.Text);
                        cmd.Parameters.AddWithValue("@GiaNhap", txt_GiaNhap.Text);
                        cmd.Parameters.AddWithValue("@GiaBan", txt_GiaBan.Text);
                        cmd.Parameters.AddWithValue("@Ngay", dt_Ngay.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@XuatXu", txt_XuatXu.Text);
                        cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                        cmd.Parameters.AddWithValue("@KhuyenMai", txt_KhuyenMai.Text);
                        cmd.Parameters.AddWithValue("@KhoiLuongTon", txt_KLTon.Text);
                        cmd.Parameters.AddWithValue("@MaSP", MaSP);

                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công sản phẩm có mã sản phẩm là : " + MaSP, "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không có sản phẩm nào được cập nhật.", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
                }
            }

        }
        private void btn_SuaSP_Click_1(object sender, EventArgs e)
        {
            SuaSanPham();
            XemDanhSachSanPham();
        }
        private void dgv_SanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_SanPham.CurrentRow.Index;

            //DataGridViewCell item = dgv_SanPham.;
            if (dgv_SanPham.Rows[i].Cells[7].Value.ToString() != "")
            {
                txt_MaSP.Text = dgv_SanPham.Rows[i].Cells[0].Value.ToString();
                txt_TenSP.Text = dgv_SanPham.Rows[i].Cells[1].Value.ToString();
                cbB_NCC.Text = dgv_SanPham.Rows[i].Cells[2].Value.ToString();
                cbo_LoaiSP.Text = dgv_SanPham.Rows[i].Cells[3].Value.ToString();
                txt_KhoiLuongNhap.Text = dgv_SanPham.Rows[i].Cells[4].Value.ToString();
                txt_GiaNhap.Text = dgv_SanPham.Rows[i].Cells[5].Value.ToString();
                txt_GiaBan.Text = dgv_SanPham.Rows[i].Cells[6].Value.ToString();
                dt_Ngay.Value = DateTime.Parse(dgv_SanPham.Rows[i].Cells[7].Value.ToString());
                txt_XuatXu.Text = dgv_SanPham.Rows[i].Cells[8].Value.ToString();
                txt_KhuyenMai.Text = dgv_SanPham.Rows[i].Cells[10].Value.ToString();
                txt_KLTon.Text = dgv_SanPham.Rows[i].Cells[11].Value.ToString();
                if ((bool)dgv_SanPham.Rows[i].Cells[9].Value == false)
                {
                    chk_TrangThai.Checked = false;
                }
                else
                {
                    chk_TrangThai.Checked = true;
                }


            }
           
            
        }

        private void btn_QuayLaiSP_Click(object sender, EventArgs e)
        {
            this.Close();

            //TrangQuanLy ql = new TrangQuanLy();
            //bool isAdmin = ql.isAdmin;

            //if (isAdmin)
            //{
            //    TrangQuanLy qlch = new TrangQuanLy();
            //    qlch.Show();
            //}
            //else
            //{
            //    TrangQuanLyChoNhanVien qlnv = new TrangQuanLyChoNhanVien();
            //    qlnv.Show();
            //}
        }

        //TÌM KIẾM
        public void TimKiem()
        {
            string TimKiemTheo = "", TimKiemThongKe = "";

            TimKiemTheo = cbo_TimKiem.Text;
            TimKiemThongKe = txt_TimKiemSP.Text;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    string sSQLs = "SELECT * FROM SANPHAM WHERE " + TimKiemTheo + " = @TimKiemThongKe";
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQLs, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@TimKiemThongKe", TimKiemThongKe);

                        SqlDataAdapter daSP = new SqlDataAdapter(cmd);
                        DataSet dsSP = new DataSet();
                        daSP.Fill(dsSP);

                        dgv_SanPham.DataSource = dsSP.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        private void btn_TimSP_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiem.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TimKiemSP.Text))
            {
                MessageBox.Show("Bạn chưa điền vào ô tìm kiếm hoặc bạn chọn chức năng tìm kiếm chưa phù hợp.", "Thông Báo", MessageBoxButtons.OKCancel);
            }
            else
            {
                TimKiem();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {

        }
    }
}
