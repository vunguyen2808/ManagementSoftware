using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyHoaDon
    {
        public QLShopDataContext db;
        public XuLyHoaDon()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<HoaDon> DanhSachHoaDon()
        {
            IList<HoaDon> dshd = new List<HoaDon>();
            var query = db.HoaDons.ToList();
            foreach (var hd in query)
            {
                dshd.Add(new HoaDon()
                {
                    MaHoaDon = hd.MaHoaDon,
                    MaKhachHang = hd.MaKhachHang,
                    MaNhanVien = hd.MaNhanVien,
                    NgayBan = hd.NgayBan,
                    CaBan = hd.CaBan,
                    TongTien = hd.TongTien,
                    TienNhan = hd.TienNhan,
                    TienThua = hd.TienThua
                });
            }
            return dshd;
        }
        public bool KiemTraTonTai(string p)
        {
            var dshd = db.HoaDons.Where(m => m.MaHoaDon == p).ToList();
            if (dshd.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruHoaDon(string mahd, string makh, string manv, DateTime nb, string cb, string tong, string nhan, string thua)
        {
            var hoadondata = new HoaDon()
            {
                MaHoaDon = mahd,
                MaKhachHang = makh,
                MaNhanVien = manv,
                NgayBan = nb,
                CaBan = cb,
                TongTien = decimal.Parse(tong),
                TienNhan = decimal.Parse(nhan),
                TienThua = decimal.Parse(thua)
            };
            db.HoaDons.InsertOnSubmit(hoadondata);
            db.SubmitChanges();
        }
        public void CapNhatHoaDon(string mahd, string makh, string manv, DateTime nb, string cb, string tong, string nhan, string thua)
        {
            HoaDon hd = db.HoaDons.Where(m => m.MaHoaDon == mahd).SingleOrDefault();
            hd.MaKhachHang = makh;
            hd.MaNhanVien = manv;
            hd.NgayBan = nb;
            hd.CaBan = cb;
            hd.TongTien = decimal.Parse(tong);
            hd.TienNhan = decimal.Parse(nhan);
            hd.TienThua = decimal.Parse(thua);
            db.SubmitChanges();
        }
        public void XoaHoaDon(string ma)
        {
            try
            {
                HoaDon hd = db.HoaDons.Where(m => m.MaHoaDon == ma).SingleOrDefault();
                db.HoaDons.DeleteOnSubmit(hd);
                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Không thể xóa vì hiện tại chất liệu này đang được sử dụng", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
            }
        }
    }
}
