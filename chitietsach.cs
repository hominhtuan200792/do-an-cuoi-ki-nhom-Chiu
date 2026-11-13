using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class chitietsach : Form
    {
        public chitietsach(
        Image anh,
        string tenSach,
        string tacGia,
        string theLoai,
        string moTa)
        {
            InitializeComponent();
            picsach.Image = anh;

            lbMasach.Text = tenSach;

            lbTacGiaSach.Text = tacGia;

            lbTheLoaiSach.Text = theLoai;

            rbMoTa.Text = moTa;
        }
        public chitietsach(sach s)
        {
            InitializeComponent();
            if (s.AnhBia != null) picsach.Image = s.AnhBia;
            lbTenSach.Text = s.TenSach;
            lbMasach.Text = s.MaSach;
            lbTacGiaSach.Text = s.TacGia;
            lbTheLoaiSach.Text = s.TheLoai;
            rbMoTa.Text = s.MoTa;
            rbMoTa.ReadOnly = true;
            btClose.Click += (o, e) => Close();
        }
        private void grbxThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void rbMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void picsach_Click(object sender, EventArgs e)
        {

        }

        private void lbMasach_Click(object sender, EventArgs e)
        {

        }
    }
}
