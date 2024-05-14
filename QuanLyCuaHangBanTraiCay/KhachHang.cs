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

        public void XemDanhSach()
        {
            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaKH, TenKH, DiaChi, SDT, GioiTinh FROM KHACHHANG; ";
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
            XemDanhSach();
        }

        //THÊM KHÁCH HÀNG
        public bool ThemKhachHang(string sTenKhachHang, string sDiaChi, string sSDT, string sGioiTinh)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO KHACHHANG VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", sTenKhachHang, sDiaChi, sSDT, sGioiTinh);
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
            string MaKhachHang = txt_MaKH.Text;

            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn xóa
                string sSQL = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@MaKH", MaKhachHang);

                        // Thực thi truy vấn xóa
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa khách hàng có mã là: " + MaKhachHang, "THÔNG BÁO");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi!!!. Chi tiết: " + ex.Message);
                }
            }
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            XoaKhachHang();
            XemDanhSach();
        }

        //SỬA KHÁCH HÀNG
        public void SuaKhachHang()
        {
            string MaKhachHang = txt_MaKH.Text;
            
            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn cập nhật
                string sSQL = "UPDATE KHACHHANG SET TenKH = @TenKH, DiaChi = @DiaChi, SDT = @SDT, GioiTinh = @GioiTinh WHERE MaKH = @MaKH";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@TenKH", txt_TenKH.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChiKH.Text);
                        
                        cmd.Parameters.AddWithValue("@SDT", txt_SDTKH.Text); 
                        if (rad_Nam.Checked)
                        {
                            cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                        }
                        cmd.Parameters.AddWithValue("@MaKH", txt_MaKH.Text);

                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công sản phẩm có mã sản phẩm là : " + MaKhachHang, "Thông báo");
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
        private void btn_SuaKH_Click(object sender, EventArgs e)
        {
            SuaKhachHang();
            XemDanhSach();
        }
        private void dgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_KhachHang.CurrentRow.Index;
            txt_MaKH.Text = dgv_KhachHang.Rows[i].Cells[0].Value.ToString();
            txt_TenKH.Text = dgv_KhachHang.Rows[i].Cells[1].Value.ToString();
            txt_DiaChiKH.Text = dgv_KhachHang.Rows[i].Cells[2].Value.ToString();
            txt_SDTKH.Text = dgv_KhachHang.Rows[i].Cells[3].Value.ToString();
            string gioiTinhValue = (string)dgv_KhachHang.Rows[i].Cells[4].Value;
            if (gioiTinhValue == "Nam")
            {
                rad_Nam.Checked = true;
            }
            else
            {
                rad_Nu.Checked = true;
            }
        }

        private void btn_QuayLaiTrangKH_Click(object sender, EventArgs e)
        {
            this.Close();
            //TrangQuanLy ql = new TrangQuanLy();
            //ql.Show();
        }
        //TÌM KIẾM
        public void TimKiem()
        {
            string TimKiemTheo = "", TimKiemThongKe = "";

            TimKiemTheo = cbo_TimKiem.Text;
            TimKiemThongKe = txt_TimKiemKH.Text;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    string sSQLs = "SELECT * FROM KHACHHANG WHERE " + TimKiemTheo + " = @TimKiemThongKe";
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQLs, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@TimKiemThongKe", TimKiemThongKe);

                        SqlDataAdapter daSP = new SqlDataAdapter(cmd);
                        DataSet dsSP = new DataSet();
                        daSP.Fill(dsSP);

                        dgv_KhachHang.DataSource = dsSP.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        private void btn_TimKiemKH_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiem.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TimKiemKH.Text))
            {
                MessageBox.Show("Bạn chưa điền vào ô tìm kiếm hoặc bạn chọn chức năng tìm kiếm chưa phù hợp.", "Thông Báo", MessageBoxButtons.OKCancel);
            }
            else
            {
                TimKiem();
            }
        }
    }
}
