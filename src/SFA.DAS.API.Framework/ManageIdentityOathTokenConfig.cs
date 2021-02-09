using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.API.Framework
{
    public abstract class ManageIdentityOathTokenConfig
    {
        public string ClientId { get; set; }

        public string ClientSecrets { get; set; }

        public string Tenant { get; set; }

        public string GrantType => "client_credentials";

        protected abstract string ResourceEndpoint { get; }

        public string Resource => UriHelper.GetAbsoluteUri($"https://{Tenant}", ResourceEndpoint);
    }
}