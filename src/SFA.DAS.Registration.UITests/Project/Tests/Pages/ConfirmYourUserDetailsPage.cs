using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your user details";
        public ConfirmYourUserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public YouVeSuccessfullyAddedUserDetailsPage ConfirmNameAndContinue()
        {
            Continue();
            return new YouVeSuccessfullyAddedUserDetailsPage(context);
        }
    }
}
