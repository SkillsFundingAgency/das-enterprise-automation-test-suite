using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "You have confirmed your apprenticeship details";

        public AlreadyConfirmedApprenticeshipDetailsPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyText(NotificationBar, PageTitle);
        }
    }
}
