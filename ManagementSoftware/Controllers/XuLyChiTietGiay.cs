using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyChiTietGiay
    {
        public QLShopDataContext db;
        public XuLyChiTietGiay()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<CTGiay> DanhSachChiTietGiay()
        {
            IList<CTGiay> dsctg = new List<CTGiay>();
            var query = db.CTGiays.ToList().Join(db.DichVus, p => p.MaDichVu, c => c.MaDichVu, (p, c) => new { p, c });
            foreach (var ctg in query)
            {
                dsctg.Add(new CTGiay()
                {
                    MaHoaDon = ctg.p.MaHoaDon,
                    MaGiay = ctg.p.MaGiay,
                    HangGiay = ctg.p.HangGiay,
                    TenGiay = ctg.p.TenGiay,
                    MaDichVu = ctg.c.TenDichVu,
                    GhiChu = ctg.p.GhiChu,
                });
            }
            return dsctg;
        }
        public void LuuTruGiay(string mhd, string mag, string hang, string ten, string mdv,string gc, string hinh)
        {
            var giaydata = new CTGiay()
            {
                MaHoaDon = mhd,
                MaGiay = mag,
                HangGiay = hang,
                TenGiay = ten,
                MaDichVu = mdv,
                GhiChu = gc,
                Hinh = hinh
            };
            db.CTGiays.InsertOnSubmit(giaydata);
            db.SubmitChanges();
        }
        public void CapNhatGiay(string mhd, string mag, string hang, string ten, string mdv, string gc, string hinh)
        {
            CTGiay giay = db.CTGiays.Where(m => m.MaGiay == mag).SingleOrDefault();
            giay.MaHoaDon = mhd;
            giay.HangGiay = hang;
            giay.TenGiay = ten;
            giay.MaDichVu = mdv;
            giay.GhiChu = gc;
            giay.Hinh = hinh;
            db.SubmitChanges();
        }        
    }
}
