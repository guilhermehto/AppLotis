using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Rest;
using Xamarin.Forms;

namespace AppLotis.Pages.Lavagens_Logado {
    public partial class PagamentoLogadoPage : ContentPage {
        private LavagemDto _lavagem;

        public PagamentoLogadoPage() {
            InitializeComponent();
        }

        public PagamentoLogadoPage(LavagemDto lavagem) {
            InitializeComponent();
            _lavagem = lavagem;
        }

        protected override async void OnAppearing() {
            LabelValor.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
        }

        private async void OnBtnConfirmarClicked(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(EntryLocalDePagamento.Text) ||
                String.IsNullOrWhiteSpace(EntryLocalDePagamento.Text)) {
                await DisplayAlert("Erro", MensagensErro.LOCAL_DE_PAGAMENTO_BRANCO, "Ok");
                return;
            }

            var apiUsuario = new RestUsuario();
            var meuid = await apiUsuario.GetMeuId();
            if (meuid != null) {
                _lavagem.LocalDeRecebimento = EntryLocalDePagamento.Text;
                _lavagem.UsuarioId = meuid;
                _lavagem.Cidade = "Santa Cruz do Sul";
                var apiLavagem = new RestLavagem();
                var resultado = await apiLavagem.PostLavagem(_lavagem);
                await DisplayAlert("Sucesso", MensagensSucesso.LAVAGEM_CADASTRADA, "Ok");
                var page = new IndexPage();
                Application.Current.MainPage = page;
            } else {
                await DisplayAlert("Erro", MensagensErro.ERRO_REST, "ok");
            }

        }
    }
}
