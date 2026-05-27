using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReserveFundingPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Reserve funding";

        protected override bool TakeFullScreenShot => false;

        private static By ReserveFundingButton => By.LinkText("Reserve funding");

        public DoYouKnowWhichTrainingCourseYourLearnerWillTakePage ClickReserveFundingButton()
        {
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new DoYouKnowWhichTrainingCourseYourLearnerWillTakePage(context);
        }
    }
}