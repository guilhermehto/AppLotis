using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Helpers;
using AppLotis.Rest;
using AppLotis.Singletons;
using AppLotis.ViewModels;
using Xamarin.Forms;

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
            var api = new UsuarioRest();
            var model = new RegistrarUsuarioViewModel() {
                Nome = UsuarioSingleton.Nome,
                Funcao = "Usuario",
                Email = UsuarioSingleton.Email,
                Password = UsuarioSingleton.Senha,
                ConfirmPassword = UsuarioSingleton.Senha
            };

            var resultado = await api.RegistrarNovoUsuario(model);
            if (resultado) {
                await DisplayAlert("Deu", "Certo", "Povo");
            } else {
                await DisplayAlert("Deu", resultado.ToString(), "Povo");
            }


            //Navigation.PushModalAsync(new IndexPage());
        }
    }
}
