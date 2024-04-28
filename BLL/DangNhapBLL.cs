using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class DangNhapBLL
    {
        protected DangNhapDAL dangNhapDAL = new DangNhapDAL();

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return dangNhapDAL.KiemTraDangNhap(tenDangNhap, matKhau); // Gọi phương thức từ DAL
        }
        public int PhanQuyen(string tenDangNhap, string matKhau)
        {
            return dangNhapDAL.PhanQuyen(tenDangNhap, matKhau); // Gọi phương thức từ DAL
        }
    }
}
