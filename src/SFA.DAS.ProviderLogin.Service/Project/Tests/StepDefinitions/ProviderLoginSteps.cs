using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.StepDefinitions;

[Binding]
public class ProviderLoginSteps(ScenarioContext context)
{
    private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper = new(context);

    [Given(@"the provider logs in as a (Contributor|ContributorWithApproval|AccountOwner|Viewer)")]
    public void GivenTheProviderLogsInAs(ProviderConfig config) => _providerHomePageStepsHelper.GoToProviderHomePage(config, false);

    [StepArgumentTransformation(@"(Contributor|ContributorWithApproval|AccountOwner|Viewer)")]
    public ProviderConfig GetProviderUserRole(string providerUserRoles)
    {
        var userRole = Enum.Parse<ProviderUserRoles>(providerUserRoles, true);

        return true switch
        {
            bool _ when (userRole == ProviderUserRoles.Contributor) => context.GetUser<ProviderContributorUser>(),
            bool _ when (userRole == ProviderUserRoles.ContributorWithApproval) => context.GetUser<ProviderContributorWithApprovalUser>(),
            bool _ when (userRole == ProviderUserRoles.AccountOwner) => context.GetUser<ProviderAccountOwnerUser>(),
            bool _ when (userRole == ProviderUserRoles.Viewer) => context.GetUser<ProviderViewOnlyUser>(),
            _ => null,
        };
    }
}
