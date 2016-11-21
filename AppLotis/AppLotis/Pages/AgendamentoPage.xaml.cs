using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Singletons;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace AppLotis.Pages {
    public partial class AgendamentoPage {
        private string EnderecoCompleto;
        public AgendamentoPage() {
            InitializeComponent();
            LabelHorario.Text = "Horário: " + SliderHorario.Value + ":00";
            SliderHorario.ValueChanged += OnSliderHorarioChanged;
        }

        

        protected override async void OnAppearing() {
            var locator = CrossGeolocator.Current;
            Geocoder geocoder = new Geocoder();
            var posUsuario = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var enderecos = await geocoder.GetAddressesForPositionAsync(new Position(posUsuario.Latitude, posUsuario.Longitude));
            var endereco = enderecos.FirstOrDefault();
            EnderecoCompleto = endereco;
            LabelEndereco.Text = endereco.Substring(0, endereco.IndexOf('-'));
            MapLocalizacao.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(posUsuario.Latitude, posUsuario.Longitude), Distance.FromKilometers(1)));
            MapLocalizacao.Pins.Add(new Pin() {
                Position = new Position(posUsuario.Latitude, posUsuario.Longitude),
                Label = "Seu carro"
            });
        }

        private async void OnContinuarClicked(object sender, EventArgs e) {
            LavagemSingleton.Latitude = MapLocalizacao.Pins.FirstOrDefault().Position.Latitude;
            LavagemSingleton.Latitude = MapLocalizacao.Pins.FirstOrDefault().Position.Longitude;
            LavagemSingleton.Endereco = EnderecoCompleto;

            var tempo = TimeSpan.Parse(SliderHorario.Value + ":00");
            LavagemSingleton.DiaHorario = DatePickerDiaDaLavagem.Date + tempo;

            await Navigation.PushModalAsync(new PagamentoPage());
        }

        private async void OnBtnPesquisarClicked(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(EntryCep.Text)) {
                await DisplayAlert("Erro", "O campo do cep deve ser preenchido", "Ok");
                return;
            }
            Geocoder geocoder = new Geocoder();
            var localizacoes = await geocoder.GetPositionsForAddressAsync(EntryCep.Text);
            if (localizacoes.Any()) {
                var enderecos = await geocoder.GetAddressesForPositionAsync(new Position(localizacoes.FirstOrDefault().Latitude, localizacoes.FirstOrDefault().Longitude));
                var endereco = enderecos.FirstOrDefault();
                EnderecoCompleto = endereco;
                LabelEndereco.Text = endereco.Substring(0, endereco.IndexOf('-'));
                MapLocalizacao.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacoes.FirstOrDefault().Latitude, localizacoes.FirstOrDefault().Longitude), Distance.FromKilometers(1)));
                MapLocalizacao.Pins.RemoveAt(0);

                var pinCarro = new Pin() {
                    Position = new Position(localizacoes.FirstOrDefault().Latitude,
                        localizacoes.FirstOrDefault().Longitude),
                    Label = "Seu carro"
                };

                MapLocalizacao.Pins.Add(pinCarro);
            }
        }

        private void OnSliderHorarioChanged(object sender, ValueChangedEventArgs e) {
            SliderHorario.ValueChanged -= OnSliderHorarioChanged;
            SliderHorario.Value = Math.Ceiling(e.NewValue);

            var tempo = TimeSpan.Parse(Math.Ceiling(e.NewValue)+ ":00");
            LavagemSingleton.DiaHorario = DatePickerDiaDaLavagem.Date + tempo;

            LabelHorario.Text = "Horário: " + SliderHorario.Value + ":00";
            SliderHorario.ValueChanged += OnSliderHorarioChanged;
        }
    }
}
