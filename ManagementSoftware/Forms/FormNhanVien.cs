using ManagementSoftware.Controllers;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.Forms
{
    public partial class FormNhanVien : Form
    {
        XuLyDangNhap xldn = new XuLyDangNhap();
        XuLyNhanVien xlnv = new XuLyNhanVien();
        bool themmoi = true;
        public FormNhanVien()
        {
            InitializeComponent();
            HienThiDanhSachNhanVien();
            setButton(true);
            lbThongBao.Text = null;
            dtNgaySinh.Value = DateTime.Now;

            string sql = "SELECT * FROM DangNhap";
            cbTaiKhoan.DataSource = Database.Singleton.LoadData(sql);
            //Sử dụng DisplayMember show dữ liệu mà combobox muốn sở hửu
            cbTaiKhoan.DisplayMember = "TaiKhoan";
            cbChucVu.Text = cbTaiKhoan.Text;
            cbTaiKhoan.Text = null;
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;

            txtMaNhanVien.Enabled = !value;
            txtTenNhanVien.Enabled = !value;
            cbTaiKhoan.Enabled = !value;
            cbChucVu.Enabled = !value;
            cbGioiTinh.Enabled = !value;
            txtDiaChi.Enabled = !value;
            txtDienThoai.Enabled = !value;
            dtNgaySinh.Enabled = !value;
        }
        private void ResetValue()
        {
            txtMaNhanVien.Text = null;
            txtTenNhanVien.Text = null;
            cbTaiKhoan.Text = null;
            cbChucVu.Text = null;
            cbGioiTinh.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            dtNgaySinh.ResetText();
            lbThongBao.Text = null;
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
            txtMaNhanVien.Text = Functions.CreateKey("NV");
            lbThongBao.Text = "Đây sẽ là password của tài khoản mới này !";
        }
        private void HienThiDanhSachNhanVien()
        {
            lsvNhanVien.Items.Clear();
            lsvNhanVien.FullRowSelect = true;
            lsvNhanVien.View = View.Details;
            IEnumerable<NhanVien> dsnv = xlnv.DanhSachNhanVien();
            if (dsnv.Count() > 0)
            {
                foreach (NhanVien cl in dsnv)
                {
                    ListViewItem lvi;
                    lvi = lsvNhanVien.Items.Add(cl.MaNhanVien.ToString());
                    lvi.SubItems.Add(cl.TenNhanVien.ToString());
                    lvi.SubItems.Add(cl.TaiKhoan.ToString());
                    lvi.SubItems.Add(cl.Quyen.ToString());
                    lvi.SubItems.Add(cl.GioiTinh.ToString());
                    lvi.SubItems.Add(cl.DiaChi.ToString());
                    lvi.SubItems.Add(cl.DienThoai.ToString());
                    lvi.SubItems.Add(cl.NgaySinh.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
                txtMaNhanVien.Enabled = false;
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cập nhật", "Sửa Mẫu Tin", MessageBoxButtons.OK,
                                                                          MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa Nhân Viên",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlnv.XoaNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text, cbTaiKhoan.Text.Trim());
                    lsvNhanVien.Items.RemoveAt(lsvNhanVien.SelectedIndices[0]);
                    ResetValue();
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẩu tin cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã nhân viên", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên nhân viên", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (cbTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên tài khoản mới", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số điện thoại này sẽ là password của bạn - không được bỏ trống", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (themmoi)
            {
                if (xlnv.KiemTraTonTai(txtMaNhanVien.Text.Trim()) != true)
                {
                    if (xldn.KiemTraTaiKhoan(cbTaiKhoan.Text.Trim()) != true)
                    {
                        xlnv.LuuTruNhanVien(txtMaNhanVien.Text.Trim(), txtTenNhanVien.Text.Trim(), cbTaiKhoan.Text.Trim(), cbChucVu.Text.Trim(),
                                                                    cbGioiTinh.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), dtNgaySinh.Value.Date);
                        MessageBox.Show("Thêm mới thành công", "Thêm Nhân Viên !", MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning);
                        
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này đã có, bạn phải nhập tài khoản khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Warning);
                        return;
                    }                   
                }
                else
                {
                    MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Warning);
                    return;
                }               
            }
            else
            {
                xlnv.CapNhatNhanVien(txtMaNhanVien.Text.Trim(), txtTenNhanVien.Text.Trim(), cbTaiKhoan.Text.Trim(), cbChucVu.Text.Trim(), 
                                                                cbGioiTinh.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), dtNgaySinh.Value.Date);
                MessageBox.Show("Cập nhật thành công", "Cập nhật Nhân Viên !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            HienThiDanhSachNhanVien();
            ResetValue();
            setButton(true);
        }

        private void lsvNhanVien_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvNhanVien.SelectedItems)
            {
                txtMaNhanVien.Text = items.SubItems[0].Text;
                txtTenNhanVien.Text = items.SubItems[1].Text;
                cbTaiKhoan.Text = items.SubItems[2].Text;
                cbChucVu.Text = items.SubItems[3].Text;
                cbGioiTinh.Text = items.SubItems[4].Text;
                txtDiaChi.Text = items.SubItems[5].Text;
                txtDienThoai.Text = items.SubItems[6].Text;
                dtNgaySinh.Text = items.SubItems[7].Text;
            }
        }
        private void cbTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbTaiKhoan.Text == "")
            {
                cbChucVu.Text = null;
            }
            str = "SELECT Quyen FROM DangNhap WHERE TaiKhoan = N'" + cbTaiKhoan.Text.Trim() + "'";
            cbChucVu.Text = Functions.GetFieldValues(str);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
