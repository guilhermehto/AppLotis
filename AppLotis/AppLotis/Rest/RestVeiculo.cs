using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Singletons;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    public class RestVeiculo {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net";
        private readonly string CRIAR_URL = "http://webslave.azurewebsites.net/api/veiculos/criar";
        private readonly string GET_VEICULOS_URL = "http://webslave.azurewebsites.net/api/veiculos/meus";

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

        public async Task<List<VeiculoDto>> LoadVeiculos() {
            var veiculos = new List<VeiculoDto>();
            try {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add(AuthHelper.AuthorizationType, AuthHelper.MakeBearer(TokenSingleton.Token));
                var resposta = await client.GetAsync(GET_VEICULOS_URL);
                if (resposta.IsSuccessStatusCode) {
                    var conteudo = await resposta.Content.ReadAsStringAsync();
                    veiculos = JsonConvert.DeserializeObject<List<VeiculoDto>>(conteudo);
                    return veiculos;
                }
            } catch (Exception e) {
                return null;
            }
            return null;
        }
    }
}
