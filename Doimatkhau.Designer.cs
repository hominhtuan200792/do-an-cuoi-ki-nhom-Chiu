namespace libabry_app
{
    partial class Doimatkhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matkhauhientai_textbox = new System.Windows.Forms.TextBox();
            this.nhapmatkhaumoi_textbox = new System.Windows.Forms.TextBox();
            this.nhaplaimatkhau_textbox = new System.Windows.Forms.TextBox();
            this.doimatkhau_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thay đổi thông tin đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập mật khẩu hiện tại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập mật khẩu mới:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // matkhauhientai_textbox
            // 
            this.matkhauhientai_textbox.Location = new System.Drawing.Point(262, 176);
            this.matkhauhientai_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.matkhauhientai_textbox.Name = "matkhauhientai_textbox";
            this.matkhauhientai_textbox.Size = new System.Drawing.Size(213, 26);
            this.matkhauhientai_textbox.TabIndex = 4;
            this.matkhauhientai_textbox.TextChanged += new System.EventHandler(this.matkhauhientai_TextChanged);
            // 
            // nhapmatkhaumoi_textbox
            // 
            this.nhapmatkhaumoi_textbox.Location = new System.Drawing.Point(262, 251);
            this.nhapmatkhaumoi_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhapmatkhaumoi_textbox.Name = "nhapmatkhaumoi_textbox";
            this.nhapmatkhaumoi_textbox.Size = new System.Drawing.Size(213, 26);
            this.nhapmatkhaumoi_textbox.TabIndex = 5;
            // 
            // nhaplaimatkhau_textbox
            // 
            this.nhaplaimatkhau_textbox.Location = new System.Drawing.Point(262, 329);
            this.nhaplaimatkhau_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhaplaimatkhau_textbox.Name = "nhaplaimatkhau_textbox";
            this.nhaplaimatkhau_textbox.Size = new System.Drawing.Size(213, 26);
            this.nhaplaimatkhau_textbox.TabIndex = 6;
            // 
            // doimatkhau_button
            // 
            this.doimatkhau_button.BackColor = System.Drawing.Color.LightCoral;
            this.doimatkhau_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.doimatkhau_button.Location = new System.Drawing.Point(603, 370);
            this.doimatkhau_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doimatkhau_button.Name = "doimatkhau_button";
            this.doimatkhau_button.Size = new System.Drawing.Size(122, 52);
            this.doimatkhau_button.TabIndex = 7;
            this.doimatkhau_button.Text = "Đổi mật khẩu";
            this.doimatkhau_button.UseVisualStyleBackColor = false;
            this.doimatkhau_button.Click += new System.EventHandler(this.doimatkhau_button_Click);
            // 
            // Doimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.doimatkhau_button);
            this.Controls.Add(this.nhaplaimatkhau_textbox);
            this.Controls.Add(this.nhapmatkhaumoi_textbox);
            this.Controls.Add(this.matkhauhientai_textbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Doimatkhau";
            this.Text = "Doimatkhau";
            this.Load += new System.EventHandler(this.Doimatkhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox matkhauhientai_textbox;
        private System.Windows.Forms.TextBox nhapmatkhaumoi_textbox;
        private System.Windows.Forms.TextBox nhaplaimatkhau_textbox;
        private System.Windows.Forms.Button doimatkhau_button;
    }
}