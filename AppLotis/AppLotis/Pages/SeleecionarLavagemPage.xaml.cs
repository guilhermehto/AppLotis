using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Singletons;
using AppLotis.ViewModels;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class SeleecionarLavagemPage : ContentPage {
        private ObservableCollection<AdicionalDto> adicionados;
        public SeleecionarLavagemPage() {
            InitializeComponent();
            adicionados = new ObservableCollection<AdicionalDto>();
            ListViewAdicionais.ItemsSource = adicionados;
            foreach (var adicional in ListasSingleton.Adicionais) {
                PickerAdicionais.Items.Add(adicional.Nome);
            }

            foreach (var tipo in ListasSingleton.TipoLavagens) {
                PickerLavagens.Items.Add(tipo.Nome);
            }
            PickerAdicionais.SelectedIndex = 0;
            PickerLavagens.SelectedIndex = 0;
            PickerLavagens.SelectedIndexChanged += OnLavagensSelectedChanged;
            LabelDescricao.Text = ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Descricao;
            LabelValorTotal.Text = "Valor total: R$" +
                                   ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais +
                                   ",00";
        }

        private void OnAdicionarClicked(object sender, EventArgs e) {
            var selecionadoIndex = PickerAdicionais.SelectedIndex;
            var selecionadoAdd = ListasSingleton.Adicionais.ElementAt(selecionadoIndex);
            bool possuiIgual = false;
            foreach (var a in adicionados) {
                if (a.Nome == selecionadoAdd.Nome) {
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
                if (a.Nome == adicional.Text) {
                    adicionados.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        async void OnContinuarClicked(object sender, EventArgs e) {
            await Navigation.PushModalAsync(new AgendamentoPage());
        }

        private void OnLavagensSelectedChanged(object sender, EventArgs e) {
            LabelDescricao.Text = ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Descricao;
            LabelValorTotal.Text = "Valor total: R$" +
                                   ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais +
                                   ",00";
        }
    }
}
