using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace eXam
{
    public interface IAzurePlatformLogin
    {
        Task<MobileServiceUser> PerformLogin(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
    }
}
