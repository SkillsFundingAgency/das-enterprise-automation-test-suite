using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EstimatedCostsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Estimated costs";

        private readonly ScenarioContext _context;

        private By ApprenticeshipAddedTab => By.CssSelector("a[href='#apprenticeships-added']");

        private By AccountFundsTab => By.CssSelector("a[href='#account-funds']");

        private By EditApprenticeshipsLink => By.CssSelector("a[href*='EditApprenticeships']");

        private By RemoveApprenticeshipLink => By.CssSelector("a[href*='ConfirmRemoval']");

        public EstimatedCostsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EstimatedCostsPage VerifyTabs()
        {
            formCompletionHelper.Click(ApprenticeshipAddedTab);
            formCompletionHelper.Click(AccountFundsTab);
            return this;
        }

        public EditApprenticeshipsPage EditApprenticeships()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(EditApprenticeshipsLink));
            return new EditApprenticeshipsPage(_context);
        }

        public RemoveApprenticeshipsPage RemoveApprenticeships()
        {
            formCompletionHelper.Click(RemoveApprenticeshipLink);
            return new RemoveApprenticeshipsPage(_context);
        }
    }
}
