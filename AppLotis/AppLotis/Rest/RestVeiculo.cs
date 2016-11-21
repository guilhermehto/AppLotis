using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    public class RestVeiculo {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net";
        private readonly string CRIAR_URL = "http://webslave.azurewebsites.net/api/veiculos/criar";

        public RestVeiculo() {
            client = new HttpClient();
        }

        public async Task<bool> PostVeiculo(VeiculoDto veiculo) {
            try {
                var json = JsonConvert.SerializeObject(veiculo);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
                var resposta = await client.PostAsync(CRIAR_URL, conteudo);
                if (resposta.IsSuccessStatusCode) {
                    return true;
                }
                return false;
            } catch (Exception e) {
                return false;
            }
        }
    }
}
