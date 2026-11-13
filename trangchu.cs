using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace libabry_app
{
    // Trang chủ: danh sách sách (card), tìm kiếm, lọc theo thể loại.
    // Cần có sẵn: DuLieu, SachDAL (LayTatCa, LayTheLoai), sach, CardBook, PhienDangNhap,
    //             chinhsua, hoso, TienIch, Thongke.
    public partial class trangchu : Form
    {
        private string theLoaiDangChon = "";

        // Các control Designer chưa có -> tạo bằng code
        private Button bttFix;                 // nút sửa sách (chỉ người quản lý)
        private Button bttThongKe;             // nút thống kê (chỉ người quản lý)
        private FlowLayoutPanel flowDanhMuc;   // chứa các nút thể loại
        private Timer timerTim;                // trì hoãn khi gõ ô tìm kiếm

        public trangchu()
        {
            InitializeComponent();
            Text = "Thư viện Online";

            TaoControlBoSung();
            NoiSuKien();
        }

        // ===================== KHỞI TẠO =====================

        private void TaoControlBoSung()
        {
            // --- nút sửa sách ---
            bttFix = new Button();
            bttFix.Name = "bttFix";
            bttFix.Size = new Size(42, 42);
            bttFix.Location = new Point(595, 44);
            bttFix.UseVisualStyleBackColor = true;
            Image icon = Properties.Resources.fix_icon_34;
            if (icon != null)
            {
                bttFix.Image = new Bitmap(icon, new Size(bttFix.Width - 10, bttFix.Height - 10));
                bttFix.Text = "";
            }
            else bttFix.Text = "Sửa";
            panelHead.Controls.Add(bttFix);

            // --- nút thống kê ---
            bttThongKe = new Button();
            bttThongKe.Name = "bttThongKe";
            bttThongKe.Text = "Thống kê";
            bttThongKe.Size = new Size(90, 29);
            bttThongKe.Location = new Point(647, 50);
            bttThongKe.UseVisualStyleBackColor = true;
            panelHead.Controls.Add(bttThongKe);

            // --- khung chứa nút thể loại (không đè lên "Mượn sách"/"Trả sách") ---
            flowDanhMuc = new FlowLayoutPanel();
            flowDanhMuc.Location = new Point(240, 6);
            flowDanhMuc.Size = new Size(panelDanhMuc.Width - 250, 42);
            flowDanhMuc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowDanhMuc.WrapContents = false;
            flowDanhMuc.AutoScroll = true;
            flowDanhMuc.BackColor = Color.Transparent;
            panelDanhMuc.Controls.Add(flowDanhMuc);

            // --- timer tìm kiếm ---
            timerTim = new Timer();
            timerTim.Interval = 300;
            timerTim.Tick += (o, e) => { timerTim.Stop(); LocVaHienThi(); };
            FormClosed += (o, e) => timerTim.Dispose();
        }

        private void NoiSuKien()
        {
            bttFix.Click += bttFix_Click;
            bttThongKe.Click += bttThongKe_Click;
            bttMuonSach.Click += bttMuonSach_Click;
            bttTraSach.Click += bttTraSach_Click;
            label1.Click += HuongDan_Click;
            pictureBox1.Click += HuongDan_Click;

            label1.Cursor = Cursors.Hand;
            pictureBox1.Cursor = Cursors.Hand;
            picAvatar.Cursor = Cursors.Hand;

            // Enter trong ô tìm kiếm = bấm "Tìm Kiếm"
            textBox1.KeyDown += (o, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    timerTim.Stop();
                    LocVaHienThi();
                }
            };
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            ApDungNguoiDung();
            LamMoiDanhSach();     // đã gồm TaoDanhMuc + LocVaHienThi
        }

        private void ApDungNguoiDung()
        {
            lbTen.Text = string.IsNullOrEmpty(PhienDangNhap.HoTen)
                ? "Khách"
                : PhienDangNhap.HoTen;

            if (PhienDangNhap.Avatar != null)
                picAvatar.Image = PhienDangNhap.Avatar;

            // Chỉ người không phải sinh viên mới thấy nút quản lý
            bool quanLy = !PhienDangNhap.LaSinhVien;
            bttFix.Visible = quanLy;
            bttThongKe.Visible = quanLy;
        }

        // ===================== DỮ LIỆU =====================

        // Gọi lại sau khi thêm/sửa/xóa sách (form chinhsua dùng hàm này)
        public void LamMoiDanhSach()
        {
            try
            {
                DuLieu.DanhSachSach = SachDAL.LayTatCa();
            }
            catch (Exception ex)
            {
                TienIch.Loi("Không tải được danh sách sách: " + ex.Message);
                if (DuLieu.DanhSachSach == null) DuLieu.DanhSachSach = new List<sach>();
            }

            TaoDanhMuc();
            LocVaHienThi();
        }

        private void TaoDanhMuc()
        {
            List<string> ten = new List<string>();
            ten.Add("Tất cả");

            try
            {
                foreach (var tl in SachDAL.LayTheLoai())
                {
                    string t = (tl.TenTheLoai ?? "").Trim();
                    if (t != "" && !ten.Contains(t)) ten.Add(t);
                }
            }
            catch (Exception ex)
            {
                TienIch.Loi("Không tải được thể loại: " + ex.Message);
            }

            // Thể loại đang chọn không còn tồn tại -> về "Tất cả"
            if (theLoaiDangChon != "" && !ten.Contains(theLoaiDangChon))
                theLoaiDangChon = "";

            flowDanhMuc.SuspendLayout();
            foreach (Control c in flowDanhMuc.Controls.Cast<Control>().ToList()) c.Dispose();

            foreach (string t in ten)
            {
                Button b = new Button();
                b.Text = t;
                b.AutoSize = true;
                b.Tag = t == "Tất cả" ? "" : t;
                b.Margin = new Padding(4);
                b.Click += (o, e) =>
                {
                    theLoaiDangChon = ((Button)o).Tag.ToString();
                    CapNhatNutDanhMuc();
                    LocVaHienThi();
                };
                flowDanhMuc.Controls.Add(b);
            }
            flowDanhMuc.ResumeLayout();

            CapNhatNutDanhMuc();
        }

        // Tô đậm nút thể loại đang chọn
        private void CapNhatNutDanhMuc()
        {
            foreach (Button b in flowDanhMuc.Controls.OfType<Button>())
            {
                bool chon = b.Tag.ToString() == theLoaiDangChon;
                b.BackColor = chon ? Color.LightSkyBlue : SystemColors.Control;
                b.Font = new Font(b.Font, chon ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        // ===================== TÌM KIẾM / HIỂN THỊ =====================

        // Bỏ dấu + chữ thường để tìm "co so du lieu" vẫn ra "Cơ sở dữ liệu"
        private static string ChuanHoa(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            string d = s.Replace('đ', 'd').Replace('Đ', 'D').Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder(d.Length);
            foreach (char c in d)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString().ToLowerInvariant();
        }

        private void LocVaHienThi()
        {
            string tk = ChuanHoa((textBox1.Text ?? "").Trim());
            List<sach> nguon = DuLieu.DanhSachSach ?? new List<sach>();

            List<sach> kq = nguon.Where(s =>
                (theLoaiDangChon == "" || s.TheLoai == theLoaiDangChon) &&
                (tk == "" ||
                 ChuanHoa(s.TenSach).Contains(tk) ||
                 ChuanHoa(s.MaSach).Contains(tk) ||
                 ChuanHoa(s.TacGia).Contains(tk)))
                .ToList();

            HienThi(kq);
        }

        private void HienThi(List<sach> ds)
        {
            flowpanelSach.SuspendLayout();

            // Dispose card cũ để không rò rỉ bộ nhớ
            foreach (Control c in flowpanelSach.Controls.Cast<Control>().ToList()) c.Dispose();

            if (ds.Count == 0)
            {
                Label lb = new Label();
                lb.Text = "Không tìm thấy sách phù hợp.";
                lb.AutoSize = true;
                lb.Margin = new Padding(20);
                lb.BackColor = Color.Transparent;
                flowpanelSach.Controls.Add(lb);
            }
            else
            {
                foreach (sach s in ds) ThemCardSach(s);
            }

            flowpanelSach.ResumeLayout();
        }

        public void ThemCardSach(sach s)
        {
            CardBook card = new CardBook();
            card.HienThiSach(s);
            card.Margin = new Padding(10);
            flowpanelSach.Controls.Add(card);
        }

        // Giữ lại để các form khác (nếu đang gọi) không bị lỗi biên dịch
        public void LoadBooks()
        {
            LocVaHienThi();
        }

        public void ThemCardSach(Image anh, string maSach, string tenSach,
                                 string MoTa, string tacGia, string theLoai)
        {
            CardBook card = new CardBook();
            card.AnhBia = anh;
            card.TenSach = tenSach;
            card.TacGia = tacGia;
            card.TheLoai = theLoai;
            card.Ma = maSach;
            card.Margin = new Padding(10);
            flowpanelSach.Controls.Add(card);
        }

        // ===================== SỰ KIỆN =====================

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Tìm ngay khi gõ (trì hoãn 0,3 giây cho đỡ giật)
            timerTim.Stop();
            timerTim.Start();
        }

        private void bttSearch_Click(object sender, EventArgs e)
        {
            timerTim.Stop();
            LocVaHienThi();
        }

        private void bttFix_Click(object sender, EventArgs e)
        {
            chinhsua frm = new chinhsua(this);
            frm.Show();
        }

        private void bttThongKe_Click(object sender, EventArgs e)
        {
            Thongke f = Application.OpenForms.OfType<Thongke>().FirstOrDefault();
            if (f != null)
            {
                f.WindowState = FormWindowState.Normal;
                f.Activate();
                f.LamMoi();
                return;
            }
            new Thongke().Show();
        }

        // TODO: nối form Mượn sách / Trả sách khi bạn có form tương ứng
        private void bttMuonSach_Click(object sender, EventArgs e)
        {
            using (Muonsach f = new Muonsach())
            {
                f.ShowDialog(this);
            }
            LocVaHienThi();   // cập nhật lại số lượng tồn trên trang chủ
        }

        private void bttTraSach_Click(object sender, EventArgs e)
        {
            using (Trasach f = new Trasach())
            {
                f.ShowDialog(this);
            }
            LocVaHienThi();   // cập nhật lại số lượng tồn trên trang chủ
        }

        private void HuongDan_Click(object sender, EventArgs e)
        {
            TienIch.Thong(
                "1. Gõ tên sách, mã sách hoặc tác giả vào ô Tìm Kiếm (không cần gõ dấu).\n" +
                "2. Bấm vào một thể loại để lọc; bấm \"Tất cả\" để xem toàn bộ.\n" +
                "3. Bấm vào ảnh đại diện để xem hồ sơ cá nhân.");
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            hoso hs = new hoso();
            hs.FormClosed += (o, ev) => ApDungNguoiDung();   // cập nhật tên/ảnh nếu vừa sửa hồ sơ
            hs.Show();
        }

        // ===== Hàm Designer đang nối - giữ lại =====
        private void flowpanelSach_Paint(object sender, PaintEventArgs e) { }
        private void lbTen_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }

        private void bttMuonSach_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Huongdan frm = new Huongdan();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}