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
            
            NavigationPage navigationPage = new NavigationPage(new HomePage());
            
            MainPage = navigationPage;
            
        }

        public static Game CurrentGame { get; set; }

        protected override async void OnStart()
        {
            // Handle when your app starts
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var resourceStream = assembly.GetManifestResourceStream("eXam.Data.questions.json");
            var reader = new StreamReader(resourceStream);
            var json = reader.ReadToEnd();
            var embeddedQuestions = JsonConvert.DeserializeObject<List<QuizQuestion>>(json);
            CurrentGame = new Game(embeddedQuestions);

            IFileHelper fileHelper = DependencyService.Get<IFileHelper>();
            string cachedQuestions = string.Empty;

            if (CrossConnectivity.Current.IsConnected)
            {
                // We're online
            }
            else
            {
                // We're offline.  Load the questions from the local cache
                cachedQuestions = await fileHelper.LoadLocalFileAsync("cachedquestions.json");
            }

            if (string.IsNullOrWhiteSpace(cachedQuestions))
            {
                await fileHelper.SaveLocalFileAsync("cachedquestions.json", json);
            }
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
