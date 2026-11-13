using System;
using System.Collections.Generic;
using System.Linq;
using libabry_app.Data;

namespace libabry_app.Repository
{
    // Một dòng thống kê theo sách (dùng cho "còn lại" và "đang mượn")
    public class ThongKeSachItem
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int SoLuong { get; set; }
    }

    // Một dòng sách đã trả
    public class ThongKeDaTraItem
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaSo { get; set; }
        public DateTime NgayTra { get; set; }
    }

    public class ThongKeRepository
    {
        // 1) Sách còn lại = tổng số lượng - số đang được mượn
        //    (Nếu chức năng mượn đã TRỪ trực tiếp Sach.SoLuong thì đổi
        //     "s.SoLuong - dangMuon" thành "s.SoLuong")
        public List<ThongKeSachItem> LayConLai()
        {
            using (var db = new library_appEntities())
            {
                var data = db.Saches
                    .OrderBy(s => s.MaSach)
                    .Select(s => new
                    {
                        s.MaSach,
                        s.TenSach,
                        s.TacGia,
                        s.SoLuong,
                        DangMuon = s.ChiTietPhieuMuons
                            .Sum(c => (int?)(c.SoLuongMuon - c.SoLuongDaTra)) ?? 0
                    })
                    .ToList();

                return data.Select(x => new ThongKeSachItem
                {
                    MaSach = x.MaSach,
                    TenSach = x.TenSach,
                    TacGia = x.TacGia ?? "",
                    SoLuong = x.SoLuong - x.DangMuon
                }).ToList();
            }
        }

        // 2) Sách đang được mượn (còn chưa trả)
        public List<ThongKeSachItem> LayDangMuon()
        {
            using (var db = new library_appEntities())
            {
                var data = db.Saches
                    .Select(s => new
                    {
                        s.MaSach,
                        s.TenSach,
                        s.TacGia,
                        DangMuon = s.ChiTietPhieuMuons
                            .Sum(c => (int?)(c.SoLuongMuon - c.SoLuongDaTra)) ?? 0
                    })
                    .Where(x => x.DangMuon > 0)
                    .OrderBy(x => x.MaSach)
                    .ToList();

                return data.Select(x => new ThongKeSachItem
                {
                    MaSach = x.MaSach,
                    TenSach = x.TenSach,
                    TacGia = x.TacGia ?? "",
                    SoLuong = x.DangMuon
                }).ToList();
            }
        }

        // 3) Sách đã trả trong khoảng ngày [tu, den] (tính cả hai đầu)
        public List<ThongKeDaTraItem> LayDaTra(DateTime tu, DateTime den)
        {
            tu = tu.Date;
            den = den.Date;

            using (var db = new library_appEntities())
            {
                return (from ct in db.ChiTietPhieuTras
                        join pt in db.PhieuTras on ct.MaPhieuTra equals pt.MaPhieuTra
                        join cm in db.ChiTietPhieuMuons on ct.MaChiTietMuon equals cm.MaChiTietMuon
                        join pm in db.PhieuMuons on pt.MaPhieuMuon equals pm.MaPhieuMuon
                        join s in db.Saches on cm.MaSach equals s.MaSach
                        join nd in db.NguoiDungs on pm.MaNguoiMuon equals nd.MaNguoiDung
                        where pt.NgayTra >= tu && pt.NgayTra <= den
                        orderby pt.NgayTra descending, s.MaSach
                        select new ThongKeDaTraItem
                        {
                            MaSach = s.MaSach,
                            TenSach = s.TenSach,
                            MaSo = nd.MaSo,
                            NgayTra = pt.NgayTra
                        }).ToList();
            }
        }
    }
}
