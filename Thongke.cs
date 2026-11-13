using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using libabry_app.Repository;

namespace libabry_app
{
    // Thống kê tồn kho:
    //   dataGridView1: sách còn lại trong kho
    //   dataGridView2: sách đang được mượn (chưa trả)
    //   dataGridView3: sách đã trả trong khoảng Từ - Đến (nút "Lọc")
    public partial class Thongke : Form
    {
        private readonly ThongKeRepository repo = new ThongKeRepository();

        public Thongke()
        {
            InitializeComponent();

            Text = "Thống kê tồn kho";
            StartPosition = FormStartPosition.CenterScreen;

            CauHinhLuoi(dataGridView1, 4);
            CauHinhLuoi(dataGridView2, 4);
            CauHinhLuoi(dataGridView3, -1);

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;

            button1.Click += button1_Click;
            Load += Thongke_Load;
        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            LamMoi();
        }

        // Tải lại cả 3 bảng (trangchu cũng gọi hàm này)
        public void LamMoi()
        {
            try
            {
                TaiConLai();
                TaiDangMuon();
                TaiDaTra();
            }
            catch (Exception ex)
            {
                TienIch.Loi("Lỗi tải thống kê: " + ex.Message);
            }
        }

        // ===================== ĐỊNH DẠNG LƯỚI =====================

        // cotSo: chỉ số cột số lượng để căn phải (-1 nếu không có)
        private static void CauHinhLuoi(DataGridView g, int cotSo)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.MultiSelect = false;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            g.Columns[0].FillWeight = 35;                       // cột STT hẹp
            if (cotSo >= 0)
                g.Columns[cotSo].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // ===================== TRUY VẤN (Entity Framework) =====================

        // Thêm danh sách vào lưới, tự đánh số STT ở cột 0
        private static void NapLuoi<T>(DataGridView g, IEnumerable<T> ds, Func<T, object[]> doc)
        {
            g.Rows.Clear();

            int stt = 0;
            foreach (T item in ds)
            {
                object[] v = doc(item);
                object[] dong = new object[v.Length + 1];
                dong[0] = ++stt;
                Array.Copy(v, 0, dong, 1, v.Length);
                g.Rows.Add(dong);
            }
        }

        // 1) Sách còn lại = tổng số lượng - số đang được mượn
        private void TaiConLai()
        {
            NapLuoi(dataGridView1, repo.LayConLai(),
                x => new object[] { x.MaSach, x.TenSach, x.TacGia, x.SoLuong });
        }

        // 2) Sách đang được mượn (còn chưa trả)
        private void TaiDangMuon()
        {
            NapLuoi(dataGridView2, repo.LayDangMuon(),
                x => new object[] { x.MaSach, x.TenSach, x.TacGia, x.SoLuong });
        }

        // 3) Sách đã trả trong khoảng ngày
        private void TaiDaTra()
        {
            NapLuoi(dataGridView3,
                repo.LayDaTra(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date),
                x => new object[] { x.MaSach, x.TenSach, x.MaSo, x.NgayTra.ToString("dd/MM/yyyy") });
        }

        // ===================== SỰ KIỆN =====================

        // Nút "Lọc": lọc bảng "Số sách đã trả" theo Từ - Đến
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                TienIch.Loi("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }

            try
            {
                TaiDaTra();
            }
            catch (Exception ex)
            {
                TienIch.Loi("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }

        // ===== Hàm Designer đang nối - giữ lại =====
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }

}