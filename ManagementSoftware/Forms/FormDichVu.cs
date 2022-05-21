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
    public partial class FormDichVu : Form
    {
        Form1 form1 = new Form1();
        XuLyDichVu xldv = new XuLyDichVu();
        DataTable tblCTHD;
        bool themmoi = true;
        public FormDichVu()
        {
            InitializeComponent();
            HienThiDanhSachDichVu();
            setButton(true);
            string sql;

            sql = "SELECT * FROM KhoChatLieu";
            cbMaChatLieu.DataSource = Database.Singleton.LoadData(sql);
            //Sử dụng DisplayMember show dữ liệu mà combobox muốn sở hửu
            cbMaChatLieu.DisplayMember = "TenChatLieu";
            //Sử dụng ValueMember lấy dữ liệu cung cấp cho Combobox
            cbMaChatLieu.ValueMember = "MaChatLieu";
            if (cbMaChatLieu.Items.Count > 0)
            {                
                cbMaChatLieu.Text = null;
            }

            float slk, mth, tong;
            string madv, macl;
            sql = "SELECT * FROM DichVu";
            tblCTHD = Functions.GetDataToTable(sql);
            for (int i = 0; i < tblCTHD.Rows.Count; i++)
            {
                DataRow dr = tblCTHD.Rows[i];
                madv = dr[0].ToString();
                macl = dr[2].ToString();
                slk = float.Parse(Functions.GetFieldValues("SELECT SoLuong FROM KhoChatLieu WHERE MaChatLieu = N'" + macl + "'"));
                mth = float.Parse(Functions.GetFieldValues("SELECT MucTieuHao FROM DichVu WHERE MaDichVu = N'" + madv + "'"));
                tong = slk / mth;
                sql = "UPDATE DichVu SET SoLuongChatLieu = " + tong + " WHERE MaDichVu = N'" + madv + "'";
                Functions.RunSQL(sql);
            }
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;

            txtMaDichVu.Enabled = !value;
            txtTenDichVu.Enabled = !value;
            txtSoLuong.Enabled = !value;
            txtMucTieuHao.Enabled = !value;
            txtDonGiaNhap.Enabled = !value;
            txtDonGiaBan.Enabled = !value;
            txtGhiChu.Enabled = !value;
            cbMaChatLieu.Enabled = !value;
        }
        private void ResetValue()
        {
            txtMaDichVu.Text = null;
            txtTenDichVu.Text = null;
            cbMaChatLieu.Text = null;
            txtMucTieuHao.Text = null;
            txtSoLuong.Text = null;
            txtDonGiaNhap.Text = null;
            txtDonGiaBan.Text = null;
            txtGhiChu.Text = null;
            lblSoLuongKho.Text = null;
            lblDonVi.Text = null;                        
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();
            setButton(true);
        }   
        private void HienThiDanhSachDichVu()
        {
            lsvDichVu.Items.Clear();
            lsvDichVu.FullRowSelect = true;
            lsvDichVu.View = View.Details;
            IEnumerable<DichVu> dsdv = xldv.DanhSachDichVu();
            if (dsdv.Count() > 0)
            {
                foreach (DichVu cl in dsdv)
                {
                    ListViewItem lvi;
                    lvi = lsvDichVu.Items.Add(cl.MaDichVu.ToString());
                    lvi.SubItems.Add(cl.TenDichVu.ToString());
                    lvi.SubItems.Add(cl.MaChatLieu.ToString());
                    lvi.SubItems.Add(cl.MucTieuHao.ToString());
                    lvi.SubItems.Add(cl.SoLuongChatLieu.ToString());
                    lvi.SubItems.Add(cl.DonGiaNhap.ToString());
                    lvi.SubItems.Add(cl.DonGiaBan.ToString());
                    lvi.SubItems.Add(cl.GhiChu.ToString());
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {           
            themmoi = true;
            ResetValue();
            setButton(false);
            txtMaDichVu.Text = Functions.CreateKey("DV");
            txtMucTieuHao.ReadOnly = true;
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvDichVu.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
                txtMaDichVu.Enabled = false;                               
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cập nhật", "Sửa Mẫu Tin", MessageBoxButtons.OK,
                                                                          MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvDichVu.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa Dịch Vụ",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xldv.XoaDichVu(lsvDichVu.SelectedItems[0].SubItems[0].Text);
                    lsvDichVu.Items.RemoveAt(lsvDichVu.SelectedIndices[0]);
                    ResetValue();
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẩu tin cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã dịch vụ", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtTenDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên dịch vụ", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (cbMaChatLieu.Text.Trim().Length ==0 )
            {
                MessageBox.Show("Bạn cần nhập tên chất liệu", "Thông Báo !", MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Information);
                return;
            }
            if (themmoi)
            {
                if (xldv.KiemTraTonTai(txtMaDichVu.Text.Trim()))
                {
                    MessageBox.Show("Mã dịch vụ này đã có, bạn phải nhập mã khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (txtDonGiaBan.Text == "")
                    {
                        txtDonGiaBan.Text = "0";                   
                    }
                    if (txtDonGiaNhap.Text == "")
                    {
                        txtDonGiaNhap.Text = "0";
                    }
                    if (txtSoLuong.Text == "")
                    {
                        txtSoLuong.Text = "0";
                    }
                    xldv.LuuTruDichVu(txtMaDichVu.Text.Trim(), txtTenDichVu.Text.Trim(), cbMaChatLieu.SelectedValue.ToString(), txtMucTieuHao.Text.Trim(),
                                            txtSoLuong.Text.Trim(), txtDonGiaNhap.Text.Trim(), txtDonGiaBan.Text.Trim(), txtGhiChu.Text.Trim());
                    MessageBox.Show("Thêm mới thành công", "Thêm Dịch Vụ !", MessageBoxButtons.OK,
                                                                                      MessageBoxIcon.Warning);
                }                
            }
            else
            {
                xldv.CapNhatDichVu(txtMaDichVu.Text.Trim(), txtTenDichVu.Text.Trim(), cbMaChatLieu.SelectedValue.ToString(), txtMucTieuHao.Text.Trim(),
                                            txtSoLuong.Text.Trim(), txtDonGiaNhap.Text.Trim(), txtDonGiaBan.Text.Trim(), txtGhiChu.Text.Trim());
                MessageBox.Show("Cập nhật thành công", "Cập nhật Dịch Vụ !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            HienThiDanhSachDichVu();
            ResetValue();
            setButton(true);
        }

        private void lsvDichVu_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvDichVu.SelectedItems)
            {
                txtMaDichVu.Text = items.SubItems[0].Text;
                txtTenDichVu.Text = items.SubItems[1].Text;
                cbMaChatLieu.Text = items.SubItems[2].Text;
                txtMucTieuHao.Text = items.SubItems[3].Text;
                txtSoLuong.Text = items.SubItems[4].Text;
                txtDonGiaNhap.Text = items.SubItems[5].Text;
                txtDonGiaBan.Text = items.SubItems[6].Text;
                txtGhiChu.Text = items.SubItems[7].Text;
            }
        }

        private void cbMaChatLieu_Click(object sender, EventArgs e)
        {
            if (cbMaChatLieu.Items.Count < 1)         
            {
                MessageBox.Show("Kho còn trống", "Kho", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
            }
            txtMucTieuHao.ReadOnly = false;
        }
        private void cbMaChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str, stri;
            if (cbMaChatLieu.Text == null)
            {
                lblSoLuongKho.Text = null;
                lblDonVi.Text = null;
            }
            str = "SELECT SoLuong " +
                "FROM KhoChatLieu " +
                "WHERE TenChatLieu = N'" + cbMaChatLieu.Text.Trim() + "'";
            stri = "SELECT DonVi " +
                    "FROM KhoChatLieu " +
                    "WHERE TenChatLieu = N'" + cbMaChatLieu.Text.Trim() + "'";
            lblSoLuongKho.Text = Functions.GetFieldValues(str);
            lblDonVi.Text = Functions.GetFieldValues(stri);                               
        }
        private void txtMucTieuThu_TextChanged(object sender, EventArgs e)
        {
            double sl ,mth, slk;
            if (lblSoLuongKho.Text == "")
                slk = 0;
            else
                slk = Convert.ToDouble(lblSoLuongKho.Text);
            if (txtMucTieuHao.Text == "")
                mth = 0;
            else
                mth = Convert.ToDouble(txtMucTieuHao.Text);
            sl = slk / mth;
            txtSoLuong.Text = sl.ToString("0.#");
        }
        private void txtSoLuongChatLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtMucTieuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDonGiaNhap_Click(object sender, EventArgs e)
        {
            txtDonGiaNhap.Text = null;
        }

        private void txtDonGiaBan_Click(object sender, EventArgs e)
        {           
            txtDonGiaBan.Text = null;
        }
    }    
}
