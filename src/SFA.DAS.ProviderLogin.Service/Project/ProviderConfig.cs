namespace SFA.DAS.ProviderLogin.Service
{
    public class ProviderConfig
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public string Ukprn { get; set; }
    }

    public class ProviderViewOnlyUser : ProviderConfig { }

    public class ProviderContributorUser : ProviderConfig { }

    public class ProviderContributorWithApprovalUser : ProviderConfig { }

    public class ProviderAccountOwnerUser : ProviderConfig { }

}
