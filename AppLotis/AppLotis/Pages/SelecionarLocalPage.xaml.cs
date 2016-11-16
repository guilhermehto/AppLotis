using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppLotis.Pages {
    public partial class SelecionarLocalPage : ContentPage {
        public SelecionarLocalPage() {
            InitializeComponent();
            //MyMap.MoveToRegion(new MapSpan(MyMap.VisibleRegion.Center, -29.7225,-52.4348));

        }

        private void OnBtnClicked(object sender, EventArgs e) {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-29.7225, -52.4348), Distance.FromMiles(1)));
        }
    }
}
