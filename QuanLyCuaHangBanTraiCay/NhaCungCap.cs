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

        public void XemDanhSach()
        {

            SqlConnection myConnection = new SqlConnection(scon);
            string sSQL = "SELECT MaNCC, TenNCC, DiaChi, SDT, TrangThai FROM NHACUNGCAP; ";
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
            txt_MaNCC.ReadOnly = true;
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
            sTrangThai = chk_TrangThai.Checked ? "1" : "0";

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

        //XÓA NHÀ CUNG CẤP
        public void XoaNhaCungCap()
        {
            string MaNCC = txt_MaNCC.Text;


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

        //SỬA NHÀ CUNG CẤP
        public void SuaNhaCungCap()
        {
            string MaNCC = txt_MaNCC.Text;
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
                string sSQL = "UPDATE NHACUNGCAP SET TenNCC = @TenNCC, DiaChi = @DiaChi, SDT = @SDT, TrangThai = @TrangThai WHERE MaNCC = @MaNCC";

                try
                {
                    myConnection.Open();
                    // Khởi tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sSQL, myConnection))
                    {
                        // Thêm các tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@TenNCC", txt_TenNhaCungCap.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txt_SDT.Text);
                        cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                        cmd.Parameters.AddWithValue("@MaNCC", MaNCC);

                        // Thực thi truy vấn cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bạn đã thay đổi thành công sản phẩm có mã sản phẩm là : " + MaNCC, "Thông báo");
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
        private void btn_SuaNCCcc_Click(object sender, EventArgs e)
        {
            SuaNhaCungCap();
            XemDanhSach();
        }

        private void dgv_NhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_NhaCungCap.CurrentRow.Index;
            txt_MaNCC.Text = dgv_NhaCungCap.Rows[i].Cells[0].Value.ToString();
            txt_TenNhaCungCap.Text = dgv_NhaCungCap.Rows[i].Cells[1].Value.ToString();
            txt_DiaChi.Text = dgv_NhaCungCap.Rows[i].Cells[2].Value.ToString();
            txt_SDT.Text = dgv_NhaCungCap.Rows[i].Cells[3].Value.ToString();
            if ((bool)dgv_NhaCungCap.Rows[i].Cells[4].Value == false)
            {
                chk_TrangThai.Checked = false;
            }
            else
            {
                chk_TrangThai.Checked = true;
            }
        }
        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
            //TrangQuanLy  ql = new TrangQuanLy();
            //ql.Show();
        }

        
    }
}
