using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Controllers
{
    class XuLyChatLieu
    {
        public QLShopDataContext db;
        public XuLyChatLieu()
        {
            db = new QLShopDataContext();
        }
        public IEnumerable<KhoChatLieu> DanhSachChatLieu()
        {
            IList<KhoChatLieu> dscl = new List<KhoChatLieu>();
            var query = db.KhoChatLieus.ToList();
            foreach (var dn in query)
            {
                dscl.Add(new KhoChatLieu()
                {
                    MaChatLieu = dn.MaChatLieu,
                    TenChatLieu = dn.TenChatLieu,
                    SoLuong = dn.SoLuong,
                    DonVi = dn.DonVi,
                    Hinh = dn.Hinh
                });
            }
            return dscl;
        }
        public bool KiemTraTonTai(string p)
        {
            var dsscl = db.KhoChatLieus.Where(m => m.MaChatLieu == p).ToList();
            if (dsscl.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void LuuTruChatLieu(string ma, string ten, string sl, string dv, string hinh)
        {
            var chatlieudata = new KhoChatLieu()
            {
                MaChatLieu = ma,
                TenChatLieu = ten,
                SoLuong = int.Parse(sl),
                DonVi = dv,
                Hinh = hinh
            };
            db.KhoChatLieus.InsertOnSubmit(chatlieudata);
            db.SubmitChanges();
        }
        public void CapNhatChatLieu(string ma, string ten, string sl, string dv, string hinh)
        {
            KhoChatLieu cl = db.KhoChatLieus.Where(m => m.MaChatLieu == ma).SingleOrDefault();
            cl.TenChatLieu = ten;
            cl.SoLuong = int.Parse(sl);
            cl.DonVi = dv;
            cl.Hinh = hinh;
            db.SubmitChanges();
        }
        public void XoaChatLieu(string ma)
        {
            try
            {
                KhoChatLieu cl = db.KhoChatLieus.Where(m => m.MaChatLieu == ma).SingleOrDefault();
                db.KhoChatLieus.DeleteOnSubmit(cl);
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
