using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Rest;
using Xamarin.Forms;

namespace AppLotis.Pages.Lavagens_Logado {
    public partial class SelecionarLavagemEVeiculoPage : ContentPage {
        private int oldIndexTipoLavagem = 0;

        private RestVeiculo apiVeiculos;
        private RestTipoLavagem apiTipoLavagens;
        private RestAdicional apiAdicionais;

        private List<AdicionalDto> adicionais;
        private List<TipoLavagemDto> tipos;
        private List<VeiculoDto> veiculos;

        private ObservableCollection<AdicionalDto> adicionaisSelecionados;

        private LavagemDto _lavagem;

        public SelecionarLavagemEVeiculoPage() {
            InitializeComponent();
            apiVeiculos = new RestVeiculo();
            apiTipoLavagens = new RestTipoLavagem();
            apiAdicionais = new RestAdicional();
            adicionaisSelecionados = new ObservableCollection<AdicionalDto>();
            ListViewAdicionais.ItemsSource = adicionaisSelecionados;
            _lavagem = new LavagemDto();
        }

        protected override  async void OnAppearing() {
            veiculos = await apiVeiculos.LoadVeiculos();
            tipos = await apiTipoLavagens.LoadTipos();
            adicionais = await apiAdicionais.LoadAdicionais();

            foreach (var tipo in tipos) {
                PickerLavagens.Items.Add(tipo.Nome);
            }

            foreach (var veiculo in veiculos) {
                PickerVeiculos.Items.Add(veiculo.Placa);
            }

            foreach (var adicionalDto in adicionais) {
                PickerAdicionais.Items.Add(adicionalDto.Nome);
            }

            PickerAdicionais.SelectedIndex = 0;
            PickerVeiculos.SelectedIndex = 0;
            PickerVeiculos.SelectedIndexChanged += OnPickerVeiculosIndexChanged;
            PickerLavagens.SelectedIndex = 0;
            PickerLavagens.SelectedIndexChanged += OnPickerLavagensIndexChanged;

            AtualizarPrecoLavagem();

            _lavagem.VeiculoId = veiculos.ElementAt(PickerVeiculos.SelectedIndex).Id;
            _lavagem.TipoLavagemId = tipos.ElementAt(PickerLavagens.SelectedIndex).Id;
        }

        private void OnRemoverAdicionalClicked(object sender, EventArgs e) {
            var _sender = ((Button)sender);
            var parent = (StackLayout)_sender.Parent;
            var adicional = (Label)parent.Children.FirstOrDefault(x => x.GetType() == typeof(Label));
            int index = 0;
            foreach (var a in adicionaisSelecionados) {
                if (a.Nome == adicional.Text) {
                    adicionaisSelecionados.RemoveAt(index);
                    _lavagem.ValorEmReais -= a.ValorEmReais;
                    _lavagem.Adicionais = adicionaisSelecionados;
                    //LavagemSingleton.TipoLavagemId = a.Id;
                    LabelPrecoTotal.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
                    break;
                }
                index++;
            }
        }

        private void OnSelecionarAdicionalClicked(object sender, EventArgs e) {
            var index = PickerAdicionais.SelectedIndex;

            if (!adicionaisSelecionados.Contains(adicionais.ElementAt(index))) {
                adicionaisSelecionados.Add(adicionais.ElementAt(index));
                _lavagem.ValorEmReais += adicionais.ElementAt(index).ValorEmReais;
                LabelPrecoTotal.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
            }
        }

        private void AtualizarPrecoLavagem() {
            foreach (var adicionado in adicionaisSelecionados) {
                _lavagem.ValorEmReais += adicionado.ValorEmReais;
            }

            _lavagem.ValorEmReais += tipos.ElementAt(PickerLavagens.SelectedIndex).ValorEmReais;

            LabelPrecoTotal.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
        }

        private void OnPickerLavagensIndexChanged(object sender, EventArgs e) {
            _lavagem.ValorEmReais -= tipos.ElementAt(oldIndexTipoLavagem).ValorEmReais;
            oldIndexTipoLavagem = PickerLavagens.SelectedIndex;
            _lavagem.ValorEmReais += tipos.ElementAt(oldIndexTipoLavagem).ValorEmReais;
            LabelPrecoTotal.Text = "Preço total: R$" + _lavagem.ValorEmReais + ".00";
            _lavagem.TipoLavagemId = tipos.ElementAt(PickerLavagens.SelectedIndex).Id;

        }

        private void OnBtnContinuarClicked(object sender, EventArgs e) {
            _lavagem.Adicionais = adicionaisSelecionados;
            Navigation.PushModalAsync(new SelecionarLocalLogadoPage(_lavagem));
        }

        private void OnPickerVeiculosIndexChanged(object sender, EventArgs e) {
            _lavagem.VeiculoId = veiculos.ElementAt(PickerVeiculos.SelectedIndex).Id;
        }
    }
}
