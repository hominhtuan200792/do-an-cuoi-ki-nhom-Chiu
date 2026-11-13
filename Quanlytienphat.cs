
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using libabry_app.Data;

// Phân biệt PhieuMuon trong Entity Framework với lớp PhieuMuon cũ
// thuộc namespace libabry_app.
using EFPhieuMuon = libabry_app.Data.PhieuMuon;

namespace libabry_app
{
    public partial class Quanlytienphat : Form
    {
        // Tiền phạt mỗi cuốn sách cho một ngày trễ
        private const int TIEN_PHAT_MOI_NGAY = 1000;

        public Quanlytienphat()
        {
            InitializeComponent();

            Text = "Quản lý tiền phạt";
            StartPosition = FormStartPosition.CenterParent;

            Load += Quanlytienphat_Load;

            button1.Click += (o, e) => Close();
        }

        // =====================================================
        // KHỞI TẠO FORM
        // =====================================================

        private void Quanlytienphat_Load(object sender, EventArgs e)
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

            // Thiết lập tên các cột
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns[1].HeaderText = "MSSV";
            dataGridView1.Columns[2].HeaderText = "Tên sinh viên";
            dataGridView1.Columns[3].HeaderText = "Tên sách";
            dataGridView1.Columns[4].HeaderText = "Số lượng";
            dataGridView1.Columns[5].HeaderText = "Tổng tiền phạt";

            HienTienPhat();
        }

        // =====================================================
        // TÍNH SỐ NGÀY TRỄ
        // =====================================================

        private int SoNgayTre(DateTime hanTra, DateTime ngayTra)
        {
            int soNgay = (ngayTra.Date - hanTra.Date).Days;

            return soNgay > 0 ? soNgay : 0;
        }

        // =====================================================
        // THÊM DÒNG VÀO DATAGRIDVIEW
        // =====================================================

        private void ThemDong(
            ref int stt,
            ref decimal tongTien,
            string maSo,
            string hoTen,
            string tenSach,
            int soLuong,
            int soNgayTre)
        {
            if (soLuong <= 0 || soNgayTre <= 0)
                return;

            decimal tienPhat =
                (decimal)soLuong * soNgayTre * TIEN_PHAT_MOI_NGAY;

            dataGridView1.Rows.Add(
                stt++,
                maSo,
                hoTen,
                tenSach,
                soLuong,
                tienPhat.ToString("N0") + " đ"
            );

            tongTien += tienPhat;
        }

        // =====================================================
        // HIỂN THỊ DANH SÁCH TIỀN PHẠT
        // =====================================================

        private void HienTienPhat()
        {
            dataGridView1.Rows.Clear();

            int stt = 1;
            decimal tongTien = 0;

            using (library_appEntities db = new library_appEntities())
            {
                // Lấy phiếu mượn và các dữ liệu liên quan
                var dsPhieuMuon = db.PhieuMuons
                    .Include("NguoiDung1")
                    .Include("ChiTietPhieuMuons.Sach")
                    .Include("ChiTietPhieuMuons.ChiTietPhieuTras.PhieuTra")
                    .ToList();

                foreach (EFPhieuMuon phieu in dsPhieuMuon)
                {
                    // Chỉ thống kê sinh viên
                    if (phieu.NguoiDung1 == null ||
                        phieu.NguoiDung1.LoaiNguoiDung != "SinhVien")
                    {
                        continue;
                    }

                    string maSo = phieu.NguoiDung1.MaSo ?? "";
                    string hoTen = phieu.NguoiDung1.HoTen ?? "";

                    // Duyệt từng đầu sách trong phiếu mượn
                    foreach (var chiTiet in phieu.ChiTietPhieuMuons)
                    {
                        string tenSach = chiTiet.Sach != null
                            ? chiTiet.Sach.TenSach
                            : "Không xác định";

                        // Tổng số lượng đã trả theo các chi tiết trả
                        int tongDaTra = chiTiet.ChiTietPhieuTras
                            .Sum(x => x.SoLuongTra);

                        // -------------------------------------
                        // TRƯỜNG HỢP 1: SÁCH ĐÃ ĐƯỢC TRẢ
                        // -------------------------------------

                        foreach (var chiTietTra in chiTiet.ChiTietPhieuTras)
                        {
                            if (chiTietTra.PhieuTra == null)
                                continue;

                            DateTime ngayTra =
                                chiTietTra.PhieuTra.NgayTra.Date;

                            int ngayTre = SoNgayTre(
                                phieu.HanTra,
                                ngayTra
                            );

                            if (ngayTre > 0)
                            {
                                ThemDong(
                                    ref stt,
                                    ref tongTien,
                                    maSo,
                                    hoTen,
                                    tenSach,
                                    chiTietTra.SoLuongTra,
                                    ngayTre
                                );
                            }
                        }

                        // -------------------------------------
                        // TRƯỜNG HỢP 2: SÁCH CHƯA TRẢ HẾT
                        // -------------------------------------

                        int soLuongConLai =
                            chiTiet.SoLuongMuon - tongDaTra;

                        if (soLuongConLai > 0)
                        {
                            int ngayTre = SoNgayTre(
                                phieu.HanTra,
                                DateTime.Today
                            );

                            if (ngayTre > 0)
                            {
                                ThemDong(
                                    ref stt,
                                    ref tongTien,
                                    maSo,
                                    hoTen,
                                    tenSach,
                                    soLuongConLai,
                                    ngayTre
                                );
                            }
                        }
                    }
                }
            }

            // Cập nhật tổng tiền phạt trên tiêu đề form
            Text = "Quản lý tiền phạt - Tổng: "
                + tongTien.ToString("N0") + " đ";

            label1.Text = "Quản lý tiền phạt";

            if (dataGridView1.Rows.Count == 0)
            {
                // Không có sách nào bị trễ hạn
                Text = "Quản lý tiền phạt - Tổng: 0 đ";
            }
        }

        // =====================================================
        // SỰ KIỆN DESIGNER
        // =====================================================

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
