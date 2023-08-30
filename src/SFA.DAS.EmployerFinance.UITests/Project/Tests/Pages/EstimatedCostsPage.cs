using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EstimatedCostsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Estimated costs";

        private static By ApprenticeshipAddedTab => By.CssSelector("a[href='#apprenticeships-added']");

        private static By AccountFundsTab => By.CssSelector("a[href='#account-funds']");

        private static By AddApprenticeshipsLink => By.CssSelector("a[href*='apprenticeship/add']");

        private static By EditApprenticeshipsLink => By.CssSelector("a[href*='EditApprenticeships']");

        private static By RemoveApprenticeshipLink => By.CssSelector("a[href*='ConfirmRemoval']");

        private static By AccountFundsTable => By.CssSelector("#account-funds table tbody tr");

        public EstimatedCostsPage(ScenarioContext context) : base(context) => VerifyPage();

        public EstimatedCostsPage VerifyTabs()
        {
            formCompletionHelper.Click(AccountFundsTab);
            VerifyElement(AccountFundsTable);
            formCompletionHelper.Click(ApprenticeshipAddedTab);
            return this;
        }

        public AddApprenticeshipsToEstimateCostPage AddApprenticeships()
        {
            formCompletionHelper.ClickElement(AddApprenticeshipsLink);
            return new AddApprenticeshipsToEstimateCostPage(context);
        }

        public EditApprenticeshipsPage EditApprenticeships()
        {
            formCompletionHelper.ClickElement(EditApprenticeshipsLink);
            return new EditApprenticeshipsPage(context);
        }

        public RemoveApprenticeshipsPage RemoveApprenticeships()
        {
            formCompletionHelper.Click(RemoveApprenticeshipLink);
            return new RemoveApprenticeshipsPage(context);
        }

        public int ExistingApprenticeships() => pageInteractionHelper.FindElements(RemoveApprenticeshipLink).Count;

    }
}
