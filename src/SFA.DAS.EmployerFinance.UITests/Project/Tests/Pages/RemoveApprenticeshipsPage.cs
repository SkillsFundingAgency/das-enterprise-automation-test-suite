using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class RemoveApprenticeshipsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Remove apprenticeship";

        private readonly ScenarioContext _context;

        private By RemoveLabel => By.CssSelector("label[for='radio-1']");

        private By SaveButton => By.CssSelector(".button[type='submit']");

        public RemoveApprenticeshipsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EstimatedCostsPage ConfirmRemoveApprenticeship()
        {
            formCompletionHelper.Click(RemoveLabel);
            formCompletionHelper.Click(SaveButton);
            return new EstimatedCostsPage(_context);
        }
    }
}
