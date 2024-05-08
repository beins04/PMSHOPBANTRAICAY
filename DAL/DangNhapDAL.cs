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

        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            //select ra chức vụ của tài khoản
            string query = "SELECT ChucVu FROM TAIKHOAN WHERE TenDangNhap = @username AND MatKhau = @password";
            using (SqlConnection connection = db.GetConnection()) // Sử dụng kết nối từ dbConnect
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", tenDangNhap);
                cmd.Parameters.AddWithValue("@password", matKhau);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader != null) // Kiểm tra xem có bản ghi nào phù hợp không
                    {
                        // Chuyển đổi giá trị từ trường MaTK sang kiểu int
                        while (reader.Read())
                        {
                            //Lấy ra chức vụ nếu tài khoản mk đúng
                            return reader[0].ToString();
                        }

                        return "";
                    }

                    return "";
                }
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
