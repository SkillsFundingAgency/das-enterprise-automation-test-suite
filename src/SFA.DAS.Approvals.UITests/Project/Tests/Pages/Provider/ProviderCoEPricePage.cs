using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEPricePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "What's the new agreed apprenticeship price";

        protected override bool TakeFullScreenShot => false;

        private static By Price => By.Id("Price");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        public ProviderCoESummaryPage EnterNewPriceAndContinue()
        {
            formCompletionHelper.EnterText(Price, "1002");
            Continue();
            return new ProviderCoESummaryPage(context);
        }
    }
}
