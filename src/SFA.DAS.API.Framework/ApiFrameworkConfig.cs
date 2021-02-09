namespace SFA.DAS.API.Framework
{
    public class ApiFrameworkConfig
    {
        public string Fatv2ApiKey { get; set; }

        public string ApprenticeCommitmentsApiKey { get; set; }
    }

    public class ManageIdentityOathTokenConfig
    {
        public string ClientId { get; set; }

        public string ClientSecrets { get; set; }

        public string Resource { get; set; }

        public string Tenant { get; set; }

        public string GrantType => "client_credentials";
    }
}