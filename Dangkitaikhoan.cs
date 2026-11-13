using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using libabry_app.Data;

namespace libabry_app
{
    public partial class Dangkitaikhoan : Form
        
    {
        private string duongDanAnh = "";
        public Dangkitaikhoan()
        {
            InitializeComponent();
        }

        private void Dangkitaikhoan_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton_sinhvien_CheckedChanged(object sender, EventArgs e)
        {
            radiobutton_giangvien.Checked = false;
        }

        private void radiobutton_giangvien_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_sinhvien.Checked = false;
        }

        private void lammoi_button_Click(object sender, EventArgs e)
        {

        }


        private void taotaikhoan_button_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string hoTen = textBox1.Text.Trim();
            string maSo = textBox2.Text.Trim();
            string tenDangNhap = textBox3.Text.Trim();
            string matKhau = textBox4.Text;

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(maSo) ||
                string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Kiểm tra vai trò
            if (!radioButton_sinhvien.Checked &&
                !radiobutton_giangvien.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn vai trò Sinh viên hoặc Giảng viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Xác định nhóm quyền
            int maNhom;
            string loaiNguoiDung;

            if (radioButton_sinhvien.Checked)
            {
                maNhom = 3;
                loaiNguoiDung = "SinhVien";
            }
            else
            {
                maNhom = 2;
                loaiNguoiDung = "GiangVien";
            }

            try
            {
                using (var db = new library_appEntities())
                using (var giaoDich = db.Database.BeginTransaction())
                {
                    // Kiểm tra mã số đã tồn tại
                    bool trungMaSo = db.NguoiDungs
                        .Any(x => x.MaSo == maSo);

                    if (trungMaSo)
                    {
                        MessageBox.Show(
                            "Mã số này đã được đăng ký!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // Kiểm tra tên đăng nhập đã tồn tại
                    bool trungTenDangNhap = db.TaiKhoans
                        .Any(x => x.TenDangNhap == tenDangNhap);

                    if (trungTenDangNhap)
                    {
                        MessageBox.Show(
                            "Tên đăng nhập đã tồn tại!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // Kiểm tra nhóm quyền
                    bool coNhomQuyen = db.NhomQuyens
                        .Any(x => x.MaNhom == maNhom);

                    if (!coNhomQuyen)
                    {
                        MessageBox.Show(
                            "Nhóm quyền không tồn tại trong cơ sở dữ liệu!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // Lưu ảnh đại diện
                    string anhDaiDien = null;

                    if (!string.IsNullOrWhiteSpace(duongDanAnh))
                    {
                        string thuMucAnh = Path.Combine(
                            Application.StartupPath, "Images"
                        );

                        Directory.CreateDirectory(thuMucAnh);

                        string tenFile = Guid.NewGuid().ToString()
                            + Path.GetExtension(duongDanAnh);

                        string duongDanDich = Path.Combine(
                            thuMucAnh, tenFile
                        );

                        File.Copy(duongDanAnh, duongDanDich, true);

                        anhDaiDien = Path.Combine("Images", tenFile);
                    }

                    // Băm mật khẩu bằng SHA256
                    string matKhauHash;

                    using (SHA256 sha = SHA256.Create())
                    {
                        byte[] duLieu = Encoding.UTF8.GetBytes(matKhau);
                        byte[] ketQua = sha.ComputeHash(duLieu);

                        StringBuilder sb = new StringBuilder();

                        foreach (byte b in ketQua)
                        {
                            sb.Append(b.ToString("x2"));
                        }

                        matKhauHash = sb.ToString();
                    }

                    // Tạo người dùng mới
                    var nguoiDungMoi = new NguoiDung
                    {
                        MaSo = maSo,
                        HoTen = hoTen,
                        LoaiNguoiDung = loaiNguoiDung,
                        AnhDaiDien = anhDaiDien
                    };

                    db.NguoiDungs.Add(nguoiDungMoi);

                    // Lưu để lấy mã người dùng tự tăng
                    db.SaveChanges();

                    // Tạo tài khoản mới
                    var taiKhoanMoi = new TaiKhoan
                    {
                        TenDangNhap = tenDangNhap,
                        MatKhauHash = matKhauHash,
                        MaNhom = maNhom,
                        MaNguoiDung = nguoiDungMoi.MaNguoiDung,
                        TrangThai = true
                    };

                    db.TaiKhoans.Add(taiKhoanMoi);

                    db.SaveChanges();

                    // Hoàn tất giao dịch
                    giaoDich.Commit();
                }

                MessageBox.Show(
                    "Tạo tài khoản thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                );
                this.DialogResult = DialogResult.OK;
                this.Close();
                // Làm mới các ô nhập liệu
                lammoi_button_Click(sender, e);
            }
            catch (Exception ex)
            {
                string loi = ex.Message;

                if (ex.InnerException != null)
                {
                    loi += "\n\nChi tiết: " + ex.InnerException.Message;

                    if (ex.InnerException.InnerException != null)
                    {
                        loi += "\n\nLỗi SQL Server: " +
                            ex.InnerException.InnerException.Message;
                    }
                }

                MessageBox.Show(
                    loi,
                    "Chi tiết lỗi tạo tài khoản",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void anhdaidien_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn ảnh
                duongDanAnh = openFile.FileName;
                pictureBox1.Image =
                Image.FromFile(duongDanAnh);

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
