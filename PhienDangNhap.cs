using System.Drawing;

namespace libabry_app
{
    /// <summary>THAY file cũ. Giữ nguyên HoTen / MaNhomQuyen / Avatar / LaSinhVien, thêm vài trường.</summary>
    public static class PhienDangNhap
    {
        public static string HoTen;
        public static string MaNhomQuyen;
        public static Image Avatar;

        public static string TenDangNhap;
        public static string MaSo;   // MSSV hoặc mã giảng viên
        public static string Email;

        public const string NHOM_ADMIN = "1";
        public const string NHOM_THUTHU = "2";
        public const string NHOM_SINHVIEN = "3";

        public static bool LaSinhVien
        {
            get { return MaNhomQuyen != null && MaNhomQuyen.Trim() == NHOM_SINHVIEN; }
        }

        public static bool LaAdmin
        {
            get { return MaNhomQuyen != null && MaNhomQuyen.Trim() == NHOM_ADMIN; }
        }

        public static object NguoiDung { get; internal set; }

        public static void DangXuat()
        {
            HoTen = null; MaNhomQuyen = null; Avatar = null;
            TenDangNhap = null; MaSo = null; Email = null;
        }
    }
}