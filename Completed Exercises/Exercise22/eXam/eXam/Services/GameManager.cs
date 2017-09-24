using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eXam.Services
{
    public static class GameManager
    {
        public static async Task<Game> CreateGameAsync()
        {
            var questions = await LoadQuestionsAsync();
            return new Game(questions.ToList());
        }

        static async Task<IEnumerable<QuizQuestion>> LoadQuestionsAsync()
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
            
            await fileHelper.SaveLocalFileAsync("cachedquestions.json", cachedQuestions);

            return embeddedQuestions;
        }
    }
}