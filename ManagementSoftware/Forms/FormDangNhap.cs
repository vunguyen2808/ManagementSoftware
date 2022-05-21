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
    public partial class FormDangNhap : Form
    {
        Form1 form1 = new Form1();
        XuLyDangNhap xldn = new XuLyDangNhap();
        Database dt = new Database();
        public FormDangNhap()
        {
            InitializeComponent();

            label1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {            
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
            if (xldn.KiemTraTaiKhoan(txtTaiKhoan.Text.Trim()) == true)
            {
                SqlConnection conmk = new SqlConnection(dt.stringConnect);
                string sqlmk = "SELECT * FROM DANGNHAP WHERE TAIKHOAN = '" + txtTaiKhoan.Text.Trim() + "' AND MATKHAU = '" + txtMatKhau.Text.Trim() + "'";
                try
                {
                    conmk.Open();
                    SqlCommand cmdmk = new SqlCommand(sqlmk, conmk);
                    //Sử dụng ExecuteScalar truy vấn trả về một giá trị duy nhất
                    SqlDataReader mk = cmdmk.ExecuteReader();
                    if(mk.Read() == true)
                    {
                        form1 = new Form1();
                        form1.Show();
                        form1.Logo(txtTaiKhoan.Text.Trim());
                        //-----------------------TRUY VẤN ĐẾN QUYỀN----------------------
                        SqlConnection conq = new SqlConnection(dt.stringConnect);
                        string sqlq = "SELECT QUYEN FROM DANGNHAP WHERE TAIKHOAN = '" + txtTaiKhoan.Text.Trim() + "'";
                        try
                        {
                            conq.Open();
                            SqlCommand cmdq = new SqlCommand(sqlq, conq);
                            //Sử dụng ExecuteScalar truy vấn trả về một giá trị duy nhất
                            string quyen = cmdq.ExecuteScalar().ToString();
                            form1.Form(quyen);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        conq.Close();
                        form1.setButton();
                        form1.OpenHomedForm(new Forms.FormHome(), sender);
                        this.Hide();
                        return;
                    }
                    MessageBox.Show("Sai mật khẩu, hãy nhập lại", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                    return;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conmk.Close();               
            }
            MessageBox.Show("Sai tên tài khoản, hãy nhập lại", "Thông Báo !", MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
            txtTaiKhoan.Focus();
            return;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Forms.FormDangKy Signup = new Forms.FormDangKy();
            Signup.Show();

            this.Hide();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
