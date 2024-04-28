using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    internal class dbConnect
    {
        private readonly SqlConnection conn;

        public dbConnect()
        {
            // Thay đổi chuỗi kết nối của bạn tại đây
            conn = new SqlConnection("Data Source=DESKTOP-Q95BECJ;Initial Catalog=QL_BanTraiCayYPShopp;Integrated Security=True");
        }

        // Lấy dữ liệu từ câu lệnh SQL (SELECT)
        public DataTable GetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(strSQL, conn))
            {
                conn.Open();
                da.Fill(dt);
            }
            return dt;
        }

        // Lấy dữ liệu sử dụng stored procedure
        public DataTable GetData(string procName, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    conn.Open();
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Thực thi câu lệnh SQL
        public int ExecuteSQL(string strSQL)
        {
            using (SqlCommand cmd = new SqlCommand(strSQL, conn))
            {
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                return row;
            }
        }

        // Thực thi stored procedure
        public int ExecuteSQL(string procName, SqlParameter[] para)
        {
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);

                conn.Open();
                int row = cmd.ExecuteNonQuery();
                return row;
            }
        }

        // Trả về kết nối
        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
