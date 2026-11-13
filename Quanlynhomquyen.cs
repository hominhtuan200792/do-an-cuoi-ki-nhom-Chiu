using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class Quanlynhomquyen : Form
    {
        // static để dữ liệu còn nguyên khi đóng/mở lại form
        // (nếu muốn, bạn chuyển nó sang lớp DuLieu cho đồng bộ)
        private static List<NhomQuyen> dsNhom = new List<NhomQuyen>();

        // Cờ chặn SelectionChanged chạy khi đang nạp lưới
        private bool dangNap = false;

        public Quanlynhomquyen()
        {
            InitializeComponent();
            Text = "Quản lý nhóm quyền";
            StartPosition = FormStartPosition.CenterParent;

            Load += Quanlynhomquyen_Load;
            dgvNhomQuyen.SelectionChanged += dgvNhomQuyen_SelectionChanged;
            bttThem.Click += bttThem_Click;
            bttSua.Click += bttSua_Click;
            bttXoa.Click += bttXoa_Click;
            bttLamMoi.Click += bttLamMoi_Click;
        }

        private void Quanlynhomquyen_Load(object sender, EventArgs e)
        {
            dgvNhomQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Dữ liệu mẫu lần đầu chạy
            if (dsNhom.Count == 0)
            {
                dsNhom.Add(new NhomQuyen
                {
                    MaNhom = "NQ01",
                    TenNhom = "Quản trị viên",
                    MoTa = "Toàn quyền hệ thống",
                    DanhSachQuyen = clbQuyen.Items.Cast<object>().Select(x => x.ToString()).ToList()
                });
                dsNhom.Add(new NhomQuyen
                {
                    MaNhom = "NQ02",
                    TenNhom = "Thủ thư",
                    MoTa = "Quản lý sách",
                    DanhSachQuyen = new List<string> { "Xem sách", "Thêm sách" }
                });
                dsNhom.Add(new NhomQuyen
                {
                    MaNhom = "NQ03",
                    TenNhom = "Sinh viên",
                    MoTa = "Chỉ xem sách",
                    DanhSachQuyen = new List<string> { "Xem sách" }
                });
            }

            HienLuoi();
            LamMoi();
        }

        // ---------- Hỗ trợ ----------

        private void HienLuoi()
        {
            dangNap = true;
            dgvNhomQuyen.Rows.Clear();
            foreach (NhomQuyen n in dsNhom)
                dgvNhomQuyen.Rows.Add(n.MaNhom, n.TenNhom, n.MoTa);
            dgvNhomQuyen.ClearSelection();
            dangNap = false;
        }

        // Sinh mã mới dạng NQ01, NQ02...
        private string SinhMa()
        {
            int max = 0;
            foreach (NhomQuyen n in dsNhom)
            {
                int so;
                if (n.MaNhom != null && n.MaNhom.StartsWith("NQ") &&
                    int.TryParse(n.MaNhom.Substring(2), out so) && so > max)
                    max = so;
            }
            return "NQ" + (max + 1).ToString("00");
        }

        private void LamMoi()
        {
            txtMaNhom.Text = SinhMa();
            txtTenNhom.Clear();
            txtMoTa.Clear();
            for (int i = 0; i < clbQuyen.Items.Count; i++)
                clbQuyen.SetItemChecked(i, false);

            dgvNhomQuyen.ClearSelection();
            txtTenNhom.Focus();
        }

        private List<string> LayQuyenDaChon()
        {
            return clbQuyen.CheckedItems.Cast<object>().Select(x => x.ToString()).ToList();
        }

        private NhomQuyen NhomDangChon()
        {
            if (dgvNhomQuyen.CurrentRow == null || !dgvNhomQuyen.CurrentRow.Selected)
                return null;
            string ma = Convert.ToString(dgvNhomQuyen.CurrentRow.Cells["MaNhomQuyen"].Value);
            return dsNhom.FirstOrDefault(n => n.MaNhom == ma);
        }

        private bool KiemTra(string maBoQua)
        {
            string ten = txtTenNhom.Text.Trim();
            if (ten.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhóm.");
                txtTenNhom.Focus();
                return false;
            }
            bool trung = dsNhom.Any(n => n.MaNhom != maBoQua &&
                string.Equals(n.TenNhom, ten, StringComparison.OrdinalIgnoreCase));
            if (trung)
            {
                MessageBox.Show("Tên nhóm đã tồn tại.");
                txtTenNhom.Focus();
                return false;
            }
            return true;
        }

        // ---------- Sự kiện ----------

        // Bấm vào dòng nào thì đổ thông tin nhóm đó xuống phần chi tiết
        private void dgvNhomQuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dangNap) return;
            NhomQuyen n = NhomDangChon();
            if (n == null) return;

            txtMaNhom.Text = n.MaNhom;
            txtTenNhom.Text = n.TenNhom;
            txtMoTa.Text = n.MoTa;
            for (int i = 0; i < clbQuyen.Items.Count; i++)
                clbQuyen.SetItemChecked(i, n.DanhSachQuyen.Contains(clbQuyen.Items[i].ToString()));
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra(null)) return;

            dsNhom.Add(new NhomQuyen
            {
                MaNhom = SinhMa(),
                TenNhom = txtTenNhom.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                DanhSachQuyen = LayQuyenDaChon()
            });

            HienLuoi();
            LamMoi();
            MessageBox.Show("Đã thêm nhóm quyền.");
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            NhomQuyen n = NhomDangChon();
            if (n == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm cần sửa trong danh sách.");
                return;
            }
            if (!KiemTra(n.MaNhom)) return;

            n.TenNhom = txtTenNhom.Text.Trim();
            n.MoTa = txtMoTa.Text.Trim();
            n.DanhSachQuyen = LayQuyenDaChon();

            HienLuoi();
            LamMoi();
            MessageBox.Show("Đã cập nhật nhóm quyền.");
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            NhomQuyen n = NhomDangChon();
            if (n == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm cần xóa trong danh sách.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhóm \"" + n.TenNhom + "\"?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            dsNhom.Remove(n);
            HienLuoi();
            LamMoi();
        }

        private void bttLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        // Designer đang gắn sự kiện này cho label1 nên phải giữ lại
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Designer đang gắn sự kiện này cho lbHead nên phải giữ lại
        private void lbHead_Click(object sender, EventArgs e)
        {
        }
    }

    // Dữ liệu nhóm quyền (lưu tạm trong bộ nhớ, giống cách DuLieu đang làm)
    public class NhomQuyen
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public string MoTa { get; set; }
        public List<string> DanhSachQuyen { get; set; }

        public NhomQuyen()
        {
            DanhSachQuyen = new List<string>();
        }
    }
}