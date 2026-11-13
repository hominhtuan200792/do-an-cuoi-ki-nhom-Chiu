
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using libabry_app.Data;

namespace libabry_app
{
    public partial class Quanlyuser : Form
    {
        private const string TAT_CA = "Tất cả";
        private const string HOAT_DONG = "Hoạt Động";
        private const string KHOA = "Khóa";
        private const string MAT_KHAU_MAC_DINH = "123456";

        private List<TaiKhoanUser> dsTK = new List<TaiKhoanUser>();
        private List<string> dsNhom = new List<string>();

        private bool dangNap = false;

        public Quanlyuser()
        {
            InitializeComponent();

            Text = "Quản lý tài khoản";
            StartPosition = FormStartPosition.CenterParent;

            Load += Quanlyuser_Load;

            button1.Click += button1_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;

            cbLocNhom.SelectedIndexChanged += Loc_Changed;
            cbLocTrangThai.SelectedIndexChanged += Loc_Changed;

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            bttThem.Click += bttThem_Click;
            bttSua.Click += bttSua_Click;
            bttXoa.Click += bttXoa_Click;
            bttKhoa.Click += bttKhoa_Click;
            bttMoKhoa.Click += bttMoKhoa_Click;
            bttDatLaiMK.Click += bttDatLaiMK_Click;
            bttLamMoi.Click += bttLamMoi_Click;

            rbNhanVien.CheckedChanged += GanVoi_Changed;
            rbDocGia.CheckedChanged += GanVoi_Changed;
        }

        // =====================================================
        // KHỞI TẠO FORM
        // =====================================================

        private void Quanlyuser_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            txtMaTK.ReadOnly = true;

            // Đổi nội dung hai lựa chọn gắn với
            rbNhanVien.Text = "Giảng viên";
            rbDocGia.Text = "Sinh viên";

            cbNhomQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocNhom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Clear();
            comboBox1.Items.Add(HOAT_DONG);
            comboBox1.Items.Add(KHOA);

            cbLocTrangThai.Items.Clear();
            cbLocTrangThai.Items.Add(TAT_CA);
            cbLocTrangThai.Items.Add(HOAT_DONG);
            cbLocTrangThai.Items.Add(KHOA);
            cbLocTrangThai.SelectedIndex = 0;

            // Lấy nhóm quyền từ database
            NapNhomQuyen();

            // Lấy tài khoản từ database
            TaiDanhSach();

            HienLuoi();
            LamMoi();
        }

        // =====================================================
        // NẠP NHÓM QUYỀN
        // =====================================================

        private void NapNhomQuyen()
        {
            using (library_appEntities db = new library_appEntities())
            {
                dsNhom = db.NhomQuyens
                    .Select(n => n.TenNhom)
                    .ToList();
            }

            cbNhomQuyen.Items.Clear();
            cbNhomQuyen.Items.AddRange(dsNhom.Cast<object>().ToArray());

            cbLocNhom.Items.Clear();
            cbLocNhom.Items.Add(TAT_CA);
            cbLocNhom.Items.AddRange(dsNhom.Cast<object>().ToArray());

            cbLocNhom.SelectedIndex = 0;
        }

        // =====================================================
        // NẠP TÀI KHOẢN TỪ DATABASE
        // =====================================================

        private void TaiDanhSach()
        {
            using (library_appEntities db = new library_appEntities())
            {
                dsTK = db.TaiKhoans
                    .Include(t => t.NguoiDung)
                    .Include(t => t.NhomQuyen)
                    .ToList()
                    .Select(t => new TaiKhoanUser
                    {
                        MaTK = t.MaTK,
                        TenDN = t.TenDangNhap,

                        HoTen = t.NguoiDung != null
                            ? t.NguoiDung.HoTen
                            : "Quản trị hệ thống",

                        MaNhom = t.MaNhom,
                        NhomQuyen = t.NhomQuyen != null
                            ? t.NhomQuyen.TenNhom
                            : "",

                        MaNguoiDung = t.MaNguoiDung,

                        GanVoi = t.NguoiDung != null
                            ? t.NguoiDung.LoaiNguoiDung
                            : "",

                        TrangThai = t.TrangThai
                            ? HOAT_DONG
                            : KHOA
                    })
                    .ToList();
            }
        }

        // =====================================================
        // HIỂN THỊ VÀ TÌM KIẾM
        // =====================================================

