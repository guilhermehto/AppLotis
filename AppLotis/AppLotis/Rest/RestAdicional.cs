using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class RestAdicional {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/Adicionais/";

        public RestAdicional() {
            client = new HttpClient();   
        }


        public async Task<List<AdicionalDto>> LoadAdicionais() {
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var adicionais = JsonConvert.DeserializeObject<List<AdicionalDto>>(content);
                return adicionais;
            }

            return null;
        }
    }
}
