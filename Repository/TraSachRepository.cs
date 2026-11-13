
using System;
using System.Collections.Generic;
using System.Linq;
using libabry_app.Data;

namespace libabry_app.Repository
{
    public class SachDangMuon
    {
        public int MaChiTietMuon { get; set; }
        public int MaPhieuMuon { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuongConLai { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
    }

    public class KetQuaTraSach
    {
        public int TongSoLuongTra { get; set; }
        public int SoNgayTre { get; set; }
        public string TenSach { get; set; }
    }

    public class TraSachRepository
    {
        // Lấy danh sách sách sinh viên đang mượn chưa trả hết
        public List<SachDangMuon> LaySachDangMuon(string maSo)
        {
            using (var db = new library_appEntities())
            {
                var danhSach =
                    (from ct in db.ChiTietPhieuMuons
                     join pm in db.PhieuMuons
                         on ct.MaPhieuMuon equals pm.MaPhieuMuon
                     join nd in db.NguoiDungs
                         on pm.MaNguoiMuon equals nd.MaNguoiDung
                     join s in db.Saches
                         on ct.MaSach equals s.MaSach
                     where nd.MaSo == maSo
                           && ct.SoLuongMuon > ct.SoLuongDaTra
                     orderby pm.NgayMuon descending
                     select new SachDangMuon
                     {
                         MaChiTietMuon = ct.MaChiTietMuon,
                         MaPhieuMuon = pm.MaPhieuMuon,
                         MaSach = s.MaSach,
                         TenSach = s.TenSach,
                         SoLuongConLai =
                             ct.SoLuongMuon - ct.SoLuongDaTra,
                         NgayMuon = pm.NgayMuon,
                         HanTra = pm.HanTra
                     }).ToList();

                return danhSach;
            }
        }

        // Trả toàn bộ số lượng còn lại của một mã sách
        public KetQuaTraSach TraSach(
            string maSo,
            string maSach,
            DateTime ngayTra)
        {
            using (var db = new library_appEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Xác định sinh viên
                    var sinhVien = db.NguoiDungs
                        .FirstOrDefault(n =>
                            n.MaSo == maSo &&
                            n.LoaiNguoiDung == "SinhVien");

                    if (sinhVien == null)
                        throw new Exception(
                            "Không tìm thấy thông tin sinh viên.");

                    // Lấy các chi tiết mượn còn sách chưa trả
                    var cacChiTiet =
                        (from ct in db.ChiTietPhieuMuons
                         join pm in db.PhieuMuons
                             on ct.MaPhieuMuon equals pm.MaPhieuMuon
                         where pm.MaNguoiMuon == sinhVien.MaNguoiDung
                               && ct.MaSach == maSach
                               && ct.SoLuongMuon > ct.SoLuongDaTra
                         select new
                         {
                             ChiTiet = ct,
                             Phieu = pm
                         }).ToList();

                    if (cacChiTiet.Count == 0)
                        throw new Exception(
                            "Bạn không có sách này cần trả.");

                    if (cacChiTiet.Any(x =>
                        ngayTra.Date < x.Phieu.NgayMuon.Date))
                    {
                        throw new Exception(
                            "Ngày trả không được trước ngày mượn.");
                    }

                    var sach = db.Saches
                        .FirstOrDefault(s => s.MaSach == maSach);

                    if (sach == null)
                        throw new Exception("Không tìm thấy sách.");

                    int tongSoLuong = 0;
                    int soNgayTre = 0;

                    // Mỗi phiếu mượn gốc có một phiếu trả tương ứng
                    foreach (var nhom in cacChiTiet.GroupBy(
                        x => x.Phieu.MaPhieuMuon))
                    {
                        var phieuMuon = nhom.First().Phieu;

                        var phieuTra = new libabry_app.Data.PhieuTra
                        {
                            MaPhieuMuon = phieuMuon.MaPhieuMuon,
                            MaNguoiLap = sinhVien.MaNguoiDung,
                            NgayTra = ngayTra.Date
                        };

                        db.PhieuTras.Add(phieuTra);
                        db.SaveChanges();

                        foreach (var item in nhom)
                        {
                            var chiTietMuon = item.ChiTiet;

                            int soLuongCon =
                                chiTietMuon.SoLuongMuon -
                                chiTietMuon.SoLuongDaTra;

                            if (soLuongCon <= 0)
                                continue;

                            var chiTietTra =
                                new libabry_app.Data.ChiTietPhieuTra
                                {
                                    MaPhieuTra = phieuTra.MaPhieuTra,
                                    MaChiTietMuon =
                                        chiTietMuon.MaChiTietMuon,
                                    SoLuongTra = soLuongCon
                                };

                            db.ChiTietPhieuTras.Add(chiTietTra);

                            chiTietMuon.SoLuongDaTra += soLuongCon;
                            sach.SoLuong += soLuongCon;

                            tongSoLuong += soLuongCon;

                            int tre =
                                (ngayTra.Date - phieuMuon.HanTra.Date).Days;

                            if (tre > soNgayTre)
                                soNgayTre = tre;
                        }

                        db.SaveChanges();
                    }

                    transaction.Commit();

                    return new KetQuaTraSach
                    {
                        TongSoLuongTra = tongSoLuong,
                        SoNgayTre = soNgayTre,
                        TenSach = sach.TenSach
                    };
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
