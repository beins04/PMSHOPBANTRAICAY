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

            string sSQL = "SELECT MaTK FROM TAIKHOAN";

            try
            {
                myConnection.Open();

                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sSQL, myConnection);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds);

                myConnection.Close();

                cbo_MaTK.DataSource = ds.Tables[0];
                cbo_MaTK.DisplayMember = "MaTK";
                cbo_MaTK.ValueMember = "MaTK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi. Chi tiet: " + ex.Message);
            }
        }
        public void XemDanhSach()
        {
            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaNV, MaTK, TenNV, DiaChi, GioiTinh, SDT FROM NHANVIEN;";
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
            XemDanhSach();
            hienThi();
        }

        //THÊM NHÂN VIÊN
        public bool ThemNhanVien(int iMaTK, string sTenNV, string sDiaChi, string sGioiTinh, string sSDT)
        {

            bool kq;
            kq = true;

            SqlConnection myConnection = new SqlConnection(scon);
            string sSql = string.Format("INSERT INTO NHANVIEN VALUES ('{0}', N'{1}', N'{2}', N'{3}',N'{4}')", iMaTK, sTenNV, sDiaChi, sGioiTinh, sSDT);
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
            int iMaTK;

            sTenNhanVien = txt_TenNV.Text;
            sDiaChi = txt_DiaChiNV.Text;
            sSDT = txt_SDTNV.Text;
            sGioiTinh = rad_Nam.Checked ? "Nam" : "Nữ";
            iMaTK = (int)cbo_MaTK.SelectedValue;

            bool kq = ThemNhanVien(iMaTK, sTenNhanVien, sDiaChi, sGioiTinh, sSDT);
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
        public void XoaNhanVien()
        {
            string MaNV = txt_MaNV.Text;


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
            XoaNhanVien();
            XemDanhSach();
        }

        //SỬA NHÂN VIÊN
        public void SuaNhanVien()
        {
            string MaNV = txt_MaNV.Text;

            // Khởi tạo kết nối
            using (SqlConnection myConnection = new SqlConnection(scon))
            {
                // Chuỗi truy vấn cập nhật
                string sSQL = "UPDATE NHANVIEN SET MaTK = @MaTK, TenNV = @TenNV, DiaChi = @DiaChi, GioiTinh = @GioiTinh, SDT = @SDT WHERE MaNV = @MaNV";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@TenNV", txt_TenNV.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChiNV.Text);
                        if (rad_Nam.Checked)
                        {
                            cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                        }
                        cmd.Parameters.AddWithValue("@SDT", txt_SDTNV.Text);
                        cmd.Parameters.AddWithValue("@MaTK", cbo_MaTK.Text);
                        cmd.Parameters.AddWithValue("@MaNV", MaNV);
                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công sản phẩm có mã sản phẩm là : " + MaNV, "Thông báo");
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
        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            SuaNhanVien();
            XemDanhSach();
        }

        private void btn_QuayLaiTrangNV_Click(object sender, EventArgs e)
        {
            this.Close();
            //TrangQuanLy ql = new TrangQuanLy();
            //ql.Show();
        }

        private void dgv_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_NhanVien.CurrentRow.Index;
            txt_MaNV.Text = dgv_NhanVien.Rows[i].Cells[0].Value.ToString();
            cbo_MaTK.Text = dgv_NhanVien.Rows[i].Cells[1].Value.ToString();
            txt_TenNV.Text = dgv_NhanVien.Rows[i].Cells[2].Value.ToString();
            txt_DiaChiNV.Text = dgv_NhanVien.Rows[i].Cells[3].Value.ToString();
            txt_SDTNV.Text = dgv_NhanVien.Rows[i].Cells[5].Value.ToString();
            string gioiTinhValue = (string)dgv_NhanVien.Rows[i].Cells[4].Value;
            if (gioiTinhValue == "Nam")
            {
                rad_Nam.Checked = true;
            }
            else
            {
                rad_Nu.Checked = true;
            }
        }

        //TÌM KIẾM
        public void TimKiem()
        {
            string TimKiemTheo = "", TimKiemThongKe = "";

            TimKiemTheo = cbo_TimKiem.Text;
            TimKiemThongKe = txt_TiemKiemNV.Text;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(scon))
                {
                    string sSQLs = "SELECT * FROM NHANVIEN WHERE " + TimKiemTheo + " = @TimKiemThongKe";
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQLs, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@TimKiemThongKe", TimKiemThongKe);

                        SqlDataAdapter daSP = new SqlDataAdapter(cmd);
                        DataSet dsSP = new DataSet();
                        daSP.Fill(dsSP);

                        dgv_NhanVien.DataSource = dsSP.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi. Chi tiết: " + ex.Message);
            }
        }

        private void btn_TimKiemNV_Click(object sender, EventArgs e)
        {
            if (cbo_TimKiem.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_TiemKiemNV.Text))
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
