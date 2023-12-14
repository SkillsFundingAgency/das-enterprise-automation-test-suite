using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReserveFundingToTrainAndAssessAnApprenticePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reserve funding to train and assess an apprentice";

        protected override bool TakeFullScreenShot => false;

        private static By ReserveFundingButton => By.LinkText("Reserve funding");

        public ReserveFundingToTrainAndAssessAnApprenticePage(ScenarioContext context) : base(context) { }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveFundingButton()
        {
            formCompletionHelper.ClickElement(ReserveFundingButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(context);
        }
    }
}