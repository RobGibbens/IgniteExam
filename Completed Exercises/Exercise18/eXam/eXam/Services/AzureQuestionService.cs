using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam.Services
{
    public class AzureQuestionService : IQuestionService
    {
        private MobileServiceClient client;

        private IMobileServiceTable<QuizQuestion> questionsTable;
        private void Initialize()
        {
            if (client == null)
            {
                client = new MobileServiceClient("http://questionappservice-judy.azurewebsites.net");
            }

            questionsTable = client.GetTable<QuizQuestion>();
        }

        public Task<IEnumerable<QuizQuestion>> GetQuestionsAsync()
        {
            Initialize();

            return questionsTable.ReadAsync();
        }
    }

}
