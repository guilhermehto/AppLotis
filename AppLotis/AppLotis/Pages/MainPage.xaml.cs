using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using AppLotis.Pages;
using AppLotis.Rest;
using AppLotis.Singletons;
using Xamarin.Forms.Maps;

namespace AppLotis {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            foreach (var m in ListaMarcas.Marcas) {
                PickerMarcas.Items.Add(m);
            }
            PickerMarcas.SelectedIndex = 0;

            foreach (var c in ListaCores.Cores) {
                PickerCores.Items.Add(c);
            }
            PickerCores.SelectedIndex = 0;

            var apiAdicionais = new RestAdicional();
            var apiTipos = new RestTipoLavagem();
            var listaAdicionais = await apiAdicionais.LoadAdicionais();
            var listaTipos = await apiTipos.LoadTipos();
            ListasSingleton.Adicionais = listaAdicionais;
            ListasSingleton.TipoLavagens = listaTipos;


        }

        async void OnContinuarClicked(object sender, EventArgs e) {
            await ValidarForm();
            //await Navigation.PushModalAsync(new SeleecionarLavagemPage());
        }

        async Task ValidarForm() {
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
                VeiculoSingleton.Iniciar(EntryPlaca.Text, 
                    EntryModelo.Text, 
                    PickerMarcas.Items.ElementAt(PickerMarcas.SelectedIndex), 
                    PickerCores.Items.ElementAt(PickerCores.SelectedIndex));

                await Navigation.PushModalAsync(new SeleecionarLavagemPage());
            } else {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "Ok");
            }
        }

    }
}
