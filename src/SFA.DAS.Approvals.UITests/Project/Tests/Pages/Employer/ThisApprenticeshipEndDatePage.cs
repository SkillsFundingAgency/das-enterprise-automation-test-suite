using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ThisApprenticeshipEndDatePage : ApprovalsBasePage
    {
        protected override string PageTitle => "What is the planned end date for this apprenticeship training?";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("save-button");
        private static By NewMonth => By.Id("EndMonth");
        private static By NewYear => By.Id("EndYear");

        public ThisApprenticeshipEndDatePage(ScenarioContext context) : base(context) { }

        public ApprenticeDetailsPage EditEndDate(string month, string year)
        {
            formCompletionHelper.EnterText(NewMonth, month);
            formCompletionHelper.EnterText(NewYear, year);
            formCompletionHelper.Click(ContinueButton);
            return new NewTrainingDatePage(context);
        }
    }
}