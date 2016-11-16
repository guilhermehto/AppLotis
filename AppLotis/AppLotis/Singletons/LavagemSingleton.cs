using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Singletons {

    /// <summary>
    /// Utilizada apenas para a primeira lavagem do usuário, quando ele ainda não é cadastrado
    /// </summary>
    public static class LavagemSingleton {
        public static int VeiculoId { get; set; }

        public static int TipoLavagemId { get; set; }

        public static string Cidade { get; set; }

        public static string Endereco { get; set; }
        public static decimal Latitude { get; set; }
        public static decimal Longitude { get; set; }

        //TODO: REMOVER
        public static int ValorEmReais { get; set; }
    }
}
