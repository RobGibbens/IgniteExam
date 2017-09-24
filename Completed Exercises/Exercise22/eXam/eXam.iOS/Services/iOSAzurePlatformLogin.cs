using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using eXam.iOS.Services;
using System.Threading.Tasks;

[assembly: Dependency(typeof(iOSAzurePlatformLogin))]

namespace eXam.iOS.Services
{
    public class iOSAzurePlatformLogin : IAzurePlatformLogin
    {
        public async Task<MobileServiceUser> PerformLogin(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            return await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
        }
    }
}