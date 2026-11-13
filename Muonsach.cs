
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using libabry_app.Data;
using libabry_app.Repository;

namespace libabry_app
{
    public partial class Muonsach : Form
    {
        private MuonSachRepository repository = new MuonSachRepository();

        // Dòng sách đang nằm trong giỏ mượn
        private class DongGioMuon
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }

        private List<DongGioMuon> gio = new List<DongGioMuon>();
        private List<DongGioMuon> phieuCuoi = new List<DongGioMuon>();
        private List<DongGioMuon> dongIn = new List<DongGioMuon>();

        private int maPhieuMuonCuoi;

        // Giới hạn tối đa 5 cuốn sách đang mượn
        private const int GIOI_HAN_MUON = 5;

        public Muonsach()
        {
            InitializeComponent();

            Text = "Mượn sách";
            StartPosition = FormStartPosition.CenterParent;

            Load += Muonsach_Load;
            masachmuon_comboBox1.SelectedIndexChanged += Combo_Changed;
            them_button4.Click += them_button4_Click;
            datmuon_button1.Click += datmuon_button1_Click;
            inphieumuon_button3.Click += inphieumuon_button3_Click;
            thoat_button2.Click += (o, e) => Close();
            dataGridView1.KeyDown += DataGridView1_KeyDown;
        }

