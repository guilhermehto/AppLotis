using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace AppLotis.Pages {
    public partial class AgendamentoPage : ContentPage {
        public AgendamentoPage() {
            InitializeComponent();
            
        }

        protected override async void OnAppearing() {
            var locator = CrossGeolocator.Current;
            Geocoder geocoder = new Geocoder();
            var posUsuario = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var enderecos = await geocoder.GetAddressesForPositionAsync(new Position(posUsuario.Latitude, posUsuario.Longitude));
            var endereco = enderecos.FirstOrDefault();
            LabelEndereco.Text = endereco.Substring(0, endereco.IndexOf('-'));
            MapLocalizacao.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(posUsuario.Latitude, posUsuario.Longitude), Distance.FromKilometers(1)));
            MapLocalizacao.Pins.Add(new Pin() {
                Position = new Position(posUsuario.Latitude, posUsuario.Longitude),
                Label = "Seu carro"
            });
        }

        private void OnContinuarClicked(object sender, EventArgs e) {
            throw new NotImplementedException();
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
    }
}
