using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Controllers
{
    class XuLyDangNhap
    {
        public QLShopDataContext db;
        public XuLyDangNhap()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<DangNhap> DanhSachDangNhap()
        {
            IList<DangNhap> dsdn = new List<DangNhap>();
            var query = db.DangNhaps.ToList();
            foreach (var dn in query)
            {
                dsdn.Add(new DangNhap()
                {
                    TaiKhoan = dn.TaiKhoan,
                    MatKhau = dn.MatKhau,
                    Quyen = dn.Quyen
                });
            }
            return dsdn;
        }
        public bool KiemTraTaiKhoan(string p)
        {
            var dssdn = db.DangNhaps.Where(m => m.TaiKhoan == p).ToList();
            if (dssdn.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool KiemTraMatKhau(string p)
        {
            var dssdn = db.DangNhaps.Where(m => m.MatKhau == p).ToList();
            if (dssdn.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruDangNhap(string ma, string ten, string tk, string mk, string q, string gt, string dc, string dt, DateTime ns)
        {
            var dangnhapdata = new DangNhap()
            {
                TaiKhoan = tk,
                MatKhau = mk,
                Quyen = q
            };
            db.DangNhaps.InsertOnSubmit(dangnhapdata);           

            var nhanviendata = new NhanVien()
            {
                MaNhanVien = ma,
                TenNhanVien = ten,
                TaiKhoan = tk,
                Quyen = q,
                GioiTinh = gt,
                DiaChi = dc,
                DienThoai = dt,
                NgaySinh = ns
            };
            db.NhanViens.InsertOnSubmit(nhanviendata);
            db.SubmitChanges();
        }
        public void CapNhatDangNhap(string tk, string mk, string q)
        {
            DangNhap dn = db.DangNhaps.Where(m => m.TaiKhoan == tk).SingleOrDefault();
            dn.MatKhau = mk;
            dn.Quyen = q;
            db.SubmitChanges();
        }
        public void XoaDangNhap(string tk)
        {
            DangNhap dn = db.DangNhaps.Where(m => m.TaiKhoan == tk).SingleOrDefault();
            db.DangNhaps.DeleteOnSubmit(dn);
            db.SubmitChanges();
        }
    }
}
