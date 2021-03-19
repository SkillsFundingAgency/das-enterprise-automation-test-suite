using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ProviderAccessDeniedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You do not have permission to access this page";

        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        private By SetUpEmployerAccountGoBackToHomePage => By.LinkText("Go back to home page");

        public ProviderAccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            VerifyPage();
        }

        public void GoBackToTheProviderHomePage()
        {
            formCompletionHelper.ClickElement(SetUpEmployerAccountGoBackToHomePage);
            _providerHomePageStepsHelper.GoToProviderHomePage(true);            
        }
    }
}
