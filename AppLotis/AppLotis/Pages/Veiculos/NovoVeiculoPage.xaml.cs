using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using AppLotis.Rest;
using AppLotis.Singletons;
using Xamarin.Forms;

namespace AppLotis.Pages.Veiculos {
    public partial class NovoVeiculoPage : ContentPage {
        private VeiculoDto _veiculo;
        public NovoVeiculoPage() {
            InitializeComponent();
            _veiculo = new VeiculoDto();
            
        }

        protected override async void OnAppearing() {
            foreach (var marca in ListaMarcas.Marcas) {
                PickerMarcas.Items.Add(marca);
            }

            foreach (var cor in ListaCores.Cores) {
                PickerCores.Items.Add(cor);
            }

            PickerMarcas.SelectedIndex = 0;
            PickerMarcas.SelectedIndexChanged += OnPickerMarcasIndexChanged;
            PickerCores.SelectedIndex = 0;
            PickerCores.SelectedIndexChanged += OnPickerCoresIndexChanged;

            _veiculo.Marca = PickerMarcas.Items.ElementAt(PickerMarcas.SelectedIndex);
            _veiculo.Cor = PickerCores.Items.ElementAt(PickerCores.SelectedIndex);

            var apiUsuario = new RestUsuario();
            _veiculo.UsuarioId = await apiUsuario.GetMeuId();
        }

        private void OnPickerCoresIndexChanged(object sender, EventArgs e) {
            _veiculo.Cor = PickerCores.Items.ElementAt(PickerCores.SelectedIndex);
        }

        private void OnPickerMarcasIndexChanged(object sender, EventArgs e) {
            _veiculo.Marca = PickerMarcas.Items.ElementAt(PickerMarcas.SelectedIndex);
        }

        private async void OnBtnSalvarClicked(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(EntryPlaca.Text) && String.IsNullOrEmpty(EntryModelo.Text)) {
                await DisplayAlert("Erro", MensagensErro.CAMPOS_EM_BRANCO, "Ok");
                return;
            }
            _veiculo.Placa = EntryPlaca.Text;
            _veiculo.Modelo = EntryModelo.Text;
            var apiVeiculos = new RestVeiculo();
            var resultado = await apiVeiculos.PostVeiculo(_veiculo);
            if (resultado.Id != 0) {
                await DisplayAlert("Sucesso", MensagensSucesso.VEICULO_CADASTRADO, "Ok");
                var page = new IndexPage();
                Application.Current.MainPage = page;
            } else {
                await DisplayAlert("Sucesso", MensagensErro.ERRO_REST, "Ok");
            }
        }
    }
}
