using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Pages.Lavagens_Logado;
using AppLotis.Rest;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class LavagensPage : ContentPage {
        public LavagensPage() {
            InitializeComponent();
        }


        protected override async void OnAppearing() {
            var apiLavagens = new RestLavagem();
            var lavagens = await apiLavagens.LoadLavagens();
            ListLavagens.ItemsSource = lavagens;
        }

        private async void OnNovaLavagemClicked(object sender, EventArgs e) {
            await Navigation.PushModalAsync(new SelecionarLavagemEVeiculoPage());

        }
    }
}
