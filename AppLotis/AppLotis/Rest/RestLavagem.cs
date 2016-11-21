using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Rest {
    public class RestLavagem {
        HttpClient client;
        private readonly string URL = "webslave.azurewebsites.net/api/lavagens/criar";


        public RestLavagem() {
            client = new HttpClient();
        }

        public async Task<LavagemDto> PostLavagem(LavagemDto lavagem) {
            
        }


    }
}
