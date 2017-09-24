using eXam.Services;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace eXam
{
    public partial class App : Application
    {
        static MobileServiceClient client = new MobileServiceClient(AppConstants.AzureUrl);

        public App()
        {
            InitializeComponent();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<AzureQuestionService>();

            if (AuthStorage.HasLoggedIn)
            {
                AuthStorage.LoadSavedUserDetails(client);

                App.NavigateToExamPage();
            }
            else
            {
                App.NavigateToSigninPage();
            }
        }

        public static async void NavigateToExamPage()
        {
            Current.MainPage = new LoadingQuestionsPage();

            CurrentGame = await GameManager.CreateGameAsync();

            Current.MainPage = new NavigationPage(new HomePage());
        }

        public static void NavigateToSigninPage()
        {
            Current.MainPage = new SigninPage(client);
        }

        public static Game CurrentGame { get; set; }
    }
}
