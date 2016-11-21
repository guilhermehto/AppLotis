using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Singletons;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class PagamentoPage : ContentPage {
        public PagamentoPage() {
            InitializeComponent();
            LabelValor.Text = "Preço total: R$" + LavagemSingleton.ValorEmReais + ",00";
        }

        private async void OnBtnContinuarClicked(object sender, EventArgs e) {
            bool erro = false;
            foreach (Entry child in StackPrincipal.Children.Where(x => x.GetType() == typeof(Entry))) {
                if (String.IsNullOrEmpty(child.Text)) {
                    child.PlaceholderColor = Color.Red;
                    child.Placeholder = "Preencher";
                    erro = true;
                }
            }
            if (erro) {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos marcados em vermelho.", "Ok");
                return;
            }

            UsuarioSingleton.Nome = EntryNome.Text;
            UsuarioSingleton.Telefone = EntryTelefone.Text;
            LavagemSingleton.LocalDeRecebimento = EntryLocalDePagamento.Text;
            LavagemSingleton.TrocoEmReais = float.Parse(EntryTroco.Text);
            await Navigation.PushModalAsync(new CadastrarPage());
        }
    }
}
