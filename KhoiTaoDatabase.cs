using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace libabry_app
{
    public static class KhoiTaoDatabase
    {
        public const string TEN_DB = "library_app";

        // Thử lần lượt các server thường gặp
        private static readonly string[] DsServer =
        {
            @".\SQLEXPRESS",
            @"(localdb)\MSSQLLocalDB",
            @".",
            @".\SQLEXPRESS01"
        };

        public static string Server { get; private set; }

        public static string ChuoiKetNoi(string server, string db)
        {
            return "Data Source=" + server + ";Initial Catalog=" + db +
                   ";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;";
        }

        public static string ChuoiKetNoiApp()
        {
            return ChuoiKetNoi(Server, TEN_DB);
        }

        // Chuỗi kết nối dành cho Entity Framework (Database First)
        public static string EntityConnectionString
        {
            get
            {
                return "metadata=res://*/LibraryModel.csdl|res://*/LibraryModel.ssdl|res://*/LibraryModel.msl;" +
                       "provider=System.Data.SqlClient;provider connection string=\"" +
                       ChuoiKetNoiApp() + "MultipleActiveResultSets=True;\"";
            }
        }

        public static void DamBaoCoDatabase()
        {
            Database.SetInitializer<DbContext>(null);

            Server = TimServer();
            if (Server == null)
                throw new Exception("Không tìm thấy SQL Server trên máy này.\n" +
                                    "Hãy cài SQL Server Express hoặc LocalDB và bật dịch vụ.");

            if (Database.Exists(ChuoiKetNoiApp()))
                return;

            try
            {
                using (var master = new DbContext(ChuoiKetNoi(Server, "master")))
                {
                    master.Database.ExecuteSqlCommand(
                        TransactionalBehavior.DoNotEnsureTransaction,
                        "CREATE DATABASE [" + TEN_DB + "]");
                }

                using (var db = new DbContext(ChuoiKetNoiApp()))
                {
                    ChayScript(db);
                }
            }
            catch
            {
                // Tạo dở thì xóa đi để lần mở sau tạo lại từ đầu
                try
                {
                    using (var master = new DbContext(ChuoiKetNoi(Server, "master")))
                    {
                        master.Database.ExecuteSqlCommand(
                            TransactionalBehavior.DoNotEnsureTransaction,
                            "DROP DATABASE [" + TEN_DB + "]");
                    }
                }
                catch { }
                throw;
            }
        }

        private static string TimServer()
        {
            foreach (string s in DsServer)
            {
                try
                {
                    using (var ctx = new DbContext(ChuoiKetNoi(s, "master")))
                    {
                        ctx.Database.Connection.Open();
                        return s;
                    }
                }
                catch { }
            }
            return null;
        }

        private static void ChayScript(DbContext db)
        {
            var asm = Assembly.GetExecutingAssembly();
            string ten = asm.GetManifestResourceNames()
                            .FirstOrDefault(n => n.EndsWith("library_app.sql"));
            if (ten == null)
                throw new Exception("Thiếu file script library_app.sql (Embedded Resource).");

            string sql;
            using (var rd = new StreamReader(asm.GetManifestResourceStream(ten),
                                             System.Text.Encoding.UTF8))
                sql = rd.ReadToEnd();

            // Tách theo dòng chỉ có chữ GO
            string[] cacLenh = Regex.Split(sql, @"^\s*GO\s*$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase);

            foreach (string lenh in cacLenh)
            {
                string l = lenh.Trim();
                if (l.Length == 0 || l.StartsWith("USE ", StringComparison.OrdinalIgnoreCase))
                    continue;

                db.Database.ExecuteSqlCommand(
                    TransactionalBehavior.DoNotEnsureTransaction, l);
            }
        }
    }
}