        private void Muonsach_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaSinhVien)
            {
                MessageBox.Show(
                    "Chức năng mượn sách chỉ dành cho sinh viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            // Hiển thị thông tin sinh viên
            mssv_textBox1.Text = PhienDangNhap.MaSo;
            hoten_textBox2.Text = PhienDangNhap.HoTen;

            mssv_textBox1.ReadOnly = true;
            hoten_textBox2.ReadOnly = true;

            // Thiết lập ngày mượn và hạn trả
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(14);

            // Thiết lập số lượng
            soluong_numericUpDown1.Minimum = 1;
            soluong_numericUpDown1.Maximum = GIOI_HAN_MUON;
            soluong_numericUpDown1.Value = 1;

            // Thiết lập bảng giỏ mượn
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            NapCombo();
            HienGio();
            CapNhatGioiHanSoLuong();
        }

        // Nạp sách từ SQL Server vào ComboBox
        private void NapCombo()
        {
            try
            {
                masachmuon_comboBox1.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                masachmuon_comboBox1.DataSource = null;

                var danhSach = repository.LaySachConHang();

                masachmuon_comboBox1.DataSource = danhSach;
                masachmuon_comboBox1.DisplayMember = "MaSach";
                masachmuon_comboBox1.ValueMember = "MaSach";
                masachmuon_comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sách.\n" + ex.Message);
            }
        }

        // Lấy sách đang chọn từ cơ sở dữ liệu
        private Sach TimSach(string maSach)
        {
            if (string.IsNullOrWhiteSpace(maSach))
                return null;

            return repository.LaySach(maSach);
        }

        // Tổng số sách sinh viên đang mượn chưa trả
        private int LaySoSachDangMuon()
        {
            return repository.LayTongSoLuongDangMuon(
                PhienDangNhap.MaSo);
        }

        // Tổng số sách trong giỏ
        private int LaySoSachTrongGio()
        {
            return gio.Sum(p => p.SoLuong);
        }

        // Cập nhật giới hạn số lượng được phép chọn
        private void CapNhatGioiHanSoLuong()
        {
            int daMuon = LaySoSachDangMuon();
            int trongGio = LaySoSachTrongGio();

            int conDuocMuon = GIOI_HAN_MUON - daMuon - trongGio;

            if (conDuocMuon < 0)
                conDuocMuon = 0;

            soluong_numericUpDown1.Minimum = 1;
            soluong_numericUpDown1.Maximum =
                Math.Max(1, conDuocMuon);

            soluong_numericUpDown1.Value = 1;

            // Nếu không còn quyền mượn thêm
            if (conDuocMuon == 0)
            {
                soluong_numericUpDown1.Enabled = false;
                them_button4.Enabled = false;
            }
            else
            {
                soluong_numericUpDown1.Enabled = true;
                them_button4.Enabled = true;
            }
        }

        // Khi chọn sách
        private void Combo_Changed(object sender, EventArgs e)
        {
            string maSach = masachmuon_comboBox1.SelectedValue == null
                ? null
                : masachmuon_comboBox1.SelectedValue.ToString();

            Sach sach = TimSach(maSach);

            if (sach == null)
                return;

            int daChon = gio
                .Where(p => p.MaSach == sach.MaSach)
                .Sum(p => p.SoLuong);

            int conLaiKho = sach.SoLuong - daChon;

            int daMuon = LaySoSachDangMuon();
            int trongGio = LaySoSachTrongGio();

            int conDuocMuon = GIOI_HAN_MUON - daMuon - trongGio;

            int soLuongToiDa = Math.Min(conLaiKho, conDuocMuon);

            if (soLuongToiDa <= 0)
            {
                soluong_numericUpDown1.Minimum = 1;
                soluong_numericUpDown1.Maximum = 1;
                soluong_numericUpDown1.Value = 1;
                soluong_numericUpDown1.Enabled = false;
                them_button4.Enabled = false;
            }
            else
            {
                soluong_numericUpDown1.Minimum = 1;
                soluong_numericUpDown1.Maximum = soLuongToiDa;
                soluong_numericUpDown1.Value = 1;
                soluong_numericUpDown1.Enabled = true;
                them_button4.Enabled = true;
            }
        }

        // Hiển thị giỏ mượn
        private void HienGio()
        {
            dataGridView1.Rows.Clear();

            int stt = 1;

            foreach (DongGioMuon p in gio)
            {
                dataGridView1.Rows.Add(
                    stt++,
                    p.MaSach,
                    p.TenSach,
                    p.SoLuong);
            }
        }

        // Thêm sách vào giỏ
        private void them_button4_Click(object sender, EventArgs e)
        {
            string maSach = masachmuon_comboBox1.SelectedValue == null
                ? null
                : masachmuon_comboBox1.SelectedValue.ToString();

            Sach sach = TimSach(maSach);

            if (sach == null)
            {
                MessageBox.Show("Vui lòng chọn mã sách cần mượn.");
                masachmuon_comboBox1.Focus();
                return;
            }

            int soLuong = (int)soluong_numericUpDown1.Value;

            // Kiểm tra tổng số sách đang mượn và trong giỏ
            int daMuon = LaySoSachDangMuon();
            int trongGio = LaySoSachTrongGio();

            if (daMuon + trongGio + soLuong > GIOI_HAN_MUON)
            {
                int conDuocMuon =
                    GIOI_HAN_MUON - daMuon - trongGio;

                MessageBox.Show(
                    "Bạn chỉ được mượn tối đa 5 cuốn sách.\n" +
                    "Đang mượn chưa trả: " + daMuon + " cuốn.\n" +
                    "Đang có trong giỏ: " + trongGio + " cuốn.\n" +
                    "Chỉ được thêm tối đa: " + Math.Max(0, conDuocMuon) + " cuốn.",
                    "Giới hạn mượn sách",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DongGioMuon dong = gio.FirstOrDefault(
                p => p.MaSach == sach.MaSach);

            int daChon = dong == null ? 0 : dong.SoLuong;

            if (daChon + soLuong > sach.SoLuong)
            {
                MessageBox.Show(
                    "Sách \"" + sach.TenSach +
                    "\" không còn đủ số lượng.");

                return;
            }

            if (dong == null)
            {
                gio.Add(new DongGioMuon
                {
                    MaSach = sach.MaSach,
                    TenSach = sach.TenSach,
                    SoLuong = soLuong
                });
            }
            else
            {
                dong.SoLuong += soLuong;
            }

            HienGio();
            CapNhatGioiHanSoLuong();
            Combo_Changed(null, EventArgs.Empty);
        }

        // Nhấn Delete để xóa sách khỏi giỏ
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete ||
                dataGridView1.CurrentRow == null)
                return;

            int viTri = dataGridView1.CurrentRow.Index;

            if (viTri >= 0 && viTri < gio.Count)
            {
                gio.RemoveAt(viTri);

                HienGio();
                CapNhatGioiHanSoLuong();
                Combo_Changed(null, EventArgs.Empty);
            }

            e.Handled = true;
        }

        // Xác nhận mượn sách
        private void datmuon_button1_Click(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaSinhVien)
            {
                MessageBox.Show("Chỉ sinh viên mới được mượn sách.");
                return;
            }

            if (string.IsNullOrWhiteSpace(PhienDangNhap.MaSo))
            {
                MessageBox.Show("Không xác định được MSSV của tài khoản.");
                return;
            }

            if (gio.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ mượn đang trống. Hãy chọn sách và bấm Thêm.");
                return;
            }

            // Kiểm tra lại giới hạn trước khi tạo phiếu
            int daMuon = LaySoSachDangMuon();
            int trongGio = LaySoSachTrongGio();

            if (daMuon + trongGio > GIOI_HAN_MUON)
            {
                MessageBox.Show(
                    "Bạn không thể mượn thêm vì tổng số sách sẽ vượt quá 5 cuốn.\n" +
                    "Đang mượn chưa trả: " + daMuon + " cuốn.\n" +
                    "Trong giỏ: " + trongGio + " cuốn.",
                    "Giới hạn mượn sách",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DateTime ngayMuon = dateTimePicker1.Value.Date;
            DateTime hanTra = dateTimePicker2.Value.Date;

            if (ngayMuon < DateTime.Today)
            {
                MessageBox.Show("Ngày mượn không được nhỏ hơn ngày hiện tại.");
                return;
            }

            if (hanTra < ngayMuon)
            {
                MessageBox.Show("Hạn trả phải sau hoặc bằng ngày mượn.");
                dateTimePicker2.Focus();
                return;
            }

            try
            {
                List<ChiTietMuonInput> danhSach = gio.Select(p =>
                    new ChiTietMuonInput
                    {
                        MaSach = p.MaSach,
                        SoLuong = p.SoLuong
                    }).ToList();

                maPhieuMuonCuoi = repository.TaoPhieuMuon(
                    PhienDangNhap.MaSo,
                    ngayMuon,
                    hanTra,
                    danhSach);

                phieuCuoi = gio.Select(p => new DongGioMuon
                {
                    MaSach = p.MaSach,
                    TenSach = p.TenSach,
                    SoLuong = p.SoLuong
                }).ToList();

                gio.Clear();
                HienGio();
                NapCombo();
                CapNhatGioiHanSoLuong();

                MessageBox.Show(
                    "Mượn sách thành công!\nMã phiếu mượn: " +
                    maPhieuMuonCuoi,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (MessageBox.Show(
                    "Bạn có muốn in phiếu mượn không?",
                    "In phiếu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InPhieu(phieuCuoi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tạo phiếu mượn.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                NapCombo();
                CapNhatGioiHanSoLuong();
            }
        }

        // Nút in phiếu
        private void inphieumuon_button3_Click(object sender, EventArgs e)
        {
            List<DongGioMuon> ds = gio.Count > 0 ? gio : phieuCuoi;

            if (ds == null || ds.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào để in phiếu.");
                return;
            }

            InPhieu(ds);
        }

        private void InPhieu(List<DongGioMuon> ds)
        {
            dongIn = ds.ToList();

            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += VePhieu;

                using (PrintPreviewDialog xem = new PrintPreviewDialog())
                {
                    xem.Document = pd;
                    xem.Width = 800;
                    xem.Height = 700;
                    xem.ShowDialog(this);
                }
            }
        }

        // Nội dung phiếu mượn
        private void VePhieu(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font fTieuDe = new Font("Arial", 18, FontStyle.Bold))
            using (Font fThuong = new Font("Arial", 12))
            {
                float x = 60;
                float y = 60;

                g.DrawString("PHIẾU MƯỢN SÁCH",
                    fTieuDe, Brushes.Black, x, y);

                y += 60;

                g.DrawString("Mã phiếu: " + maPhieuMuonCuoi,
                    fThuong, Brushes.Black, x, y);

                y += 28;

                g.DrawString("MSSV: " + PhienDangNhap.MaSo,
                    fThuong, Brushes.Black, x, y);

                y += 28;

                g.DrawString("Họ tên: " + PhienDangNhap.HoTen,
                    fThuong, Brushes.Black, x, y);

                y += 28;

                g.DrawString("Ngày mượn: " +
                    dateTimePicker1.Value.ToString("dd/MM/yyyy"),
                    fThuong, Brushes.Black, x, y);

                y += 28;

                g.DrawString("Hạn trả: " +
                    dateTimePicker2.Value.ToString("dd/MM/yyyy"),
                    fThuong, Brushes.Black, x, y);

                y += 45;

                g.DrawString("STT", fThuong, Brushes.Black, x, y);
                g.DrawString("Mã sách", fThuong, Brushes.Black, x + 60, y);
                g.DrawString("Tên sách", fThuong, Brushes.Black, x + 180, y);
                g.DrawString("Số lượng", fThuong, Brushes.Black, x + 520, y);

                y += 25;

                g.DrawLine(Pens.Black, x, y, x + 620, y);
                y += 8;

                int stt = 1;
                int tong = 0;

                foreach (DongGioMuon p in dongIn)
                {
                    g.DrawString(stt++.ToString(),
                        fThuong, Brushes.Black, x, y);

                    g.DrawString(p.MaSach,
                        fThuong, Brushes.Black, x + 60, y);

                    g.DrawString(p.TenSach,
                        fThuong, Brushes.Black, x + 180, y);

                    g.DrawString(p.SoLuong.ToString(),
                        fThuong, Brushes.Black, x + 520, y);

                    tong += p.SoLuong;
                    y += 28;
                }

                g.DrawLine(Pens.Black, x, y, x + 620, y);
                y += 10;

                g.DrawString("Tổng số sách: " + tong,
                    fThuong, Brushes.Black, x, y);
            }

            e.HasMorePages = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void them_button4_Click_1(object sender, EventArgs e)
        {
            // Không sử dụng sự kiện này.
        }
    }
}
