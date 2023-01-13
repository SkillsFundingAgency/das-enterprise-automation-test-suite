using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmWhenApprenticeshipTrainingStoppedPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.TagName("h1");
        protected override string PageTitle => "Confirm when apprenticeship training stopped";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.CssSelector("#submit-status-change");
        protected By DateIsCorrectRadionButton => By.CssSelector("#IsCorrectStopDate");
        protected By DateIsWrongRadioButton => By.CssSelector("#IsCorrectStopDate-no");


        public ConfirmWhenApprenticeshipTrainingStoppedPage(ScenarioContext context) : base(context) { }

        public EnterUkprnPage ClickOnContinueButton()
        {
            Continue();
            return new EnterUkprnPage(context);
        }

        public ApprenticeDetailsPage ClickDateIsCorrectRadionButton()
        {
            formCompletionHelper.SelectRadioOptionByLocator(DateIsCorrectRadionButton);
            Continue();

            return new ApprenticeDetailsPage(context);
        }

        public ThisApprenticeshipTrainingStopPage ClickDateIsWrongRadionButton()
        {
            formCompletionHelper.SelectRadioOptionByLocator(DateIsWrongRadioButton);
            Continue();

            return new ThisApprenticeshipTrainingStopPage(context);
        }
    }
}
