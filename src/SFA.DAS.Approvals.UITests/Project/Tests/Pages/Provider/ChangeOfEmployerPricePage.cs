using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerPricePage : ApprovalsBasePage
    {
        protected override string PageTitle => "What's the new agreed apprenticeship price";

        private readonly ScenarioContext _context;       
        private By Price => By.Id("Price");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        public ChangeOfEmployerPricePage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfEmployerSummaryPage EnterNewPriceAndContinue()
        {
            formCompletionHelper.EnterText(Price, "1002");
            Continue();
            return new ChangeOfEmployerSummaryPage(_context);
        }
    }
}
