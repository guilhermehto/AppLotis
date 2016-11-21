using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class VeiculosPage : ContentPage {
        public VeiculosPage() {
            InitializeComponent();
            
        }
        
        protected override async void OnAppearing() {
            /*var sourceVEiculos = new List<VeiculoDto>();
            for (int i = 0; i < 5; i++) {
                var veiculo = new VeiculoDto {
                    Placa = $"ABC - {i}{i}{i}{i}",
                    Modelo = "Fiesta",
                    Marca = "Ford",
                    Cor = "Rosa"
                };
                sourceVEiculos.Add(veiculo);
            }
            ListVeiculos.ItemsSource = sourceVEiculos;*/
        }
    }
}
