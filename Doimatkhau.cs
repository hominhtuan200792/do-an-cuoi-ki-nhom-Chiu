
using System;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using libabry_app.Data;

namespace libabry_app
{
    public partial class Doimatkhau : Form
    {
        private string MaHoaMatKhau(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] duLieu = Encoding.UTF8.GetBytes(matKhau);
                byte[] ketQua = sha.ComputeHash(duLieu);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in ketQua)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        public Doimatkhau()
        {
            InitializeComponent();
        }

        private void Doimatkhau_Load(object sender, EventArgs e)
        {
            matkhauhientai_textbox.UseSystemPasswordChar = true;
            nhapmatkhaumoi_textbox.UseSystemPasswordChar = true;
            nhaplaimatkhau_textbox.UseSystemPasswordChar = true;
        }

        private void matkhauhientai_TextChanged(object sender, EventArgs e)
        {

        }

        private void doimatkhau_button_Click(object sender, EventArgs e)
        {
            string matKhauHienTai = matkhauhientai_textbox.Text;
            string matKhauMoi = nhapmatkhaumoi_textbox.Text;
            string nhapLaiMatKhau = nhaplaimatkhau_textbox.Text;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(matKhauHienTai) ||
                string.IsNullOrWhiteSpace(matKhauMoi) ||
                string.IsNullOrWhiteSpace(nhapLaiMatKhau))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Kiểm tra mật khẩu mới và mật khẩu hiện tại
            if (matKhauHienTai == matKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!");
                return;
            }

            // Kiểm tra nhập lại mật khẩu
            if (matKhauMoi != nhapLaiMatKhau)
            {
                MessageBox.Show(
                    "Mật khẩu mới nhập lại không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (var db = new library_appEntities())
                {
                    // Tìm tài khoản đang đăng nhập
                    string tenDangNhap = PhienDangNhap.TenDangNhap;

                    var taiKhoan = db.TaiKhoans
                        .FirstOrDefault(x => x.TenDangNhap == tenDangNhap);

                    if (taiKhoan == null)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản!");
                        return;
                    }

                    // Kiểm tra mật khẩu hiện tại
                    string hashHienTai = MaHoaMatKhau(matKhauHienTai);

                    if (taiKhoan.MatKhauHash != hashHienTai)
                    {
                        MessageBox.Show(
                            "Mật khẩu hiện tại không chính xác!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // Mã hóa mật khẩu mới
                    string hashMoi = MaHoaMatKhau(matKhauMoi);

                    // Cập nhật mật khẩu vào CSDL
                    taiKhoan.MatKhauHash = hashMoi;

                    db.SaveChanges();

                    MessageBox.Show(
                        "Đổi mật khẩu thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Xóa dữ liệu trên các ô nhập
                    matkhauhientai_textbox.Clear();
                    nhapmatkhaumoi_textbox.Clear();
                    nhaplaimatkhau_textbox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi đổi mật khẩu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}