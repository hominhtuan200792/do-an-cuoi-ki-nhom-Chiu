using System;
using System.Collections.Generic;

namespace libabry_app
{
    // Một lượt mượn sách
    public class PhieuMuon
    {
        public string MaSo { get; set; }          // MSSV người mượn (khớp PhienDangNhap.MaSo)
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public DateTime? NgayTra { get; set; }    // null = chưa trả
    }

    public static class DuLieu
    {
        public static List<sach> DanhSachSach = new List<sach>();

        public static List<PhieuMuon> DanhSachMuon = new List<PhieuMuon>();
    }
}