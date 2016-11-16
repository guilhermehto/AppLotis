using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class RestTipoLavagem {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/TipoLavagens/";

        public RestTipoLavagem() {
            client = new HttpClient();
        }

        public async Task<List<TipoLavagemDto>> LoadTipos() {
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var adicionais = JsonConvert.DeserializeObject<List<TipoLavagemDto>>(content);
                return adicionais;
            }

            return null;
        }
    }
}

