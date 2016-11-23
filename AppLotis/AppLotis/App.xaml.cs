using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLotis.Database;
using AppLotis.Pages;
using Xamarin.Forms;

namespace AppLotis {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            var dbtoken = new TokenDatabase();
            if (dbtoken.TokenExists()) {
                MainPage = new IndexPage();
            } else {
                MainPage = new AppLotis.MainPage();
            }


        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
