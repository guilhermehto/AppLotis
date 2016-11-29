using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Helpers;
using AppLotis.Singletons;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class PagamentoPage : ContentPage {
        public PagamentoPage() {
            InitializeComponent();
            LabelValor.Text = "Preço total: R$" + LavagemSingleton.ValorEmReais + ",00";
        }

        private async void OnBtnContinuarClicked(object sender, EventArgs e) {
            bool correto = true;
            foreach (Entry child in StackPrincipal.Children.Where(x => x.GetType() == typeof(Entry))) {
                if (correto) {
                    correto = VerificarLocalPagamento();
                } else {
                    VerificarLocalPagamento();
                }

                if (correto) {
                    correto = VerificarTelefoneValido();
                } else {
                    VerificarTelefoneValido();
                }

                if (correto) {
                    correto = VerificarNomeValido();
                } else {
                    VerificarNomeValido();
                }
            }
            if (!correto) {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos marcados em vermelho.", "Ok");
                return;
            }

            UsuarioSingleton.Nome = EntryNome.Text;
            UsuarioSingleton.Telefone = EntryTelefone.Text;
            LavagemSingleton.LocalDeRecebimento = EntryLocalDePagamento.Text;
            LavagemSingleton.TrocoEmReais = EntryTroco.Text == null ? 0f : float.Parse(EntryTroco.Text);
            await Navigation.PushModalAsync(new CadastrarPage());
        }


        private bool VerificarTelefoneValido() {
            var telefone = EntryTelefone.Text ?? "";
            if (telefone.Length < 8) {
                EntryTelefone.PlaceholderColor = Color.Red;
                EntryTelefone.Placeholder = MensagensErro.TELEFONE_INVALIDO;
                return false;
            }

            return true;
        }

        private bool VerificarNomeValido() {
            var nome = EntryNome.Text ?? "";
            if (String.IsNullOrEmpty(nome)) {
                EntryNome.PlaceholderColor = Color.Red;
                EntryNome.Placeholder = MensagensErro.NOME_EM_BRANCO;
                return false;
            }

            if (nome.Length < 6) {
                EntryNome.PlaceholderColor = Color.Red;
                EntryNome.Placeholder = MensagensErro.NOME_INVALIDO;
                return false;
            }

            return true;
        }

        private bool VerificarLocalPagamento() {
            var nome = EntryLocalDePagamento.Text ?? "";
            if (String.IsNullOrEmpty(nome)) {
                EntryLocalDePagamento.PlaceholderColor = Color.Red;
                EntryLocalDePagamento.Placeholder = MensagensErro.LOCAL_DE_PAGAMENTO_BRANCO;
                return false;
            }

            return true;
        }

    }
}
