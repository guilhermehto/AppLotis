using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using AppLotis.Helpers;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppLotis.Pages.Lavagens_Logado {
    public partial class SelecionarLocalLogadoPage : ContentPage {
        private string _enderecoCompleto;
        private LavagemDto _lavagem;
        private double _latitude;
        private double _longitude;
       
        public SelecionarLocalLogadoPage() {
            InitializeComponent();
        }

        public SelecionarLocalLogadoPage(LavagemDto lavagem) {
            InitializeComponent();
            _lavagem = lavagem;
            LabelHorario.Text = "Horário: " + SliderHorario.Value + ":00";
            var tempo = TimeSpan.Parse(SliderHorario.Value + ":00");
            _lavagem.DiaHorario = DatePickerDiaDaLavagem.Date + tempo;
            SliderHorario.ValueChanged += OnSliderHorarioChanged;
        }


        protected override async void OnAppearing() {
            var locator = CrossGeolocator.Current;
            Geocoder geocoder = new Geocoder();
            var posUsuario = await locator.GetPositionAsync(timeoutMilliseconds: 20000);
            var enderecos = await geocoder.GetAddressesForPositionAsync(new Position(posUsuario.Latitude, posUsuario.Longitude));
            var endereco = enderecos.FirstOrDefault();
            _enderecoCompleto = endereco;
            LabelEndereco.Text = endereco.Substring(0, endereco.IndexOf('-'));
            _latitude = posUsuario.Latitude;
            _longitude = posUsuario.Longitude;
            MapLocalizacao.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(posUsuario.Latitude, posUsuario.Longitude), Distance.FromKilometers(1)));
            MapLocalizacao.Pins.Add(new Pin() {
                Position = new Position(posUsuario.Latitude, posUsuario.Longitude),
                Label = "Seu carro"
            });
        }



        private async void OnBtnPesquisarClicked(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(EntryCep.Text)) {
                await DisplayAlert("Erro", "O campo do cep deve ser preenchido", "Ok");
                return;
            }

            try {
                Geocoder geocoder = new Geocoder();
                var localizacoes = await geocoder.GetPositionsForAddressAsync(EntryCep.Text);
                if (localizacoes.Any()) {
                    var enderecos =
                        await
                            geocoder.GetAddressesForPositionAsync(new Position(localizacoes.FirstOrDefault().Latitude,
                                localizacoes.FirstOrDefault().Longitude));
                    var endereco = enderecos.FirstOrDefault();
                    _enderecoCompleto = endereco;
                    LabelEndereco.Text = endereco.Substring(0, endereco.IndexOf('-'));
                    _latitude = localizacoes.ElementAt(0).Latitude;
                    _longitude = localizacoes.ElementAt(0).Longitude;
                    MapLocalizacao.MoveToRegion(
                        MapSpan.FromCenterAndRadius(
                            new Position(localizacoes.ElementAt(0).Latitude, localizacoes.ElementAt(0).Longitude),
                            Distance.FromKilometers(1)));
                    MapLocalizacao.Pins.RemoveAt(0);

                    var pinCarro = new Pin() {
                        Position = new Position(localizacoes.FirstOrDefault().Latitude,
                            localizacoes.FirstOrDefault().Longitude),
                        Label = "Seu carro"
                    };

                    MapLocalizacao.Pins.Add(pinCarro);
                } else {
                    await DisplayAlert("Erro", MensagensErro.CEP_NAO_ENCONTRADO, "Ok");
                    EntryCep.Text = "";
                }
            } catch (Exception ex) {
                await DisplayAlert("Erro", MensagensErro.CEP_NAO_ENCONTRADO, "Ok");
                EntryCep.Text = "";
            }
        }

        private async void OnContinuarClicked(object sender, EventArgs e) {
            //Latitude e longitude são setadas quando a page é carregada e quando o usuário pesquisa por um novo endereço.
            _lavagem.Endereco = _enderecoCompleto;
            _lavagem.Longitude = _longitude;
            _lavagem.Latitude = _latitude;
            await Navigation.PushModalAsync(new PagamentoLogadoPage(_lavagem));
        }

        private void OnSliderHorarioChanged(object sender, ValueChangedEventArgs e) {
            SliderHorario.ValueChanged -= OnSliderHorarioChanged;
            SliderHorario.Value = Math.Ceiling(e.NewValue);

            var tempo = TimeSpan.Parse(Math.Ceiling(e.NewValue) + ":00");
            _lavagem.DiaHorario = DatePickerDiaDaLavagem.Date + tempo;

            LabelHorario.Text = "Horário: " + SliderHorario.Value + ":00";
            SliderHorario.ValueChanged += OnSliderHorarioChanged;
        }
    }
}
