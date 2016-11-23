using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Models;
using AppLotis.Rest;
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
                var page = new IndexPage();
                Application.Current.MainPage = page;
            } else {
                await DisplayAlert("Erro", "Deu errado", "Ok");
            }

            
        }
    }
}
