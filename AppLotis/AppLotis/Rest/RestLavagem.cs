using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Singletons;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    public class RestLavagem {
        HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/lavagens";
        private readonly string CRIAR_URL = "http://webslave.azurewebsites.net/api/lavagens/criar";
        private readonly string MINHAS_LAVAGENS_URL = "http://webslave.azurewebsites.net/api/lavagens/minhas";

        public RestLavagem() {
            client = new HttpClient();
        }

        public async Task<string> PostLavagem(LavagemDto lavagem) {
            //try {
                var json = JsonConvert.SerializeObject(lavagem);
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
                var resposta = await client.PostAsync(CRIAR_URL, conteudo);
                var respostaConteudo = await resposta.Content.ReadAsStringAsync();
                if (resposta.IsSuccessStatusCode) {
                    return respostaConteudo;
                    //return JsonConvert.DeserializeObject<LavagemDto>(respostaConteudo);
                }
                return respostaConteudo;
            /*} catch (Exception e) {
                return "Exception " + e.InnerException;  
            }*/
        }

        public async Task<IEnumerable<LavagemDto>> LoadLavagens() {
            var lavagens = new List<LavagemDto>();
            try {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenSingleton.Token);
                var resposta = await client.GetAsync(MINHAS_LAVAGENS_URL);
                if (resposta.IsSuccessStatusCode) {
                    var conteudo = await resposta.Content.ReadAsStringAsync();
                    lavagens = JsonConvert.DeserializeObject<List<LavagemDto>>(conteudo);
                    return lavagens;
                }
            } catch (Exception e) {
                return null;
            }

            return null;
        }


    }
}
