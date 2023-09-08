using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouVeSuccessfullyAddedUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully added user details";
        public YouVeSuccessfullyAddedUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public CreateYourEmployerAccountPage ClickContinueButtonToAcknowledge()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }

        public InvitationsPage ClickContinueToInvitationsPage()
        {
            Continue();
            return new InvitationsPage(context);
        }
    }
}
