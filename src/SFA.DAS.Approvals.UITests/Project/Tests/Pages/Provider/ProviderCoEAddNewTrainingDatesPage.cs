using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEAddNewTrainingDatesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Add new training dates";

        protected override bool TakeFullScreenShot => false;

        private static By StartDateMonth => By.Name("StartMonth");
        private static By StartDateYear => By.Name("StartYear");
        private static By EndDateMonth => By.Name("EndMonth");
        private static By EndDateYear => By.Name("EndYear");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        public ProviderCoEPricePage EnterNewTrainingDatesAndContinue()
        {
            formCompletionHelper.EnterText(StartDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(StartDateYear, DateTime.UtcNow.Year.ToString());
            formCompletionHelper.EnterText(EndDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(EndDateYear, DateTime.UtcNow.AddYears(1).Year.ToString());
            Continue();
            return new ProviderCoEPricePage(context);
        }
    }
}
