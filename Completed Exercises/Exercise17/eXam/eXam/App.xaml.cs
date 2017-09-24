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
            IFileHelper fileHelper = DependencyService.Get<IFileHelper>();
            string cachedQuestions;

            if (CrossConnectivity.Current.IsConnected)
            {
                // We're online
                IQuestionService questionService = new AzureQuestionService();
                var questionsList = await questionService.GetQuestionsAsync();
                cachedQuestions = JsonConvert.SerializeObject(questionsList);
            }
            else
            {
                // We're offline.  Load the questions from the local cache
                cachedQuestions = await fileHelper.LoadLocalFileAsync("cachedquestions.json");
                if (string.IsNullOrWhiteSpace(cachedQuestions))
                {
                    var assembly = typeof(App).GetTypeInfo().Assembly;
                    using (var resourceStream = assembly.GetManifestResourceStream("eXam.Data.questions.json"))
                    {
                        using (var reader = new StreamReader(resourceStream))
                        {
                            cachedQuestions = reader.ReadToEnd();
                        }
                    }
                }
            }

            var embeddedQuestions = JsonConvert.DeserializeObject<List<QuizQuestion>>(cachedQuestions);
            CurrentGame = new Game(embeddedQuestions);
            await fileHelper.SaveLocalFileAsync("cachedquestions.json", cachedQuestions);
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
