using eXam.Services;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace eXam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<NavigationService>();
            NavigationPage navigationPage = new NavigationPage(new HomePage());
            
            MainPage = navigationPage;
            
        }

        public static Game CurrentGame { get; set; }

        protected override async void OnStart()
        {
            
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
