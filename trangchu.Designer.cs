namespace libabry_app
{
    partial class trangchu
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
            this.lbTen = new System.Windows.Forms.Label();
            this.bttSearch = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbHead = new System.Windows.Forms.Label();
            this.panelDanhMuc = new System.Windows.Forms.Panel();
            this.bttTraSach = new System.Windows.Forms.Button();
            this.bttMuonSach = new System.Windows.Forms.Button();
            this.flowpanelSach = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.panelHead.SuspendLayout();
            this.panelDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelHead.Controls.Add(this.label1);
            this.panelHead.Controls.Add(this.pictureBox1);
            this.panelHead.Controls.Add(this.lbTen);
            this.panelHead.Controls.Add(this.picAvatar);
            this.panelHead.Controls.Add(this.bttSearch);
            this.panelHead.Controls.Add(this.lbSearch);
            this.panelHead.Controls.Add(this.textBox1);
            this.panelHead.Controls.Add(this.lbHead);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(1488, 125);
            this.panelHead.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1111, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hướng dẫn";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Location = new System.Drawing.Point(1205, 89);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(67, 20);
            this.lbTen.TabIndex = 5;
            this.lbTen.Text = "tên user";
            this.lbTen.Click += new System.EventHandler(this.lbTen_Click);
            // 
            // bttSearch
            // 
            this.bttSearch.Location = new System.Drawing.Point(495, 50);
            this.bttSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttSearch.Name = "bttSearch";
            this.bttSearch.Size = new System.Drawing.Size(84, 29);
            this.bttSearch.TabIndex = 3;
            this.bttSearch.Text = "Tìm Kiếm";
            this.bttSearch.UseVisualStyleBackColor = true;
            this.bttSearch.Click += new System.EventHandler(this.bttSearch_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(133, 56);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(114, 20);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Tìm Kiếm Sách";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(262, 51);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbHead
            // 
            this.lbHead.AutoSize = true;
            this.lbHead.Location = new System.Drawing.Point(14, 11);
            this.lbHead.Name = "lbHead";
            this.lbHead.Size = new System.Drawing.Size(121, 20);
            this.lbHead.TabIndex = 0;
            this.lbHead.Text = "Thư Viện Online";
            // 
            // panelDanhMuc
            // 
            this.panelDanhMuc.BackColor = System.Drawing.SystemColors.Info;
            this.panelDanhMuc.Controls.Add(this.bttTraSach);
            this.panelDanhMuc.Controls.Add(this.bttMuonSach);
            this.panelDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDanhMuc.Location = new System.Drawing.Point(0, 125);
            this.panelDanhMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelDanhMuc.Name = "panelDanhMuc";
            this.panelDanhMuc.Size = new System.Drawing.Size(1488, 52);
            this.panelDanhMuc.TabIndex = 2;
            // 
            // bttTraSach
            // 
            this.bttTraSach.Location = new System.Drawing.Point(128, 8);
            this.bttTraSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttTraSach.Name = "bttTraSach";
            this.bttTraSach.Size = new System.Drawing.Size(94, 39);
            this.bttTraSach.TabIndex = 0;
            this.bttTraSach.Text = "Trả sách";
            this.bttTraSach.UseVisualStyleBackColor = true;
            this.bttTraSach.Click += new System.EventHandler(this.bttTraSach_Click);
            // 
            // bttMuonSach
            // 
            this.bttMuonSach.Location = new System.Drawing.Point(12, 8);
            this.bttMuonSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttMuonSach.Name = "bttMuonSach";
            this.bttMuonSach.Size = new System.Drawing.Size(100, 39);
            this.bttMuonSach.TabIndex = 0;
            this.bttMuonSach.Text = "Mượn sách";
            this.bttMuonSach.UseVisualStyleBackColor = true;
            this.bttMuonSach.Click += new System.EventHandler(this.bttMuonSach_Click_1);
            // 
            // flowpanelSach
            // 
            this.flowpanelSach.AutoScroll = true;
            this.flowpanelSach.BackColor = System.Drawing.Color.Transparent;
            this.flowpanelSach.BackgroundImage = global::libabry_app.Properties.Resources.cHJpdmF0ZS90ZW1wbGF0ZXMvZmlsZXMvY3JlYXRlX3Rvb2wvMjAyMy0wNy8wMWd6ZDNwMjVhNms5aHBhNzl4enFkZGZ5cy1sazhpa3NlMi5wbmc;
            this.flowpanelSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowpanelSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowpanelSach.Location = new System.Drawing.Point(0, 177);
            this.flowpanelSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowpanelSach.Name = "flowpanelSach";
            this.flowpanelSach.Size = new System.Drawing.Size(1488, 873);
            this.flowpanelSach.TabIndex = 3;
            this.flowpanelSach.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanelSach_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::libabry_app.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(1115, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Image = global::libabry_app.Properties.Resources._74464;
            this.picAvatar.Location = new System.Drawing.Point(1195, 15);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(73, 70);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 4;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 1050);
            this.Controls.Add(this.flowpanelSach);
            this.Controls.Add(this.panelDanhMuc);
            this.Controls.Add(this.panelHead);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "trangchu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "trangchu";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.panelDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbHead;
        private System.Windows.Forms.Button bttSearch;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel panelDanhMuc;
        private System.Windows.Forms.FlowLayoutPanel flowpanelSach;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bttTraSach;
        private System.Windows.Forms.Button bttMuonSach;
        private System.Windows.Forms.Label label1;
    }
}