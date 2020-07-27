using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EditApprenticeshipsPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Edit apprenticeships in your current estimate";

        private readonly ScenarioContext _context;

        private By NoOfApprentice => By.CssSelector("input#no-of-app");

        private By SaveButton => By.CssSelector("#save");

        private By TotalFundingCost => By.CssSelector("#total-funding-cost");

        public EditApprenticeshipsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EstimatedCostsPage Edit()
        {
            formCompletionHelper.EnterText(NoOfApprentice, 2);
            formCompletionHelper.Click(TotalFundingCost);
            formCompletionHelper.Click(SaveButton);
            return new EstimatedCostsPage(_context);
        }
    }
}
