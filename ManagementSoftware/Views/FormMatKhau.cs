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
    public partial class FormMatKhau : Form
    {
        XuLyDangNhap xldn = new XuLyDangNhap();
        Database dt = new Database();
        public FormMatKhau()
        {
            InitializeComponent();
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên tài khoản", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                txtMatKhauCu.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mật khẩu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                txtMatKhauMoi.Focus();
                return;
            }
            if (txtNhapLai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mật khẩu", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                txtNhapLai.Focus();
                return;
            }
            if (xldn.KiemTraTaiKhoan(lblTaiKhoan.Text.Trim()))
            {
                if (txtNhapLai.Text.Trim() == txtMatKhauMoi.Text.Trim())
                {
                    string sql = "SELECT Quyen FROM DangNhap WHERE TaiKhoan = '" + lblTaiKhoan.Text.Trim() + "'";
                    string q = Functions.GetFieldValues(sql);
                    xldn.CapNhatDangNhap(lblTaiKhoan.Text.Trim(), txtMatKhauMoi.Text.Trim(), q);
                    MessageBox.Show("Đổi mật khẩu thành công", "Cập nhật Mật Khẩu !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu chưa trùng khớp, hãy nhập lại", "Thông Báo !", MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
                    txtNhapLai.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản, hãy nhập lại", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
