namespace SFA.DAS.ProviderLogin.Service.Project;

public class ProviderConfig
{
    public string UserId { get; set; }

    public string Password { get; set; }

    public string Ukprn { get; set; }
}

public class RplWhiteListedProviderConfig : ProviderConfig { }

public class ChangeOfPartyConfig : ProviderConfig
{
    public string NewProviderName { get; set; }
}

public class ProviderPermissionsConfig : ProviderConfig
{
    public string PermissionsCosmosUrl { get; set; }

    public string PermissionsCosmosDBKey { get; set; }

    public string PermissionsCosmosDatabaseName { get; set; }

    public string PermissionsCosmosCollectionName { get; set; }
}

public class PortableFlexiJobProviderConfig : ProviderConfig { }

public class PerfTestProviderPermissionsConfig : ProviderConfig { }

public class ProviderLoginUser : ProviderConfig { }

public class ProviderViewOnlyUser : ProviderConfig { }

public class ProviderContributorUser : ProviderConfig { }

public class ProviderContributorWithApprovalUser : ProviderConfig { }

public class ProviderAccountOwnerUser : ProviderConfig { }