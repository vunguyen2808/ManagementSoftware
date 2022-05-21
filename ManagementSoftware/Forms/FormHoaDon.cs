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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace ManagementSoftware.Forms
{
    public partial class FormHoaDon : Form
    {
        XuLyChatLieu xlcl = new XuLyChatLieu();
        XuLyHoaDon xlhd = new XuLyHoaDon();
        XuLyChiTietHoaDon xlcthd = new XuLyChiTietHoaDon();
        XuLyChiTietGiay xlctg = new XuLyChiTietGiay();
        DataTable tblCTHD;

        string localAnh = "";
        int flag = 0;
        public FormHoaDon()
        {
            InitializeComponent();
            LoadDataListView();
            setButton(true);
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            dtNgayBan.Value = DateTime.Now;

            lsvChiTietHD.Columns.Add("Mã giày");
            lsvChiTietHD.Columns.Add("Tên giày");
            lsvChiTietHD.Columns.Add("Mã dịch vụ");
            lsvChiTietHD.Columns.Add("Tên dịch vụ");
            lsvChiTietHD.Columns.Add("Số lượng");
            lsvChiTietHD.Columns.Add("Đơn giá");
            lsvChiTietHD.Columns.Add("Giảm giá %");
            lsvChiTietHD.Columns.Add("Thành tiền");
            lsvChiTietHD.Columns.Add("Ghi chú");
            lsvChiTietHD.Columns[0].Width = 120;
            lsvChiTietHD.Columns[1].Width = 150;
            lsvChiTietHD.Columns[2].Width = 120;
            lsvChiTietHD.Columns[3].Width = 150;
            lsvChiTietHD.Columns[4].Width = 60;
            lsvChiTietHD.Columns[5].Width = 150;
            lsvChiTietHD.Columns[6].Width = 70;
            lsvChiTietHD.Columns[7].Width = 150;
            lsvChiTietHD.Columns[8].Width = 200;


            cbMaHDTimKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMaHDTimKiem.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTenKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            Functions.FillCombo("SELECT * FROM NhanVien", cbTenNhanVien, "TenNhanVien", "MaNhanVien");
            Functions.FillCombo("SELECT * FROM KhachHang", cbTenKhachHang, "TenKhachHang", "MaKhachHang");
            Functions.FillCombo("SELECT * FROM DichVu", cbDichVu, "TenDichVu", "MaDichVu");
            Functions.FillCombo("SELECT * FROM HoaDon", cbMaHDTimKiem, "MaHoaDon", "MaHoaDon");           
            cbMaHDTimKiem.Text = null;
            if (cbTenNhanVien.SelectedIndex > -1 )
            {
                cbTenNhanVien.Text = null;
            }            
            if (cbTenKhachHang.SelectedIndex > -1)
            {
                cbTenKhachHang.Text = null;
            }
            
            if (cbDichVu.SelectedIndex > -1)
            {
                cbDichVu.Text = null;
            }
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            dtNgayBan.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            cbTenNhanVien.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT MaKhachHang FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            cbTenKhachHang.SelectedValue = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);            
            str = "SELECT CaBan FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            lblCaBan.Text = Functions.GetFieldValues(str);
            str = "SELECT TienNhan FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
            txtTienNhan.Text = Functions.GetFieldValues(str);
        }
        private void LoadDataListView()
        {
            string sql;
            sql = "SELECT c.MaGiay, c.TenGiay, a.MaDichVu, b.TenDichVu, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien, c.GhiChu " +
                     "FROM CTHoaDon AS a, DichVu AS b, CTGiay AS c " +
                      "WHERE a.MaHoaDon = N'" + txtMaHD.Text + "' AND a.MaDichVu = b.MaDichVu AND a.MaDichVu = c.MaDichVu AND c.MaGiay = a.MaGiay";
            tblCTHD = Functions.GetDataToTable(sql);
            lsvChiTietHD.Items.Clear();                      
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
                item.SubItems.Add(dr[7].ToString());
                item.SubItems.Add(dr[8].ToString());
                lsvChiTietHD.Items.Add(item);
            }
            lsvChiTietHD.View = View.Details;
            lsvChiTietHD.Sorting = SortOrder.Ascending;            
        }
        public void setButton(bool value)
        {
            //Button chức năng
            btnThem.Enabled = value;
            btnLuu.Enabled = !value;
            btnClear.Enabled = !value;
            btnIn.Enabled = value;
            btnHuy.Enabled = value;
            btnTimKiem.Enabled = value;

            //Thông tin hóa đơn
            txtMaHD.Enabled = !value;
            dtNgayBan.Enabled = !value;
            cbTenNhanVien.Enabled = !value;
            cbTenKhachHang.Enabled = !value;
            txtDiaChi.Enabled = !value;
            txtSoDienThoai.Enabled = !value;

            //Thông tin giày
            btnThemGiay.Enabled = !value;
            txtMaGiay.Enabled = !value;
            txtTenGiay.Enabled = !value;
            txtHangGiay.Enabled = !value;
            txtGhiChu.Enabled = !value;            
            btnMo.Enabled = !value;

            //Thông tin dịch vụ
            cbDichVu.Enabled = !value;
            txtDonGia.Enabled = !value;
            txtSoLuongChatLieu.Enabled = !value;
            txtGiamGia.Enabled = !value;
            txtThanhTien.Enabled = !value;
            txtTienNhan.Enabled = !value;
            txtTienThua.Enabled = !value;

            cbMaHDTimKiem.Enabled = value;
        }
        private void ResetValue()
        {
            //Thông tin chung
            txtMaHD.Text = null;
            dtNgayBan.ResetText();
            cbTenNhanVien.Text = null;
            cbTenKhachHang.Text = null;
            lblCaBan.Text = null;

            //Thông tin giày
            txtMaGiay.Text = null;
            txtTenGiay.Text = null;
            txtHangGiay.Text = null;
            txtGhiChu.Text = null;

            //Thông tin dịch vụ
            cbDichVu.Text = null;
            txtSoLuongChatLieu.Text = null;
            txtGiamGia.Text = null;
            txtThanhTien.Text = null;
            picAnh.Image = null;
            cbMaHDTimKiem.Text = null;
            txtTongTien.Text = null;
            txtTienNhan.Text = null;
            txtTienThua.Text = null;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            flag = 0;
            string madv, macl, sql;
            float soLuongXoa, sl, slcon, slth, slcl;
            //Cập nhật lại số lượng cho dịch vụ
            sql = "SELECT * FROM CTHoaDon WHERE MaHoaDon = N'" + txtMaHD.Text.Trim() + "'";
            tblCTHD = Functions.GetDataToTable(sql);            
            for (int i = 0; i < tblCTHD.Rows.Count; i++)
            {
                DataRow dr = tblCTHD.Rows[i];
                madv = dr[2].ToString();
                soLuongXoa = float.Parse(dr[3].ToString());                
                sl = float.Parse(Functions.GetFieldValues("SELECT SoLuongChatLieu FROM DichVu WHERE MaDichVu = N'" + madv + "'"));
                slcon = sl + soLuongXoa;
                sql = "UPDATE DichVu SET SoLuongChatLieu =" + slcon + " WHERE MaDichVu = N'" + madv + "'";
                Functions.RunSQL(sql);

                //Cập nhật lại số lượng chất liệu
                slth = float.Parse(Functions.GetFieldValues("SELECT MucTieuHao FROM DichVu WHERE MaDichVu = N'" + madv + "'"));
                slcl = float.Parse(Functions.GetFieldValues("SELECT a.SoLuong FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                    madv + "' AND a.MaChatLieu = b.MaChatLieu"));
                macl = Functions.GetFieldValues("SELECT a.MaChatLieu FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                    madv + "' AND a.MaChatLieu = b.MaChatLieu");
                slcon = slcl + (slth * soLuongXoa);
                sql = "UPDATE KhoChatLieu SET SoLuong = " + slcon + " WHERE MaChatLieu = N'" + macl + "'";
                Functions.RunSQL(sql);
            }
            sql = "DELETE CTHoaDon WHERE MaHoaDon = N'" + txtMaHD.Text.Trim() + "'";
            Functions.RunSQL(sql);
            sql = "DELETE CTGiay WHERE MaHoaDon = N'" + txtMaHD.Text.Trim() + "'";
            Functions.RunSQL(sql);
            sql = "DELETE HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text.Trim() + "'";
            Functions.RunSQL(sql);

            ResetValue();
            setButton(true);
            LoadDataListView();
            groupBox3.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtTongTien.Text = "0";
            lblChuyenChu.Text = "0 (VNĐ)";
            txtTienNhan.Text = "0";
            txtTienThua.Text = "0";
        }        
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = Functions.CreateKey("HD");
            setButton(false);
            btnClear.Enabled = true;
            txtTongTien.Text = "0";
            lblChuyenChu.Text = "0 (VNĐ)";
            txtTienNhan.Text = "0";
            txtTienThua.Text = "0";

            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            if (partsTime[2].Substring(3, 2) == "PM")
                lblCaBan.Text = "Ca chiều";
            if (partsTime[2].Substring(3, 2) == "AM")
                lblCaBan.Text = "Ca sáng";
        }   
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string macl, sql;
            decimal tong, tongMoi;
            float sl, SLcon, slth, soLuongXoa, slcl, slcon;
            //Thông tin chung
            if (xlhd.KiemTraTonTai(txtMaHD.Text.Trim()) == false)
            {
                if (txtMaHD.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập mã hóa đơn", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Information);
                    return;
                }
                if (cbTenNhanVien.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập nhân viên", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Information);
                    return;
                }
                if (cbTenKhachHang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập khách hàng", "Thông Báo !", MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Information);
                    return;
                }
                xlhd.LuuTruHoaDon(txtMaHD.Text.Trim(), cbTenKhachHang.SelectedValue.ToString(), cbTenNhanVien.SelectedValue.ToString(), 
                                    dtNgayBan.Value.Date, lblCaBan.Text.Trim(), txtTongTien.Text.Trim(), txtTienNhan.Text.Trim(), txtTienThua.Text.Trim());
            }

            //Thông tin dịch vụ & giày
            if (cbDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập dịch vụ cần bán", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtTenGiay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập tên giày", "Thông Báo !", MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Information);
                return;
            }
            if (txtSoLuongChatLieu.Text == "")
            {
                txtSoLuongChatLieu.Text = "0";
            }
            if (txtGiamGia.Text == "")
            {
                txtGiamGia.Text = "0";
            }
            // Kiểm tra xem số lượng dịch vụ trong kho còn đủ để phụ vụ không?
            sl = float.Parse(Functions.GetFieldValues("SELECT SoLuongChatLieu FROM DichVu WHERE MaDichVu = N'" + cbDichVu.SelectedValue + "'"));
            if (float.Parse(txtSoLuongChatLieu.Text) > sl)
            {
                MessageBox.Show("Số lượng dịch vụ này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongChatLieu.Text = "";
                return;
            }
            try
            {
                sql = "SELECT MaGiay, MaDichVu FROM CTGiay WHERE MaGiay = N'" + txtMaGiay.Text.Trim() + "' AND MaDichVu = N'" + cbDichVu.SelectedValue.ToString() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Dịch vụ này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    xlctg.LuuTruGiay(txtMaHD.Text.Trim(), txtMaGiay.Text.Trim(), txtHangGiay.Text.Trim(), txtTenGiay.Text.Trim(),
                                                                                        cbDichVu.SelectedValue.ToString(), txtGhiChu.Text.Trim(), localAnh.Trim());

                    xlcthd.LuuTruChiTietHoaDon(txtMaGiay.Text.Trim(), txtMaHD.Text.Trim(), cbDichVu.SelectedValue.ToString(), txtSoLuongChatLieu.Text.Trim(),
                                                                                            txtDonGia.Text.Trim(), txtGiamGia.Text.Trim(), txtThanhTien.Text.Trim());
                    MessageBox.Show("Thêm mới thành công", "Thêm Hóa Đơn !", MessageBoxButtons.OK,
                                                                       MessageBoxIcon.Warning);
                    cbMaHDTimKiem.Enabled = false;
                    flag = 1;
                }               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            LoadDataListView();

            // Cập nhật lại số lượng dịch vụ
            SLcon = sl - float.Parse(txtSoLuongChatLieu.Text);
            sql = "UPDATE DichVu SET SoLuongChatLieu = " + SLcon.ToString("0.#") + " WHERE MaDichVu = N'" + cbDichVu.SelectedValue + "'";
            Functions.RunSQL(sql);

            //Cập nhật lại số lượng chất liệu
            soLuongXoa = float.Parse(txtSoLuongChatLieu.Text.Trim());
            slth = float.Parse(Functions.GetFieldValues("SELECT MucTieuHao FROM DichVu WHERE MaDichVu = N'" + cbDichVu.SelectedValue + "'"));
            slcl = float.Parse(Functions.GetFieldValues("SELECT a.SoLuong FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                cbDichVu.SelectedValue + "' AND a.MaChatLieu = b.MaChatLieu"));
            macl = Functions.GetFieldValues("SELECT a.MaChatLieu FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                cbDichVu.SelectedValue + "' AND a.MaChatLieu = b.MaChatLieu");
            slcon = slcl - (slth * soLuongXoa);
            sql = "UPDATE KhoChatLieu SET SoLuong = " + slcon + " WHERE MaChatLieu = N'" + macl + "'";
            Functions.RunSQL(sql);

            //Cập nhật lại tổng tiền hóa đơn
            tong = Convert.ToDecimal(Functions.GetFieldValues("SELECT TongTien FROM HoaDon Where MaHoaDon = N'" + txtMaHD.Text.Trim() + "'"));
            tongMoi = tong + Convert.ToDecimal(txtThanhTien.Text.Trim());            
            xlhd.CapNhatHoaDon(txtMaHD.Text.Trim(), cbTenKhachHang.SelectedValue.ToString(), cbTenNhanVien.SelectedValue.ToString(),
                                    dtNgayBan.Value.Date, lblCaBan.Text.Trim(), tongMoi.ToString(), txtTienNhan.Text.Trim(), txtTienThua.Text.Trim());
            txtTongTien.Text = tongMoi.ToString();
            lblChuyenChu.Text = Functions.ChuyenSoSangChu(txtTongTien.Text);

            txtHangGiay.Enabled = false;
            txtTenGiay.Enabled = false;
            txtGhiChu.Enabled = false;
            btnMo.Enabled = false;           
            btnHuy.Enabled = true;
            cbDichVu.Text = null;
            txtDonGia.Text = null;
            txtSoLuongChatLieu.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTienNhan.Text = "0";
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
                localAnh = dlgOpen.FileName;
            }
        }
        private void cbTenNhanVien_Click(object sender, EventArgs e)
        {
            if (cbTenNhanVien.Items.Count < 1)           
            {
                MessageBox.Show("Bạn cần thêm nhân viên", "Hóa Đơn", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
            }
        }
        private void cbDichVu_Click(object sender, EventArgs e)
        {
            if (cbDichVu.Items.Count < 1)          
            {
                MessageBox.Show("Bạn cần thêm dịch vụ", "Hóa Đơn", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
            }
        }
        private void cbTenKhachHang_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.Items.Count < 1)            
            {
                MessageBox.Show("Bạn cần thêm khách hàng", "Hóa Đơn", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
            }
        }
        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str, stri;        
            str = "SELECT DiaChi " +
            "FROM KhachHang " +
            "WHERE TenKhachHang = N'" + cbTenKhachHang.Text.Trim() + "'";
            stri = "SELECT DienThoai " +
                    "FROM KhachHang " +
                    "WHERE TenKhachHang = N'" + cbTenKhachHang.Text.Trim() + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            txtSoDienThoai.Text = Functions.GetFieldValues(stri);                                        
        }
        private void cbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbDichVu.Text == "")
            {
                txtDonGia.Text = null;
            }
            str = "SELECT DonGiaBan " +
                    "FROM DichVu " +
                    "WHERE TenDichVu = N'" + cbDichVu.Text.Trim() + "'";            
            txtDonGia.Text = Functions.GetFieldValues(str);
        }
        private void txtSoLuongChatLieu_TextChanged(object sender, EventArgs e)
        {
            decimal tt, sl, dg, gg;
            if (txtSoLuongChatLieu.Text == "")
                sl = 0;
            else
                sl = Convert.ToDecimal(txtSoLuongChatLieu.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDecimal(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDecimal(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString("");
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            decimal tt, sl, dg, gg;
            if (txtSoLuongChatLieu.Text == "")
                sl = 0;
            else
                sl = Convert.ToDecimal(txtSoLuongChatLieu.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDecimal(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDecimal(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString("");
        }
        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNhan.Text == "" || txtTienNhan.Text == "0" || decimal.Parse(txtTienNhan.Text) < decimal.Parse(txtTongTien.Text))
            {
                btnIn.Enabled = false;
                txtTienThua.Text = "0";
            }
            else
            {
                btnIn.Enabled = true;
                decimal tt, tn, tong;
                if (txtTongTien.Text == "")
                    tong = 0;
                else
                    tong = Convert.ToDecimal(txtTongTien.Text);
                if (txtTienNhan.Text == "")
                    tn = 0;
                else
                    tn = Convert.ToDecimal(txtTienNhan.Text);
                tt = tn - tong;
                txtTienThua.Text = tt.ToString("");
            }           
        }
        private void txtSoLuongChatLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void txtTienNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void txtSoLuongChatLieu_Click(object sender, EventArgs e)
        {
            txtSoLuongChatLieu.Text = null;
        }
        private void txtGiamGia_Click(object sender, EventArgs e)
        {
            txtGiamGia.Text = null;
        }
        private void txtTienNhan_Click(object sender, EventArgs e)
        {
            txtTienNhan.Text = "";
        }
        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (MessageBox.Show("Hóa đơn vẫn sẽ được lưu. Bạn có chắc chắn muốn thêm hóa đơn mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetValue();
                    setButton(false);
                    LoadDataListView();
                    txtMaHD.Text = Functions.CreateKey("HD");
                    btnIn.Enabled = false;
                    groupBox3.Enabled = false;
                    txtTongTien.Text = "0";
                    lblChuyenChu.Text = "0 (VNĐ)";
                    txtTienNhan.Text = "0";
                    txtTienThua.Text = "0";
                    flag = 0;

                    string[] partsTime;
                    partsTime = DateTime.Now.ToLongTimeString().Split(':');
                    if (partsTime[2].Substring(3, 2) == "PM")
                        lblCaBan.Text = "Ca chiều";
                    if (partsTime[2].Substring(3, 2) == "AM")
                        lblCaBan.Text = "Ca sáng";
                }
            }
            if (flag == 0)
            {
                ResetValue();
                setButton(false);
                LoadDataListView();
                txtMaHD.Text = Functions.CreateKey("HD");
                btnIn.Enabled = false;
                groupBox3.Enabled = false;
                txtTongTien.Text = "0";
                lblChuyenChu.Text = "0 (VNĐ)";
                txtTienNhan.Text = "0";
                txtTienThua.Text = "0";
                flag = 0;

                string[] partsTime;
                partsTime = DateTime.Now.ToLongTimeString().Split(':');
                if (partsTime[2].Substring(3, 2) == "PM")
                    lblCaBan.Text = "Ca chiều";
                if (partsTime[2].Substring(3, 2) == "AM")
                    lblCaBan.Text = "Ca sáng";
            }                        
        }
        private void btnThemGiay_Click(object sender, EventArgs e)
        {
            txtMaGiay.Text = Functions.CreateKey("S");
            txtHangGiay.Enabled = true;
            txtTenGiay.Enabled = true;
            txtGhiChu.Enabled = true;
            btnMo.Enabled = true;
            txtHangGiay.Text = null;
            txtTenGiay.Text = null;
            txtGhiChu.Text = null;
            picAnh.Image = null;
            groupBox3.Enabled = true;
            txtSoLuongChatLieu.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTienNhan.Text = "0";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbMaHDTimKiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHD.Text = cbMaHDTimKiem.Text;
            LoadInfoHoaDon();
            LoadDataListView();
            setButton(false);
            btnTimKiem.Enabled = true;
            cbMaHDTimKiem.Enabled = true;
            btnHuy.Enabled = true;
            flag = 0;
        }
        private void cbMaHDTimKiem_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHoaDon FROM HoaDon", cbMaHDTimKiem, "MaHoaDon", "MaHoaDon");
            cbMaHDTimKiem.SelectedIndex = -1;
        }
        private void lsvChiTietHD_DoubleClick(object sender, EventArgs e)
        {
            string magiay = "", madv = "", macl, sql;
            Decimal thanhTienxoa = 0, tong, tongMoi;
            float soLuongXoa = 0, slcl, slcon, slth;
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                foreach (ListViewItem items in lsvChiTietHD.SelectedItems)
                {
                    magiay = items.SubItems[0].Text;
                    madv = items.SubItems[2].Text;
                    soLuongXoa = float.Parse(items.SubItems[4].Text);
                    thanhTienxoa = Convert.ToDecimal(items.SubItems[7].Text);
                }
                //Xóa dịch vụ
                sql = "DELETE CTHoaDon WHERE MaGiay = N'" + magiay + "' AND MaDichVu = N'" + madv + "'";
                Functions.RunSQL(sql);
                sql = "DELETE CTGiay WHERE MaGiay = N'" + magiay + "' AND MaDichVu = N'" + madv + "'";
                Functions.RunSQL(sql);

                //Cập nhật lại số lượng dịch vụ
                slcl = float.Parse(Functions.GetFieldValues("SELECT SoLuongChatLieu FROM DichVu WHERE MaDichVu = N'" + madv + "'"));
                slcon = slcl + soLuongXoa;
                sql = "UPDATE DichVu SET SoLuongChatLieu = " + slcon + " WHERE MaDichVu = N'" + madv + "'";
                Functions.RunSQL(sql);

                //Cập nhật lại số lượng chất liệu
                slth = float.Parse(Functions.GetFieldValues("SELECT MucTieuHao FROM DichVu WHERE MaDichVu = N'" + madv + "'"));                
                slcl = float.Parse(Functions.GetFieldValues("SELECT a.SoLuong FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                    madv + "' AND a.MaChatLieu = b.MaChatLieu"));
                macl = Functions.GetFieldValues("SELECT a.MaChatLieu FROM KhoChatLieu AS a, DichVu AS b WHERE MaDichVu = N'" +
                                                                                    madv + "' AND a.MaChatLieu = b.MaChatLieu");
                slcon = slcl + (slth * soLuongXoa);
                sql = "UPDATE KhoChatLieu SET SoLuong = " + slcon + " WHERE MaChatLieu = N'" + macl + "'";
                Functions.RunSQL(sql);

                //Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDecimal(Functions.GetFieldValues("SELECT TongTien FROM HoaDon WHERE MaHoaDon = N'" + txtMaHD.Text + "'"));
                tongMoi = tong - thanhTienxoa;
                sql = "UPDATE HoaDon SET TongTien = " + tongMoi + " WHERE MaHoaDon = N'" + txtMaHD.Text + "'";
                Functions.RunSQL(sql);
                txtTongTien.Text = tongMoi.ToString();
                LoadDataListView();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {            
            if (flag == 0)
            {
                ResetValue();
                setButton(true);
                LoadDataListView();
                groupBox3.Enabled = false;
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
                flag = 0;
                txtTongTien.Text = "0";
                lblChuyenChu.Text = "0 (VNĐ)";
                txtTienNhan.Text = "0";
                txtTienThua.Text = "0";
            }
            if(flag == 1)
            {
                if(MessageBox.Show("Hóa đơn vẫn sẽ được lưu. Bạn có chắc chắn muốn tẩy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetValue();
                    setButton(true);
                    LoadDataListView();
                    groupBox3.Enabled = false;
                    btnHuy.Enabled = false;
                    btnIn.Enabled = false;
                    flag = 0;
                    txtTongTien.Text = "0";
                    lblChuyenChu.Text = "0 (VNĐ)";
                    txtTienNhan.Text = "0";
                    txtTienThua.Text = "0";
                }
            }                    
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            flag = 0;
            xlhd.CapNhatHoaDon(txtMaHD.Text.Trim(), cbTenKhachHang.SelectedValue.ToString(), cbTenNhanVien.SelectedValue.ToString(),
                                    dtNgayBan.Value.Date, lblCaBan.Text.Trim(), txtTongTien.Text.Trim(), txtTienNhan.Text.Trim(), txtTienThua.Text.Trim());

            MessageBox.Show("Hóa đơn xuất thành công", "Thêm Hóa Đơn !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnLuu.Enabled = false;
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Size = 10;
            exRange.Range["A1:D3"].Font.Bold = true;
            exRange.Range["A1:D3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:D1"].Value = "EXTRIM SHOE CARE EXPRESS";
            exRange.Range["A2:D2"].MergeCells = true;
            exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:D2"].Value = "Address: 101A Lê Văn Duyệt, Bình Thạnh, TP.HCM";
            exRange.Range["A3:D3"].MergeCells = true;
            exRange.Range["A3:D3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:D3"].Value = "Hotline: 1900-633-916";
            exRange.Range["C5:G5"].Font.Size = 16;
            exRange.Range["C5:G5"].Font.Bold = true;
            exRange.Range["C5:G5"].Font.ColorIndex = 3;
            exRange.Range["C5:G5"].MergeCells = true;
            exRange.Range["C5:G5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C5:G5"].Value = "HÓA ĐƠN DỊCH VỤ";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDon, a.NgayBan, a.TongTien, b.TenKhachHang, b.DiaChi, b.DienThoai, c.TenNhanVien " +
                "FROM HoaDon AS a, KhachHang AS b, NhanVien AS c " +
                "WHERE a.MaHoaDon = N'" + txtMaHD.Text + "' AND a.MaKhachHang = b.MaKhachHang AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B7:C10"].Font.Size = 12;
            exRange.Range["B7:B7"].Value = "Mã hóa đơn:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B8:B8"].Value = "Khách hàng:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B9:B9"].Value = "Địa chỉ:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B10:B10"].Value = "Điện thoại:";
            exRange.Range["C10:E10"].MergeCells = true;
            exRange.Range["C10:E10"].Value = "(+84) " + tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT c.MaGiay, c.TenGiay, b.TenDichVu, a.SoLuong, a.GiamGia, a.ThanhTien, c.GhiChu " +
                     "FROM CTHoaDon AS a, DichVu AS b, CTGiay AS c " +
                      "WHERE a.MaHoaDon = N'" + txtMaHD.Text + "' AND a.MaDichVu = b.MaDichVu AND a.MaDichVu = c.MaDichVu AND c.MaGiay = a.MaGiay";
            tblThongtinHang = Functions.GetDataToTable(sql);
            exRange.Range["A12:H12"].Font.Bold = true;
            exRange.Range["A12:H12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].ColumnWidth = 4;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].ColumnWidth = 15.29;
            exRange.Range["B12:B12"].Value = "Mã giày";
            exRange.Range["C12:C12"].ColumnWidth = 11;
            exRange.Range["C12:C12"].Value = "Tên giày";
            exRange.Range["D12:D12"].ColumnWidth = 13;
            exRange.Range["D12:D12"].Value = "Tên dịch vụ";
            exRange.Range["E12:E12"].ColumnWidth = 3;
            exRange.Range["E12:E12"].Value = "SL";
            exRange.Range["F12:F12"].ColumnWidth = 5;
            exRange.Range["F12:F12"].Value = "Giảm";
            exRange.Range["G12:G12"].ColumnWidth = 12;
            exRange.Range["G12:G12"].Value = "Thành tiền";
            exRange.Range["H12:H12"].ColumnWidth = 20;
            exRange.Range["H12:H12"].Value = "Ghi chú";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 13] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 4) 
                        exSheet.Cells[cot + 2][hang + 13] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[5][hang + 17]; 
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Italic = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:D1"].Value = "Bình Thạnh, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:D2"].MergeCells = true;
            exRange.Range["A2:D2"].Font.Italic = true;
            exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:D2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:D6"].MergeCells = true;
            exRange.Range["A6:D6"].Font.Italic = true;
            exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:D6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void lsvChiTietHD_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lsvChiTietHD.SelectedItems)
            {
                txtMaGiay.Text = items.SubItems[0].Text;
                txtTenGiay.Text = items.SubItems[1].Text;
                cbDichVu.Text = items.SubItems[3].Text;
                txtSoLuongChatLieu.Text = items.SubItems[4].Text;
                txtDonGia.Text = items.SubItems[5].Text;
                txtGiamGia.Text = items.SubItems[6].Text;
                txtThanhTien.Text = items.SubItems[7].Text;
                txtGhiChu.Text = items.SubItems[8].Text;
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
    }
}
