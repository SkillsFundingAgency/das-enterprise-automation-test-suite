using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using System;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderLoginSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderLoginSteps(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(context);
        }

        [Given(@"the provider logs in as a (Contributor|ContributorWithApproval|AccountOwner|Viewer)")]
        public void GivenTheProviderLogsInAs(ProviderConfig config)
        {
            _providerHomePageStepsHelper.SetProviderLogin(config);
            _providerHomePageStepsHelper.GoToProviderHomePage(false);
        }

        [StepArgumentTransformation(@"(Contributor|ContributorWithApproval|AccountOwner|Viewer)")]
        public ProviderConfig GetProviderUserRole(string providerUserRoles)
        {
            var userRole = Enum.Parse<ProviderUserRoles>(providerUserRoles, true);

            return true switch
            {
                bool _ when (userRole == ProviderUserRoles.Contributor) => _context.GetUser<ProviderContributorUser>(),
                bool _ when (userRole == ProviderUserRoles.ContributorWithApproval) => _context.GetUser<ProviderContributorWithApprovalUser>(),
                bool _ when (userRole == ProviderUserRoles.AccountOwner) => _context.GetUser<ProviderAccountOwnerUser>(),
                bool _ when (userRole == ProviderUserRoles.Viewer) => _context.GetUser<ProviderViewOnlyUser>(),
                _ => null,
            };
        }
    }
}
