
namespace ManagementSoftware
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.btnCaiDat = new System.Windows.Forms.Button();
            this.btnHoTro = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnVeSinh = new System.Windows.Forms.Button();
            this.btnCS = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.dropdownMenu1 = new ManagementSoftware.Theme.DropdownMenu(this.components);
            this.storesWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revenueChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownMenu2 = new ManagementSoftware.Theme.DropdownMenu(this.components);
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billOfCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownMenu3 = new ManagementSoftware.Theme.DropdownMenu(this.components);
            this.passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.dropdownMenu1.SuspendLayout();
            this.dropdownMenu2.SuspendLayout();
            this.dropdownMenu3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(60)))));
            this.panelMenu.Controls.Add(this.btnLogo);
            this.panelMenu.Controls.Add(this.btnCaiDat);
            this.panelMenu.Controls.Add(this.btnHoTro);
            this.panelMenu.Controls.Add(this.btnBaoCao);
            this.panelMenu.Controls.Add(this.btnTimKiem);
            this.panelMenu.Controls.Add(this.btnVeSinh);
            this.panelMenu.Controls.Add(this.btnCS);
            this.panelMenu.Controls.Add(this.btnKho);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 808);
            this.panelMenu.TabIndex = 3;
            // 
            // btnLogo
            // 
            this.btnLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogo.FlatAppearance.BorderSize = 0;
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogo.Location = new System.Drawing.Point(0, 748);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnLogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogo.Size = new System.Drawing.Size(220, 60);
            this.btnLogo.TabIndex = 18;
            this.btnLogo.Text = "Logo";
            this.btnLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCaiDat.FlatAppearance.BorderSize = 0;
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaiDat.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCaiDat.Image = global::ManagementSoftware.Properties.Resources.settings;
            this.btnCaiDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaiDat.Location = new System.Drawing.Point(0, 440);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnCaiDat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCaiDat.Size = new System.Drawing.Size(220, 60);
            this.btnCaiDat.TabIndex = 15;
            this.btnCaiDat.Text = "Setting";
            this.btnCaiDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaiDat.UseVisualStyleBackColor = true;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // btnHoTro
            // 
            this.btnHoTro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoTro.FlatAppearance.BorderSize = 0;
            this.btnHoTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoTro.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHoTro.Image = global::ManagementSoftware.Properties.Resources.icons8_help_30;
            this.btnHoTro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoTro.Location = new System.Drawing.Point(0, 380);
            this.btnHoTro.Name = "btnHoTro";
            this.btnHoTro.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnHoTro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHoTro.Size = new System.Drawing.Size(220, 60);
            this.btnHoTro.TabIndex = 14;
            this.btnHoTro.Text = "Help";
            this.btnHoTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoTro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoTro.UseVisualStyleBackColor = true;
            this.btnHoTro.Click += new System.EventHandler(this.btnHoTro_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCao.Image = global::ManagementSoftware.Properties.Resources.bar_chart;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 320);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnBaoCao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBaoCao.Size = new System.Drawing.Size(220, 60);
            this.btnBaoCao.TabIndex = 13;
            this.btnBaoCao.Text = "Report";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTimKiem.Image = global::ManagementSoftware.Properties.Resources.icons8_search_30;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 260);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnTimKiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTimKiem.Size = new System.Drawing.Size(220, 60);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Search";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnVeSinh
            // 
            this.btnVeSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeSinh.FlatAppearance.BorderSize = 0;
            this.btnVeSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeSinh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVeSinh.Image = global::ManagementSoftware.Properties.Resources.icons8_shoe_brush_1_30;
            this.btnVeSinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeSinh.Location = new System.Drawing.Point(0, 200);
            this.btnVeSinh.Name = "btnVeSinh";
            this.btnVeSinh.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnVeSinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVeSinh.Size = new System.Drawing.Size(220, 60);
            this.btnVeSinh.TabIndex = 11;
            this.btnVeSinh.Text = "Quality control";
            this.btnVeSinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeSinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVeSinh.UseVisualStyleBackColor = true;
            this.btnVeSinh.Click += new System.EventHandler(this.btnVeSinh_Click);
            // 
            // btnCS
            // 
            this.btnCS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCS.FlatAppearance.BorderSize = 0;
            this.btnCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCS.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCS.Image = global::ManagementSoftware.Properties.Resources.value__1_;
            this.btnCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCS.Location = new System.Drawing.Point(0, 140);
            this.btnCS.Name = "btnCS";
            this.btnCS.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnCS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCS.Size = new System.Drawing.Size(220, 60);
            this.btnCS.TabIndex = 9;
            this.btnCS.Text = "Counter staff";
            this.btnCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCS.UseVisualStyleBackColor = true;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // btnKho
            // 
            this.btnKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKho.Image = global::ManagementSoftware.Properties.Resources.icons8_manager_30;
            this.btnKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.Location = new System.Drawing.Point(0, 80);
            this.btnKho.Name = "btnKho";
            this.btnKho.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnKho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnKho.Size = new System.Drawing.Size(220, 60);
            this.btnKho.TabIndex = 6;
            this.btnKho.Text = "Manager";
            this.btnKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::ManagementSoftware.Properties.Resources.LogoExtrim;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.FlatAppearance.BorderSize = 0;
            this.panelLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLogo.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 16;
            this.panelLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.panelLogo.UseVisualStyleBackColor = true;
            this.panelLogo.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1052, 80);
            this.panelTitleBar.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(72, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // panelDesktop
            // 
            this.panelDesktop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1052, 728);
            this.panelDesktop.TabIndex = 5;
            // 
            // dropdownMenu1
            // 
            this.dropdownMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownMenu1.IsMainMenu = false;
            this.dropdownMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.storesWarehouseToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.revenueChartToolStripMenuItem});
            this.dropdownMenu1.MenuItemHeaderSize = null;
            this.dropdownMenu1.MenuItemHeight = 25;
            this.dropdownMenu1.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dropdownMenu1.Name = "dropdownMenu1";
            this.dropdownMenu1.PrimaryColor = System.Drawing.Color.Empty;
            this.dropdownMenu1.Size = new System.Drawing.Size(211, 122);
            // 
            // storesWarehouseToolStripMenuItem
            // 
            this.storesWarehouseToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.shopping_list;
            this.storesWarehouseToolStripMenuItem.Name = "storesWarehouseToolStripMenuItem";
            this.storesWarehouseToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.storesWarehouseToolStripMenuItem.Text = "Store\'s warehouse";
            this.storesWarehouseToolStripMenuItem.Click += new System.EventHandler(this.storesWarehouseToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.icons8_service_30;
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.icons8_staff_30;
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.staffToolStripMenuItem.Text = "Staff";
            this.staffToolStripMenuItem.Click += new System.EventHandler(this.staffToolStripMenuItem_Click);
            // 
            // revenueChartToolStripMenuItem
            // 
            this.revenueChartToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.icons8_combo_chart_30;
            this.revenueChartToolStripMenuItem.Name = "revenueChartToolStripMenuItem";
            this.revenueChartToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.revenueChartToolStripMenuItem.Text = "Revenue chart";
            this.revenueChartToolStripMenuItem.Click += new System.EventHandler(this.revenueChartToolStripMenuItem_Click);
            // 
            // dropdownMenu2
            // 
            this.dropdownMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownMenu2.IsMainMenu = false;
            this.dropdownMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.billOfCSToolStripMenuItem});
            this.dropdownMenu2.MenuItemHeaderSize = null;
            this.dropdownMenu2.MenuItemHeight = 25;
            this.dropdownMenu2.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dropdownMenu2.Name = "dropdownMenu2";
            this.dropdownMenu2.PrimaryColor = System.Drawing.Color.Empty;
            this.dropdownMenu2.Size = new System.Drawing.Size(148, 52);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.value;
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // billOfCSToolStripMenuItem
            // 
            this.billOfCSToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.shopping_cart__1_;
            this.billOfCSToolStripMenuItem.Name = "billOfCSToolStripMenuItem";
            this.billOfCSToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.billOfCSToolStripMenuItem.Text = "Bill of CS";
            this.billOfCSToolStripMenuItem.Click += new System.EventHandler(this.billOfCSToolStripMenuItem_Click);
            // 
            // dropdownMenu3
            // 
            this.dropdownMenu3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownMenu3.IsMainMenu = false;
            this.dropdownMenu3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.dropdownMenu3.MenuItemHeaderSize = null;
            this.dropdownMenu3.MenuItemHeight = 25;
            this.dropdownMenu3.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dropdownMenu3.Name = "dropdownMenu3";
            this.dropdownMenu3.PrimaryColor = System.Drawing.Color.Empty;
            this.dropdownMenu3.Size = new System.Drawing.Size(207, 52);
            // 
            // passToolStripMenuItem
            // 
            this.passToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passToolStripMenuItem.Image")));
            this.passToolStripMenuItem.Name = "passToolStripMenuItem";
            this.passToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.passToolStripMenuItem.Text = "Change password";
            this.passToolStripMenuItem.Click += new System.EventHandler(this.passToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::ManagementSoftware.Properties.Resources.icons8_export_48;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.thoátToolStripMenuItem.Text = "Log out";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 808);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.dropdownMenu1.ResumeLayout(false);
            this.dropdownMenu2.ResumeLayout(false);
            this.dropdownMenu3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnHoTro;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnVeSinh;
        private System.Windows.Forms.Button btnCS;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button panelLogo;
        private Theme.DropdownMenu dropdownMenu1;
        private System.Windows.Forms.ToolStripMenuItem storesWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private Theme.DropdownMenu dropdownMenu2;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billOfCSToolStripMenuItem;
        private System.Windows.Forms.Button btnCaiDat;
        private Theme.DropdownMenu dropdownMenu3;
        private System.Windows.Forms.ToolStripMenuItem passToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.ToolStripMenuItem revenueChartToolStripMenuItem;
    }
}

