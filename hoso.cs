using System;
using System.Drawing;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class hoso : Form
    {
        public hoso()
        {
            InitializeComponent();
            Text = "Hồ sơ";
            StartPosition = FormStartPosition.CenterParent;
        }

        private void hoso_Load(object sender, EventArgs e)
        {
            lichsudamuon_button.Visible = PhienDangNhap.LaSinhVien;
            HienThongTin();
        }

        // Đổ thông tin người đang đăng nhập lên form
        private void HienThongTin()
        {
            // Chưa đăng nhập thì TenDangNhap sẽ là null
            if (string.IsNullOrEmpty(PhienDangNhap.TenDangNhap))
            {
                MessageBox.Show("Chưa đăng nhập.");
                Close();
                return;
            }

            lbTenUser.Text = PhienDangNhap.HoTen;
            lbTenLoginUser.Text = PhienDangNhap.TenDangNhap;
            

            // MaSo là MSSV (sinh viên) hoặc mã giảng viên
            lbMSSV.Text = (PhienDangNhap.LaSinhVien
                ? "Mã số sinh viên: "
                : "Mã số: ") + PhienDangNhap.MaSo;

            // Có ảnh riêng thì dùng, không thì giữ ảnh mặc định trong Designer
            if (PhienDangNhap.Avatar != null)
                pictureBox1.Image = PhienDangNhap.Avatar;
        }

        // Đổi ảnh đại diện
        private void bttDoiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                using (Image tmp = Image.FromFile(ofd.FileName))
                {
                    Bitmap anhMoi = new Bitmap(tmp);   // sao chép để không khóa file
                    pictureBox1.Image = anhMoi;
                    PhienDangNhap.Avatar = anhMoi;
                }
            }
            MessageBox.Show("Đã đổi ảnh đại diện.");
        }

        private void lichsudamuon_button_Click(object sender, EventArgs e)
        {
            
            TienIch.MoModal(this, new Lichsu());
            
        }

        private void doimatkhau_Click(object sender, EventArgs e)
        {
            using (Doimatkhau f = new Doimatkhau())
            {
                f.ShowDialog(this);
            }
        }

        private void thoat_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lbMSSV_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void thoat_button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doimatkhau_Click_1(object sender, EventArgs e)
        {
            Doimatkhau frm = new Doimatkhau();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button1_dangxuat_Click(object sender, EventArgs e)
        {
            login frmLogin = new login();
            frmLogin.Show();

           
            foreach (Form f in Application.OpenForms)
            {
                if (f != frmLogin)
                {
                    f.Hide(); 
                }
            }
        }
    }
}