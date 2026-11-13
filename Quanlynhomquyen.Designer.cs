namespace libabry_app
{
    partial class Quanlynhomquyen
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
            this.lbHead = new System.Windows.Forms.Label();
            this.dgvNhomQuyen = new System.Windows.Forms.DataGridView();
            this.MaNhomQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.bttLamMoi = new System.Windows.Forms.Button();
            this.bttXoa = new System.Windows.Forms.Button();
            this.bttSua = new System.Windows.Forms.Button();
            this.clbQuyen = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.txtMaNhom = new System.Windows.Forms.TextBox();
            this.panelHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyen)).BeginInit();
            this.gbDanhSach.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelHead.Controls.Add(this.lbHead);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.ForeColor = System.Drawing.Color.Transparent;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(682, 60);
            this.panelHead.TabIndex = 0;
            // 
            // lbHead
            // 
            this.lbHead.AutoSize = true;
            this.lbHead.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbHead.ForeColor = System.Drawing.Color.Black;
            this.lbHead.Location = new System.Drawing.Point(153, 15);
            this.lbHead.Name = "lbHead";
            this.lbHead.Size = new System.Drawing.Size(354, 32);
            this.lbHead.TabIndex = 0;
            this.lbHead.Text = "QUẢN LÝ NHÓM QUYỀN";
            this.lbHead.Click += new System.EventHandler(this.lbHead_Click);
            // 
            // dgvNhomQuyen
            // 
            this.dgvNhomQuyen.AllowUserToAddRows = false;
            this.dgvNhomQuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhomQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhomQuyen,
            this.TenNhomQuyen,
            this.MoTa});
            this.dgvNhomQuyen.Location = new System.Drawing.Point(0, 21);
            this.dgvNhomQuyen.MultiSelect = false;
            this.dgvNhomQuyen.Name = "dgvNhomQuyen";
            this.dgvNhomQuyen.ReadOnly = true;
            this.dgvNhomQuyen.RowHeadersVisible = false;
            this.dgvNhomQuyen.RowHeadersWidth = 51;
            this.dgvNhomQuyen.RowTemplate.Height = 24;
            this.dgvNhomQuyen.Size = new System.Drawing.Size(360, 165);
            this.dgvNhomQuyen.TabIndex = 1;
            // 
            // MaNhomQuyen
            // 
            this.MaNhomQuyen.HeaderText = "Mã Nhóm";
            this.MaNhomQuyen.MinimumWidth = 6;
            this.MaNhomQuyen.Name = "MaNhomQuyen";
            this.MaNhomQuyen.ReadOnly = true;
            // 
            // TenNhomQuyen
            // 
            this.TenNhomQuyen.HeaderText = "Tên Nhóm Quyền";
            this.TenNhomQuyen.MinimumWidth = 6;
            this.TenNhomQuyen.Name = "TenNhomQuyen";
            this.TenNhomQuyen.ReadOnly = true;
            // 
            // MoTa
            // 
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDanhSach.Controls.Add(this.dgvNhomQuyen);
            this.gbDanhSach.Location = new System.Drawing.Point(0, 66);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Size = new System.Drawing.Size(366, 186);
            this.gbDanhSach.TabIndex = 2;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "Danh sách nhóm quyền";
            // 
            // gbThongTin
            // 
            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThongTin.Controls.Add(this.bttLamMoi);
            this.gbThongTin.Controls.Add(this.bttXoa);
            this.gbThongTin.Controls.Add(this.bttSua);
            this.gbThongTin.Controls.Add(this.clbQuyen);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.bttThem);
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Controls.Add(this.txtMoTa);
            this.gbThongTin.Controls.Add(this.txtTenNhom);
            this.gbThongTin.Controls.Add(this.txtMaNhom);
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbThongTin.Location = new System.Drawing.Point(0, 258);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(498, 157);
            this.gbThongTin.TabIndex = 3;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin nhóm";
            // 
            // bttLamMoi
            // 
            this.bttLamMoi.Location = new System.Drawing.Point(346, 128);
            this.bttLamMoi.Name = "bttLamMoi";
            this.bttLamMoi.Size = new System.Drawing.Size(114, 23);
            this.bttLamMoi.TabIndex = 9;
            this.bttLamMoi.Text = "Làm Mới";
            this.bttLamMoi.UseVisualStyleBackColor = true;
            // 
            // bttXoa
            // 
            this.bttXoa.Location = new System.Drawing.Point(241, 128);
            this.bttXoa.Name = "bttXoa";
            this.bttXoa.Size = new System.Drawing.Size(75, 23);
            this.bttXoa.TabIndex = 8;
            this.bttXoa.Text = "Xóa";
            this.bttXoa.UseVisualStyleBackColor = true;
            // 
            // bttSua
            // 
            this.bttSua.Location = new System.Drawing.Point(140, 127);
            this.bttSua.Name = "bttSua";
            this.bttSua.Size = new System.Drawing.Size(75, 23);
            this.bttSua.TabIndex = 7;
            this.bttSua.Text = "Sửa";
            this.bttSua.UseVisualStyleBackColor = true;
            // 
            // clbQuyen
            // 
            this.clbQuyen.CheckOnClick = true;
            this.clbQuyen.FormattingEnabled = true;
            this.clbQuyen.Items.AddRange(new object[] {
            "Xem sách",
            "Thêm sách",
            "Quản lý user "});
            this.clbQuyen.Location = new System.Drawing.Point(354, 38);
            this.clbQuyen.Name = "clbQuyen";
            this.clbQuyen.Size = new System.Drawing.Size(126, 61);
            this.clbQuyen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quyền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mô tả  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên nhóm";
            // 
            // bttThem
            // 
            this.bttThem.Location = new System.Drawing.Point(21, 128);
            this.bttThem.Name = "bttThem";
            this.bttThem.Size = new System.Drawing.Size(75, 23);
            this.bttThem.TabIndex = 4;
            this.bttThem.Text = "Thêm";
            this.bttThem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã nhóm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(115, 86);
            this.txtMoTa.MaxLength = 255;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(100, 24);
            this.txtMoTa.TabIndex = 2;
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Location = new System.Drawing.Point(115, 58);
            this.txtTenNhom.MaxLength = 50;
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(100, 24);
            this.txtTenNhom.TabIndex = 1;
            // 
            // txtMaNhom
            // 
            this.txtMaNhom.Location = new System.Drawing.Point(115, 30);
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.ReadOnly = true;
            this.txtMaNhom.Size = new System.Drawing.Size(100, 24);
            this.txtMaNhom.TabIndex = 0;
            // 
            // Quanlynhomquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 425);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.panelHead);
            this.Name = "Quanlynhomquyen";
            this.Text = "Quanlynhomquyen";
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomQuyen)).EndInit();
            this.gbDanhSach.ResumeLayout(false);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label lbHead;
        private System.Windows.Forms.DataGridView dgvNhomQuyen;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.Button bttThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTenNhom;
        private System.Windows.Forms.TextBox txtMaNhom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttXoa;
        private System.Windows.Forms.Button bttSua;
        private System.Windows.Forms.Button bttLamMoi;
        private System.Windows.Forms.CheckedListBox clbQuyen;
        private System.Windows.Forms.Label label4;
    }
}