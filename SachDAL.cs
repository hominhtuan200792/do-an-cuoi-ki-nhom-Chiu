using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using libabry_app.Data;

namespace libabry_app
{
    public static class SachDAL
    {
        // Lấy toàn bộ sách
        public static List<sach> LayTatCa()
        {
            using (var db = new library_appEntities())
            {
                var danhSach = db.Saches
                    .Include("TheLoai")
                    .OrderBy(x => x.TenSach)
                    .ToList();

                return danhSach.Select(x => new sach
                {
                    MaSach = x.MaSach,
                    TenSach = x.TenSach,
                    TacGia = x.TacGia,
                    TheLoai = x.TheLoai == null ? "" : x.TheLoai.TenTheLoai,
                    SoLuong = x.SoLuong,
                    MoTa = x.MoTa,
                    DuongDanAnh = x.Anh,
                    AnhBia = DocAnh(x.Anh)
                }).ToList();
            }
        }

        // Lấy danh sách thể loại
        public static List<TheLoai> LayTheLoai()
        {
            using (var db = new library_appEntities())
            {
                return db.TheLoais
                    .OrderBy(x => x.TenTheLoai)
                    .ToList();
            }
        }

        // Thêm sách
        public static void Them(sach s, int maTheLoai)
        {
            using (var db = new library_appEntities())
            {
                if (db.Saches.Any(x => x.MaSach == s.MaSach))
                {
                    throw new Exception("Mã sách đã tồn tại.");
                }

                var sachMoi = new libabry_app.Data.Sach
                {
                    MaSach = s.MaSach,
                    TenSach = s.TenSach,
                    TacGia = s.TacGia,
                    MaTheLoai = maTheLoai,
                    SoLuong = s.SoLuong,
                    MoTa = s.MoTa,
                    Anh = s.DuongDanAnh
                };

                db.Saches.Add(sachMoi);
                db.SaveChanges();
            }
        }

        // Sửa thông tin sách
        public static void Sua(sach s, int maTheLoai)
        {
            using (var db = new library_appEntities())
            {
                var sachSua = db.Saches
                    .FirstOrDefault(x => x.MaSach == s.MaSach);

                if (sachSua == null)
                {
                    throw new Exception("Không tìm thấy sách cần sửa.");
                }

                sachSua.TenSach = s.TenSach;
                sachSua.TacGia = s.TacGia;
                sachSua.MaTheLoai = maTheLoai;
                sachSua.SoLuong = s.SoLuong;
                sachSua.MoTa = s.MoTa;
                sachSua.Anh = s.DuongDanAnh;

                db.SaveChanges();
            }
        }

        // Xóa sách
        public static void Xoa(string maSach)
        {
            using (var db = new library_appEntities())
            {
                bool dangDuocMuon = db.ChiTietPhieuMuons
                    .Any(x => x.MaSach == maSach);

                if (dangDuocMuon)
                {
                    throw new Exception(
                        "Không thể xóa sách vì sách đã có trong lịch sử mượn."
                    );
                }

                var sachXoa = db.Saches
                    .FirstOrDefault(x => x.MaSach == maSach);

                if (sachXoa == null)
                {
                    throw new Exception("Không tìm thấy sách cần xóa.");
                }

                db.Saches.Remove(sachXoa);
                db.SaveChanges();
            }
        }

        // Đọc ảnh từ đường dẫn
        private static Image DocAnh(string duongDan)
        {
            if (string.IsNullOrWhiteSpace(duongDan))
                return null;

            try
            {
                string duongDanDayDu = duongDan;

                if (!Path.IsPathRooted(duongDan))
                {
                    duongDanDayDu = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        duongDan
                    );
                }

                if (!File.Exists(duongDanDayDu))
                    return null;

                byte[] duLieuAnh = File.ReadAllBytes(duongDanDayDu);

                using (var ms = new MemoryStream(duLieuAnh))
                using (var img = Image.FromStream(ms))
                {
                    return new Bitmap(img);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}