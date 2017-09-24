using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using eXam.UWP.Services;
using System.Threading.Tasks;

[assembly: Dependency(typeof(UWPAzurePlatformLogin))]

namespace eXam.UWP.Services
{
    class UWPAzurePlatformLogin : IAzurePlatformLogin
    {
        public async Task<MobileServiceUser> PerformLogin(
           MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            return await client.LoginAsync(provider);
        }
    }
}