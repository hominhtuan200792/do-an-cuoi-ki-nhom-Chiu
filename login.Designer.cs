namespace libabry_app
{
    partial class login
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
            this.grDangNhap = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttLogin = new System.Windows.Forms.Button();
            this.bttDangKi = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.rGV = new System.Windows.Forms.RadioButton();
            this.ckGhiNho = new System.Windows.Forms.CheckBox();
            this.rSV = new System.Windows.Forms.RadioButton();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.bttThoat = new System.Windows.Forms.Button();
            this.lbbHead = new System.Windows.Forms.Label();
            this.grDangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grDangNhap
            // 
            this.grDangNhap.BackgroundImage = global::libabry_app.Properties.Resources.back_to_school_background_with_silhouette_of_books_feathers_school_tool_doodle_and_copy_space_area_suitable_to_place_on_content_with_that_theme_free_vector;
            this.grDangNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grDangNhap.Controls.Add(this.label1);
            this.grDangNhap.Controls.Add(this.bttLogin);
            this.grDangNhap.Controls.Add(this.bttDangKi);
            this.grDangNhap.Controls.Add(this.txtPass);
            this.grDangNhap.Controls.Add(this.lbPass);
            this.grDangNhap.Controls.Add(this.rGV);
            this.grDangNhap.Controls.Add(this.ckGhiNho);
            this.grDangNhap.Controls.Add(this.rSV);
            this.grDangNhap.Controls.Add(this.txtTen);
            this.grDangNhap.Controls.Add(this.lbTen);
            this.grDangNhap.Location = new System.Drawing.Point(12, 90);
            this.grDangNhap.Name = "grDangNhap";
            this.grDangNhap.Size = new System.Drawing.Size(393, 430);
            this.grDangNhap.TabIndex = 0;
            this.grDangNhap.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = " Đăng Nhập ";
            // 
            // bttLogin
            // 
            this.bttLogin.BackColor = System.Drawing.Color.MistyRose;
            this.bttLogin.Location = new System.Drawing.Point(73, 278);
            this.bttLogin.Name = "bttLogin";
            this.bttLogin.Size = new System.Drawing.Size(90, 52);
            this.bttLogin.TabIndex = 8;
            this.bttLogin.Text = "Đăng Nhập";
            this.bttLogin.UseVisualStyleBackColor = false;
            this.bttLogin.Click += new System.EventHandler(this.bttLogin_Click);
            // 
            // bttDangKi
            // 
            this.bttDangKi.BackColor = System.Drawing.Color.Tomato;
            this.bttDangKi.Location = new System.Drawing.Point(232, 278);
            this.bttDangKi.Name = "bttDangKi";
            this.bttDangKi.Size = new System.Drawing.Size(96, 52);
            this.bttDangKi.TabIndex = 10;
            this.bttDangKi.Text = "Đăng Ký";
            this.bttDangKi.UseVisualStyleBackColor = false;
            this.bttDangKi.Click += new System.EventHandler(this.bttDangKi_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(165, 143);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(163, 22);
            this.txtPass.TabIndex = 7;
            this.txtPass.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.BackColor = System.Drawing.Color.Transparent;
            this.lbPass.Location = new System.Drawing.Point(51, 149);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(68, 16);
            this.lbPass.TabIndex = 6;
            this.lbPass.Text = "Mật Khẩu :";
            // 
            // rGV
            // 
            this.rGV.AutoSize = true;
            this.rGV.BackColor = System.Drawing.Color.Transparent;
            this.rGV.Location = new System.Drawing.Point(170, 66);
            this.rGV.Name = "rGV";
            this.rGV.Size = new System.Drawing.Size(94, 20);
            this.rGV.TabIndex = 5;
            this.rGV.TabStop = true;
            this.rGV.Text = "Giảng Viên";
            this.rGV.UseVisualStyleBackColor = false;
            // 
            // ckGhiNho
            // 
            this.ckGhiNho.AutoSize = true;
            this.ckGhiNho.BackColor = System.Drawing.Color.Transparent;
            this.ckGhiNho.Location = new System.Drawing.Point(54, 198);
            this.ckGhiNho.Name = "ckGhiNho";
            this.ckGhiNho.Size = new System.Drawing.Size(148, 20);
            this.ckGhiNho.TabIndex = 4;
            this.ckGhiNho.Text = "Ghi Nhớ Đăng Nhập";
            this.ckGhiNho.UseVisualStyleBackColor = false;
            this.ckGhiNho.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rSV
            // 
            this.rSV.AutoSize = true;
            this.rSV.BackColor = System.Drawing.Color.Transparent;
            this.rSV.Location = new System.Drawing.Point(54, 66);
            this.rSV.Name = "rSV";
            this.rSV.Size = new System.Drawing.Size(84, 20);
            this.rSV.TabIndex = 1;
            this.rSV.TabStop = true;
            this.rSV.Text = "Sinh Viên";
            this.rSV.UseVisualStyleBackColor = false;
            this.rSV.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(165, 108);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(163, 22);
            this.txtTen.TabIndex = 3;
            this.txtTen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.BackColor = System.Drawing.Color.Transparent;
            this.lbTen.Location = new System.Drawing.Point(51, 114);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(108, 16);
            this.lbTen.TabIndex = 2;
            this.lbTen.Text = "Tên Đăng Nhập :";
            // 
            // bttThoat
            // 
            this.bttThoat.Location = new System.Drawing.Point(704, 12);
            this.bttThoat.Name = "bttThoat";
            this.bttThoat.Size = new System.Drawing.Size(66, 28);
            this.bttThoat.TabIndex = 11;
            this.bttThoat.Text = "Thoát";
            this.bttThoat.UseVisualStyleBackColor = true;
            this.bttThoat.Click += new System.EventHandler(this.bttThoat_Click);
            // 
            // lbbHead
            // 
            this.lbbHead.AutoSize = true;
            this.lbbHead.BackColor = System.Drawing.Color.Transparent;
            this.lbbHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbHead.Location = new System.Drawing.Point(293, 38);
            this.lbbHead.Name = "lbbHead";
            this.lbbHead.Size = new System.Drawing.Size(234, 32);
            this.lbbHead.TabIndex = 12;
            this.lbbHead.Text = "Thư Viện Online";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::libabry_app.Properties.Resources.book_background_fe1vlrrmvaabwo8l;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.lbbHead);
            this.Controls.Add(this.bttThoat);
            this.Controls.Add(this.grDangNhap);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.login_Load);
            this.grDangNhap.ResumeLayout(false);
            this.grDangNhap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grDangNhap;
        private System.Windows.Forms.RadioButton rSV;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.CheckBox ckGhiNho;
        private System.Windows.Forms.RadioButton rGV;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Button bttLogin;
        private System.Windows.Forms.Button bttDangKi;
        private System.Windows.Forms.Button bttThoat;
        private System.Windows.Forms.Label lbbHead;
        private System.Windows.Forms.Label label1;
    }
}

