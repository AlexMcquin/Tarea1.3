using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1._3
{
    public partial class App : Application
    {
        public static string ubicacionDB = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(String DBlocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            ubicacionDB = DBlocal;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
