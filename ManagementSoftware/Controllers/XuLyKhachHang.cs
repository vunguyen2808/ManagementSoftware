using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyKhachHang
    {
        public QLShopDataContext db;

        public XuLyKhachHang()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<KhachHang> DanhSachKhachHang()
        {
            IList<KhachHang> dskh = new List<KhachHang>();
            var query = db.KhachHangs.ToList();
            {
                foreach (var kh in query)
                {
                    dskh.Add(new KhachHang()
                    {
                        MaKhachHang = kh.MaKhachHang,
                        TenKhachHang = kh.TenKhachHang,
                        GioiTinh = kh.GioiTinh,
                        DiaChi = kh.DiaChi,
                        DienThoai = kh.DienThoai,
                        NgaySinh = kh.NgaySinh
                    });
                }
                return dskh;
            }
        }
        public bool KiemTraTonTai(string p)
        {
            var dskh = db.KhachHangs.Where(m => m.MaKhachHang == p).ToList();
            if (dskh.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruKhachHang(string ma, string ten, string gt, string dc, string dt, DateTime ns)
        {
            var khachhangdata = new KhachHang()
            {
                MaKhachHang = ma,
                TenKhachHang = ten,              
                GioiTinh = gt,
                DiaChi = dc,
                DienThoai = dt,
                NgaySinh = ns
            };
            db.KhachHangs.InsertOnSubmit(khachhangdata);
            db.SubmitChanges();
        }
        public void CapNhatKhachHang(string ma, string ten, string gt, string dc, string dt, DateTime ns)
        {
            KhachHang kh = db.KhachHangs.Where(m => m.MaKhachHang == ma).SingleOrDefault();
            kh.TenKhachHang = ten;          
            kh.GioiTinh = gt;
            kh.DiaChi = dc;
            kh.DienThoai = dt;
            kh.NgaySinh = ns;
            db.SubmitChanges();
        }
        public void XoaKhachHang(string ma)
        {
            try
            {
                KhachHang kh = db.KhachHangs.Where(m => m.MaKhachHang == ma).SingleOrDefault();
                db.KhachHangs.DeleteOnSubmit(kh);
                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Không thể xóa vì hiện tại khách hàng này đang được lưu trữ", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
            }
        }
    }
}
