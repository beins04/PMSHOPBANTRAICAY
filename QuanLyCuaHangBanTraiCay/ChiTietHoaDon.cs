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
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void btn_TaoMoiHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangHoaDon ql = new TrangHoaDon();
            ql.Show();
        }
    }
}
