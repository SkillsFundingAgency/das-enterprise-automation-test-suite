using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEStartDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "New training start date";

        protected override bool TakeFullScreenShot => false;

        private static By StartDateMonth => By.Name("StartMonth");
        private static By StartDateYear => By.Name("StartYear");
        protected override By ContinueButton => By.Id("save-and-continue-button");

        public ProviderCoEStartDatePage(ScenarioContext context) : base(context)  { }

        public ProviderCoEEndDatePage EndNewStartDateAndContinue()
        {
            formCompletionHelper.EnterText(StartDateMonth, DateTime.UtcNow.Month.ToString());
            formCompletionHelper.EnterText(StartDateYear, DateTime.UtcNow.Year.ToString());
            Continue();
            return new ProviderCoEEndDatePage(context);
        }
    }
}
