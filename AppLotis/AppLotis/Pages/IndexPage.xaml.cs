using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLotis.Pages {
    public partial class IndexPage : TabbedPage {
        public IndexPage() {
            InitializeComponent();
            CurrentPage = LavagensPageChild;
        }
    }
}
