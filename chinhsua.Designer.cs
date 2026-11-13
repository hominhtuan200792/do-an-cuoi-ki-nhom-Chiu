namespace libabry_app
{
    partial class chinhsua
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbbMa = new System.Windows.Forms.Label();
            this.lbbTen = new System.Windows.Forms.Label();
            this.lbbTacGia = new System.Windows.Forms.Label();
            this.lbbTheLoai = new System.Windows.Forms.Label();
            this.txtboxMoTa = new System.Windows.Forms.RichTextBox();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.btAnh = new System.Windows.Forms.Button();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.bttThem = new System.Windows.Forms.Button();
            this.bttFix = new System.Windows.Forms.Button();
            this.bttXoa = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbbSoLuong = new System.Windows.Forms.Label();
            this.cbSoLuong = new System.Windows.Forms.TextBox();
            this.bttLamMoi = new System.Windows.Forms.Button();
            this.picSach = new System.Windows.Forms.PictureBox();
            this.panelHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHead.Controls.Add(this.label2);
            this.panelHead.Controls.Add(this.label1);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(1105, 62);
            this.panelHead.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quản Lý Thư Viện ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lbbMa
            // 
            this.lbbMa.AutoSize = true;
            this.lbbMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbMa.Location = new System.Drawing.Point(12, 120);
            this.lbbMa.Name = "lbbMa";
            this.lbbMa.Size = new System.Drawing.Size(109, 25);
            this.lbbMa.TabIndex = 1;
            this.lbbMa.Text = "Mã Sách :";
            // 
            // lbbTen
            // 
            this.lbbTen.AutoSize = true;
            this.lbbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbTen.Location = new System.Drawing.Point(7, 160);
            this.lbbTen.Name = "lbbTen";
            this.lbbTen.Size = new System.Drawing.Size(116, 25);
            this.lbbTen.TabIndex = 2;
            this.lbbTen.Text = "Tên Sách :";
            // 
            // lbbTacGia
            // 
            this.lbbTacGia.AutoSize = true;
            this.lbbTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbTacGia.Location = new System.Drawing.Point(20, 201);
            this.lbbTacGia.Name = "lbbTacGia";
            this.lbbTacGia.Size = new System.Drawing.Size(99, 25);
            this.lbbTacGia.TabIndex = 3;
            this.lbbTacGia.Text = "Tác Giả :";
            this.lbbTacGia.Click += new System.EventHandler(this.lbbTacGia_Click);
            // 
            // lbbTheLoai
            // 
            this.lbbTheLoai.AutoSize = true;
            this.lbbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbTheLoai.Location = new System.Drawing.Point(14, 246);
            this.lbbTheLoai.Name = "lbbTheLoai";
            this.lbbTheLoai.Size = new System.Drawing.Size(108, 25);
            this.lbbTheLoai.TabIndex = 4;
            this.lbbTheLoai.Text = "Thể Loại :";
            // 
            // txtboxMoTa
            // 
            this.txtboxMoTa.Location = new System.Drawing.Point(14, 368);
            this.txtboxMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtboxMoTa.Name = "txtboxMoTa";
            this.txtboxMoTa.Size = new System.Drawing.Size(1077, 125);
            this.txtboxMoTa.TabIndex = 5;
            this.txtboxMoTa.Text = "";
            this.txtboxMoTa.TextChanged += new System.EventHandler(this.txtboxMoTa_TextChanged);
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Location = new System.Drawing.Point(115, 246);
            this.cbTheLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(192, 28);
            this.cbTheLoai.TabIndex = 6;
            this.cbTheLoai.SelectedIndexChanged += new System.EventHandler(this.cbTheLoai_SelectedIndexChanged);
            this.cbTheLoai.DropDownStyleChanged += new System.EventHandler(this.cbTheLoai_SelectedIndexChanged);
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(115, 199);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(192, 26);
            this.txtTacGia.TabIndex = 7;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(115, 160);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(192, 26);
            this.txtTenSach.TabIndex = 8;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(115, 120);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(192, 26);
            this.txtMaSach.TabIndex = 9;
            this.txtMaSach.TextChanged += new System.EventHandler(this.txtMaSach_TextChanged);
            // 
            // btAnh
            // 
            this.btAnh.Location = new System.Drawing.Point(657, 199);
            this.btAnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAnh.Name = "btAnh";
            this.btAnh.Size = new System.Drawing.Size(96, 52);
            this.btAnh.TabIndex = 10;
            this.btAnh.Text = "Thêm ảnh";
            this.btAnh.UseVisualStyleBackColor = true;
            this.btAnh.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbMoTa
            // 
            this.lbMoTa.AutoSize = true;
            this.lbMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoTa.Location = new System.Drawing.Point(14, 339);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(85, 25);
            this.lbMoTa.TabIndex = 12;
            this.lbMoTa.Text = "Mô Tả :";
            // 
            // bttThem
            // 
            this.bttThem.Location = new System.Drawing.Point(486, 100);
            this.bttThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttThem.Name = "bttThem";
            this.bttThem.Size = new System.Drawing.Size(96, 52);
            this.bttThem.TabIndex = 13;
            this.bttThem.Text = "Thêm";
            this.bttThem.UseVisualStyleBackColor = true;
            this.bttThem.Click += new System.EventHandler(this.bttThem_Click);
            // 
            // bttFix
            // 
            this.bttFix.Location = new System.Drawing.Point(486, 160);
            this.bttFix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttFix.Name = "bttFix";
            this.bttFix.Size = new System.Drawing.Size(96, 52);
            this.bttFix.TabIndex = 14;
            this.bttFix.Text = "Chỉnh Sửa";
            this.bttFix.UseVisualStyleBackColor = true;
            this.bttFix.Click += new System.EventHandler(this.bttFix_Click);
            // 
            // bttXoa
            // 
            this.bttXoa.Location = new System.Drawing.Point(486, 224);
            this.bttXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttXoa.Name = "bttXoa";
            this.bttXoa.Size = new System.Drawing.Size(96, 52);
            this.bttXoa.TabIndex = 15;
            this.bttXoa.Text = "Xóa";
            this.bttXoa.UseVisualStyleBackColor = true;
            this.bttXoa.Click += new System.EventHandler(this.bttXoa_Click);
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AllowUserToOrderColumns = true;
            this.dgvSach.AllowUserToResizeColumns = false;
            this.dgvSach.AllowUserToResizeRows = false;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSach,
            this.TenSach,
            this.TacGia,
            this.TheLoai,
            this.SoLuong,
            this.Mota,
            this.anh});
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSach.Location = new System.Drawing.Point(0, 501);
            this.dgvSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(1105, 315);
            this.dgvSach.TabIndex = 16;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            this.dgvSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellContentClick);
            // 
            // MaSach
            // 
            this.MaSach.HeaderText = "Mã Sách";
            this.MaSach.MinimumWidth = 20;
            this.MaSach.Name = "MaSach";
            this.MaSach.ReadOnly = true;
            this.MaSach.Width = 125;
            // 
            // TenSach
            // 
            this.TenSach.HeaderText = "Tên Sách";
            this.TenSach.MinimumWidth = 20;
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            this.TenSach.Width = 125;
            // 
            // TacGia
            // 
            this.TacGia.HeaderText = "Tác Giả";
            this.TacGia.MinimumWidth = 20;
            this.TacGia.Name = "TacGia";
            this.TacGia.ReadOnly = true;
            this.TacGia.Width = 125;
            // 
            // TheLoai
            // 
            this.TheLoai.HeaderText = "Thể Loại";
            this.TheLoai.MinimumWidth = 20;
            this.TheLoai.Name = "TheLoai";
            this.TheLoai.ReadOnly = true;
            this.TheLoai.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 125;
            // 
            // Mota
            // 
            this.Mota.HeaderText = "Mô Tả";
            this.Mota.MinimumWidth = 6;
            this.Mota.Name = "Mota";
            this.Mota.ReadOnly = true;
            this.Mota.Width = 125;
            // 
            // anh
            // 
            this.anh.HeaderText = "Ảnh";
            this.anh.MinimumWidth = 6;
            this.anh.Name = "anh";
            this.anh.ReadOnly = true;
            this.anh.Width = 125;
            // 
            // lbbSoLuong
            // 
            this.lbbSoLuong.AutoSize = true;
            this.lbbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbSoLuong.Location = new System.Drawing.Point(7, 285);
            this.lbbSoLuong.Name = "lbbSoLuong";
            this.lbbSoLuong.Size = new System.Drawing.Size(116, 25);
            this.lbbSoLuong.TabIndex = 17;
            this.lbbSoLuong.Text = "Số Lượng :";
            // 
            // cbSoLuong
            // 
            this.cbSoLuong.Location = new System.Drawing.Point(115, 285);
            this.cbSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSoLuong.Name = "cbSoLuong";
            this.cbSoLuong.Size = new System.Drawing.Size(192, 26);
            this.cbSoLuong.TabIndex = 18;
            this.cbSoLuong.TextChanged += new System.EventHandler(this.cbSoLuong_TextChanged);
            // 
            // bttLamMoi
            // 
            this.bttLamMoi.Location = new System.Drawing.Point(486, 285);
            this.bttLamMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttLamMoi.Name = "bttLamMoi";
            this.bttLamMoi.Size = new System.Drawing.Size(96, 52);
            this.bttLamMoi.TabIndex = 19;
            this.bttLamMoi.Text = "Làm mới";
            this.bttLamMoi.UseVisualStyleBackColor = true;
            this.bttLamMoi.Click += new System.EventHandler(this.bttLamMoi_Click);
            // 
            // picSach
            // 
            this.picSach.Location = new System.Drawing.Point(759, 120);
            this.picSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picSach.Name = "picSach";
            this.picSach.Size = new System.Drawing.Size(332, 240);
            this.picSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSach.TabIndex = 11;
            this.picSach.TabStop = false;
            // 
            // chinhsua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1105, 816);
            this.Controls.Add(this.bttLamMoi);
            this.Controls.Add(this.cbSoLuong);
            this.Controls.Add(this.lbbSoLuong);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.bttXoa);
            this.Controls.Add(this.bttFix);
            this.Controls.Add(this.bttThem);
            this.Controls.Add(this.lbMoTa);
            this.Controls.Add(this.picSach);
            this.Controls.Add(this.btAnh);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.cbTheLoai);
            this.Controls.Add(this.txtboxMoTa);
            this.Controls.Add(this.lbbTheLoai);
            this.Controls.Add(this.lbbTacGia);
            this.Controls.Add(this.lbbTen);
            this.Controls.Add(this.lbbMa);
            this.Controls.Add(this.panelHead);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "chinhsua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chinhsua";
            this.Load += new System.EventHandler(this.chinhsua_Load);
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbbMa;
        private System.Windows.Forms.Label lbbTen;
        private System.Windows.Forms.Label lbbTacGia;
        private System.Windows.Forms.Label lbbTheLoai;
        private System.Windows.Forms.RichTextBox txtboxMoTa;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btAnh;
        private System.Windows.Forms.PictureBox picSach;
        private System.Windows.Forms.Label lbMoTa;
        private System.Windows.Forms.Button bttThem;
        private System.Windows.Forms.Button bttFix;
        private System.Windows.Forms.Button bttXoa;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Label lbbSoLuong;
        private System.Windows.Forms.TextBox cbSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mota;
        private System.Windows.Forms.DataGridViewTextBoxColumn anh;
        private System.Windows.Forms.Button bttLamMoi;
    }
}