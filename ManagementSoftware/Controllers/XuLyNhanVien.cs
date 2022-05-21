using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyNhanVien
    {
        public QLShopDataContext db;
        public XuLyNhanVien()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<NhanVien> DanhSachNhanVien()
        {
            IList<NhanVien> dsnv = new List<NhanVien>();
            //Note: Đệ qui
            var query = db.NhanViens.ToList().Join(db.DangNhaps, p => p.TaiKhoan, c => c.TaiKhoan, (p, c) => new { p, c });
            foreach (var nv in query)
            {
                dsnv.Add(new NhanVien()
                {
                    MaNhanVien = nv.p.MaNhanVien,
                    TenNhanVien = nv.p.TenNhanVien,
                    TaiKhoan = nv.c.TaiKhoan,
                    Quyen = nv.c.Quyen,
                    GioiTinh = nv.p.GioiTinh,
                    DiaChi = nv.p.DiaChi,
                    DienThoai = nv.p.DienThoai,
                    NgaySinh = nv.p.NgaySinh
                });
            }
            return dsnv;
        }
        public bool KiemTraTonTai(string p)
        {
            var dsnv = db.NhanViens.Where(m => m.MaNhanVien == p).ToList();
            if (dsnv.Count > 0)
            {
                return true;
            }
            return false;
        }       
        public void LuuTruNhanVien(string ma, string ten, string tk, string q, string gt, string dc, string dt, DateTime ns)
        {
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

            var dangnhapdata = new DangNhap()
            {
                TaiKhoan = tk,
                MatKhau = dt,
                Quyen = q
            };
            db.DangNhaps.InsertOnSubmit(dangnhapdata);           
            db.SubmitChanges();
        }
        public void CapNhatNhanVien(string ma, string ten, string tk, string q, string gt, string dc, string dt, DateTime ns)
        {
            NhanVien nv = db.NhanViens.Where(m => m.MaNhanVien == ma).SingleOrDefault();
            nv.TenNhanVien = ten;
            nv.TaiKhoan = tk;
            nv.Quyen = q;
            nv.GioiTinh = gt;
            nv.DiaChi = dc;
            nv.DienThoai = dt;
            nv.NgaySinh = ns;

            DangNhap dn = db.DangNhaps.Where(m => m.TaiKhoan == tk).SingleOrDefault();           
            dn.Quyen = q;
            db.SubmitChanges();
        }
        public void XoaNhanVien(string ma, string tk)
        {
            try
            {
                NhanVien nv = db.NhanViens.Where(m => m.MaNhanVien == ma).SingleOrDefault();
                db.NhanViens.DeleteOnSubmit(nv);

                DangNhap dn = db.DangNhaps.Where(m => m.TaiKhoan == tk).SingleOrDefault();
                db.DangNhaps.DeleteOnSubmit(dn);
                db.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Không thể xóa vì hiện tại nhân viên này đang được lưu trữ", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
            }
        }
    }
}
