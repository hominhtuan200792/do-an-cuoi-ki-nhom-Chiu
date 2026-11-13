namespace libabry_app
{
    partial class CardBook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.picBook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(3, 248);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(77, 20);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Tên Sách";
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(3, 284);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(95, 20);
            this.lblTacGia.TabIndex = 2;
            this.lblTacGia.Text = "Tên Tác Giả";
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(3, 319);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(70, 20);
            this.lblTheLoai.TabIndex = 3;
            this.lblTheLoai.Text = "Thể Loại";
            this.lblTheLoai.Click += new System.EventHandler(this.lblTheLoai_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(70, 358);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(104, 56);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "Chi Tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(179, 415);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(69, 20);
            this.lblMa.TabIndex = 5;
            this.lblMa.Text = "Mã sách";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(3, 418);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(78, 20);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số Lượng";
            this.lblSoLuong.Click += new System.EventHandler(this.lblSoLuong_Click);
            // 
            // picBook
            // 
            this.picBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBook.Location = new System.Drawing.Point(0, 0);
            this.picBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBook.Name = "picBook";
            this.picBook.Size = new System.Drawing.Size(248, 226);
            this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBook.TabIndex = 0;
            this.picBook.TabStop = false;
            this.picBook.Click += new System.EventHandler(this.picBook_Click);
            // 
            // CardBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.lblTheLoai);
            this.Controls.Add(this.lblTacGia);
            this.Controls.Add(this.lblTenSach);
            this.Controls.Add(this.picBook);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CardBook";
            this.Size = new System.Drawing.Size(248, 438);
            this.Load += new System.EventHandler(this.CardBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBook;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblSoLuong;
    }
}
