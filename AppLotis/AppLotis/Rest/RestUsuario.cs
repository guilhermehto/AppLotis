﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Models;
using AppLotis.Singletons;
using AppLotis.ViewModels;
using Newtonsoft.Json;

namespace AppLotis.Rest {
    class RestUsuario {
        private HttpClient client;
        private readonly string URL = "http://webslave.azurewebsites.net/api/Account";
        private readonly string REGISTER_URL = "Register";
        private readonly string LOGIN_URL = "http://webslave.azurewebsites.net/token";
        private readonly string MEU_ID_URL = "http://webslave.azurewebsites.net/api/account/meuid";


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

        public async Task<Token> Logar(Login model) {
           var tokenModel = new Dictionary<string,string>() {
               {"grant_type", "password" },
               {"username", model.Username },
               {"password", model.Password },
           };
            var resposta = await client.PostAsync(LOGIN_URL, new FormUrlEncodedContent(tokenModel));
            var respostaConteudo = await resposta.Content.ReadAsStringAsync();
            if (resposta.IsSuccessStatusCode) {
                var token = JsonConvert.DeserializeObject<Token>(respostaConteudo);
                return token;
            }
            return null;
        }

        public async Task<string> GetMeuId() {
            try {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                client.DefaultRequestHeaders.Add(AuthHelper.AuthorizationType, AuthHelper.MakeBearer(TokenSingleton.Token));
                var resposta = await client.GetAsync(MEU_ID_URL);
                if (resposta.IsSuccessStatusCode) {
                    var conteudo = resposta.Content.ReadAsStringAsync().Result;
                    var conteudoNovo = conteudo.Replace("\"", "");
                    return conteudoNovo;
                }

            } catch (Exception e) {
                return null;
            }

            return null;
        }
    }
}
