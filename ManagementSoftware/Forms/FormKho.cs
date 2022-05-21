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
    public partial class FormKho : Form
    {
        XuLyChatLieu xlcl = new XuLyChatLieu();
        bool themmoi = true;
        public FormKho()
        {
            InitializeComponent();
            HienThiDanhSachChatLieu();
            setButton(true);
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;

            txtMaChatLieu.Enabled = !value;
            txtTenChatLieu.Enabled = !value;
            txtSoLuong.Enabled = !value;
            txtLocal.Enabled = !value;
            cbDonVi.Enabled = !value;
            btnMo.Enabled = !value;
            btnThemSLChatLieu.Enabled = !value;
        }
        private void ResetValue()
        {
            txtTenChatLieu.Text = null;
            txtMaChatLieu.Text = null;
            txtSoLuong.Text = null;
            cbDonVi.Text = null;
            txtLocal.Text = null;
            picAnh.Image = null;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetValue();
            setButton(true);
        }        
        public void HienThiDanhSachChatLieu()
        {
            lsvChatLieu.Items.Clear();
            lsvChatLieu.FullRowSelect = true;
            lsvChatLieu.View = View.Details;
            IEnumerable<KhoChatLieu> dsscl = xlcl.DanhSachChatLieu();
            if (dsscl.Count() > 0)
            {
                foreach (KhoChatLieu cl in dsscl)
                {
                    ListViewItem lvi;
                    lvi = lsvChatLieu.Items.Add(cl.MaChatLieu.ToString());
                    lvi.SubItems.Add(cl.TenChatLieu.ToString());
                    lvi.SubItems.Add(cl.SoLuong.ToString());
                    lvi.SubItems.Add(cl.DonVi.ToString());
                    lvi.SubItems.Add(cl.Hinh.ToString());
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            ResetValue();
            setButton(false);
            btnThemSLChatLieu.Enabled = false;
            txtMaChatLieu.Text = Functions.CreateKey("CL");
            txtSoLuong.Text = "0";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvChatLieu.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
                txtMaChatLieu.Enabled = false;
            }
            else
                MessageBox.Show("Bạn cần chọn mẫu tin cập nhật", "Sửa Mẫu Tin", MessageBoxButtons.OK,
                                                                          MessageBoxIcon.Information);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvChatLieu.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa Chất Liệu",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    xlcl.XoaChatLieu(lsvChatLieu.SelectedItems[0].SubItems[0].Text);
                    lsvChatLieu.Items.RemoveAt(lsvChatLieu.SelectedIndices[0]);
                    ResetValue();
                }
            }
            else
                MessageBox.Show("Bạn cần chọn mẩu tin cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã chất liệu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên chất liệu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (themmoi)
            {
                if (xlcl.KiemTraTonTai(txtMaChatLieu.Text.Trim()))
                {
                    MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Warning);
                    return;
                }
                if(txtSoLuong.Text == "")
                {
                    txtSoLuong.Text = "0";
                }
                xlcl.LuuTruChatLieu(txtMaChatLieu.Text.Trim(), txtTenChatLieu.Text.Trim(), txtSoLuong.Text.Trim(), cbDonVi.Text.Trim(), txtLocal.Text.Trim());
                MessageBox.Show("Thêm mới thành công", "Thêm Chất Liệu !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            else
            {
                xlcl.CapNhatChatLieu(txtMaChatLieu.Text.Trim(),txtTenChatLieu.Text.Trim(), txtSoLuong.Text.Trim(), cbDonVi.Text.Trim(), txtLocal.Text.Trim());
                MessageBox.Show("Cập nhật thành công", "Cập nhật Chất Liệu !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            }
            HienThiDanhSachChatLieu();
            ResetValue();
            setButton(true);
        }
        private void lsvChatLieu_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvChatLieu.SelectedItems)
            {
                txtMaChatLieu.Text = items.SubItems[0].Text;
                txtTenChatLieu.Text = items.SubItems[1].Text;
                txtSoLuong.Text = items.SubItems[2].Text;
                cbDonVi.Text = items.SubItems[3].Text;
                txtLocal.Text = items.SubItems[4].Text;
                try
                {
                    picAnh.Image = Image.FromFile(txtLocal.Text.Trim());
                } catch
                {
                    picAnh.Image = null;
                }                    
            }              
        }        
        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(*.gif)|*.gif|All files(*.*)|*.*"; 
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtLocal.Text = dlgOpen.FileName;
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void txtSoLuong_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = null;
        }
        private void btnThemSLChatLieu_Click(object sender, EventArgs e)
        {    
            Forms.FormThemSLCL sLCL = new Forms.FormThemSLCL(txtMaChatLieu.Text);
            sLCL.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThiDanhSachChatLieu();
        }
    }
}
