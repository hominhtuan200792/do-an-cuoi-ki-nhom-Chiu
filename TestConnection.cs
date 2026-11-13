
using System;
using System.Windows.Forms;
using libabry_app.Data;

public class TestConnection
{
    public static void KiemTraKetNoi()
    {
        try
        {
            using (var db = new library_appEntities())
            {
                db.Database.Connection.Open();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "LỖI KẾT NỐI:\n\n" + ex.Message,
                "Kiểm tra kết nối",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
