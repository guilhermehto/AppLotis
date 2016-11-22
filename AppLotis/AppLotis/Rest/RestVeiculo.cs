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

        public async Task<VeiculoDto> PostVeiculo(VeiculoDto veiculo) {
            try {
                var json = JsonConvert.SerializeObject(veiculo);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
                var resposta = await client.PostAsync(CRIAR_URL, conteudo);
                var respostaConteudo = await resposta.Content.ReadAsStringAsync();
                if (resposta.IsSuccessStatusCode) {
                    return JsonConvert.DeserializeObject<VeiculoDto>(respostaConteudo);
                }
                return null;
            } catch (Exception e) {
                return null;
            }
        }
    }
}
