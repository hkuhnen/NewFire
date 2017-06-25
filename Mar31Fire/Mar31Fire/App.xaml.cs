using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mar31Fire
{
    //partial
    public partial class App : Application
    {
        public static BuildingManager BuildManager { get; private set; }
        public App()
        {
            //InitializeComponent();
            BuildManager = new BuildingManager(new RestService());

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
