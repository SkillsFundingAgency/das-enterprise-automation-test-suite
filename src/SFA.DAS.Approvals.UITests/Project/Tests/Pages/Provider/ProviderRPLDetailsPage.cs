using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class AddRPLDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add recognition of prior learning details";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        private static By TrainingTotalHoursTextBox => By.Id("TrainingTotalHours");
        private static By DurationReducedByHoursTextBox => By.Id("DurationReducedByHours");
        private static By DurationReducedByTextBox => By.Id("DurationReducedBy");
        private static By PriceReduced => By.Id("PriceReduced");

        public AddRPLDetailsPage(ScenarioContext context) : base(context) { }

        public void EnterRPLDataAndContinue()
        {
            formCompletionHelper.EnterText(TrainingTotalHoursTextBox, RPLDataHelper.TrainingTotalHours);
            formCompletionHelper.EnterText(DurationReducedByHoursTextBox, RPLDataHelper.DurationReducedByHours);
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(DurationReducedByTextBox, RPLDataHelper.DurationReducedBy);
            formCompletionHelper.EnterText(PriceReduced, RPLDataHelper.PriceReducedBy);

            Continue();
        }
    }
}
