using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using eXam.Droid.Services;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DroidAzurePlatformLogin))]

namespace eXam.Droid.Services
{
    public class DroidAzurePlatformLogin : IAzurePlatformLogin
    {
        public async Task<MobileServiceUser> PerformLogin(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            return await client.LoginAsync(Forms.Context, provider);
        }
    }
}