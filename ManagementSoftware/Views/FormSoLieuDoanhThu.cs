using ManagementSoftware.Controllers;
using ManagementSoftware.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class FormSoLieuDoanhThu : Form
    {
        Database dt = new Database();
        public FormSoLieuDoanhThu()
        {
            InitializeComponent();
            this.rpDoanhThuThang.RefreshReport();
            this.rpDoanhThuNam.RefreshReport();
            this.rpDoanhThuNgay.RefreshReport();
        }
        private System.Data.DataSet GetDataSetNgay()
        {
            string sql;
            DateTime d = DateTime.Now;
            DateTime m = DateTime.Now;
            DateTime y = DateTime.Now;
            sql = "SELECT DAY(NgayBan) AS NgayBan, SUM(TongTien) AS TongTien " +
                "FROM HoaDon " +
                "WHERE NgayBan BETWEEN '" + y.Year + "/" + m.Month + "/" + d.Day + "' AND '" + y.Year + "/" + m.Month + "/" + Functions.ConvertDay(d.Day + 7) + "' " +
                "GROUP BY DAY(NgayBan)";
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(dt.stringConnect);
            sqlConn.Open();
            sql = string.Format(sql);
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(sql, sqlConn);
            System.Data.DataSet ds = new System.Data.DataSet();
            ad.Fill(ds);
            sqlConn.Close();
            return ds;
        }
        private System.Data.DataSet GetDataSetThang()
        {
            string sql;
            DateTime m = DateTime.Now;        
            sql = "SELECT DAY(NgayBan) AS NgayBan, SUM(TongTien) AS TongTien " +
                "FROM HoaDon " +
                "WHERE MONTH(NgayBan) = " + m.Month +
                "GROUP BY DAY(NgayBan)";
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(dt.stringConnect);
            sqlConn.Open();
            sql = string.Format(sql);
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(sql, sqlConn);
            System.Data.DataSet ds = new System.Data.DataSet();
            ad.Fill(ds);
            sqlConn.Close();
            return ds;
        }
        private System.Data.DataSet GetDataSetNam()
        {
            string sql;
            DateTime y = DateTime.Now;
            sql = "SELECT MONTH(NgayBan) AS NgayBan, SUM(TongTien) AS TongTien " +
                "FROM HoaDon " +
                "WHERE YEAR(NgayBan) = " + y.Year + 
                "GROUP BY MONTH(NgayBan)";
            System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(dt.stringConnect);
            sqlConn.Open();
            sql = string.Format(sql);
            System.Data.SqlClient.SqlDataAdapter ad = new System.Data.SqlClient.SqlDataAdapter(sql, sqlConn);
            System.Data.DataSet ds = new System.Data.DataSet();
            ad.Fill(ds);
            sqlConn.Close();
            return ds;
        }
        private void rpDoanhThuNgay_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = GetDataSetNgay();
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            rpDoanhThuNgay.LocalReport.DataSources.Clear();
            rpDoanhThuNgay.LocalReport.DataSources.Add(rds);
            rpDoanhThuNgay.RefreshReport();
        }
        private void rpDoanhThuThang_Load(object sender, EventArgs e)
        {
            System.Data.DataSet ds = GetDataSetThang();
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            rpDoanhThuThang.LocalReport.DataSources.Clear();
            rpDoanhThuThang.LocalReport.DataSources.Add(rds);
            rpDoanhThuThang.RefreshReport();
        }
        private void rpDoanhThuNam_Load(object sender, EventArgs e)
        {
            System.Data.DataSet dst = GetDataSetNam();
            ReportDataSource rdst = new ReportDataSource("DataSet1", dst.Tables[0]);
            rpDoanhThuNam.LocalReport.DataSources.Clear();
            rpDoanhThuNam.LocalReport.DataSources.Add(rdst);
            rpDoanhThuNam.RefreshReport();
        }
    }
}
