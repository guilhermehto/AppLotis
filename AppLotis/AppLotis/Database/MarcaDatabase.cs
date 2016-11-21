using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Interfaces;
using Xamarin.Forms;

namespace AppLotis.Database {
    //TODO
    public class MarcaDatabase {
        public MarcaDatabase() {
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<MarcaDto>();
        }
    }
}
