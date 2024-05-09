using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        //khai báo chuoi ket noi CSDL
        string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";
        public int MaHD;
        public int MaTK;
        public int TienKhachDua;

        public bool KiemTraSoLuongSanPham()
        {
            int Khoiluongmuahang = (int)num_SL.Value;
            SqlConnection myConnection = new SqlConnection(scon);
            try
            {
                myConnection.Open();

                // Lấy số lượng hiện tại của sản phẩm từ CSDL
                string sSQL = "SELECT KhoiLuongNhap FROM SANPHAM WHERE MaSP = @MaSP";
                SqlCommand command = new SqlCommand(sSQL, myConnection);
                command.Parameters.AddWithValue("@MaSP", int.Parse(cbo_MaSP.Text));
                int khoiluongdb = (int)command.ExecuteScalar();

                // Tính số lượng còn lại sau khi mua
                int khoiluongtravedb = khoiluongdb - Khoiluongmuahang;

                if (khoiluongtravedb< 0)
                {
                    MessageBox.Show("Hiện số lượng không đủ để bán, hãy thử giảm số lượng mua hoặc quay lại lần sau nhé!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return false; // Trả về false nếu số lượng không đủ
                }
                else
                {
                    // Cập nhật số lượng sản phẩm
                    string updateSQL = "UPDATE SANPHAM SET KhoiLuongNhap = @KhoiLuongTraVedb WHERE MaSP = @MaSP";
                    SqlCommand updateCommand = new SqlCommand(updateSQL, myConnection);
                    updateCommand.Parameters.AddWithValue("@KhoiLuongTraVedb", khoiluongtravedb);
                    updateCommand.Parameters.AddWithValue("@MaSP", int.Parse(cbo_MaSP.Text));
                    updateCommand.ExecuteNonQuery();

                    return true; // Trả về true nếu cập nhật thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
            finally
            {
                myConnection.Close(); // Đảm bảo kết nối được đóng lại
            }
        }
        public void XemChiTietHoaDon(int MaHD)
        {
            // Khai báo chuỗi kết nối CSDL
            string sSQL = "SELECT CHITIETHOADON.MaHD, SANPHAM.MaSP, SANPHAM.TenSP, SANPHAM.GiaBan, SANPHAM.KhuyenMai, CHITIETHOADON.KhoiLuongNhap, CHITIETHOADON.ThanhTien FROM SANPHAM INNER JOIN CHITIETHOADON ON SANPHAM.MaSP = CHITIETHOADON.MaSP WHERE CHITIETHOADON.MaHD = @MaHD";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);

                        SqlDataAdapter daSanPham = new SqlDataAdapter(cmd);
                        DataSet dsSanPham = new DataSet();
                        daSanPham.Fill(dsSanPham);

                        dgv_ChiTietHoaDon.DataSource = dsSanPham.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }
        public void HienThi()
        {

            //Doi tuong ket noi CSDL
            SqlConnection myConnection = new SqlConnection(scon);
            string sSql;
            sSql = "SELECT MaSP, TenSP, GiaBan FROM SANPHAM";
            try
            {
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                //DataSet: du lieu tren bo nho RAM
                DataSet ds = new DataSet();
                da.Fill(ds);
                myConnection.Close();

                //cbo_MaSP
                cbo_MaSP.DataSource = ds.Tables[0];
                cbo_MaSP.DisplayMember = "MaSP";
                cbo_MaSP.ValueMember = "TenSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("LOI. Chi tiet: " + ex.Message);
            }
        }
        public void XuatThongTinSP()
        {
            String MaSP = cbo_MaSP.Text;
            string sSQL = "SELECT TenSP, GiaBan, KhuyenMai FROM SANPHAM WHERE MaSP = @MaSP";

            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", MaSP);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Set other text fields
                                txt_TenSP.Text = reader["TenSP"].ToString();
                                txt_Gia.Text = reader["GiaBan"].ToString();
                                txt_KhuyenMai.Text = reader["KhuyenMai"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
        public void TongHD()
        {
            string MaSP = cbo_MaSP.Text;
            string sSQL = "SELECT SUM(ThanhTien) as 'Tổng tiền' FROM CHITIETHOADON INNER JOIN HOADON on CHITIETHOADON.MaHD = HOADON.MaHD WHERE HOADON.MaHD = @MaHD GROUP BY CHITIETHOADON.MaHD";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_TongTien.Text = reader["Tổng tiền"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        //THÊM CHI TIẾT HÓA ĐƠN
        public void ThemChiTietHoaDon(int MaHD)
        {
            int KhoiLuong = int.Parse(num_SL.Value.ToString());
            int DonGia = int.Parse(txt_Gia.Text);
            int KhuyenMai = int.Parse(txt_KhuyenMai.Text);
            double ThanhTien = (KhoiLuong * DonGia) * ((100.0 - KhuyenMai) / 100.0);
            txt_ThanhTien.Text = ThanhTien.ToString();
            string sSQL = "INSERT INTO CHITIETHOADON (MaHD,MaSP,SoLuong,ThanhTien) VALUES (@MaHD,@MaSP,@SoLuong,@ThanhTien)";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        cmd.Parameters.AddWithValue("@MaSP", cbo_MaSP.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", num_SL.Value);
                        cmd.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }
        //XÓA CHI TIẾT HÓA ĐƠN
        public void XoaSP(int MaHD)
        {
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                myConnection.Open();
                string sSQL = "DELETE CHITIETHOADON WHERE MaHD = @MaHD and MaSP = @MaSP";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        cmd.Parameters.AddWithValue("@MaSP", int.Parse(cbo_MaSP.Text));
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            MessageBox.Show("Xóa sản Phẩm thành công!", "Thông báo");
                        else
                            MessageBox.Show("Ko có sản phẩm để xóa !", "Thông báo");

                    }
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
                }
            }
        }
        //SỬA CHI TIẾT HÓA ĐƠN
        public void SuaSP(int MaHD)
        {
            // Khai báo chuỗi kết nối CSDL
            string sSQL = "UPDATE CHITIETHOADON SET SoLuong = @SoLuong WHERE MaHD = @MaHD AND MaSP = @MaSP";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        cmd.Parameters.AddWithValue("@MaSP", cbo_MaSP.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", num_SL.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật thành công !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }
        //
        public void HoanThienHoaDon(int MaHD)
        {
            string sSQL = "UPDATE HOADON SET TienKhachDua = @TienKhachDua , TienGuiLai = @TienGuiLai , TongHD = @TongHD WHERE MaHD = @MaHD";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", MaHD);
                        cmd.Parameters.AddWithValue("@TienKhachDua", txt_TienKhachDua.Text);
                        cmd.Parameters.AddWithValue("@TienGuiLai", txt_TienGuiLai.Text);
                        cmd.Parameters.AddWithValue("@TongHD", txt_TongTien.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            txt_TienKhachDua.Text = TienKhachDua.ToString();
            XemChiTietHoaDon(MaHD);
            HienThi();
            TongHD();
            DataGridViewImageColumn avatar_column = (DataGridViewImageColumn)dgv_ChiTietHoaDon.Columns[7];
            avatar_column.Width = 60;
            avatar_column.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void cbo_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            XuatThongTinSP();
        }

        private void num_SL_ValueChanged(object sender, EventArgs e)
        {
            int KhuyenMai = int.Parse(txt_KhuyenMai.Text);
            int Gia = int.Parse(txt_Gia.Text);
            int Soluong = (int)num_SL.Value;
            double ThanhTien = (Soluong * Gia) * ((100.0 - KhuyenMai) / 100);
            txt_ThanhTien.Text = ThanhTien.ToString();

            TongHD();
        }

        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị nhập vào có rỗng hoặc trống không
            string tienKhachDuaText = txt_TienKhachDua.Text.Trim();
            if (string.IsNullOrEmpty(tienKhachDuaText))
            {
                MessageBox.Show("Hãy nhập số tiền mà khách đã đưa cho bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double tienKhachDua;
            try
            {
                // Chuyển đổi giá trị sang kiểu số
                tienKhachDua = double.Parse(tienKhachDuaText);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ. Hãy nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tienKhachDua <= 0)
            {
                MessageBox.Show("Số tiền của khách đưa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double TongTien;
            try
            {
                TongTien = double.Parse(txt_TongTien.Text); // Giả sử giá trị này luôn hợp lệ
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Tổng tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double tienGuiKhach = tienKhachDua - TongTien;

            txt_TienGuiLai.Text = tienGuiKhach.ToString();

            HoanThienHoaDon(MaHD);
            TrangHoaDon hoaDonBanHang = new TrangHoaDon();
            hoaDonBanHang.Show();
            hoaDonBanHang.MaTK = MaTK;

            this.Hide();
        }

        private void btn_SuaKH_Click(object sender, EventArgs e)
        {
            SuaSP(MaHD);
            XemChiTietHoaDon(MaHD);
        }

        private void dgv_ChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dgv_ChiTietHoaDon.Rows[rowIndex];
            if (selectedRow != null)
            {
                int i = dgv_ChiTietHoaDon.CurrentRow.Index;
                cbo_MaSP.Text = dgv_ChiTietHoaDon.Rows[i].Cells[1].Value.ToString();
                txt_TenSP.Text = dgv_ChiTietHoaDon.Rows[i].Cells[2].Value.ToString();
                txt_Gia.Text = dgv_ChiTietHoaDon.Rows[i].Cells[3].Value.ToString();
                txt_KhuyenMai.Text = dgv_ChiTietHoaDon.Rows[i].Cells[4].Value.ToString();
                num_SL.Value = Convert.ToInt32(dgv_ChiTietHoaDon.Rows[i].Cells[5].Value);
                txt_ThanhTien.Text = dgv_ChiTietHoaDon.Rows[i].Cells[6].Value.ToString();
            }
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            XoaSP(MaHD);
            XemChiTietHoaDon(MaHD);
        }

        private void dgv_ChiTietHoaDon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv_ChiTietHoaDon.Rows[e.RowIndex].Height = 80;
        }

        private void btn_QuayLaiTrangKH_Click(object sender, EventArgs e)
        {
            TrangHoaDon ql = new TrangHoaDon();
            ql.MaTK = MaTK;
            ql.Show();
            this.Hide();
        }

        private void ChiTietHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int KhuyenMai = int.Parse(txt_KhuyenMai.Text);
            int SoLuong = (int)num_SL.Value;

            if (SoLuong == 0)
            {
                MessageBox.Show("Hãy chọn số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát khỏi hàm nếu không có số lượng
            }

            if (KhuyenMai > 0)
            {
                MessageBox.Show("Sản phẩm hiện đang được khuyên mãi: " + KhuyenMai + "%", "Bạn có biết?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Kiểm tra số lượng sản phẩm trước khi thực hiện các thao tác khác
            bool soLuongDu = KiemTraSoLuongSanPham();
            if (soLuongDu)
            {
                // Chỉ thực hiện nếu số lượng đủ
                ThemChiTietHoaDon(MaHD);
                XemChiTietHoaDon(MaHD);
                TongHD();
            }
        }
    }
}

