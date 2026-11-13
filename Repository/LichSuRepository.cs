
using System;
using System.Collections.Generic;
using System.Linq;
using libabry_app.Data;

namespace libabry_app.Repository
{
    public class LichSuMuonItem
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
    }

    public class LichSuRepository
    {
        public List<LichSuMuonItem> LayLichSu(string maSo)
        {
            using (var db = new library_appEntities())
            {
                var danhSach =
                    (from pm in db.PhieuMuons
                     join nd in db.NguoiDungs
                         on pm.MaNguoiMuon equals nd.MaNguoiDung
                     join ct in db.ChiTietPhieuMuons
                         on pm.MaPhieuMuon equals ct.MaPhieuMuon
                     join s in db.Saches
                         on ct.MaSach equals s.MaSach
                     where nd.MaSo == maSo
                     orderby pm.NgayMuon descending
                     select new LichSuMuonItem
                     {
                         MaSach = s.MaSach,
                         TenSach = s.TenSach,
                         SoLuong = ct.SoLuongMuon,
                         NgayMuon = pm.NgayMuon,
                         HanTra = pm.HanTra
                     }).ToList();

                return danhSach;
            }
        }
    }
}