        private void HienLuoi()
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            string nhom = cbLocNhom.SelectedItem as string;
            string trangThai = cbLocTrangThai.SelectedItem as string;

            IEnumerable<TaiKhoanUser> ds = dsTK;

            // Tìm theo tên đăng nhập, mã tài khoản hoặc họ tên
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                ds = ds.Where(t =>
                    t.TenDN.IndexOf(
                        tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    ||
                    t.MaTK.ToString().Contains(tuKhoa)
                    ||
                    t.HoTen.IndexOf(
                        tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            if (!string.IsNullOrEmpty(nhom) && nhom != TAT_CA)
                ds = ds.Where(t => t.NhomQuyen == nhom);

            if (!string.IsNullOrEmpty(trangThai) && trangThai != TAT_CA)
                ds = ds.Where(t => t.TrangThai == trangThai);

            dangNap = true;

            dataGridView1.Rows.Clear();

            foreach (TaiKhoanUser t in ds)
            {
                int i = dataGridView1.Rows.Add(
                    t.MaTK,
                    t.TenDN,
                    t.HoTen,
                    t.NhomQuyen,
                    t.TrangThai
                );

                // Lưu đối tượng tài khoản vào dòng tương ứng
                dataGridView1.Rows[i].Tag = t;

                if (t.TrangThai == KHOA)
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor =
                        Color.Gray;
            }

            dataGridView1.ClearSelection();

            dangNap = false;
        }

        private TaiKhoanUser TaiKhoanDangChon()
        {
            if (dataGridView1.CurrentRow == null)
                return null;

            return dataGridView1.CurrentRow.Tag as TaiKhoanUser;
        }

        // =====================================================
        // HIỂN THỊ THÔNG TIN CHI TIẾT
        // =====================================================

        private void dataGridView1_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dangNap) return;

            TaiKhoanUser t = TaiKhoanDangChon();

            if (t == null) return;

            txtMaTK.Text = t.MaTK.ToString();
            txtTenDN.Text = t.TenDN;

            cbNhomQuyen.SelectedItem = t.NhomQuyen;

            rbNhanVien.Checked = t.GanVoi == "GiangVien";
            rbDocGia.Checked = t.GanVoi == "SinhVien";

            comboBox1.SelectedItem = t.TrangThai;
        }

        private void LamMoi()
        {
            txtMaTK.Text = "Tự động";
            txtTenDN.Clear();

            cbNhomQuyen.SelectedIndex = -1;

            rbNhanVien.Checked = false;
            rbDocGia.Checked = false;

            comboBox1.SelectedItem = HOAT_DONG;

            dataGridView1.ClearSelection();

            txtTenDN.Focus();
        }

        // =====================================================
        // XỬ LÝ GẮN VỚI GIẢNG VIÊN / SINH VIÊN
        // =====================================================

        private void GanVoi_Changed(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb == null || !cb.Checked)
                return;

