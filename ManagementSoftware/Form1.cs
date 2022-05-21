using ManagementSoftware.Controllers;
using ManagementSoftware.Forms;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private ToolStripMenuItem menuTool;
        private Random random = new Random();
        private int tempIndex;
        private Form activeForm;
        private string titleName;
        public string quyen = "";
        public Form1()
        {
            InitializeComponent();
            dropdownMenu1.IsMainMenu = true;
            dropdownMenu2.IsMainMenu = true;
            dropdownMenu3.IsMainMenu = true;
            dropdownMenu1.PrimaryColor = Color.Orange;
            dropdownMenu2.PrimaryColor = Color.Orange;
            dropdownMenu3.PrimaryColor = Color.Orange;

            btnKho.Enabled = false;
            btnCS.Enabled = false;
            btnVeSinh.Enabled = false;
            btnTimKiem.Enabled = true;
            btnBaoCao.Enabled = true;
            btnCaiDat.Enabled = true;
        }       
        public void Logo(string name)
        {
            btnLogo.Text = name;
        }
        //-----------------------QUYỀN TRUY CẬP----------------------
        public void Form(string q)
        {
            this.quyen = q;           
        }
        public void setButton()
        {          
            if (quyen == "Waitting")
            {               
                btnKho.Enabled = false;
                btnCS.Enabled = false;
                btnVeSinh.Enabled = false;
                btnTimKiem.Enabled = true;
                btnBaoCao.Enabled = false;
                btnHoTro.Enabled = true;
                btnCaiDat.Enabled = true;
            }
            if (quyen == "Admin")
            {
                btnKho.Enabled = true;
                btnCS.Enabled = true;
                btnVeSinh.Enabled = true;
                btnTimKiem.Enabled = true;
                btnBaoCao.Enabled = true;
                btnHoTro.Enabled = true;
                btnCaiDat.Enabled = true;
            }
            if (quyen == "CS")
            {
                btnKho.Enabled = false;                
                btnCS.Enabled = true;
                btnVeSinh.Enabled = false;
                btnTimKiem.Enabled = true;
                btnBaoCao.Enabled = false;
                btnHoTro.Enabled = true;
                btnCaiDat.Enabled = true;
            }
            if (quyen == "QC")
            {
                btnKho.Enabled = false;                
                btnCS.Enabled = false;
                btnVeSinh.Enabled = true;
                btnTimKiem.Enabled = true;
                btnBaoCao.Enabled = false;
                btnHoTro.Enabled = true;
                btnCaiDat.Enabled = true;
            }
        }
        //-----------------------XỬ LÝ GIAO DIỆN NGƯỜI DÙNG----------------------
        public Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        public void ActivateColorButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (menuTool != btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;                    
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, 
                                                                                                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton = (Button)btnSender;                   
                    panelTitleBar.BackColor = color;
                }
            }
        }
        public void MenuActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (menuTool != btnSender)
                {
                    DisableButton();
                    menuTool = (ToolStripMenuItem)btnSender;                   
                    titleName = menuTool.Text;
                    //Sử dụng thư viện Globalization để convert chữ thường -> UPPERCASE
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    titleName = textInfo.ToTitleCase(textInfo.ToUpper(titleName));
                }               
            }
        }

        public void DisableButton()
        {
            foreach (Control priviousBtn in panelMenu.Controls)
            {
                if (priviousBtn.GetType() == typeof(Button))
                {
                    priviousBtn.BackColor = Color.FromArgb(37, 39, 60);
                    priviousBtn.ForeColor = Color.White;
                    priviousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, 
                                                                                                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        //-----------------------BUTTON CHỨC NĂNG----------------------
        public void OpenMenuDropdown(Form childForm, object btnSender)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            ActivateColorButton(btnSender);           
        }
        //-----------------------MENU_DROPDOWN FORM----------------------
        public void OpenChildForm(Form childForm, object btnSender)
        {
            
            if (activeForm != null)
            {
                activeForm.Close();
            }
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            MenuActivateButton(btnSender);
            lblTitle.Text = titleName;                        
        }
        //-----------------------BUTTON HOME FORM -> SET NULL (MẶC ĐỊNH)----------------------
        public void OpenHomedForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = null;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            dropdownMenu3.Show(btnLogo, btnLogo.Width - 190, -120);
            ActivateColorButton(btnLogo);
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            dropdownMenu1.Show(btnKho, btnKho.Width, 0);
            ActivateColorButton(btnKho);
        }        

        private void btnCS_Click(object sender, EventArgs e)
        {
            dropdownMenu2.Show(btnCS, btnCS.Width, 0);
            ActivateColorButton(btnCS);
        }

        private void btnVeSinh_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblTitle.Text = textInfo.ToTitleCase(textInfo.ToUpper(btnVeSinh.Text));
            OpenMenuDropdown(new Forms.FormVeSinh(), sender);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblTitle.Text = textInfo.ToTitleCase(textInfo.ToUpper(btnTimKiem.Text));
            OpenMenuDropdown(new Forms.FormTimKiem(), sender);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblTitle.Text = textInfo.ToTitleCase(textInfo.ToUpper(btnBaoCao.Text));
            OpenMenuDropdown(new Forms.FormReport(), sender);
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblTitle.Text = textInfo.ToTitleCase(textInfo.ToUpper(btnHoTro.Text));
            OpenMenuDropdown(new Forms.FormHoTro(), sender);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblTitle.Text = textInfo.ToTitleCase(textInfo.ToUpper(btnCaiDat.Text));
            OpenMenuDropdown(new Forms.FormCaiDat(), sender);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenHomedForm(new Forms.FormHome(), sender);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.FormDangNhap login = new Forms.FormDangNhap();
            login.Show();
        }

        private void storesWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKho(), sender);
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDichVu(), sender);
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNhanVien(), sender);
        }

        private void revenueChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSoLieuDoanhThu(), sender);
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKhachHang(), sender);
        }

        private void billOfCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHoaDon(), sender);
        }
        private void passToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMatKhau mk = new FormMatKhau();
            mk.lblTaiKhoan.Text = btnLogo.Text.Trim();
            mk.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
