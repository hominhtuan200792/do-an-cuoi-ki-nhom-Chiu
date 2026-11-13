using System;
using System.Drawing;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class CardBook : UserControl
    {
        
        public sach DuLieuSach { get; set; }

        public CardBook()
        {
            InitializeComponent();
        }

        public string TenSach { get => lblTenSach.Text; set => lblTenSach.Text = value; }
        public string TacGia { get => lblTacGia.Text; set => lblTacGia.Text = value; }
        public string TheLoai { get => lblTheLoai.Text; set => lblTheLoai.Text = value; }
        public string Ma { get => lblMa.Text; set => lblMa.Text = value; }
        public Image AnhBia { get => picBook.Image; set => picBook.Image = value; }
        public int SoLuong { set => lblSoLuong.Text = "Số lượng: " + value; }

        private void CardBook_Load(object sender, EventArgs e) { }
        private void picBook_Click(object sender, EventArgs e) { }
        private void lblTheLoai_Click(object sender, EventArgs e) { }
        public void HienThiSach(sach s)
        {
            DuLieuSach = s;
            TenSach = s.TenSach;
            TacGia = s.TacGia;
            TheLoai = s.TheLoai;
            Ma = "Mã: " + s.MaSach;
            SoLuong = s.SoLuong;
            AnhBia = s.AnhBia;
        }
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (DuLieuSach == null) return;
            using (chitietsach frm = new chitietsach(DuLieuSach))
            {
                frm.ShowDialog();
            }
        }

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }
    }
}