using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DangNhapDAL
    {
        private dbConnect db;

        public DangNhapDAL()
        {
            db = new dbConnect(); // Khởi tạo đối tượng dbConnect
        }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE TenDangNhap = @username AND MatKhau = @password";
            using (SqlConnection connection = db.GetConnection()) // Sử dụng kết nối từ dbConnect
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", tenDangNhap);
                cmd.Parameters.AddWithValue("@password", matKhau);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader.Read(); // Trả về true nếu có bản ghi phù hợp
            }
        }
        public int PhanQuyen(string tenDangNhap, string matKhau)
        {
            int MaTK = 0; // Mặc định không có quyền

            string query = "SELECT MaTK FROM TAIKHOAN WHERE TenDangNhap = @username AND MatKhau = @password";
            using (SqlConnection connection = db.GetConnection()) // Sử dụng kết nối từ dbConnect
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", tenDangNhap);
                cmd.Parameters.AddWithValue("@password", matKhau);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Kiểm tra xem có bản ghi nào phù hợp không
                    {
                        // Chuyển đổi giá trị từ trường MaTK sang kiểu int
                        MaTK = Convert.ToInt32(reader["MaTK"]);
                    }
                }
            }

            return MaTK; // Trả về mã tài khoản, hoặc 0 nếu không có bản ghi phù hợp
        }
    }
}
