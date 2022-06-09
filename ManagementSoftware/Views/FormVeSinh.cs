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
    public partial class FormVeSinh : Form
    {
        DataTable tblCTHD;
        XuLyChiTietGiay xlctg = new XuLyChiTietGiay();
        public FormVeSinh()
        {
            InitializeComponent();
            LoadDataListView();

            lsvVeSinh.Columns.Add("Hóa đơn");
            lsvVeSinh.Columns.Add("Mã giày");
            lsvVeSinh.Columns.Add("Hãng");
            lsvVeSinh.Columns.Add("Tên");
            lsvVeSinh.Columns.Add("Mã dịch vụ");
            lsvVeSinh.Columns.Add("Tên dịch vụ");
            lsvVeSinh.Columns.Add("Ghi chú");
            lsvVeSinh.Columns[0].Width = 115;
            lsvVeSinh.Columns[1].Width = 115;
            lsvVeSinh.Columns[2].Width = 80;
            lsvVeSinh.Columns[3].Width = 80;
            lsvVeSinh.Columns[4].Width = 115;
            lsvVeSinh.Columns[5].Width = 80;
            lsvVeSinh.Columns[6].Width = 185;
        }
        private void LoadDataListView()
        {
            string sql;
            sql = "SELECT a.MaHoaDon, a.MaGiay, a.HangGiay, a.TenGiay, b.MaDichVu, b.TenDichVu, a.GhiChu " +
                     "FROM CTGiay AS a, DichVu AS b " +
                     "WHERE a.MaDichVu = b.MaDichVu";
            tblCTHD = Functions.GetDataToTable(sql);
            lsvVeSinh.Items.Clear();
            for (int i = 0; i < tblCTHD.Rows.Count; i++)
            {
                DataRow dr = tblCTHD.Rows[i];
                ListViewItem item = new ListViewItem(dr[0].ToString());
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, tblCTHD.Rows[i][0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                lsvVeSinh.Items.Add(item);
            }
            lsvVeSinh.View = View.Details;
            lsvVeSinh.Sorting = SortOrder.Ascending;
        }

        private void lsvVeSinh_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvVeSinh.SelectedItems)
            {
                txtMaHD.Text = items.SubItems[0].Text;
                txtMaGiay.Text = items.SubItems[1].Text;
                txtHangGiay.Text = items.SubItems[2].Text;
                txtTenGiay.Text = items.SubItems[3].Text;
                lblMaDichVu.Text = items.SubItems[4].Text;
                txtDichVu.Text = items.SubItems[5].Text;
                txtGhiChu.Text = items.SubItems[6].Text;
            }
            string sql = "SELECT HangGiay FROM CTGiay WHERE MaGiay = '" + txtMaGiay.Text.Trim() + "'";
            txtHangGiay.Text = Functions.GetFieldValues(sql);
            sql = "SELECT Hinh FROM CTGiay WHERE MaGiay = '" + txtMaGiay.Text.Trim() + "'";
            try
            {
                picAnh.Image = Image.FromFile(Functions.GetFieldValues(sql));
            }
            catch
            {
                picAnh.Image = null;
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã hóa đơn", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtMaGiay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập mã giày", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập dịch vụ", "Thông Báo !", MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Information);
                return;
            }
            string sql = "DELETE CTGiay WHERE MaGiay = N'" + txtMaGiay.Text.Trim() + "' AND MaDichVu = N'" + lblMaDichVu.Text.Trim() + "'";
            Functions.RunSQL(sql);
            MessageBox.Show("Hoàn thành", "Cập nhật trạng thái !", MessageBoxButtons.OK,
                                                                       MessageBoxIcon.Warning);
            LoadDataListView();
        }
    }
}
