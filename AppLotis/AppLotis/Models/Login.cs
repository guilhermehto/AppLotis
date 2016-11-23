using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Models {
    public class Login {
        public string Grant_Type = "password";
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
