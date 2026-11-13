namespace libabry_app
{
    partial class Quanlyuser
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
            this.panelHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.Label();
            this.trangthaitk = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbLocNhom = new System.Windows.Forms.ComboBox();
            this.cbLocTrangThai = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttMoKhoa = new System.Windows.Forms.Button();
            this.bttLamMoi = new System.Windows.Forms.Button();
            this.bttXoa = new System.Windows.Forms.Button();
            this.bttDatLaiMK = new System.Windows.Forms.Button();
            this.bttSua = new System.Windows.Forms.Button();
            this.bttKhoa = new System.Windows.Forms.Button();
            this.bttThem = new System.Windows.Forms.Button();
            this.rbDocGia = new System.Windows.Forms.CheckBox();
            this.rbNhanVien = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbNhomQuyen = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MaTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelHead.Controls.Add(this.label1);
            this.panelHead.Location = new System.Drawing.Point(14, 15);
            this.panelHead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(915, 62);
            this.panelHead.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(233, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ TÀI KHOẢN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tim
            // 
            this.tim.AutoSize = true;
            this.tim.Location = new System.Drawing.Point(14, 105);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(34, 20);
            this.tim.TabIndex = 1;
            this.tim.Text = "Tìm";
            this.tim.Click += new System.EventHandler(this.label2_Click);
            // 
            // nhom
            // 
            this.nhom.AutoSize = true;
            this.nhom.Location = new System.Drawing.Point(250, 104);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(98, 20);
            this.nhom.TabIndex = 2;
            this.nhom.Text = "Nhóm quyền";
            // 
            // trangthaitk
            // 
            this.trangthaitk.AutoSize = true;
            this.trangthaitk.Location = new System.Drawing.Point(528, 104);
            this.trangthaitk.Name = "trangthaitk";
            this.trangthaitk.Size = new System.Drawing.Size(84, 20);
            this.trangthaitk.TabIndex = 3;
            this.trangthaitk.Text = "Trạng Thái";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(54, 98);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(169, 26);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 85);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbLocNhom
            // 
            this.cbLocNhom.FormattingEnabled = true;
            this.cbLocNhom.Location = new System.Drawing.Point(354, 98);
            this.cbLocNhom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLocNhom.Name = "cbLocNhom";
            this.cbLocNhom.Size = new System.Drawing.Size(136, 28);
            this.cbLocNhom.TabIndex = 8;
            // 
            // cbLocTrangThai
            // 
            this.cbLocTrangThai.FormattingEnabled = true;
            this.cbLocTrangThai.Location = new System.Drawing.Point(623, 98);
            this.cbLocTrangThai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLocTrangThai.Name = "cbLocTrangThai";
            this.cbLocTrangThai.Size = new System.Drawing.Size(136, 28);
            this.cbLocTrangThai.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTaiKhoan,
            this.Column1,
            this.TenDangNhap,
            this.HoTen,
            this.TenNhomQuyen,
            this.TrangThai});
            this.dataGridView1.Location = new System.Drawing.Point(17, 144);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(834, 86);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtMaTK
            // 
            this.txtMaTK.Location = new System.Drawing.Point(94, 30);
            this.txtMaTK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.Size = new System.Drawing.Size(112, 26);
            this.txtMaTK.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mã TK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttMoKhoa);
            this.groupBox1.Controls.Add(this.bttLamMoi);
            this.groupBox1.Controls.Add(this.bttXoa);
            this.groupBox1.Controls.Add(this.bttDatLaiMK);
            this.groupBox1.Controls.Add(this.bttSua);
            this.groupBox1.Controls.Add(this.bttKhoa);
            this.groupBox1.Controls.Add(this.bttThem);
            this.groupBox1.Controls.Add(this.rbDocGia);
            this.groupBox1.Controls.Add(this.rbNhanVien);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.cbNhomQuyen);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTenDN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaTK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 251);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(909, 258);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thôn tin tài khoản";
            // 
            // bttMoKhoa
            // 
            this.bttMoKhoa.Location = new System.Drawing.Point(584, 164);
            this.bttMoKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttMoKhoa.Name = "bttMoKhoa";
            this.bttMoKhoa.Size = new System.Drawing.Size(84, 29);
            this.bttMoKhoa.TabIndex = 34;
            this.bttMoKhoa.Text = "Mở Khóa";
            this.bttMoKhoa.UseVisualStyleBackColor = true;
            // 
            // bttLamMoi
            // 
            this.bttLamMoi.Location = new System.Drawing.Point(584, 30);
            this.bttLamMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttLamMoi.Name = "bttLamMoi";
            this.bttLamMoi.Size = new System.Drawing.Size(84, 29);
            this.bttLamMoi.TabIndex = 33;
            this.bttLamMoi.Text = "Làm Mới";
            this.bttLamMoi.UseVisualStyleBackColor = true;
            // 
            // bttXoa
            // 
            this.bttXoa.Location = new System.Drawing.Point(430, 164);
            this.bttXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttXoa.Name = "bttXoa";
            this.bttXoa.Size = new System.Drawing.Size(84, 29);
            this.bttXoa.TabIndex = 32;
            this.bttXoa.Text = "Xóa";
            this.bttXoa.UseVisualStyleBackColor = true;
            // 
            // bttDatLaiMK
            // 
            this.bttDatLaiMK.Location = new System.Drawing.Point(710, 81);
            this.bttDatLaiMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttDatLaiMK.Name = "bttDatLaiMK";
            this.bttDatLaiMK.Size = new System.Drawing.Size(124, 58);
            this.bttDatLaiMK.TabIndex = 31;
            this.bttDatLaiMK.Text = "Đặt lại mật khẩu";
            this.bttDatLaiMK.UseVisualStyleBackColor = true;
            // 
            // bttSua
            // 
            this.bttSua.Location = new System.Drawing.Point(430, 96);
            this.bttSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttSua.Name = "bttSua";
            this.bttSua.Size = new System.Drawing.Size(84, 29);
            this.bttSua.TabIndex = 30;
            this.bttSua.Text = "Sửa";
            this.bttSua.UseVisualStyleBackColor = true;
            // 
            // bttKhoa
            // 
            this.bttKhoa.Location = new System.Drawing.Point(584, 96);
            this.bttKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttKhoa.Name = "bttKhoa";
            this.bttKhoa.Size = new System.Drawing.Size(84, 29);
            this.bttKhoa.TabIndex = 29;
            this.bttKhoa.Text = "Khóa";
            this.bttKhoa.UseVisualStyleBackColor = true;
            // 
            // bttThem
            // 
            this.bttThem.Location = new System.Drawing.Point(430, 30);
            this.bttThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttThem.Name = "bttThem";
            this.bttThem.Size = new System.Drawing.Size(84, 29);
            this.bttThem.TabIndex = 28;
            this.bttThem.Text = "Thêm";
            this.bttThem.UseVisualStyleBackColor = true;
            // 
            // rbDocGia
            // 
            this.rbDocGia.AutoSize = true;
            this.rbDocGia.Location = new System.Drawing.Point(224, 160);
            this.rbDocGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbDocGia.Name = "rbDocGia";
            this.rbDocGia.Size = new System.Drawing.Size(93, 24);
            this.rbDocGia.TabIndex = 27;
            this.rbDocGia.Text = "Độc Giả";
            this.rbDocGia.UseVisualStyleBackColor = true;
            // 
            // rbNhanVien
            // 
            this.rbNhanVien.AutoSize = true;
            this.rbNhanVien.Location = new System.Drawing.Point(97, 160);
            this.rbNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbNhanVien.Name = "rbNhanVien";
            this.rbNhanVien.Size = new System.Drawing.Size(109, 24);
            this.rbNhanVien.TabIndex = 26;
            this.rbNhanVien.Text = "Nhân Viên";
            this.rbNhanVien.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hoạt Động",
            "Khóa"});
            this.comboBox1.Location = new System.Drawing.Point(97, 195);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 28);
            this.comboBox1.TabIndex = 24;
            // 
            // cbNhomQuyen
            // 
            this.cbNhomQuyen.FormattingEnabled = true;
            this.cbNhomQuyen.Items.AddRange(new object[] {
            "Xem sách",
            "Thêm sách",
            "Quản lý user "});
            this.cbNhomQuyen.Location = new System.Drawing.Point(111, 111);
            this.cbNhomQuyen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbNhomQuyen.Name = "cbNhomQuyen";
            this.cbNhomQuyen.Size = new System.Drawing.Size(136, 28);
            this.cbNhomQuyen.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Trạng thái";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Gắn với";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(94, 69);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(112, 26);
            this.txtTenDN.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Nhóm quyền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên ĐN";
            // 
            // MaTaiKhoan
            // 
            this.MaTaiKhoan.HeaderText = "Mã Tài Khoản";
            this.MaTaiKhoan.MinimumWidth = 6;
            this.MaTaiKhoan.Name = "MaTaiKhoan";
            this.MaTaiKhoan.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "MSSV/MaGV";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.HeaderText = "Tên Đăng Nhập";
            this.TenDangNhap.MinimumWidth = 6;
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 125;
            // 
            // TenNhomQuyen
            // 
            this.TenNhomQuyen.HeaderText = "Tên Nhóm Quyền";
            this.TenNhomQuyen.MinimumWidth = 6;
            this.TenNhomQuyen.Name = "TenNhomQuyen";
            this.TenNhomQuyen.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // Quanlyuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbLocTrangThai);
            this.Controls.Add(this.cbLocNhom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.trangthaitk);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.panelHead);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Quanlyuser";
            this.Text = "Quanlyuser";
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tim;
        private System.Windows.Forms.Label nhom;
        private System.Windows.Forms.Label trangthaitk;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbLocNhom;
        private System.Windows.Forms.ComboBox cbLocTrangThai;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNhomQuyen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox rbDocGia;
        private System.Windows.Forms.CheckBox rbNhanVien;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bttLamMoi;
        private System.Windows.Forms.Button bttXoa;
        private System.Windows.Forms.Button bttDatLaiMK;
        private System.Windows.Forms.Button bttSua;
        private System.Windows.Forms.Button bttKhoa;
        private System.Windows.Forms.Button bttThem;
        private System.Windows.Forms.Button bttMoKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}