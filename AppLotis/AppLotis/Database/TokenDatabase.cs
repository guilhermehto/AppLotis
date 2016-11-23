using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Interfaces;
using AppLotis.Models;
using SQLite;
using Xamarin.Forms;

namespace AppLotis.Database {
    public class TokenDatabase {
        private static object locker = new object();
        private SQLiteConnection db;
        public TokenDatabase() {
            db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<Token>();
        }

        public int AddToken(Token token) {
            lock (locker) {
                if (token.Id == 0) {
                    return db.Insert(token);

                }
                db.Update(token);
                return token.Id;
            }
        }

        public bool TokenExists() {
            lock (locker) {
                var tokens = db.Table<Token>().FirstOrDefault();
                if (tokens != null) {
                    return true;
                }

                return false;
            }
        }

        public Token GetToken() {
            lock (locker) {
                return db.Table<Token>().FirstOrDefault();
            }
        }

        public int DeleteToken(int id) {
            lock (locker) {
                return db.Delete<Token>(id);
            }
        }

    }
}
