using ManagementSoftware.Controllers;
using ManagementSoftware.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReport : Form
    {
        Database dt = new Database();
        public FormReport()
        {
            InitializeComponent();

            cbTenNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTenKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;

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
        }
        private void ResetValues()
        {
            cbTenNhanVien.Text = null;
            cbTenKhachHang.Text = null;
            cbThang.Text = null;
            txtNam.Text = null;
        }
        private void FormReport_Load(object sender, EventArgs e)
        {
            
        }
        private System.Data.DataSet GetDataSet()
        {
            DataTable tblHD;
            string sql;
            if ((cbThang.Text == "") && (txtNam.Text == "") && (cbTenNhanVien.Text == "") && (cbTenKhachHang.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            sql = "SELECT * FROM HoaDon WHERE 1=1";
            if (cbThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + cbThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (cbTenNhanVien.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + cbTenNhanVien.SelectedValue + "%'";
            if (cbTenKhachHang.Text != "")
                sql = sql + " AND MaKhachHang Like N'%" + cbTenKhachHang.SelectedValue + "%'";
            tblHD = Functions.GetDataToTable(sql);
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(dt.stringConnect);
            sqlConn.Open();
            sql = string.Format(sql);
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(sql, sqlConn);
            System.Data.DataSet ds = new System.Data.DataSet();
            ad.Fill(ds);
            sqlConn.Close();
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có kết quả nào phù hợp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHD.Rows.Count + " kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);           
            return ds;
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = GetDataSet();
            //rpBaoCao.LocalReport.ReportPath = "Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            rpv1.LocalReport.DataSources.Clear();
            rpv1.LocalReport.DataSources.Add(rds);
            rpv1.RefreshReport();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ResetValues();
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
    }
}
