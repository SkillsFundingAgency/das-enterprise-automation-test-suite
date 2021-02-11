using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.API.Framework.Configs
{
    public abstract class Inner_ApiAuthTokenConfig
    {
        public string ClientId { get; set; }

        public string ClientSecrets { get; set; }

        public string Tenant { get; set; }

        public string GrantType => "client_credentials";

        protected abstract string ApiName { get; }

        public string Resource => UriHelper.GetAbsoluteUri($"https://{Tenant}", ApiName);
    }
}