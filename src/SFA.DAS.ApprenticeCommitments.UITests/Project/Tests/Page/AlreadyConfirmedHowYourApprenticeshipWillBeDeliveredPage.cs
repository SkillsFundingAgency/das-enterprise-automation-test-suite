using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have understood how your apprenticeship will be delivered";

        public AlreadyConfirmedHowYourApprenticeshipWillBeDeliveredPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
        }
    }
}
