using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanTraiCay
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DangNhap());
            //Application.Run(new SanPham());
            //Application.Run(new NhanVien());
            //Application.Run(new DoiMK());
            Application.Run(new KhachHang());
            //Application.Run(new QuanLyKhoHang());
            //Application.Run(new ThongKe());
            //Application.Run(new LapHoaDon());
            //Application.Run(new TaiKhoan());
            //Application.Run(new NhaCungCap());

        }
    }
}
