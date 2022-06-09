using ManagementSoftware.Controllers;
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
    public partial class FormDangKy : Form
    {
        Form1 form1 = new Form1();
        XuLyDangNhap xldn = new XuLyDangNhap();
        public FormDangKy()
        {
            InitializeComponent();
            dtNgaySinh.Value = DateTime.Now;

            label1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label2.BackColor = Color.FromArgb(100, 0, 0, 0);           
            label4.BackColor = Color.FromArgb(100, 0, 0, 0);
            label5.BackColor = Color.FromArgb(100, 0, 0, 0);
            label6.BackColor = Color.FromArgb(100, 0, 0, 0);
            label7.BackColor = Color.FromArgb(100, 0, 0, 0);
            label8.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string a;
            if (txtTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên tài khoản", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mật khẩu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên cá nhân, Tên cá nhân", "Thông Báo !", MessageBoxButtons.OK,
                                                                           MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cần nhập số điện thoại liên lạc , Điện thoại", "Thông Báo !", MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }            
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập địa chỉ cư trú, Địa chỉ", "Thông Báo !", MessageBoxButtons.OK,
                                                                          MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (xldn.KiemTraTaiKhoan(txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Tài khoản này đã có người sử dụng, bạn hãy nhập tên khác", "Thông Báo !", MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                txtConnect.BackColor = Color.Red;
                return;
            }        
            else
            {
                xldn.LuuTruDangNhap(a = Functions.CreateKey("NV"), txtTenNhanVien.Text.Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim(), "Waitting",
                                                                                           cbGioiTinh.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), dtNgaySinh.Value.Date);
                MessageBox.Show("Thêm mới thành công, đã lưu thông tin tài khoản và chờ ADMIN duyệt", "Thông Báo !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
                txtConnect.BackColor = Color.Green;

            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.FormDangNhap Login = new Forms.FormDangNhap();
            Login.Show();           
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
