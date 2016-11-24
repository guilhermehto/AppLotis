using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Database;
using AppLotis.Models;
using AppLotis.Rest;
using AppLotis.Singletons;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private async void OnEntrarClicked(object sender, EventArgs e) {
            var usuario = EntryEmail.Text;
            var senha = EntrySenha.Text;
            var model = new Login {
                Password = senha,
                Username = usuario,
            };
            var apiUsuario = new RestUsuario();
            var resultadoLogin = await apiUsuario.Logar(model);
            
            if (resultadoLogin != null) {
                var dbToken = new TokenDatabase();
                dbToken.AddToken(resultadoLogin);
                TokenSingleton.Token = resultadoLogin.AccessToken;
                var page = new IndexPage();
                Application.Current.MainPage = page;
            } else {
                await DisplayAlert("Erro", "Deu errado", "Ok");
            }

            
        }
    }
}
