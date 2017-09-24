namespace eXam
{
	public class QuizQuestionViewModel
	{
		public string Question { get { return quizQuestion.Question; } }
		public bool   Answer { get { return quizQuestion.Answer; } }
		public string Explanation { get { return quizQuestion.Explanation; } }

		public bool?  Response { get; private set; }

		public bool   IsCorrect { get { return quizQuestion.Answer == Response; } }

		QuizQuestion quizQuestion;

		public QuizQuestionViewModel (QuizQuestion quizQuestion, bool? response)
		{
			this.Response = response;
			this.quizQuestion = quizQuestion;
		}
	}
}