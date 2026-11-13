
using System;
using System.Collections.Generic;
using System.Linq;
using libabry_app.Data;

namespace libabry_app.Repository
{
    public class ChiTietMuonInput
    {
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
    }
    
    
    public class MuonSachRepository
    {
        // Lấy danh sách sách còn trong kho
        public List<Sach> LaySachConHang()
        {
            using (var db = new library_appEntities())
            {
                return db.Saches
                    .Where(s => s.SoLuong > 0)
                    .OrderBy(s => s.MaSach)
                    .ToList();
            }
        }

        // Tìm sách theo mã
        public Sach LaySach(string maSach)
        {
            using (var db = new library_appEntities())
            {
                return db.Saches
                    .FirstOrDefault(s => s.MaSach == maSach);
            }
        }

        // Lấy thông tin sinh viên theo MSSV
        public NguoiDung LaySinhVien(string maSo)
        {
            using (var db = new library_appEntities())
            {
                return db.NguoiDungs
                    .FirstOrDefault(n =>
                        n.MaSo == maSo &&
                        n.LoaiNguoiDung == "SinhVien");
            }
        }
        // Tính tổng số sách sinh viên đang mượn nhưng chưa trả
        public int LayTongSoLuongDangMuon(string maSo)
        {
            using (var db = new library_appEntities())
            {
                var tong = (from pm in db.PhieuMuons
                            join nd in db.NguoiDungs
                                on pm.MaNguoiMuon equals nd.MaNguoiDung
                            join ct in db.ChiTietPhieuMuons
                                on pm.MaPhieuMuon equals ct.MaPhieuMuon
                            where nd.MaSo == maSo
                            select ct.SoLuongMuon - ct.SoLuongDaTra)
                            .ToList()
                            .Sum();

                return tong;
            }
        }

        // Tạo phiếu mượn và cập nhật tồn kho
        public int TaoPhieuMuon(
            string maSo,
            DateTime ngayMuon,
            DateTime hanTra,
            List<ChiTietMuonInput> danhSachSach)
        {
            using (var db = new library_appEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Tìm sinh viên đang đăng nhập
                    var sinhVien = db.NguoiDungs
                        .FirstOrDefault(n =>
                            n.MaSo == maSo &&
                            n.LoaiNguoiDung == "SinhVien");

                    if (sinhVien == null)
                        throw new Exception("Không tìm thấy thông tin sinh viên.");

                    if (danhSachSach == null || danhSachSach.Count == 0)
                        throw new Exception("Danh sách sách mượn đang trống.");

                    if (hanTra.Date < ngayMuon.Date)
                        throw new Exception("Hạn trả không hợp lệ.");

                    // Tạo phiếu mượn
                    var phieuMuon = new libabry_app.Data.PhieuMuon
                    {
                        MaNguoiMuon = sinhVien.MaNguoiDung,

                        // Sinh viên tự đăng ký mượn
                        MaNguoiLap = sinhVien.MaNguoiDung,

                        NgayMuon = ngayMuon,
                        HanTra = hanTra
                    };

                    db.PhieuMuons.Add(phieuMuon);
                    db.SaveChanges();

                    // Thêm chi tiết và cập nhật số lượng sách
                    foreach (var item in danhSachSach)
                    {
                        var sach = db.Saches
                            .FirstOrDefault(s => s.MaSach == item.MaSach);

                        if (sach == null)
                            throw new Exception(
                                "Không tìm thấy sách có mã: " + item.MaSach);

                        if (item.SoLuong <= 0)
                            throw new Exception("Số lượng mượn phải lớn hơn 0.");

                        if (sach.SoLuong < item.SoLuong)
                            throw new Exception(
                                "Sách " + sach.TenSach +
                                " không còn đủ số lượng.");

                        var chiTiet = new libabry_app.Data.ChiTietPhieuMuon
                        {
                            MaPhieuMuon = phieuMuon.MaPhieuMuon,
                            MaSach = sach.MaSach,
                            SoLuongMuon = item.SoLuong,
                            SoLuongDaTra = 0
                        };

                        db.ChiTietPhieuMuons.Add(chiTiet);

                        sach.SoLuong -= item.SoLuong;
                    }

                    db.SaveChanges();
                    transaction.Commit();

                    return phieuMuon.MaPhieuMuon;
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
