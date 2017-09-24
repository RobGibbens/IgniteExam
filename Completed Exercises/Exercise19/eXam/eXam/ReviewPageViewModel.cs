using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXam
{
    public class ReviewPageViewModel
    {
        private readonly Game game;
        public List<QuizQuestionViewModel> QuestionViewModels { get; set; }

        public ReviewPageViewModel(Game game)
        {
            this.game = game;
            QuestionViewModels = new List<QuizQuestionViewModel>();
            for (int index = 0; index < game.NumberOfQuestions; index++)
            {
                var question = game.Questions[index];
                var response = game.Responses[index];
                var viewModel = new QuizQuestionViewModel(question, response);
                QuestionViewModels.Add(viewModel);
            }
        }
    }

}
