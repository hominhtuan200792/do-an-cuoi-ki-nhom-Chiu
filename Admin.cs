using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libabry_app
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Text = "Quản trị - Thư viện online";

            // Các nút Designer CHƯA nối -> nối bằng code
            quanlyuser_button.Click += (o, e) => TienIch.MoModal(this, new Quanlyuser());
            quanlytienphat_button.Click += (o, e) => TienIch.MoModal(this, new Quanlytienphat());
            thongkekhosach_button.Click += (o, e) => TienIch.MoModal(this, new Thongke());
            chinhsua_button.Click += chinhsua_button_Click;
            thoat_button.Click += (o, e) => Close();
        }

        // Đã nối sẵn trong Designer
        private void quanlynhomquyen_button_Click(object sender, EventArgs e)
        {
            TienIch.MoModal(this, new Quanlynhomquyen());
        }

        // "Chỉnh sửa" = mở form quản lý sách (chinhsua). Form đó cần 1 đối tượng trangchu
        // để làm mới danh sách thẻ sách, nên tạo trangchu ẩn rồi truyền vào.
        private void chinhsua_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            trangchu tc = new trangchu();
            tc.LamMoiDanhSach();   // nạp DuLieu.DanhSachSach (hàm này đã có sẵn trong trangchu)
            using (chinhsua f = new chinhsua(tc))
            {
                f.ShowDialog();
            }
            this.Show();
        }

        private void quanlyuser_button_Click(object sender, EventArgs e)
        {

        }

        private void thongkekhosach_button_Click(object sender, EventArgs e)
        {

        }
    }
}
