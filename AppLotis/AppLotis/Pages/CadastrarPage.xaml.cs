using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
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
            var apiUsuario = new UsuarioRest();
            var model = new RegistrarUsuarioViewModel() {
                Nome = UsuarioSingleton.Nome,
                Funcao = "Usuario",
                Email = UsuarioSingleton.Email,
                Password = UsuarioSingleton.Senha,
                ConfirmPassword = UsuarioSingleton.Senha
            };

            var apiVeiculo = new RestVeiculo();
            var modelVeiculo = new VeiculoDto() {
                Placa = VeiculoSingleton.Placa,
                Cor = VeiculoSingleton.Cor,
                Marca = VeiculoSingleton.Marca,
                Modelo = VeiculoSingleton.Modelo
            };

            /*var resultadoVeiculo = await apiVeiculo.PostVeiculo(modelVeiculo);

            var resultadoUsuario = await apiUsuario.RegistrarNovoUsuario(model);
            if (resultadoUsuario && resultadoVeiculo) {
                await Navigation.PushModalAsync(new IndexPage());
            } else {
                await DisplayAlert("Deu", "Errado", "Povo");
            }*/

            var page = new IndexPage();
            Application.Current.MainPage = page;
        }
    }
}
