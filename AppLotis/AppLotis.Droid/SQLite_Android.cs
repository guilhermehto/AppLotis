using System;
using System.IO;
using AppLotis.Droid;
using AppLotis.Interfaces;
using SQLite;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLite_Android))]
namespace AppLotis.Droid {
    public class SQLite_Android : ISQLite {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConnection() {
            SQLitePCL.Batteries.Init();
            var sqlNomeDb = "TokenDatabase.db3";
            string caminhoDocumento = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var caminho = Path.Combine(caminhoDocumento, sqlNomeDb);
            var conn = new SQLite.SQLiteConnection(caminho);
            return conn;
        }

    }
}