using System.Threading.Tasks;
using System;

namespace eXam
{
	public enum AppPage
	{
		HomePage,
		QuestionPage,
		ReviewPage,
	}

	public class NavigationService
	{
		public async Task GotoPageAsync (AppPage page)
		{
			var nav = App.Current.MainPage.Navigation;

			switch (page) 
			{
				case AppPage.HomePage:
					await nav.PushAsync (new HomePage (), true);
					return;

				case AppPage.QuestionPage:
					if (App.Current == null) return; // Prevent starting before the game is ready
					await nav.PushAsync (new QuestionPage (new QuestionPageViewModel(App.CurrentGame)), true);
					return;

				case AppPage.ReviewPage:
					await nav.PushAsync (new ReviewPage (new ReviewPageViewModel (App.CurrentGame)), true);
					nav.RemovePage (nav.NavigationStack [1]); // Forces app to HomePage when navigating back from the review page
					return;

				default:
					throw new ArgumentOutOfRangeException("Attempt to navigate to invalid page");
			}
		}
	}
}