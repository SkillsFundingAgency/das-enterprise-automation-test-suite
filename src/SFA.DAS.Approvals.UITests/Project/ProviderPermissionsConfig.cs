using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.Approvals.UITests.Project
{
    public class ProviderPermissionsConfig : ProviderLoginConfig
    {
        public string PermissionsDbConnectionString { get; set; }

        public string PermissionsCosmosUrl { get; set; }

        public string PermissionsCosmosDBKey { get; set; }

        public string PermissionsCosmosDatabaseName { get; set; }

        public string PermissionsCosmosCollectionName { get; set; }
    }
}