            if (cb == rbNhanVien)
                rbDocGia.Checked = false;
            else
                rbNhanVien.Checked = false;
        }

        private string LayGanVoi()
        {
            if (rbNhanVien.Checked)
                return "GiangVien";

            if (rbDocGia.Checked)
                return "SinhVien";

            return "";
        }

        // =====================================================
        // KIỂM TRA DỮ LIỆU
        // =====================================================

        private bool KiemTra(string tenDangNhap, int maBoQua)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.");
                txtTenDN.Focus();
                return false;
            }

            using (library_appEntities db = new library_appEntities())
            {
                bool trung = db.TaiKhoans.Any(t =>
                    t.TenDangNhap == tenDangNhap &&
                    t.MaTK != maBoQua);

                if (trung)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                    txtTenDN.Focus();
                    return false;
                }
            }

            if (cbNhomQuyen.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền.");
                cbNhomQuyen.Focus();
                return false;
            }

            string nhom = cbNhomQuyen.SelectedItem.ToString();

            if (nhom != "Quản trị viên" && LayGanVoi() == "")
            {
                MessageBox.Show("Vui lòng chọn Giảng viên hoặc Sinh viên.");
                return false;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.");
                comboBox1.Focus();
                return false;
            }

            return true;
        }

        // =====================================================
        // LẤY NGƯỜI DÙNG ĐƯỢC GẮN VỚI TÀI KHOẢN
        // =====================================================

        private int? LayMaNguoiDung(string loaiNguoiDung)
        {
            if (loaiNguoiDung == "")
                return null;

            string maSo = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập mã số của " +
                (loaiNguoiDung == "GiangVien" ? "giảng viên" : "sinh viên")
                + ":",
                "Gắn tài khoản với người dùng"
            ).Trim();

            if (maSo == "")
                return null;

            using (library_appEntities db = new library_appEntities())
            {
                var nguoiDung = db.NguoiDungs.FirstOrDefault(n =>
                    n.MaSo == maSo &&
                    n.LoaiNguoiDung == loaiNguoiDung);

                if (nguoiDung == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy người dùng phù hợp với mã số đã nhập."
                    );
                    return null;
                }

                return nguoiDung.MaNguoiDung;
            }
        }

        private string BamMatKhau(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(matKhau);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        // =====================================================
        // TÌM KIẾM
        // =====================================================

        private void button1_Click(object sender, EventArgs e)
        {
            HienLuoi();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài khoản phù hợp.");
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienLuoi();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Loc_Changed(object sender, EventArgs e)
        {
            if (!dangNap)
                HienLuoi();
        }

        // =====================================================
        // THÊM TÀI KHOẢN
        // =====================================================

        private void bttThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenDN.Text.Trim();

            if (!KiemTra(ten, 0))
                return;

            string nhom = cbNhomQuyen.SelectedItem.ToString();

            string loaiNguoiDung =
                nhom == "Quản trị viên" ? "" : LayGanVoi();

            int? maNguoiDung = null;

            if (loaiNguoiDung != "")
            {
                maNguoiDung = LayMaNguoiDung(loaiNguoiDung);

                if (maNguoiDung == null)
                    return;
            }

            using (library_appEntities db = new library_appEntities())
            {
                var nhomQuyen = db.NhomQuyens.FirstOrDefault(
                    n => n.TenNhom == nhom);

                if (nhomQuyen == null)
                {
                    MessageBox.Show("Không tìm thấy nhóm quyền trong database.");
                    return;
                }

                TaiKhoan tk = new TaiKhoan();

                tk.TenDangNhap = ten;
                tk.MatKhauHash = BamMatKhau(MAT_KHAU_MAC_DINH);
                tk.MaNhom = nhomQuyen.MaNhom;
                tk.MaNguoiDung = maNguoiDung;
                tk.TrangThai =
                    comboBox1.SelectedItem.ToString() == HOAT_DONG;

                db.TaiKhoans.Add(tk);
                db.SaveChanges();
            }

            TaiDanhSach();
            HienLuoi();
            LamMoi();

            MessageBox.Show(
                "Thêm tài khoản thành công.\nMật khẩu mặc định: "
                + MAT_KHAU_MAC_DINH
            );
        }

        // =====================================================
        // SỬA TÀI KHOẢN
        // =====================================================

        private void bttSua_Click(object sender, EventArgs e)
        {
            TaiKhoanUser dangChon = TaiKhoanDangChon();

            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa.");
                return;
            }

            string ten = txtTenDN.Text.Trim();

            if (!KiemTra(ten, dangChon.MaTK))
                return;

            string nhom = cbNhomQuyen.SelectedItem.ToString();

            string loaiNguoiDung =
                nhom == "Quản trị viên" ? "" : LayGanVoi();

            using (library_appEntities db = new library_appEntities())
            {
                TaiKhoan tk = db.TaiKhoans.FirstOrDefault(
                    t => t.MaTK == dangChon.MaTK);

                if (tk == null)
                {
                    MessageBox.Show("Tài khoản không còn tồn tại.");
                    return;
                }

                var nhomQuyen = db.NhomQuyens.FirstOrDefault(
                    n => n.TenNhom == nhom);

                if (nhomQuyen == null)
                {
                    MessageBox.Show("Không tìm thấy nhóm quyền.");
                    return;
                }

                int? maNguoiDung = null;

                if (loaiNguoiDung != "")
                {
                    // Giữ liên kết cũ nếu đúng loại người dùng
                    var nguoiDungCu = tk.MaNguoiDung.HasValue
                        ? db.NguoiDungs.FirstOrDefault(
                            n => n.MaNguoiDung == tk.MaNguoiDung.Value)
                        : null;

                    if (nguoiDungCu != null &&
                        nguoiDungCu.LoaiNguoiDung == loaiNguoiDung)
                    {
                        maNguoiDung = nguoiDungCu.MaNguoiDung;
                    }
                    else
                    {
                        maNguoiDung = LayMaNguoiDung(loaiNguoiDung);

                        if (maNguoiDung == null)
                            return;
                    }
                }

                tk.TenDangNhap = ten;
                tk.MaNhom = nhomQuyen.MaNhom;
                tk.MaNguoiDung = maNguoiDung;
                tk.TrangThai =
                    comboBox1.SelectedItem.ToString() == HOAT_DONG;

                db.SaveChanges();
            }

            TaiDanhSach();
            HienLuoi();
            LamMoi();

            MessageBox.Show("Cập nhật tài khoản thành công.");
        }

        // =====================================================
        // XÓA TÀI KHOẢN
        // =====================================================

        private void bttXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanUser dangChon = TaiKhoanDangChon();

            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa tài khoản "
                + dangChon.TenDN + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            using (library_appEntities db = new library_appEntities())
            {
                TaiKhoan tk = db.TaiKhoans.FirstOrDefault(
                    t => t.MaTK == dangChon.MaTK);

                if (tk == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return;
                }

                db.TaiKhoans.Remove(tk);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Không thể xóa tài khoản vì dữ liệu đang được sử dụng "
                        + "ở bảng khác. Bạn nên khóa tài khoản thay vì xóa."
                    );
                    return;
                }
            }

            TaiDanhSach();
            HienLuoi();
            LamMoi();

            MessageBox.Show("Đã xóa tài khoản.");
        }

        // =====================================================
        // KHÓA / MỞ KHÓA TÀI KHOẢN
        // =====================================================

        private void DoiTrangThai(bool trangThaiMoi)
        {
            TaiKhoanUser dangChon = TaiKhoanDangChon();

            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản trong danh sách.");
                return;
            }

            if (dangChon.TrangThai == (trangThaiMoi ? HOAT_DONG : KHOA))
            {
                MessageBox.Show("Tài khoản đã ở trạng thái này.");
                return;
            }

            using (library_appEntities db = new library_appEntities())
            {
                TaiKhoan tk = db.TaiKhoans.FirstOrDefault(
                    t => t.MaTK == dangChon.MaTK);

                if (tk == null)
                    return;

                tk.TrangThai = trangThaiMoi;
                db.SaveChanges();
            }

            TaiDanhSach();
            HienLuoi();
            LamMoi();

            MessageBox.Show("Đã cập nhật trạng thái tài khoản.");
        }

        private void bttKhoa_Click(object sender, EventArgs e)
        {
            DoiTrangThai(false);
        }

        private void bttMoKhoa_Click(object sender, EventArgs e)
        {
            DoiTrangThai(true);
        }

        // =====================================================
        // ĐẶT LẠI MẬT KHẨU
        // =====================================================

        private void bttDatLaiMK_Click(object sender, EventArgs e)
        {
            TaiKhoanUser dangChon = TaiKhoanDangChon();

            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Đặt lại mật khẩu của tài khoản "
                + dangChon.TenDN + " về mặc định?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            using (library_appEntities db = new library_appEntities())
            {
                TaiKhoan tk = db.TaiKhoans.FirstOrDefault(
                    t => t.MaTK == dangChon.MaTK);

                if (tk == null)
                    return;

                tk.MatKhauHash = BamMatKhau(MAT_KHAU_MAC_DINH);

                db.SaveChanges();
            }

            MessageBox.Show(
                "Đã đặt lại mật khẩu.\nMật khẩu mới: "
                + MAT_KHAU_MAC_DINH
            );
        }

        // =====================================================
        // LÀM MỚI
        // =====================================================

        private void bttLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            dangNap = true;

            cbLocNhom.SelectedIndex = 0;
            cbLocTrangThai.SelectedIndex = 0;

            dangNap = false;

            TaiDanhSach();
            HienLuoi();
            LamMoi();
        }

        // =====================================================
        // CÁC SỰ KIỆN ĐƯỢC DESIGNER GẮN SẴN
        // =====================================================

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // =========================================================
    // LỚP DỮ LIỆU HIỂN THỊ TRÊN FORM
    // =========================================================

    public class TaiKhoanUser
    {
        public int MaTK { get; set; }
        public string TenDN { get; set; }
        public string HoTen { get; set; }
        public int MaNhom { get; set; }
        public string NhomQuyen { get; set; }
        public int? MaNguoiDung { get; set; }
        public string GanVoi { get; set; }
        public string TrangThai { get; set; }
    }
}
