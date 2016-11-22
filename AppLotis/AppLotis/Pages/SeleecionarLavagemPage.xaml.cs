using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Singletons;
using AppLotis.ViewModels;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class SeleecionarLavagemPage : ContentPage {
        private ObservableCollection<AdicionalDto> adicionados;
        private bool SemInternet = false;
        private int IndexLavagemAntigo = 0;
        public SeleecionarLavagemPage() {
            InitializeComponent();
            adicionados = new ObservableCollection<AdicionalDto>();
            ListViewAdicionais.ItemsSource = adicionados;
            try {
                foreach (var adicional in ListasSingleton.Adicionais) {
                    PickerAdicionais.Items.Add(adicional.Nome);
                }

                foreach (var tipo in ListasSingleton.TipoLavagens) {
                    PickerLavagens.Items.Add(tipo.Nome);
                }
                PickerAdicionais.SelectedIndex = 0;
                PickerLavagens.SelectedIndex = 0;
                PickerLavagens.SelectedIndexChanged += OnLavagensSelectedChanged;
                LavagemSingleton.TipoLavagemId = 
                    ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Id;
                LavagemSingleton.ValorEmReais =
                    ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais;
                LabelDescricao.Text = ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Descricao;
                UpdateTextoValorTotal();
            } catch (Exception e) {
                DisplayAlert("Erro", MensagensErro.SEM_INTERNET, "Ok");
                SemInternet = true;
            }
            
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
                LavagemSingleton.ValorEmReais += selecionadoAdd.ValorEmReais;
                UpdateTextoValorTotal();
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
                    LavagemSingleton.ValorEmReais -= a.ValorEmReais;
                    //LavagemSingleton.TipoLavagemId = a.Id;
                    UpdateTextoValorTotal();
                    break;
                }
                index++;
            }
        }

        async void OnContinuarClicked(object sender, EventArgs e) {
            if (!SemInternet) {
                await Navigation.PushModalAsync(new AgendamentoPage());
            }
            else {
                await DisplayAlert("Erro", MensagensErro.SEM_INTERNET, "Ok");
            }
        }

        private void OnLavagensSelectedChanged(object sender, EventArgs e) {
            LabelDescricao.Text = ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Descricao;
            LabelValorTotal.Text = "Valor total: R$" +
                                   ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais +
                                   ",00";
            LavagemSingleton.ValorEmReais -=
                ListasSingleton.TipoLavagens.ElementAt(IndexLavagemAntigo).ValorEmReais;
            LavagemSingleton.ValorEmReais +=
                ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais;
            LavagemSingleton.TipoLavagemId = ListasSingleton.TipoLavagens.ElementAt(PickerLavagens.SelectedIndex).Id;
            IndexLavagemAntigo = PickerLavagens.SelectedIndex;
            UpdateTextoValorTotal();


        }

        private void UpdateTextoValorTotal() {
            LabelValorTotal.Text = "Valor total: R$" + LavagemSingleton.ValorEmReais + ",00";
        }
    }
}
