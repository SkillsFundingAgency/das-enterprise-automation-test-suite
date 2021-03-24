using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.ProviderLogin.Service
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string Ukprn = "ukprn";
        private const string ProviderLogin = "providerlogin";
        #endregion
        
        internal static void SetUkprn(this ObjectContext objectContext, string value)
        {
            objectContext.Replace(Ukprn, value);
        }
        
        internal static string GetUkprn(this ObjectContext objectContext)
        {
            return objectContext.Get(Ukprn);
        }

        internal static void SetProviderLogin(this ObjectContext objectContext, ProviderLoginUser value)
        {
            objectContext.Replace(ProviderLogin, value);
        }

        internal static ProviderLoginUser GetProviderLogin(this ObjectContext objectContext)
        {
            return objectContext.Get<ProviderLoginUser>(ProviderLogin);
        }
    }
}
