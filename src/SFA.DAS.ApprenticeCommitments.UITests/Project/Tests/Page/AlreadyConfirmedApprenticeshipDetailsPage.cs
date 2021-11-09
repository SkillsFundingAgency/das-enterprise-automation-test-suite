using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "";
        private string GreenTickTextInfo => "You have confirmed these are the details of your apprenticeship";

        public AlreadyConfirmedApprenticeshipDetailsPage(ScenarioContext context) : base(context) =>
            pageInteractionHelper.VerifyText(GreenTickText, GreenTickTextInfo);
    }
}
