using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class chinhsua : Form
    {
        private trangchu tc;
        private int indexSach = -1;
        private string duongDanAnhDangChon = "";
        public chinhsua(trangchu trang)
        {
            InitializeComponent();

            tc = trang;
            cbTheLoai.DataSource = SachDAL.LayTheLoai();
            cbTheLoai.DisplayMember = "TenTheLoai";
            cbTheLoai.ValueMember = "MaTheLoai";
            cbTheLoai.SelectedIndex = -1;
            cbSoLuong.KeyPress += (o, ev) =>
            {
                // chỉ cho phép số và phím điều khiển (Backspace...)
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                    ev.Handled = true;
            };
        }
        private void CauHinhLuoi()
        {
            dgvSach.RowTemplate.Height = 60;

            DataGridViewColumn cotAnh = dgvSach.Columns["anh"];
            if (!(cotAnh is DataGridViewImageColumn))
            {
                int vt = cotAnh.Index;
                dgvSach.Columns.RemoveAt(vt);

                DataGridViewImageColumn cotMoi = new DataGridViewImageColumn();
                cotMoi.Name = "anh";
                cotMoi.HeaderText = "Ảnh";
                cotMoi.ImageLayout = DataGridViewImageCellLayout.Zoom;
                cotMoi.DefaultCellStyle.NullValue = null;
                dgvSach.Columns.Insert(vt, cotMoi);
            }

            if (!dgvSach.Columns.Contains("SoLuong"))
                dgvSach.Columns.Add("SoLuong", "Số Lượng");
            foreach (DataGridViewColumn c in dgvSach.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void XoaForm()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            cbTheLoai.Text = "";
            cbSoLuong.Text = "0"; 
            txtboxMoTa.Clear();
            picSach.Image = null;
            indexSach = -1;
            duongDanAnhDangChon = "";
            txtMaSach.Enabled = true;
        }
        private void chinhsua_Load(object sender, EventArgs e)
        {
            CauHinhLuoi();

            // Tải sách từ database
            DuLieu.DanhSachSach = SachDAL.LayTatCa();

            // Tải lại danh sách thể loại từ database
            cbTheLoai.DataSource = SachDAL.LayTheLoai();
            cbTheLoai.DisplayMember = "TenTheLoai";
            cbTheLoai.ValueMember = "MaTheLoai";
            cbTheLoai.SelectedIndex = -1;

            LoadDataGridView();
        }

        private void lbbTacGia_Click(object sender, EventArgs e)
        {

        }
        Image AnhSach;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Tạo thư mục Images nếu chưa tồn tại
                        string thuMucAnh = Path.Combine(
                            Application.StartupPath, "Images");

                        if (!Directory.Exists(thuMucAnh))
                            Directory.CreateDirectory(thuMucAnh);

                        // Sao chép ảnh vào thư mục Images
                        string tenFile = Guid.NewGuid().ToString()
                            + Path.GetExtension(ofd.FileName);

                        string duongDanMoi = Path.Combine(thuMucAnh, tenFile);

                        File.Copy(ofd.FileName, duongDanMoi, true);

                        // Lưu đường dẫn tương đối để ghi vào database
                        duongDanAnhDangChon = Path.Combine("Images", tenFile);

                        // Hiển thị ảnh
                        using (Image tmp = Image.FromFile(duongDanMoi))
                        {
                            picSach.Image = new Bitmap(tmp);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                    }
                }
            }
        }
        private bool KiemTraThongTin(out int soLuong, sach boQua)
        {
            soLuong = 0;   
            string ma = txtMaSach.Text.Trim();

            switch (true)
            {
                case true when ma =="":
                    MessageBox.Show("Vui lòng nhập mã sách.");
                    txtMaSach.Focus();
                    return false;

                case true when DuLieu.DanhSachSach.Any(x =>
                        !ReferenceEquals(x, boQua) &&
                        string.Equals(x.MaSach, ma, StringComparison.OrdinalIgnoreCase)):
                    MessageBox.Show("Mã sách đã tồn tại. Vui lòng chọn mã khác.");
                    txtMaSach.Focus();
                    return false;

                case true when string.IsNullOrWhiteSpace(txtTenSach.Text):
                    MessageBox.Show("Vui lòng nhập tên sách.");
                    txtTenSach.Focus();
                    return false;

                case true when string.IsNullOrWhiteSpace(txtTacGia.Text):
                    MessageBox.Show("Vui lòng nhập tác giả.");
                    txtTacGia.Focus();
                    return false;

                case true when cbTheLoai.SelectedIndex < 0:
                    MessageBox.Show("Vui lòng chọn thể loại.");
                    cbTheLoai.Focus();
                    return false;
                case true when string.IsNullOrWhiteSpace(cbSoLuong.Text):
                    MessageBox.Show("Vui lòng nhập số lượng.");
                    cbSoLuong.Focus();
                    return false;

                case true when !int.TryParse(cbSoLuong.Text.Trim(), out soLuong) || soLuong < 0:
                    MessageBox.Show("Số lượng phải là số nguyên không âm.");
                    cbSoLuong.Focus();
                    return false;
                case true when string.IsNullOrWhiteSpace(txtboxMoTa.Text):
                    MessageBox.Show("Vui lòng nhập mô tả.");
                    txtboxMoTa.Focus();
                    return false;

                case true when picSach.Image == null:
                    MessageBox.Show("Vui lòng chọn ảnh bìa.");
                    return false;

                default:
                    return true;
            }
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            int soLuong;

            if (!KiemTraThongTin(out soLuong, null))
                return;

            try
            {
                sach s = new sach();

                s.MaSach = txtMaSach.Text.Trim();
                s.TenSach = txtTenSach.Text.Trim();
                s.TacGia = txtTacGia.Text.Trim();

                // Lấy mã thể loại kiểu int từ ComboBox
                int maTheLoai = Convert.ToInt32(cbTheLoai.SelectedValue);

                s.TheLoai = cbTheLoai.Text;
                s.SoLuong = soLuong;
                s.MoTa = txtboxMoTa.Text.Trim();

                // Lưu đường dẫn và ảnh bìa
                s.DuongDanAnh = duongDanAnhDangChon;
                s.AnhBia = picSach.Image;

                // Lưu sách xuống SQL Server bằng Entity Framework
                SachDAL.Them(s, maTheLoai);

                // Tải lại danh sách từ database
                DuLieu.DanhSachSach = SachDAL.LayTatCa();

                LoadDataGridView();
                tc.LoadBooks();

                XoaForm();
                duongDanAnhDangChon = "";

                MessageBox.Show("Thêm sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm sách.\nChi tiết: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ma = Convert.ToString(dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value);
            indexSach = DuLieu.DanhSachSach.FindIndex(x =>
                string.Equals(x.MaSach, ma, StringComparison.OrdinalIgnoreCase));
            if (indexSach < 0) return;
            
            sach s = DuLieu.DanhSachSach[indexSach];
            txtMaSach.Enabled = false;
            duongDanAnhDangChon = "";

            txtMaSach.Text = s.MaSach;
            txtTenSach.Text = s.TenSach;
            txtTacGia.Text = s.TacGia;
            cbTheLoai.Text = s.TheLoai;
            cbSoLuong.Text = s.SoLuong.ToString();
            txtboxMoTa.Text = s.MoTa;
            picSach.Image = s.AnhBia;
        }

        private void LoadDataGridView()
        {
            dgvSach.Rows.Clear();

            foreach (sach s in DuLieu.DanhSachSach)
            {
                
                int i = dgvSach.Rows.Add();
                DataGridViewRow r = dgvSach.Rows[i];
                r.Cells["MaSach"].Value = s.MaSach;
                r.Cells["TenSach"].Value = s.TenSach;
                r.Cells["TacGia"].Value = s.TacGia;
                r.Cells["TheLoai"].Value = s.TheLoai;
                r.Cells["SoLuong"].Value = s.SoLuong;
                r.Cells["Mota"].Value = s.MoTa;
                r.Cells["anh"].Value = s.AnhBia;
            }
        }

        private void bttFix_Click(object sender, EventArgs e)
        {
            if (indexSach < 0 || indexSach >= DuLieu.DanhSachSach.Count)
            {
                MessageBox.Show("Hãy chọn một sách trong danh sách để sửa.");
                return;
            }

            sach s = DuLieu.DanhSachSach[indexSach];

            int soLuong;

            if (!KiemTraThongTin(out soLuong, s))
                return;

            if (MessageBox.Show(
                "Lưu thay đổi cho sách \"" + s.TenSach + "\"?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                s.TenSach = txtTenSach.Text.Trim();
                s.TacGia = txtTacGia.Text.Trim();
                s.TheLoai = cbTheLoai.Text;
                s.SoLuong = soLuong;
                s.MoTa = txtboxMoTa.Text.Trim();
                s.AnhBia = picSach.Image;

                if (!string.IsNullOrWhiteSpace(duongDanAnhDangChon))
                {
                    s.DuongDanAnh = duongDanAnhDangChon;
                }

                int maTheLoai = Convert.ToInt32(cbTheLoai.SelectedValue);

                SachDAL.Sua(s, maTheLoai);

                DuLieu.DanhSachSach = SachDAL.LayTatCa();

                LoadDataGridView();
                tc.LoadBooks();
                XoaForm();

                MessageBox.Show("Cập nhật sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật sách: " + ex.Message);
            }
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            if (indexSach < 0 || indexSach >= DuLieu.DanhSachSach.Count)
            {
                MessageBox.Show("Hãy chọn một sách trong danh sách để xóa.");
                return;
            }

            sach s = DuLieu.DanhSachSach[indexSach];

            if (MessageBox.Show(
                "Xóa sách \"" + s.TenSach + "\"?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                SachDAL.Xoa(s.MaSach);

                DuLieu.DanhSachSach = SachDAL.LayTatCa();

                LoadDataGridView();
                tc.LoadBooks();
                XoaForm();

                MessageBox.Show("Xóa sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa sách: " + ex.Message);
            }
        }

        private void txtboxMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttLamMoi_Click(object sender, EventArgs e)
        {
            XoaForm();
            dgvSach.ClearSelection();   
            txtMaSach.Focus();
          
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
