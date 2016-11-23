using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;
using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class LavagensPage : ContentPage {
        public LavagensPage() {
            InitializeComponent();
            List<LavagemDto> lavagens = new List<LavagemDto>();
            lavagens.Add(new LavagemDto() {
                Endereco = "Rua Albino Augusto Assmann, 50",
                DiaHorario = DateTime.Now,
                ValorEmReais = 40
            });

            lavagens.Add(new LavagemDto() {
                Endereco = "Rua Albinio, 50",
                DiaHorario = DateTime.Now,
                ValorEmReais = 40
            });

            lavagens.Add(new LavagemDto() {
                Endereco = "Rua Albinio, 50",
                DiaHorario = DateTime.Now,
                ValorEmReais = 40
            });

            lavagens.Add(new LavagemDto() {
                Endereco = "Rua Albinio, 50",
                DiaHorario = DateTime.Now,
                ValorEmReais = 40
            });

            lavagens.Add(new LavagemDto() {
                Endereco = "Rua Albinio, 50",
                DiaHorario = DateTime.Now,
                ValorEmReais = 40
            });

            ListLavagens.ItemsSource = lavagens;


        }
    }
}
