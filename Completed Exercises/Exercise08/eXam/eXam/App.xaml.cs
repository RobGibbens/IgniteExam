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
            var resourceStream = assembly.GetManifestResourceStream("eXam.Data.questions.xml");
            var reader = new StreamReader(resourceStream);
            var xml = reader.ReadToEnd();
            var embeddedQuestions = QuizQuestionXmlSerializer.Deserialize(xml);
            CurrentGame = new Game(embeddedQuestions);
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
