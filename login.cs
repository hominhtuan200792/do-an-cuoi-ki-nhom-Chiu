
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using libabry_app.Data;
using System.Data.Entity;

namespace libabry_app
{
    public partial class login : Form
    {
        // File lưu tên đăng nhập khi chọn Ghi nhớ
        private static readonly string FileGhiNho = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "libabry_ghinho.txt");

        public login()
        {
            InitializeComponent();

            TestConnection.KiemTraKetNoi();

            txtPass.UseSystemPasswordChar = true;
            AcceptButton = bttLogin;
            Text = "Đăng nhập - Thư viện online";
        }

        private void login_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FileGhiNho))
                {
                    txtTen.Text = File.ReadAllText(FileGhiNho).Trim();
                    ckGhiNho.Checked = true;
                    txtPass.Focus();
                }
            }
            catch
            {
                // Bỏ qua lỗi đọc file ghi nhớ
            }

            rSV.Checked = true;
        }

        // ==========================================
        // ĐĂNG NHẬP
        // ==========================================
        private void bttLogin_Click(object sender, EventArgs e)
        {
            string user = txtTen.Text.Trim();
            string pass = txtPass.Text;

            if (string.IsNullOrWhiteSpace(user))
            {
                TienIch.Loi("Vui lòng nhập tên đăng nhập.");
                txtTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                TienIch.Loi("Vui lòng nhập mật khẩu.");
                txtPass.Focus();
                return;
            }

            string hoTen, maNhom, maSo, email;
            Image avatar;

            if (!SQL_DangNhap(
                user,
                pass,
                out hoTen,
                out maNhom,
                out maSo,
                out email,
                out avatar))
            {
                txtPass.Clear();
                txtPass.Focus();
                return;
            }

            // Kiểm tra loại tài khoản
            bool laAdmin = maNhom == PhienDangNhap.NHOM_ADMIN;

            // Admin không cần chọn Sinh viên hoặc Giảng viên
            if (!laAdmin)
            {
                if (!rSV.Checked && !rGV.Checked)
                {
                    TienIch.Loi(
                        "Vui lòng chọn Sinh viên hoặc Giảng viên.");
                    return;
                }

                bool laSV =
                    maNhom == PhienDangNhap.NHOM_SINHVIEN;

                if (rSV.Checked && !laSV)
                {
                    TienIch.Loi(
                        "Tài khoản này không phải Sinh viên.");
                    return;
                }

                if (rGV.Checked && laSV)
                {
                    TienIch.Loi(
                        "Tài khoản này là Sinh viên, hãy chọn Sinh viên.");
                    return;
                }
            }

            // Lưu thông tin phiên đăng nhập
            PhienDangNhap.HoTen = hoTen;
            PhienDangNhap.MaNhomQuyen = maNhom;
            PhienDangNhap.MaSo = maSo;
            PhienDangNhap.Email = email;
            PhienDangNhap.TenDangNhap = user;
            PhienDangNhap.Avatar = avatar;

            LuuGhiNho(user);

            this.Hide();

            using (Form f = laAdmin
                ? (Form)new Admin()
                : new trangchu())
            {
                f.ShowDialog();
            }

            PhienDangNhap.DangXuat();

            txtPass.Clear();
            this.Show();
        }

        // ==========================================
        // GHI NHỚ TÊN ĐĂNG NHẬP
        // ==========================================
        private void LuuGhiNho(string user)
        {
            try
            {
                if (ckGhiNho.Checked)
                {
                    File.WriteAllText(FileGhiNho, user);
                }
                else if (File.Exists(FileGhiNho))
                {
                    File.Delete(FileGhiNho);
                }
            }
            catch
            {
                // Bỏ qua lỗi ghi file
            }
        }

        // ==========================================
        // ĐĂNG KÝ
        // ==========================================
        private void bttDangKi_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Dangkitaikhoan frmDangKy = new Dangkitaikhoan())
            {
                frmDangKy.ShowDialog();
            }

            this.Show();
        }

        // ==========================================
        // THOÁT
        // ==========================================
        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==========================================
        // CÁC SỰ KIỆN DESIGNER
        // ==========================================
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        // ==========================================
        // HÀM BĂM MẬT KHẨU SHA256
        // ==========================================
        private string BamMatKhau(string matKhau)
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

        // ==========================================
        // KIỂM TRA ĐĂNG NHẬP TỪ DATABASE
        // ==========================================
        private bool SQL_DangNhap(
            string user,
            string pass,
            out string hoTen,
            out string maNhom,
            out string maSo,
            out string email,
            out Image avatar)
        {
            hoTen = "";
            maNhom = "";
            maSo = "";
            email = "";
            avatar = null;

            // Băm mật khẩu vừa nhập
            string matKhauHash = BamMatKhau(pass);

            try
            {
                using (var db = new library_appEntities())
                {
                    // Tìm tài khoản theo tên đăng nhập
                    var taiKhoan = db.TaiKhoans
                        .Include("NguoiDung")
                        .FirstOrDefault(
                            x => x.TenDangNhap == user);

                    // Không tìm thấy tài khoản
                    if (taiKhoan == null)
                    {
                        MessageBox.Show(
                            "Không tìm thấy tên đăng nhập trong CSDL!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    // Kiểm tra trạng thái
                    if (taiKhoan.TrangThai != true)
                    {
                        MessageBox.Show(
                            "Tài khoản hiện đang bị khóa!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    // Kiểm tra mật khẩu
                    if (taiKhoan.MatKhauHash == null ||
                        taiKhoan.MatKhauHash.Trim() != matKhauHash)
                    {
                        MessageBox.Show(
                            "Mật khẩu không khớp với dữ liệu trong CSDL!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    // Lấy nhóm quyền
                    maNhom = taiKhoan.MaNhom.ToString();

                    // ==================================
                    // ADMIN
                    // ==================================
                    // Admin không cần NguoiDung
                    if (taiKhoan.MaNhom == 1)
                    {
                        hoTen = "Quản trị viên";
                        maSo = "";
                        email = "";
                        avatar = null;

                        return true;
                    }

                    // ==================================
                    // SINH VIÊN VÀ GIẢNG VIÊN
                    // ==================================
                    // Hai nhóm này phải có NguoiDung
                    if (taiKhoan.NguoiDung == null)
                    {
                        MessageBox.Show(
                            "Tài khoản chưa liên kết với thông tin người dùng!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    // Lấy thông tin người dùng
                    hoTen = taiKhoan.NguoiDung.HoTen;
                    maSo = taiKhoan.NguoiDung.MaSo;
                    email = taiKhoan.NguoiDung.Email ?? "";

                    // Lấy ảnh đại diện
                    string duongDanAnh =
                        taiKhoan.NguoiDung.AnhDaiDien;

                    if (!string.IsNullOrWhiteSpace(duongDanAnh))
                    {
                        string duongDanDayDu = Path.Combine(
                            Application.StartupPath,
                            duongDanAnh);

                        if (File.Exists(duongDanDayDu))
                        {
                            using (Image anhGoc =
                                Image.FromFile(duongDanDayDu))
                            {
                                avatar = new Bitmap(anhGoc);
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đăng nhập: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}
