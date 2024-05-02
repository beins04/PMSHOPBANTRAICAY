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
        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaSPN, MaNCC, TongSoLuongNhap, TongThanhTien, NgayNhap, TrangThai  FROM PHIEUNHAP;";
            try
            {
                myConnection.Open();

                SqlDataAdapter daPhieuNhap = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsPhieuNhap = new DataSet();
                daPhieuNhap.Fill(dsPhieuNhap);

                myConnection.Close();
                dgv_PhieuNhap.DataSource = dsPhieuNhap.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            hienThi();
            XemDanhSach();
        }

        //THÊM PHIẾU NHẬP
        public bool ThemPhieuNhap( int iMaNCC, int iTongSL, int iTongTien, string sNgayNhap, int iTrangThai)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO PHIEUNHAP VALUES ('{0}','{1}', '{2}', N'{3}', '{4}')", iMaNCC, iTongSL, iTongTien, sNgayNhap, iTrangThai);
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
        private void btn_ThemPN_Click(object sender, EventArgs e)
        {
            string sNgayNhap;
            int iTrangThai, iMaNCC, iTongSL, iTongTien;
         
            iMaNCC = (int)cbo_TenNCC.SelectedValue;
            sNgayNhap = dt_NgayNhap.Value.ToString("yyyy-MM-dd");
            iTongSL = int.Parse(txt_SLN.Text);
            iTongTien = int.Parse(txt_ThanhTien.Text);
            if (chk_TrangThai.Checked == true)
            {
                iTrangThai = 1;
            }
            else
            {
                iTrangThai = 0;
            }

            bool kq = ThemPhieuNhap(iMaNCC, iTongSL, iTongTien, sNgayNhap, iTrangThai);
            if (kq)
            {
                MessageBox.Show("Đã thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm KHÔNG thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //XÓA PHIẾU NHẬP
        public void XoaPhieuNhap()
        {
            string MaPN = txt_MaSPN.Text;


            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "DELETE FROM PHIEUNHAP WHERE MaSPN = @maphieunhap";
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(sSQL, myConnection);
                myCommand.Parameters.AddWithValue("@maphieunhap", MaPN);
                int row = myCommand.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Đã xóa phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập có mã: " + MaPN , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
            }
        }
        private void btn_XoaPN_Click(object sender, EventArgs e)
        {
            XoaPhieuNhap();
            XemDanhSach();
        }

        //SỬA PHIẾU NHẬP
        public void SuaPhieuNhap()
        {
            string MaPN = txt_MaSPN.Text;
            int TrangThai;
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
                string sSQL = "UPDATE PHIEUNHAP SET MaSPN = @MaSPN, TenSPN = @TenSPN, MaNCC = @MaNCC, NgayNhap = @NgayNhap, TrangThai = @TrangThai WHERE MaSPN = @MaSPN";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@MaNCC", cbo_TenNCC.Text);
                        cmd.Parameters.AddWithValue("@NgayNhap", dt_NgayNhap.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                        cmd.Parameters.AddWithValue("@MaSPN", MaPN);
                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công phiếu nhập có mã là : " + MaPN, "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không có phiếu nhập nào được cập nhật.", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
                }
            }

        }
        private void btn_SuaPN_Click(object sender, EventArgs e)
        {
            SuaPhieuNhap();
            XemDanhSach();
        }

        private void btn_XemChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuNhap ql = new ChiTietPhieuNhap();
            ql.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txt_SLN.ReadOnly = true;
            txt_ThanhTien.ReadOnly = true;
            chk_TrangThai.Checked = true;
            txt_MaSPN.ReadOnly = true;
        }
    }
}
