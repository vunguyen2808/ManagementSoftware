using ManagementSoftware.Controllers;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Forms
{
    public partial class FormKhachHang : Form
    {
        XuLyKhachHang xlkh = new XuLyKhachHang();
        bool themmoi = true;
        public FormKhachHang()
        {
            InitializeComponent();
            HienThiDanhSachKhachHang();
            setButton(true);
            dtNgaySinh.Value = DateTime.Now;
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;

            txtMaKhachHang.Enabled = !value;
            txtTenKhachHang.Enabled = !value;
            txtDiaChi.Enabled = !value;
            txtDienThoai.Enabled = !value;
            cbGioiTinh.Enabled = !value;
            dtNgaySinh.Enabled = !value;
        }
        private void ResetValue()
        {
            txtMaKhachHang.Text = null;
            txtTenKhachHang.Text = null;
            txtDiaChi.Text = null;
            cbGioiTinh.Text = null;
            txtDienThoai.Text = null;
            dtNgaySinh.ResetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();
            setButton(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValue();
            setButton(false);
            txtMaKhachHang.Text = Functions.CreateKey("KH");
        }
        private void HienThiDanhSachKhachHang()
        {
            lsvKhachHang.Items.Clear();
            lsvKhachHang.FullRowSelect = true;
            lsvKhachHang.View = View.Details;
            IEnumerable<KhachHang> dskh = xlkh.DanhSachKhachHang();
            if (dskh.Count() > 0)
            {
                foreach (KhachHang kh in dskh)
                {
                    ListViewItem lvi;
                    lvi = lsvKhachHang.Items.Add(kh.MaKhachHang.ToString());
                    lvi.SubItems.Add(kh.TenKhachHang.ToString());
                    lvi.SubItems.Add(kh.GioiTinh.ToString());
                    lvi.SubItems.Add(kh.DienThoai.ToString());
                    lvi.SubItems.Add(kh.NgaySinh.ToString());
                    lvi.SubItems.Add(kh.DiaChi.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
                txtMaKhachHang.Enabled = false;
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cập nhật", "Sửa Mẫu Tin", MessageBoxButtons.OK,
                                                                          MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa Khách Hàng",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlkh.XoaKhachHang(lsvKhachHang.SelectedItems[0].SubItems[0].Text);
                    lsvKhachHang.Items.RemoveAt(lsvKhachHang.SelectedIndices[0]);
                    ResetValue();
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẩu tin cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã chất liệu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên chất liệu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (themmoi)
            {
                if (xlkh.KiemTraTonTai(txtMaKhachHang.Text.Trim()))
                {
                    MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Warning);
                    return;
                }
                xlkh.LuuTruKhachHang(txtMaKhachHang.Text.Trim(), txtTenKhachHang.Text.Trim(), cbGioiTinh.Text.Trim(), txtDiaChi.Text.Trim(),
                                                                 txtDienThoai.Text.Trim(), dtNgaySinh.Value.Date);
                MessageBox.Show("Thêm mới thành công", "Thêm Khách Hàng !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            else
            {
                xlkh.CapNhatKhachHang(txtMaKhachHang.Text.Trim(), txtTenKhachHang.Text.Trim(), cbGioiTinh.Text.Trim(), txtDiaChi.Text.Trim(),
                                                                 txtDienThoai.Text.Trim(), dtNgaySinh.Value.Date);
                MessageBox.Show("Cập nhật thành công", "Cập nhật Khách Hàng !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            HienThiDanhSachKhachHang();
            ResetValue();
            setButton(true);
        }
        private void lsvKhachHang_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvKhachHang.SelectedItems)
            {
                txtMaKhachHang.Text = items.SubItems[0].Text;
                txtTenKhachHang.Text = items.SubItems[1].Text;
                cbGioiTinh.Text = items.SubItems[2].Text;
                txtDienThoai.Text = items.SubItems[3].Text;
                dtNgaySinh.Text = items.SubItems[4].Text;
                txtDiaChi.Text = items.SubItems[5].Text;
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
