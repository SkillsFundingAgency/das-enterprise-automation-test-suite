using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhatIsTheNewPricePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => $"What is the agreed price of completing the training with {changeOfPartyConfig.NewProviderName}?";

        protected override string AccessibilityPageTitle => "What is the agreed price of completing the training with new provider";

        private static By NewPriceInput => By.Id("input-newprice");
        private static By ContinueBtn => By.Id("continue-button");

        public WhatIsTheNewPricePage EnterInvalidPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, -1000);
            formCompletionHelper.Click(ContinueBtn);

            return this;
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterNewPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, 1000);
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(context);
        }

        public EmployerChangeOfProviderCheckYourAnswersPage EnterUpdatedNewPrice()
        {
            formCompletionHelper.EnterText(NewPriceInput, 2000);
            formCompletionHelper.Click(ContinueBtn);

            return new EmployerChangeOfProviderCheckYourAnswersPage(context);
        }
    }
}
