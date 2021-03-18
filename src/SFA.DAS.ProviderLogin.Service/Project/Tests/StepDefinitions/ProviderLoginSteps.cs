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
            
            switch(User)
            {
                case "Contributor":
                    login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderContributorUser>());
                    break;
                case "Contributor with approval":
                    login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderContributorWithApprovalUser>());
                    break;
                case "Account Owner":
                    login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderAccountOwnerUser>());
                    break;
                case "Viewer":
                    login = _providerHomePageStepsHelper.GetProviderLogin(_context.GetUser<ProviderViewOnlyUser>());
                    break;
                default:
                    break;
            }

            _providerHomePageStepsHelper.GoToProviderHomePage(login, false);
        }
    }
}
