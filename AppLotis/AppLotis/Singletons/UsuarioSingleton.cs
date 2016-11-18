using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Singletons {
    public static class UsuarioSingleton {

        public static string Nome { get; set; }
        public static string Senha { get; set; }
        public static string Email { get; set; }
        public static string Telefone { get; set; }
    }
}
