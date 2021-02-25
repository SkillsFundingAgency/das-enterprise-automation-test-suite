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
        private readonly ObjectContext _objectContext;
        private readonly ProviderSiginPage _loginSteps;
        private readonly TabHelper _tabHelper;
        private readonly string _providerUrl;

        public ProviderRolesSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _loginSteps = new ProviderSiginPage(_context);
            _tabHelper = _context.Get<TabHelper>();
            _providerUrl = UrlConfig.SecureFunding_Provider_BaseUrl;
        }

        [Given(@"the provider logins as '(.*)'")]
        public void GivenTheProviderLoginsAs(string User)
        {
            _tabHelper.OpenInNewTab(_providerUrl);

            ProviderSiginPage siginPage = new ProviderSiginPage(_context);

            if (User.Equals("Contributor"))
                _loginSteps.SubmitValidLoginDetails(_context.GetUser<ProviderContributorUser>(), siginPage);

            else if (User.Equals("Super Contributor"))
                _loginSteps.SubmitValidLoginDetails(_context.GetUser<ProviderSuperContributorUser>(), siginPage);

            else if (User.Equals("Account Owner"))
                _loginSteps.SubmitValidLoginDetails(_context.GetUser<ProviderAccountOwnerUser>(), siginPage);
        }

        [Then(@"the user can create reservation")]
        public void ThenTheUserCanCreateReservation()
        {
             
        }

        [Then(@"the user can delete reservation")]
        public void ThenTheUserCanDeleteReservation()
        {
           
        }

        [Then(@"the user can add an apprentice")]
        public void ThenTheUserCanAddAnApprentice()
        {
             
        }

    }
}
