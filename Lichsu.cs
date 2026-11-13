
using System;
using System.Windows.Forms;
using libabry_app.Repository;

namespace libabry_app
{
    public partial class Lichsu : Form
    {
        private LichSuRepository repository =
            new LichSuRepository();

        public Lichsu()
        {
            InitializeComponent();

            Text = "Lịch sử mượn sách";
            StartPosition = FormStartPosition.CenterParent;

            Load += Lichsu_Load;
        }

        private void Lichsu_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaSinhVien)
            {
                MessageBox.Show(
                    "Chức năng này chỉ dành cho sinh viên.");

                Close();
                return;
            }

            // Thông tin sinh viên
            tensinhvien_textBox1.Text = PhienDangNhap.HoTen;
            mssv_textBox2.Text = PhienDangNhap.MaSo;

            tensinhvien_textBox1.ReadOnly = true;
            mssv_textBox2.ReadOnly = true;
            tongmuon_textBox3.ReadOnly = true;

            // Cấu hình DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            TaoCot();
            HienLichSu();
        }

        // Tạo các cột lịch sử
        private void TaoCot()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("ColSTT", "STT");
            dataGridView1.Columns.Add("ColMaSach", "Mã sách");
            dataGridView1.Columns.Add("ColTenSach", "Tên sách");
            dataGridView1.Columns.Add("ColSoLuong", "Số lượng");
            dataGridView1.Columns.Add("ColNgayMuon", "Ngày mượn");
            dataGridView1.Columns.Add("ColHanTra", "Hạn trả");

            dataGridView1.Columns["ColSTT"].FillWeight = 40;
            dataGridView1.Columns["ColMaSach"].FillWeight = 75;
            dataGridView1.Columns["ColTenSach"].FillWeight = 150;
            dataGridView1.Columns["ColSoLuong"].FillWeight = 65;
            dataGridView1.Columns["ColNgayMuon"].FillWeight = 85;
            dataGridView1.Columns["ColHanTra"].FillWeight = 85;
        }

        // Hiển thị lịch sử mượn từ SQL Server
        private void HienLichSu()
        {
            try
            {
                dataGridView1.Rows.Clear();

                var ds = repository.LayLichSu(
                    PhienDangNhap.MaSo);

                int stt = 1;
                int tong = 0;

                foreach (LichSuMuonItem p in ds)
                {
                    dataGridView1.Rows.Add(
                        stt++,
                        p.MaSach,
                        p.TenSach,
                        p.SoLuong,
                        p.NgayMuon.ToString("dd/MM/yyyy"),
                        p.HanTra.ToString("dd/MM/yyyy"));

                    tong += p.SoLuong;
                }

                tongmuon_textBox3.Text = tong.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải lịch sử mượn sách.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
