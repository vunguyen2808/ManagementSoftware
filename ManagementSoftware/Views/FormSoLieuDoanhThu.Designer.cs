
namespace ManagementSoftware.Forms
{
    partial class FormSoLieuDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rpDoanhThuThang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpDoanhThuNam = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpDoanhThuNgay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpDoanhThuThang
            // 
            this.rpDoanhThuThang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rpDoanhThuThang.LocalReport.ReportEmbeddedResource = "ManagementSoftware.Report2.rdlc";
            this.rpDoanhThuThang.Location = new System.Drawing.Point(693, 12);
            this.rpDoanhThuThang.Name = "rpDoanhThuThang";
            this.rpDoanhThuThang.ServerReport.BearerToken = null;
            this.rpDoanhThuThang.Size = new System.Drawing.Size(675, 422);
            this.rpDoanhThuThang.TabIndex = 144;
            this.rpDoanhThuThang.Load += new System.EventHandler(this.rpDoanhThuThang_Load);
            // 
            // rpDoanhThuNam
            // 
            this.rpDoanhThuNam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rpDoanhThuNam.LocalReport.ReportEmbeddedResource = "ManagementSoftware.Report3.rdlc";
            this.rpDoanhThuNam.Location = new System.Drawing.Point(12, 440);
            this.rpDoanhThuNam.Name = "rpDoanhThuNam";
            this.rpDoanhThuNam.ServerReport.BearerToken = null;
            this.rpDoanhThuNam.Size = new System.Drawing.Size(1356, 422);
            this.rpDoanhThuNam.TabIndex = 145;
            this.rpDoanhThuNam.Load += new System.EventHandler(this.rpDoanhThuNam_Load);
            // 
            // rpDoanhThuNgay
            // 
            this.rpDoanhThuNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rpDoanhThuNgay.LocalReport.ReportEmbeddedResource = "ManagementSoftware.Report4.rdlc";
            this.rpDoanhThuNgay.Location = new System.Drawing.Point(12, 12);
            this.rpDoanhThuNgay.Name = "rpDoanhThuNgay";
            this.rpDoanhThuNgay.ServerReport.BearerToken = null;
            this.rpDoanhThuNgay.Size = new System.Drawing.Size(675, 422);
            this.rpDoanhThuNgay.TabIndex = 146;
            this.rpDoanhThuNgay.Load += new System.EventHandler(this.rpDoanhThuNgay_Load);
            // 
            // FormSoLieuDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 872);
            this.Controls.Add(this.rpDoanhThuNgay);
            this.Controls.Add(this.rpDoanhThuNam);
            this.Controls.Add(this.rpDoanhThuThang);
            this.Name = "FormSoLieuDoanhThu";
            this.Text = "Doanh Thu";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpDoanhThuThang;
        private Microsoft.Reporting.WinForms.ReportViewer rpDoanhThuNam;
        private Microsoft.Reporting.WinForms.ReportViewer rpDoanhThuNgay;
    }
}