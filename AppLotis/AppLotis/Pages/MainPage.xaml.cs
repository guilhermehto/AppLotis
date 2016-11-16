using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using AppLotis.Pages;
using AppLotis.Singletons;
using Xamarin.Forms.Maps;

namespace AppLotis {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        async void OnContinuarClicked(object sender, EventArgs e) {
            //TODO: Retomar validação
            ValidarForm();
            //await Navigation.PushModalAsync(new SeleecionarLavagemPage());
        }

        async void ValidarForm() {
            bool carregar = true;
            foreach (var child in StackPrincipal.Children) {
                if (child.GetType() == typeof(Entry)) {
                    if (String.IsNullOrEmpty(((Entry)child).Text)) {
                        carregar = false;
                        ((Entry)child).Placeholder = "Preencher";
                        ((Entry)child).PlaceholderColor = Color.Red;
                    } else if (((Entry)child).BackgroundColor == Color.Red) {
                        ((Entry)child).Placeholder = "Erro";
                        ((Entry)child).PlaceholderColor = Color.Red;
                    }
                }
            }
            if (carregar) {
                VeiculoSingleton.Iniciar(EntryPlaca.Text, EntryModelo.Text, EntryMarca.Text, EntryCor.Text);
                await Navigation.PushModalAsync(new SeleecionarLavagemPage());
            } else {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "Ok");
            }
        }
    }
}
