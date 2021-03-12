using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;

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

        [Given(@"the provider logs in as a (Contributor|Contributor with approval|Account Owner|Viewer)")]
        public void GivenTheProviderLogsInAs(string User)
        {
            ProviderLoginUser login = new ProviderLoginUser();

            if (User.Equals("Contributor"))
            {
                login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderContributorUser>());
            }
            else if (User.Equals("Contributor with approval"))
            {
                login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderContributorWithApprovalUser>());
            }
            else if (User.Equals("Account Owner"))
            {
                login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderAccountOwnerUser>());
            }
            else if (User.Equals("Viewer"))
            {
                login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderViewOnlyUser>());
            }

            _providerHomePageStepsHelper.GoToProviderHomePage(login, false);
        }
    }
}
