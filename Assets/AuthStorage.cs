using System;
using Plugin.SecureStorage;
using Microsoft.WindowsAzure.MobileServices;

namespace eXam
{
    public class AuthStorage
    {
        const string userIdKey = ":UserId";
        const string tokenKey = ":Token";

        public static bool HasLoggedIn
        {
            get
            {
                return (CrossSecureStorage.Current.HasKey(userIdKey)
                        && CrossSecureStorage.Current.HasKey(tokenKey));
            }
        }

        public static void LoadSavedUserDetails(MobileServiceClient client)
        {
            if (!HasLoggedIn)
                throw new ArgumentException("You do not have saved credentials");

            string userId = CrossSecureStorage.Current.GetValue(userIdKey);
            string token = CrossSecureStorage.Current.GetValue(tokenKey);

            client.CurrentUser = new MobileServiceUser(userId)
            {
                MobileServiceAuthenticationToken = token
            };
        }

        public static void SaveUserDetails(MobileServiceClient client)
        {
            CrossSecureStorage.Current.SetValue(userIdKey, client.CurrentUser.UserId);
            CrossSecureStorage.Current.SetValue(tokenKey, client.CurrentUser.MobileServiceAuthenticationToken);
        }
    }
}
