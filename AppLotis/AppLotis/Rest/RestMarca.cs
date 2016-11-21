using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class RestMarca {
        private HttpClient client;
        private string URL = "http://webslave.azurewebsites.net/api/marcas";

        public async Task<IEnumerable<MarcaDto>> LoadMarcas() {
            try {
                var resposta = await client.GetAsync(URL);
                if (resposta.IsSuccessStatusCode) {
                    var conteudo = await resposta.Content.ReadAsStringAsync();
                    var marcas = JsonConvert.DeserializeObject<List<MarcaDto>>(conteudo);
                    return marcas;
                }
            } catch (Exception e) {
                return null;
            }

            return null;
        }





    }
}
