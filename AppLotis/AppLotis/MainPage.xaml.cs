using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace AppLotis {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        /*private void PlacaTextChanged(object sender, TextChangedEventArgs e) {
            EntryPlaca.TextChanged -= PlacaTextChanged;
            if (e.NewTextValue.Length == 3 && e.OldTextValue != null && e.OldTextValue.Length == 2) {
                EntryPlaca.Text = e.NewTextValue + "-";
            }

            if (e.NewTextValue.Length > 4 && !Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length -1].ToString(), @"[0-9]")) {
                EntryPlaca.Text = e.OldTextValue;
            } else if (e.NewTextValue.Length < 4 && e.NewTextValue.Length != 0) {
                if (!Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length - 1].ToString(), @"[a-zA-Z]")) {
                    EntryPlaca.Text = e.OldTextValue;
                } else if (Regex.IsMatch(e.NewTextValue[e.NewTextValue.Length - 1].ToString(), @"[a-z]")) {
                    var novoTexto = e.OldTextValue + e.NewTextValue[e.NewTextValue.Length - 1].ToString().ToUpper();
                    EntryPlaca.Text = novoTexto;
                }
            }
            Task.Yield();
            EntryPlaca.TextChanged += PlacaTextChanged;
        }*/

        private void OnContinuarClicked(object sender, EventArgs e) {
            

        }
    }
}
