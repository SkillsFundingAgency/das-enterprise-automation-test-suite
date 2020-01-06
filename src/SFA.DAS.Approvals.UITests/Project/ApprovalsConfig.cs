using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.Approvals.UITests.Project
{
    public class ApprovalsConfig : ProviderLoginConfig
    {
        public string AP_EmployerConfirmIdentityCode { get; set; }

        public string AP_SupportConsoleUrl { get; set; }

        public string CommitmentsDbConnectionString { get; set; }

        public string AP_AccountsDbConnectionString { get; set; }

        public string AP_FinanceDbConnectionString { get; set; }
    }
}
