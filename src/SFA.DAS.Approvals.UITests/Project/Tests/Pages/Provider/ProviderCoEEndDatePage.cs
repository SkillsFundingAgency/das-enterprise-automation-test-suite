using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEEndDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "New training end date";

        protected override bool TakeFullScreenShot => false;

        private static By EndDateMonth => By.Name("EndMonth");
        private static By EndDateYear => By.Name("EndYear");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        public ProviderCoEEndDatePage(ScenarioContext context) : base(context)  { }

        public ProviderCoEPricePage EnterNewEndDateAndContinue()
        {
            formCompletionHelper.EnterText(EndDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(EndDateYear, DateTime.UtcNow.AddYears(1).Year.ToString());
            Continue();
            return new ProviderCoEPricePage(context);
        }
    }
}
