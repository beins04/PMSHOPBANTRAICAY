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
    public partial class TrangHoaDon : Form
    {
        public TrangHoaDon()
        {
            InitializeComponent();
        }
        //khai báo chuoi ket noi CSDL
        private string scon = "Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True";

        int TienKhachDua;
        public int MaTK;
        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
            chiTietHoaDon.MaHD = int.Parse(txt_MaHD.Text);
            this.Hide();
            chiTietHoaDon.Show();
        }

        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
            ThemHoaDon();
            this.Hide();
            chiTietHoaDon.Show();
            chiTietHoaDon.MaHD = LayMaHD();
        }

        //XEM HÓA ĐƠN
        public void XemHoaDon()
        {
            //khai báo chuoi ket noi CSDL
            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT * FROM HOADON";
            try
            {
                myConnection.Open();

                SqlDataAdapter daHoaDon = new SqlDataAdapter(sSQL, myConnection);
                DataSet dsHoaDon = new DataSet();
                daHoaDon.Fill(dsHoaDon);

                myConnection.Close();
                dgv_HoaDon.DataSource = dsHoaDon.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }

        //THÊM HÓA ĐƠN
        public void ThemHoaDon()
        {
            // Khai báo chuỗi kết nối CSDL
            string sSQL = "INSERT INTO HOADON (MaNV, MaKH, NgayLap, TienKhachDua, TienGuiLai, TongHD) VALUES (@MaNV, @MaKH, @NgayLap, @TienKhachDua, @TienGuiLai, @TongHD)";
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", cbo_MaKH .Text);
                        cmd.Parameters.AddWithValue("@MaNV", cbo_MaNV.Text);
                        cmd.Parameters.AddWithValue("@NgayLap", dt_Ngay.Value.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@TienKhachDua", DBNull.Value);
                        cmd.Parameters.AddWithValue("@TienGuiLai", DBNull.Value);
                        cmd.Parameters.AddWithValue("@TongHD", DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        //SỬA HÓA ĐƠN
        public void SuaHoaDon()
        {
            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn cập nhật
                string sSQL = "UPDATE HOADON SET MaNV = @MaNV, MaKH = @MaKH ,NgayLap = @NgayLap WHERE MaHD = @MaHD";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", int.Parse(txt_MaHD.Text));
                        cmd.Parameters.AddWithValue("@MaNV", int.Parse(cbo_MaNV.Text));
                        cmd.Parameters.AddWithValue("@MaKH", int.Parse(cbo_MaKH.Text));
                        cmd.Parameters.AddWithValue("@NgayLap", DateTime.Parse(dt_Ngay.Text));
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
                            this.Hide();
                            chiTietHoaDon.MaHD = int.Parse(txt_MaHD.Text);
                            chiTietHoaDon.TienKhachDua = TienKhachDua;
                            chiTietHoaDon.MaTK = MaTK;
                            chiTietHoaDon.Show();
                        }
                        else
                        {
                            MessageBox.Show("Không có sản phẩm nào được cập nhật.", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn chưa chọn hóa đơn ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //XÓA HÓA ĐƠN
        public void XoaHoaDon()
        {
            string maHoaDon = txt_MaHD.Text;
            bool success = true;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    SqlTransaction transaction = myConnection.BeginTransaction();

                    try
                    {
                        // Xóa chi tiết hóa đơn
                        string sSQLChiTietHoaDon = "DELETE FROM CHITIETHOADON WHERE MaHD = @MaHD";
                        using (SqlCommand cmdChiTietHoaDon = new SqlCommand(sSQLChiTietHoaDon, myConnection))
                        {
                            cmdChiTietHoaDon.Parameters.AddWithValue("@MaHD", maHoaDon);
                            cmdChiTietHoaDon.Transaction = transaction;
                            int rowsAffected = cmdChiTietHoaDon.ExecuteNonQuery();

                            // Kiểm tra nếu không có hàng nào bị xóa
                            if (rowsAffected == 0)
                            {
                                success = false;
                                MessageBox.Show("Không tìm thấy hóa đơn để xóa.", "Thông báo");
                            }
                        }

                        if (success)
                        {
                            // Xóa hóa đơn
                            string sSQLHoaDon = "DELETE FROM HOADON WHERE MaHD = @MaHD";
                            using (SqlCommand cmdHoaDon = new SqlCommand(sSQLHoaDon, myConnection))
                            {
                                cmdHoaDon.Parameters.AddWithValue("@MaHD", maHoaDon);
                                cmdHoaDon.Transaction = transaction;
                                cmdHoaDon.ExecuteNonQuery();

                                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo");
                            }
                        }

                        transaction.Commit(); // Commit transaction khi không có lỗi
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        transaction.Rollback(); // Rollback transaction nếu có lỗi
                        MessageBox.Show("Lỗi khi xóa hóa đơn. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu. Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //HIỂN THỊ MÃ NHÂN VIÊN
        public void HienThi()
        {
            //Doi tuong ket noi CSDL
            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = "SELECT MaNV, TenNV FROM NHANVIEN";
            string ssSql = "SELECT MaKH, TenKH FROM KHACHHANG";
            try
            {
                myConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(sSql, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlDataAdapter daKhachHang = new SqlDataAdapter(ssSql, myConnection);
                DataSet dsKhachHang = new DataSet();
                daKhachHang.Fill(dsKhachHang);

                myConnection.Close();

                cbo_MaNV.DataSource = ds.Tables[0];
                cbo_MaNV.DisplayMember = "MaNV";
                cbo_MaNV.ValueMember = "TenNV";

                cbo_MaKH.DataSource = dsKhachHang.Tables[0];
                cbo_MaKH.DisplayMember = "MaKH";
                cbo_MaKH.ValueMember = "TenKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("LOI. Chi tiet: " + ex.Message);
            }
        }

       //LẤY HÓA ĐƠN
        public int LayMaHD()
        {
            int MaHD = 0;
            string sSQL = "SELECT MAX(MaHD) AS MaxMaHD FROM HOADON";

            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        object result = cmd.ExecuteScalar();
                        MaHD = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }

            return MaHD;
        }

        private void dgv_HoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_HoaDon.CurrentRow.Index;
            txt_MaHD.Text = dgv_HoaDon.Rows[i].Cells[0].Value.ToString();
            cbo_MaNV.Text = dgv_HoaDon.Rows[i].Cells[1].Value.ToString();
            cbo_MaKH.Text = dgv_HoaDon.Rows[i].Cells[2].Value.ToString();
            dt_Ngay.Value = DateTime.Parse(dgv_HoaDon.Rows[i].Cells[3].Value.ToString());
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaHD.Text != "")
            {
                XoaHoaDon();
                XemHoaDon();
                txt_MaHD.Clear();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào !!!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            SuaHoaDon();
        }

        private void TrangHoaDon_Load(object sender, EventArgs e)
        {
            XemHoaDon();
            HienThi();
            cbo_Tim.Text = "Tìm kiếm theo:";
        }
        //TÌM KIẾM
        public void TimKiem()
        {
            string TimKiemTheo = "", TimKiemThongKe = "";
            if (cbo_Tim.Text == "Mã Nhân Viên")
            {
                TimKiemTheo = "MaNV";
                
            }
            else
            {
                TimKiemTheo = cbo_Tim.Text;
                TimKiemThongKe = txt_TimKiem.Text;
            }
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    string sSQL = "SELECT * FROM NHANVIEN WHERE " + TimKiemTheo + " = @TimKiemThongKe";
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@TimKiemThongKe", TimKiemThongKe);

                        SqlDataAdapter daSanPham = new SqlDataAdapter(cmd);
                        DataSet dsSanPham = new DataSet();
                        daSanPham.Fill(dsSanPham);

                        dgv_HoaDon.DataSource = dsSanPham.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            XemHoaDon();
            HienThi();
            txt_TimKiem.Clear();
            cbo_Tim.Text = "Tìm kiếm theo :";
            dt_Ngay.Visible = false;
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (cbo_Tim .SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TimKiem .Text))
            {
                MessageBox.Show("Bạn chưa điền vào ô tìm kiếm hoặc bạn chọn chức năng tìm kiếm chưa phù hợp.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                TimKiem();
            }
        }

        private void cbo_Tim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Tim.Text == "Ngày")
            {
                dt_Ngay.Visible = true;
            }
            else
            {
                dt_Ngay.Visible = false;
            }
        }

        private void TrangHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
 }
