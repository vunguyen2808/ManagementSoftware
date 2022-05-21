using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Controllers
{
    class XuLyChiTietHoaDon
    {
        public QLShopDataContext db;
        public XuLyChiTietHoaDon()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<CTHoaDon> DanhSachChiTietHoaDon()
        {
            IList<CTHoaDon> dscthd = new List<CTHoaDon>();
            var query = db.CTHoaDons.ToList();
            foreach (var cthd in query)
            {
                dscthd.Add(new CTHoaDon()
                {
                    MaGiay = cthd.MaGiay,
                    MaHoaDon = cthd.MaHoaDon,
                    MaDichVu = cthd.MaDichVu,
                    SoLuong = cthd.SoLuong,
                    DonGia = cthd.DonGia,
                    GiamGia = cthd.GiamGia,
                    ThanhTien = cthd.ThanhTien
                });
            }
            return dscthd;
        }
        public bool KiemTraTonTai(string p)
        {
            var dscthd = db.CTHoaDons.Where(m => m.MaHoaDon == p).ToList();
            if (dscthd.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruChiTietHoaDon(string mag ,string mahd, string madv, string sl, string dg, string gg, string tong)
        {
            var cthoadondata = new CTHoaDon()
            {
                MaGiay = mag,
                MaHoaDon = mahd,
                MaDichVu = madv,
                SoLuong = int.Parse(sl),
                DonGia = decimal.Parse(dg),
                GiamGia = int.Parse(gg),
                ThanhTien = decimal.Parse(tong),
            };
            db.CTHoaDons.InsertOnSubmit(cthoadondata);
            db.SubmitChanges();
        }
        public void CapNhatChiTietHoaDon(string mag, string mahd, string madv, string sl, string dg, string gg, string tong)
        {
            CTHoaDon cthd = db.CTHoaDons.Where(m => m.MaHoaDon == mahd).SingleOrDefault();
            cthd.MaGiay = mag;
            cthd.MaDichVu = madv;
            cthd.SoLuong = int.Parse(sl);
            cthd.DonGia = decimal.Parse(dg);
            cthd.GiamGia = int.Parse(gg);
            cthd.ThanhTien = decimal.Parse(tong);
            db.SubmitChanges();
        }
    }
}
