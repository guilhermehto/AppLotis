using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLotis.ViewModels;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class UsuarioRest {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/Account";
        private readonly string REGISTER_URL = "Register";

        public UsuarioRest() {
            client = new HttpClient();
            //client.BaseAddress = new Uri(URL);
        }

        public async Task<bool> RegistrarNovoUsuario(RegistrarUsuarioViewModel usuario) {
            try {
                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var resposta = await client.PostAsync("http://webslave.azurewebsites.net/api/Account/Register", content);
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
