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

        private By AddApprenticeshipsLink => By.CssSelector("a[href*='apprenticeship/add']");

        private By EditApprenticeshipsLink => By.CssSelector("a[href*='EditApprenticeships']");

        private By RemoveApprenticeshipLink => By.CssSelector("a[href*='ConfirmRemoval']");

        private By AccountFundsTable => By.CssSelector("#account-funds table tbody tr");

        public EstimatedCostsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EstimatedCostsPage VerifyTabs()
        {
            formCompletionHelper.Click(AccountFundsTab);
            VerifyPage(AccountFundsTable);
            formCompletionHelper.Click(ApprenticeshipAddedTab);
            return this;
        }

        public AddApprenticeshipsToEstimateCostPage AddApprenticeships()
        {
            formCompletionHelper.ClickElement(AddApprenticeshipsLink);
            return new AddApprenticeshipsToEstimateCostPage(_context);
        }

        public EditApprenticeshipsPage EditApprenticeships()
        {
            formCompletionHelper.ClickElement(EditApprenticeshipsLink);
            return new EditApprenticeshipsPage(_context);
        }

        public RemoveApprenticeshipsPage RemoveApprenticeships()
        {
            formCompletionHelper.Click(RemoveApprenticeshipLink);
            return new RemoveApprenticeshipsPage(_context);
        }

        public int ExistingApprenticeships() => pageInteractionHelper.FindElements(RemoveApprenticeshipLink).Count;

    }
}
