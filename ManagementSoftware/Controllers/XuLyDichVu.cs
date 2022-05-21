using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyDichVu
    {
        public QLShopDataContext db;
        public XuLyDichVu()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<DichVu> DanhSachDichVu()
        {
            IList<DichVu> dsdv = new List<DichVu>();
            var query = db.DichVus.ToList().Join(db.KhoChatLieus, p => p.MaChatLieu, c => c.MaChatLieu, (p, c) => new { p, c });
            foreach (var dv in query)
            {
                dsdv.Add(new DichVu()
                {
                    MaDichVu = dv.p.MaDichVu,
                    TenDichVu = dv.p.TenDichVu,
                    MaChatLieu = dv.c.TenChatLieu,
                    MucTieuHao = dv.p.MucTieuHao,
                    SoLuongChatLieu = dv.p.SoLuongChatLieu,
                    DonGiaNhap = dv.p.DonGiaNhap,
                    DonGiaBan = dv.p.DonGiaBan,
                    GhiChu = dv.p.GhiChu
                });
            }
            return dsdv;
        }
        public bool KiemTraTonTai(string p)
        {
            var dsscl = db.DichVus.Where(m => m.MaDichVu == p).ToList();
            if (dsscl.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruDichVu(string ma, string ten, string macl, string mth, string slcl, string dgn, string dgb, string gc)
        {
            var dichvudata = new DichVu()
            {
                MaDichVu = ma,
                TenDichVu = ten,
                MaChatLieu = macl,
                MucTieuHao = float.Parse(mth),
                SoLuongChatLieu = float.Parse(slcl),
                DonGiaNhap = decimal.Parse(dgn),
                DonGiaBan = decimal.Parse(dgb),
                GhiChu = gc
            };
            db.DichVus.InsertOnSubmit(dichvudata);
            db.SubmitChanges();
        }
        public void CapNhatDichVu(string ma, string ten, string macl, string mth, string slcl, string dgn, string dgb, string gc)
        {
            DichVu dv = db.DichVus.Where(m => m.MaDichVu == ma).SingleOrDefault();
            dv.TenDichVu = ten;
            dv.MaChatLieu = macl;
            dv.MucTieuHao = float.Parse(mth);
            dv.SoLuongChatLieu = float.Parse(slcl);
            dv.DonGiaNhap = decimal.Parse(dgn);
            dv.DonGiaBan = decimal.Parse(dgb);
            dv.GhiChu = gc;
            db.SubmitChanges();
        }
        public void XoaDichVu(string ma)
        {
            try
            {
                DichVu cl = db.DichVus.Where(m => m.MaDichVu == ma).SingleOrDefault();
                db.DichVus.DeleteOnSubmit(cl);
                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Không thể xóa vì hiện tại dịch vụ này đang được sử dụng", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
            }
        }
    }
}
