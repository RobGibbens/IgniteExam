using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace eXam
{
    public partial class SigninPage : ContentPage
    {
        readonly MobileServiceClient client;

        public SigninPage(MobileServiceClient client)
        {
            this.client = client;

            InitializeComponent();
        }

        async Task LoginToAuthenticationProvider(MobileServiceAuthenticationProvider provider)
        {
            // Check that we don't have a saved login
            if (AuthStorage.HasLoggedIn)
            {
                // Automatically load the credentials if we have
                AuthStorage.LoadSavedUserDetails(client);
                App.NavigateToExamPage();

                return;
            }

            // Perform the login
            var loginService = DependencyService.Get<IAzurePlatformLogin>();
            client.CurrentUser = await loginService.PerformLogin(client, provider);

            // Save the fact that we have logged in
            if (client.CurrentUser != null)
            {
                AuthStorage.SaveUserDetails(client);
                App.NavigateToExamPage();
            }
        }

        async void PerformFacebookLogin(object sender, System.EventArgs e)
        {
            await LoginToAuthenticationProvider(MobileServiceAuthenticationProvider.Facebook);
        }

        async void PerformTwitterLogin(object sender, System.EventArgs e)
        {
            await LoginToAuthenticationProvider(MobileServiceAuthenticationProvider.Twitter);
        }
    }
}