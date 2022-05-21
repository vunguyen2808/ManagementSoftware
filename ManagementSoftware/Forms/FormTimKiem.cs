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
    public partial class FormTimKiem : Form
    {
        DataTable tblHD;
        public FormTimKiem()
        {
            InitializeComponent();

            cbMaHD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaHD.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTenNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTenKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;

            Functions.FillCombo("SELECT * FROM HoaDon", cbMaHD, "MaHoaDon", "MaHoaDon");
            Functions.FillCombo("SELECT * FROM NhanVien", cbTenNhanVien, "TenNhanVien", "MaNhanVien");
            Functions.FillCombo("SELECT * FROM KhachHang", cbTenKhachHang, "TenKhachHang", "MaKhachHang");
            if (cbTenNhanVien.SelectedIndex > -1)
            {
                cbTenNhanVien.Text = null;
            }
            if (cbTenKhachHang.SelectedIndex > -1)
            {
                cbTenKhachHang.Text = null;
            }
            if (cbMaHD.SelectedIndex > -1)
            {
                cbMaHD.Text = null;
            }
        }
        private void frmTimHDBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void ResetValues()
        {
            cbMaHD.Text = null;
            cbTenNhanVien.Text = null;
            cbTenKhachHang.Text = null;
            cbThang.Text = null;
            txtNam.Text = null;
            txtTongTien.Text = null;
            cbMaHD.Focus();
        }
        private void LoadDataGridView()
        {
            dgvTKHoaDon.Columns[0].HeaderText = "Mã HĐ";
            dgvTKHoaDon.Columns[1].HeaderText = "Mã KH";
            dgvTKHoaDon.Columns[2].HeaderText = "Mã NV";
            dgvTKHoaDon.Columns[3].HeaderText = "Ngày bán";
            dgvTKHoaDon.Columns[4].HeaderText = "Ca bán";
            dgvTKHoaDon.Columns[5].HeaderText = "Tổng tiền";
            dgvTKHoaDon.Columns[6].HeaderText = "Số nhận";
            dgvTKHoaDon.Columns[7].HeaderText = "Số dư";
            dgvTKHoaDon.Columns[0].Width = 115;
            dgvTKHoaDon.Columns[1].Width = 115;
            dgvTKHoaDon.Columns[2].Width = 115;
            dgvTKHoaDon.Columns[3].Width = 115;
            dgvTKHoaDon.Columns[4].Width = 70;
            dgvTKHoaDon.Columns[5].Width = 85;
            dgvTKHoaDon.Columns[6].Width = 70;
            dgvTKHoaDon.Columns[7].Width = 70;
            dgvTKHoaDon.AllowUserToAddRows = false;
            dgvTKHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbMaHD.Text == "") && (cbThang.Text == "") && (txtNam.Text == "") &&
               (cbTenNhanVien.Text == "") && (cbTenKhachHang.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDon WHERE 1=1";
            if (cbMaHD.Text != "")
                sql = sql + " AND MaHoaDon Like N'%" + cbMaHD.SelectedValue + "%'";
            if (cbThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + cbThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (cbTenNhanVien.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + cbTenNhanVien.SelectedValue + "%'";
            if (cbTenKhachHang.Text != "")
                sql = sql + " AND MaKhachHang Like N'%" + cbTenKhachHang.SelectedValue + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TongTien <=" + txtTongTien.Text;
            tblHD = Functions.GetDataToTable(sql);
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có kết quả nào phù hợp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHD.Rows.Count + " kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHoaDon.DataSource = tblHD;
            LoadDataGridView();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void dgvTKHoaDon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string mahd;
                if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mahd = dgvTKHoaDon.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                    FormHoaDon frm = new FormHoaDon();
                    frm.cbMaHDTimKiem.Text = mahd;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTKHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTKHoaDon.Rows[e.RowIndex];
                cbMaHD.Text = row.Cells[0].Value.ToString();
                cbTenNhanVien.Text = row.Cells[1].Value.ToString();
                cbTenKhachHang.Text = row.Cells[2].Value.ToString();
                cbThang.Text = row.Cells[3].Value.ToString();
                txtNam.Text = row.Cells[4].Value.ToString();
                txtTongTien.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}
