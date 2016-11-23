using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Database;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class ConfiguracoesPage : ContentPage {
        public ConfiguracoesPage() {
            InitializeComponent();
        }

        private void OnSairClicked(object sender, EventArgs e) {
            var dbToken = new TokenDatabase();
            var token = dbToken.GetToken();
            //TODO: Remover ID
            var id = dbToken.DeleteToken(token.Id);
            DisplayAlert("Token", id.ToString(), "Ok");
            Application.Current.MainPage = new MainPage();
        }
    }
}
