using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.ProviderLogin.Service.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderRolesSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the provider Navigates to ""(.*)""")]
        public void GivenTheProviderNavigatesTo(string url)
        {
            _providerStepsHelper.GoToProviderSpecificUrl(url);
        }


        public void GivenLogsInAsUser()
        {
            ProviderLoginUser login = new ProviderLoginUser();

            if (User.Equals("Contributor"))
            {
                login.Username = _context.GetUser<ProviderContributorUser>().Username;
                login.Password = _context.GetUser<ProviderContributorUser>().Password;
            }
            else if (User.Equals("Super Contributor"))
            {
                login.Username = _context.GetUser<ProviderSuperContributorUser>().Username;
                login.Password = _context.GetUser<ProviderSuperContributorUser>().Password;
            }
            else if (User.Equals("Account Owner"))
            {
                login.Username = _context.GetUser<ProviderAccountOwnerUser>().Username;
                login.Password = _context.GetUser<ProviderAccountOwnerUser>().Password;
            }

            new ProviderSiginPage(_context).SubmitValidLoginDetails(login);
        }


       

    }
}
