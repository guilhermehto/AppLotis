using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class ConfiguracoesPage : ContentPage {
        public ConfiguracoesPage() {
            InitializeComponent();
        }

        private void OnSairClicked(object sender, EventArgs e) {
            //TODO: Deslogar da API e remover da base de dados
            Application.Current.MainPage = new MainPage();
        }
    }
}
