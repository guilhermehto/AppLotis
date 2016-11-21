using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.ViewModels;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class RestUsuario {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/Account";
        private readonly string REGISTER_URL = "Register";

        public RestUsuario() {
            client = new HttpClient();
            //client.BaseAddress = new Uri(URL);
        }

        public async Task<UsuarioDto> RegistrarNovoUsuario(RegistrarUsuarioViewModel usuario) {
            try {
                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var resposta = await client.PostAsync("http://webslave.azurewebsites.net/api/Account/Register", content);
                var respostaContent = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode) {
                    UsuarioDto novoUsuario = JsonConvert.DeserializeObject<UsuarioDto>(respostaContent);
                    return novoUsuario;

                }
                return null;
            } catch (Exception e) {
                return null;
            }   
        } 
    }
}
