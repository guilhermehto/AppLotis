using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Database;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Models;
using AppLotis.Rest;
using AppLotis.Singletons;
using AppLotis.ViewModels;
using Xamarin.Forms;
using static AppLotis.App;

namespace AppLotis.Pages {
    public partial class CadastrarPage : ContentPage {
        public CadastrarPage() {
            InitializeComponent();
        }

        private async void OnBtnFinalizarClicked(object sender, EventArgs e) {
            if (EntryConfirmarSenha.Text != EntrySenha.Text) {
                await DisplayAlert("Erro", MensagensErro.SENHA_CONFIRMACAO_ERRADA, "Ok");
                EntryConfirmarSenha.TextColor = Color.Red;
                EntrySenha.TextColor = Color.Red;
                return;
            }
            UsuarioSingleton.Senha = EntrySenha.Text;
            UsuarioSingleton.Email = EntryEmail.Text;
            var apiUsuario = new RestUsuario();
            var model = new RegistrarUsuarioViewModel() {
                Nome = UsuarioSingleton.Nome,
                Funcao = "Usuario",
                Email = UsuarioSingleton.Email,
                Password = UsuarioSingleton.Senha,
                ConfirmPassword = UsuarioSingleton.Senha
            };

            
            var resultadoUsuario = await apiUsuario.RegistrarNovoUsuario(model);

            var apiVeiculo = new RestVeiculo();
            var modelVeiculo = new VeiculoDto() {
                Placa = VeiculoSingleton.Placa,
                Cor = VeiculoSingleton.Cor,
                Marca = VeiculoSingleton.Marca,
                Modelo = VeiculoSingleton.Modelo,
                UsuarioId = resultadoUsuario.Id
            };

            var resultadoVeiculo = await apiVeiculo.PostVeiculo(modelVeiculo);

            var apiLavagem = new RestLavagem();

            //TODO: Pegar a cidade dinamicamente
            var modelLavagem = new LavagemDto() {
                ValorEmReais = LavagemSingleton.ValorEmReais,
                Longitude = LavagemSingleton.Longitude,
                Latitude = LavagemSingleton.Latitude,
                Cidade = "Santa Cruz do Sul",
                DiaHorario = LavagemSingleton.DiaHorario,
                Endereco = LavagemSingleton.Endereco,
                LocalDeRecebimento = LavagemSingleton.LocalDeRecebimento,
                TipoLavagemId = LavagemSingleton.TipoLavagemId,
                TrocoEmReais = LavagemSingleton.TrocoEmReais,
                UsuarioId = resultadoUsuario.Id,
                VeiculoId = resultadoVeiculo.Id,
                Adicionais = LavagemSingleton.Adicionais
            };
            var resultadoLavagem = await apiLavagem.PostLavagem(modelLavagem);

            await DisplayAlert("Erro", resultadoLavagem, "Ok");


            //TODO: Melhorar essas verificações
            if (resultadoUsuario.Id != null && resultadoVeiculo.Cor != null && resultadoLavagem != null) {
                var resultadoLogin = await apiUsuario.Logar(new Login() {
                    Password = UsuarioSingleton.Senha,
                    Username = UsuarioSingleton.Email
                });

                if (resultadoLogin != null) {
                    var dbToken = new TokenDatabase();
                    dbToken.AddToken(resultadoLogin);
                    TokenSingleton.Token = resultadoLogin.AccessToken;
                    var page = new IndexPage();
                    Application.Current.MainPage = page;
                }
            } else {
                await DisplayAlert("Erro", resultadoLavagem, "Ok");
            }

            
        }
    }
}
