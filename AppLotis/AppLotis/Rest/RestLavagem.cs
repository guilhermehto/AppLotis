using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    public class RestLavagem {
        HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/lavagens";
        private readonly string CRIAR_URL = "http://webslave.azurewebsites.net/api/lavagens/criar";


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


    }
}
