using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanTraiCay
{
    public static class DP
    {
        private static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-C5AR9CK3;Initial Catalog=SHOPBANGIAY;Integrated Security=True");
        public static DataTable query(string query)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable res = new DataTable();
                adapter.Fill(res);
                conn.Close();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable queryProc(string proc, string[] paras = null, string[] value = null)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(proc, conn);
                command.CommandType = CommandType.StoredProcedure;

                if (paras != null && value != null)
                {
                    for (int i = 0; i < paras.Length; i++)
                    {
                        SqlParameter p = new SqlParameter("@" + paras[i], value[i]);
                        p.Direction = ParameterDirection.Input;
                        p.DbType = DbType.String;
                        command.Parameters.Add(p);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable res = new DataTable();
                adapter.Fill(res);
                conn.Close();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
