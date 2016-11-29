using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Helpers {
    public class AuthHelper {

        public static readonly string AuthorizationType = "Authorization";
        public static string MakeBearer(string token) {
            return "Bearer " + token;
        }

        
    }
}
