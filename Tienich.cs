using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace libabry_app
{
    /// <summary>File MỚI - thêm vào project. Chứa hàm dùng chung cho mọi form.</summary>
    public static class TienIch
    {
        // ===== Quy định thư viện (đổi tại đây là áp dụng toàn app) =====
        public const int SO_SACH_TOI_DA = 5;       // tối đa số cuốn / 1 phiếu mượn
        public const int SO_NGAY_MUON = 14;        // hạn trả mặc định (ngày)
        public const decimal PHAT_MOI_NGAY = 2000; // tiền phạt / ngày trễ hạn

        // ===== Hộp thoại =====
        public static void Thong(string nd)
        {
            MessageBox.Show(nd, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Loi(string nd)
        {
            MessageBox.Show(nd, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static bool HoiXacNhan(string nd)
        {
            return MessageBox.Show(nd, "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ===== Kiểm tra dữ liệu nhập =====
        public static bool LaEmailHopLe(string email)
        {
            return Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        /// <summary>Trả về true (và báo lỗi, focus ô) nếu ô đang trống.</summary>
        public static bool Trong(TextBoxBase o, string thongBao)
        {
            if (string.IsNullOrWhiteSpace(o.Text))
            {
                Loi(thongBao);
                o.Focus();
                return true;
            }
            return false;
        }

        /// <summary>Xóa sạch các ô nhập trong 1 container (Form, GroupBox, Panel...).</summary>
        public static void XoaNhap(Control cha)
        {
            foreach (Control c in cha.Controls)
            {
                if (c is TextBoxBase) c.Text = "";
                else if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
                else if (c is CheckBox) ((CheckBox)c).Checked = false;
                else if (c.HasChildren) XoaNhap(c);
            }
        }

        // ===== Mở form =====
        /// <summary>Ẩn form hiện tại, mở form mới dạng hộp thoại, đóng xong thì hiện lại.</summary>
        public static void MoModal(Form hienTai, Form moi)
        {
            hienTai.Hide();
            using (moi) { moi.ShowDialog(); }
            hienTai.Show();
        }

        // ===== DataGridView =====
        /// <summary>Cấu hình lưới chỉ xem: không sửa trực tiếp, chọn nguyên dòng.</summary>
        public static void LuoiChiXem(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>Đổ danh sách dòng vào lưới. themSTT = true thì tự thêm số thứ tự ở cột đầu.</summary>
        public static void DoLuoi(DataGridView dgv, List<object[]> dong, bool themSTT)
        {
            dgv.Rows.Clear();
            int stt = 1;
            foreach (object[] r in dong)
            {
                object[] o = r;
                if (themSTT)
                {
                    o = new object[r.Length + 1];
                    o[0] = stt++;
                    Array.Copy(r, 0, o, 1, r.Length);
                }
                dgv.Rows.Add(o);
            }
        }

        // ===== Mật khẩu / In ấn / Ảnh =====
        public static string TaoMatKhauTam(int doDai)
        {
            const string kyTu = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            byte[] b = new byte[doDai];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                rng.GetBytes(b);
            StringBuilder sb = new StringBuilder();
            foreach (byte x in b) sb.Append(kyTu[x % kyTu.Length]);
            return sb.ToString();
        }

        public static void XemTruocIn(string noiDung)
        {
            try
            {
                var pd = new System.Drawing.Printing.PrintDocument();
                pd.PrintPage += (s, e) =>
                {
                    using (Font f = new Font("Arial", 12))
                        e.Graphics.DrawString(noiDung, f, Brushes.Black, e.MarginBounds);
                };
                using (var dlg = new PrintPreviewDialog())
                {
                    dlg.Document = pd;
                    dlg.Width = 800;
                    dlg.Height = 600;
                    dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Loi("Không in được: " + ex.Message);
            }
        }

        /// <summary>Chọn ảnh từ máy, trả về null nếu bấm Cancel. Không khóa file gốc.</summary>
        public static Image ChonAnh()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() != DialogResult.OK) return null;
                using (Image tmp = Image.FromFile(ofd.FileName))
                    return new Bitmap(tmp);
            }
        }
    }
}