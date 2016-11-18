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
        }

        private async void OnBtnContinuarClicked(object sender, EventArgs e) {
            UsuarioSingleton.Nome = EntryNome.Text;
            UsuarioSingleton.Telefone = EntryTelefone.Text;
            LavagemSingleton.LocalDeRecebimento = EntryLocalDePagamento.Text;
            LavagemSingleton.TrocoEmReais = float.Parse(EntryTroco.Text);
            await Navigation.PushModalAsync(new CadastrarPage());
        }
    }
}
