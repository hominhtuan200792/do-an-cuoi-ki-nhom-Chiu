
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using libabry_app.Repository;

namespace libabry_app
{
    public partial class Trasach : Form
    {
        private TraSachRepository repository =
            new TraSachRepository();

        private List<SachDangMuon> danhSachDangMuon =
            new List<SachDangMuon>();

        public Trasach()
        {
            InitializeComponent();

            Text = "Trả sách";
            StartPosition = FormStartPosition.CenterParent;

            // Sự kiện nút Trả sách đã được gán trong Designer
            Load += Trasach_Load;
            comboBox1.SelectedIndexChanged +=
                comboBox1_SelectedIndexChanged;
            dataGridView1.CellClick +=
                dataGridView1_CellClick;
        }

        private void Trasach_Load(object sender, EventArgs e)
        {
            // Chỉ sinh viên được trả sách
            if (!PhienDangNhap.LaSinhVien)
            {
                MessageBox.Show(
                    "Chức năng trả sách chỉ dành cho sinh viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            // Hiển thị thông tin sinh viên
            textBox1.Text = PhienDangNhap.MaSo;
            textBox2.Text = PhienDangNhap.HoTen;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            // Ngày trả mặc định là hôm nay
            dateTimePicker2.Format =
                DateTimePickerFormat.Short;

            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;

            // Thiết lập bảng
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Bổ sung cột ngày mượn và hạn trả
            if (dataGridView1.Columns.Count == 4)
            {
                dataGridView1.Columns.Add(
                    "ColNgayMuon", "Ngày mượn");

                dataGridView1.Columns.Add(
                    "ColHanTra", "Hạn trả");
            }

            comboBox1.DropDownStyle =
                ComboBoxStyle.DropDownList;

            LamMoi();
        }

        // Lấy danh sách sách đang mượn từ SQL Server
        private void LamMoi()
        {
            try
            {
                danhSachDangMuon =
                    repository.LaySachDangMuon(
                        PhienDangNhap.MaSo);

                // Nạp các mã sách còn cần trả
                comboBox1.Items.Clear();

                var danhSachMaSach = danhSachDangMuon
                    .Select(p => p.MaSach)
                    .Distinct()
                    .ToList();

                comboBox1.Items.AddRange(
                    danhSachMaSach.Cast<object>().ToArray());

                comboBox1.SelectedIndex = -1;

                // Hiển thị danh sách sách
                dataGridView1.Rows.Clear();

                int stt = 1;

                foreach (SachDangMuon p in danhSachDangMuon)
                {
                    dataGridView1.Rows.Add(
                        stt++,
                        p.MaSach,
                        p.TenSach,
                        p.SoLuongConLai,
                        p.NgayMuon.ToString("dd/MM/yyyy"),
                        p.HanTra.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sách đang mượn.\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Chọn mã sách trong ComboBox
        private void comboBox1_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            string maSach = comboBox1.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToString(row.Cells[1].Value)
                    == maSach)
                {
                    dataGridView1.ClearSelection();

                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[1];

                    break;
                }
            }
        }

        // Bấm vào dòng trong bảng để chọn mã sách
        private void dataGridView1_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maSach = Convert.ToString(
                dataGridView1.Rows[e.RowIndex].Cells[1].Value);

            comboBox1.SelectedItem = maSach;
        }

        // Nút Trả sách
        private void nuttrasach_Click(
            object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaSinhVien)
            {
                MessageBox.Show(
                    "Chỉ sinh viên mới được trả sách.");
                return;
            }

            if (string.IsNullOrWhiteSpace(PhienDangNhap.MaSo))
            {
                MessageBox.Show(
                    "Không xác định được mã số sinh viên.");
                return;
            }

            string maSach = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(maSach))
            {
                MessageBox.Show(
                    "Vui lòng chọn mã sách cần trả.");

                comboBox1.Focus();
                return;
            }

            // Tìm các dòng đang mượn của mã sách đã chọn
            var cacDong = danhSachDangMuon
                .Where(p => p.MaSach == maSach)
                .ToList();

            if (cacDong.Count == 0)
            {
                MessageBox.Show(
                    "Bạn không có sách này cần trả.");
                return;
            }

            DateTime ngayTra = dateTimePicker2.Value.Date;

            // Kiểm tra ngày trả không trước ngày mượn
            if (cacDong.Any(p => ngayTra < p.NgayMuon.Date))
            {
                MessageBox.Show(
                    "Ngày trả không được trước ngày mượn.");

                dateTimePicker2.Focus();
                return;
            }

            int tongSoLuong = cacDong.Sum(
                p => p.SoLuongConLai);

            string tenSach = cacDong[0].TenSach;

            DialogResult xacNhan = MessageBox.Show(
                "Xác nhận trả " + tongSoLuong +
                " cuốn \"" + tenSach + "\"?",
                "Xác nhận trả sách",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                KetQuaTraSach ketQua = repository.TraSach(
                    PhienDangNhap.MaSo,
                    maSach,
                    ngayTra);

                LamMoi();

                if (ketQua.SoNgayTre > 0)
                {
                    MessageBox.Show(
                        "Trả sách thành công!\n" +
                        "Tên sách: " + ketQua.TenSach + "\n" +
                        "Số lượng đã trả: " +
                        ketQua.TongSoLuongTra + "\n" +
                        "Bạn trả trễ " +
                        ketQua.SoNgayTre + " ngày.",
                        "Trả sách thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Trả sách thành công!\n" +
                        "Tên sách: " + ketQua.TenSach + "\n" +
                        "Số lượng đã trả: " +
                        ketQua.TongSoLuongTra,
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể trả sách.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LamMoi();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(
            object sender, EventArgs e)
        {
        }
    }
}
