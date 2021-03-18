using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class ProviderAccessDeniedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "You do not have permission to access this page";

        private readonly ScenarioContext _context;

        private By SecureFundingGoBackToHomePage => By.LinkText("Go back to home page");

        public ProviderAccessDeniedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprovalsProviderHomePage GoBackToTheServiceHomePage()
        {
            formCompletionHelper.ClickElement(SecureFundingGoBackToHomePage);
            return new ApprovalsProviderHomePage(_context);
        }
    }
}
