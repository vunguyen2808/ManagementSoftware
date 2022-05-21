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
    public partial class FormThemSLCL : Form
    {
        public FormThemSLCL()
        {
            InitializeComponent();
        }
        public FormThemSLCL(string a) : this()
        {
            string str = "SELECT TenChatLieu FROM KhoChatLieu WHERE MaChatLieu = N'" + a + "'";
            txtTenCL.Text = Functions.GetFieldValues(str);
            lblMaCL.Text = a;
        }        
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            float tong, sl, slcl;
            //Cập nhật số lượng chất liệu
            sql = "SELECT SoLuong FROM KhoChatLieu WHERE MaChatLieu = N'" + lblMaCL.Text.Trim() + "'";
            sl = float.Parse(Functions.GetFieldValues(sql));
            tong = sl + float.Parse(txtSoLuong.Text);
            sql = "UPDATE KhoChatLieu SET SoLuong = " + tong.ToString() + " WHERE MaChatLieu = N'" + lblMaCL.Text.Trim() + "'";
            Functions.RunSQL(sql);
            //Cập nhật số lượng dịch vụ
            sql = "SELECT a.SoLuongChatLieu " +
                "FROM DichVu AS a, KhoChatLieu AS b " +
                "WHERE b.MaChatLieu = N'" + lblMaCL.Text.Trim() + "' AND a.MaChatLieu = b.MaChatLieu";
            float sldv = float.Parse(Functions.GetFieldValues(sql));
            sql = "SELECT a.MucTieuHao " +
                "FROM DichVu AS a, KhoChatLieu AS b " +
                "WHERE b.MaChatLieu = N'" + lblMaCL.Text.Trim() + "' AND a.MaChatLieu = b.MaChatLieu";
            float mth = float.Parse(Functions.GetFieldValues(sql));
            float sldvm = sldv + (float.Parse(txtSoLuong.Text) / mth);
            sql = "SELECT a.MaDichVu " +
                "FROM DichVu AS a, KhoChatLieu AS b " +
                "WHERE b.MaChatLieu = N'" + lblMaCL.Text.Trim() + "' AND a.MaChatLieu = b.MaChatLieu";
            string mdv = Functions.GetFieldValues(sql);
            sql = "UPDATE DichVu SET SoLuongChatLieu = " + sldvm.ToString() + " WHERE MaDichVu = N'" + mdv + "'";
            Functions.RunSQL(sql);
            MessageBox.Show("Cập nhật số lượng thành công", "Cập nhật !", MessageBoxButtons.OK,
                                                                   MessageBoxIcon.Warning);
            this.Close();            
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
