using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class HomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly RegistrationConfig _registrationConfig;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;

        public HomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _registrationConfig = _context.GetRegistrationConfig<RegistrationConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public HomePage GotoEmployerHomePage()
        {
            _tabHelper.OpenInNewtab(_registrationConfig.EmployerApprenticeshipServiceBaseURL);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin();
            }

            if (_loginHelper.IsYourAccountPageDisplayed())
            {
                return new YourAccountsPage(_context)
                    .GoToHomePage(_objectContext.GetOrganisationName());
            }

            return new HomePage(_context);
        }
    }
}