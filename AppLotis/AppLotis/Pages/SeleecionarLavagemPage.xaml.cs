using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.ViewModels;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class SeleecionarLavagemPage : ContentPage {
        private ObservableCollection<AdicionaisViewModel> adicionados;
        public SeleecionarLavagemPage() {
            InitializeComponent();
            adicionados = new ObservableCollection<AdicionaisViewModel>();
            ListViewAdicionais.ItemsSource = adicionados;
            SpinnerAdicionais.SelectedIndex = 0;
            SpinnerLavagens.SelectedIndex = 0;
        }

        private void OnAdicionarClicked(object sender, EventArgs e) {
            var selecionadoIndex = SpinnerAdicionais.SelectedIndex;
            var selecionado = SpinnerAdicionais.Items[selecionadoIndex];
            var selecionadoAdd = new AdicionaisViewModel {
                Adicional = selecionado,
                Valor = "R$10,00"
            };
            bool possuiIgual = false;
            foreach (var a in adicionados) {
                if (a.Adicional == selecionadoAdd.Adicional) {
                    possuiIgual = true;
                    break;
                }
            }
            if (!possuiIgual) {
                adicionados.Add(selecionadoAdd);
            }
        }

        private void OnRemoverClicked(object sender, EventArgs e) {
            var _sender = ((Button) sender);
            var parent = (StackLayout) _sender.Parent;
            var adicional = (Label) parent.Children.FirstOrDefault(x => x.GetType() == typeof(Label));
            int index = 0;
            foreach (var a in adicionados) {
                if (a.Adicional == adicional.Text) {
                    adicionados.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        async void OnContinuarClicked(object sender, EventArgs e) {
            await Navigation.PushModalAsync(new AgendamentoPage());
        }
    }
}
