
namespace ManagementSoftware.Forms
{
    partial class FormKho
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnMo = new System.Windows.Forms.Button();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.lsvChatLieu = new System.Windows.Forms.ListView();
            this.MaChatLieu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenChatLieu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DonVi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDonVi = new System.Windows.Forms.ComboBox();
            this.txtMaChatLieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemSLChatLieu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Location = new System.Drawing.Point(653, 602);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 37);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Location = new System.Drawing.Point(549, 602);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(98, 37);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Save";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.Location = new System.Drawing.Point(237, 602);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 37);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Add";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSua.Location = new System.Drawing.Point(341, 602);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(98, 37);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Edit";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnMo
            // 
            this.btnMo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMo.Location = new System.Drawing.Point(304, 161);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(98, 37);
            this.btnMo.TabIndex = 6;
            this.btnMo.Text = "Open";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // txtLocal
            // 
            this.txtLocal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocal.Location = new System.Drawing.Point(85, 161);
            this.txtLocal.Multiline = true;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.ReadOnly = true;
            this.txtLocal.Size = new System.Drawing.Size(203, 139);
            this.txtLocal.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "Local:";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(445, 602);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 37);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Delete";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.picAnh);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(418, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 275);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(63, 42);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(156, 196);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 0;
            this.picAnh.TabStop = false;
            // 
            // lsvChatLieu
            // 
            this.lsvChatLieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lsvChatLieu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaChatLieu,
            this.TenChatLieu,
            this.SoLuong,
            this.DonVi,
            this.Hinh});
            this.lsvChatLieu.HideSelection = false;
            this.lsvChatLieu.Location = new System.Drawing.Point(42, 350);
            this.lsvChatLieu.Name = "lsvChatLieu";
            this.lsvChatLieu.Size = new System.Drawing.Size(709, 246);
            this.lsvChatLieu.TabIndex = 71;
            this.lsvChatLieu.UseCompatibleStateImageBehavior = false;
            this.lsvChatLieu.Click += new System.EventHandler(this.lsvChatLieu_Click);
            // 
            // MaChatLieu
            // 
            this.MaChatLieu.Text = "Code";
            this.MaChatLieu.Width = 110;
            // 
            // TenChatLieu
            // 
            this.TenChatLieu.Text = "Name";
            this.TenChatLieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TenChatLieu.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.Text = "Quantity";
            this.SoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DonVi
            // 
            this.DonVi.Text = "Unit";
            this.DonVi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Hinh
            // 
            this.Hinh.Text = "Local";
            this.Hinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Hinh.Width = 260;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Unit:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(85, 93);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(180, 28);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.Click += new System.EventHandler(this.txtSoLuong_Click);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 68;
            this.label2.Text = "Quantity:";
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenChatLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChatLieu.Location = new System.Drawing.Point(85, 59);
            this.txtTenChatLieu.Multiline = true;
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(203, 28);
            this.txtTenChatLieu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Name:";
            // 
            // cbDonVi
            // 
            this.cbDonVi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDonVi.FormattingEnabled = true;
            this.cbDonVi.Items.AddRange(new object[] {
            "L",
            "ml",
            "Kg",
            "g",
            "Peace"});
            this.cbDonVi.Location = new System.Drawing.Point(85, 127);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(203, 28);
            this.cbDonVi.TabIndex = 4;
            // 
            // txtMaChatLieu
            // 
            this.txtMaChatLieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaChatLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChatLieu.Location = new System.Drawing.Point(85, 25);
            this.txtMaChatLieu.Multiline = true;
            this.txtMaChatLieu.Name = "txtMaChatLieu";
            this.txtMaChatLieu.ReadOnly = true;
            this.txtMaChatLieu.Size = new System.Drawing.Size(203, 28);
            this.txtMaChatLieu.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 83;
            this.label5.Text = "Code:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btnThemSLChatLieu);
            this.groupBox2.Controls.Add(this.btnMo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbDonVi);
            this.groupBox2.Controls.Add(this.txtMaChatLieu);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenChatLieu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtLocal);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(42, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(709, 316);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chất liệu";
            // 
            // btnThemSLChatLieu
            // 
            this.btnThemSLChatLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSLChatLieu.Image = global::ManagementSoftware.Properties.Resources.icons8_add_16;
            this.btnThemSLChatLieu.Location = new System.Drawing.Point(265, 93);
            this.btnThemSLChatLieu.Name = "btnThemSLChatLieu";
            this.btnThemSLChatLieu.Size = new System.Drawing.Size(23, 28);
            this.btnThemSLChatLieu.TabIndex = 84;
            this.btnThemSLChatLieu.UseVisualStyleBackColor = true;
            this.btnThemSLChatLieu.Click += new System.EventHandler(this.btnThemSLChatLieu_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ManagementSoftware.Properties.Resources.icons8_available_updates_30;
            this.button1.Location = new System.Drawing.Point(194, 602);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 85;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // FormKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 680);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lsvChatLieu);
            this.Name = "FormKho";
            this.Text = "FormKho";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnMo;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvChatLieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDonVi;
        private System.Windows.Forms.TextBox txtMaChatLieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader MaChatLieu;
        private System.Windows.Forms.ColumnHeader TenChatLieu;
        private System.Windows.Forms.ColumnHeader SoLuong;
        private System.Windows.Forms.ColumnHeader DonVi;
        private System.Windows.Forms.ColumnHeader Hinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThemSLChatLieu;
        private System.Windows.Forms.Button button1;
    }
}