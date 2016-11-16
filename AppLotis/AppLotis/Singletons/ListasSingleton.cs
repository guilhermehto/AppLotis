using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;

namespace AppLotis.Singletons {
    public static class ListasSingleton {
        public static IEnumerable<TipoLavagemDto> TipoLavagens { get; set; }
        public static IEnumerable<AdicionalDto> Adicionais { get; set; }
    }
}
