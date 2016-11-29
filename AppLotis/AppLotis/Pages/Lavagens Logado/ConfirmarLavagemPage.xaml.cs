using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Xamarin.Forms;

namespace AppLotis.Pages.Lavagens_Logado {
    public partial class ConfirmarLavagemPage : ContentPage {
        private LavagemDto _lavagem;
        public ConfirmarLavagemPage() {
            InitializeComponent();
        }

        public ConfirmarLavagemPage(LavagemDto lavagem) {
            InitializeComponent();
            _lavagem = lavagem;
        }

        protected override async void OnAppearing() {
            LabelEndereco.Text = _lavagem.Endereco;
            LabelPlaca.Text = "TODO";
            LabelPrecoTotal.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
            LabelTroco.Text = "Troco para: R$" + _lavagem.TrocoEmReais + ".00";
            LabelEndereco.Text = _lavagem.Endereco;
        }
        private async void OnBtnConfirmarClicked(object sender, EventArgs e) {
            await DisplayAlert("Err", "Confirmar", "ok");
        }

        private async void OnBtnCancelarClicked(object sender, EventArgs e) {
            await DisplayAlert("Err", "Cancelar", "ok");
        }
    }
}
