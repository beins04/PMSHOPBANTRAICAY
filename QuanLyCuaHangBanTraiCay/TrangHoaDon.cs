using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietHoaDon ql = new ChiTietHoaDon();
            ql.Show();
        }
    }
}
