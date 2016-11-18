using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.ViewModels {
    class RegistrarUsuarioViewModel {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
    }
}
