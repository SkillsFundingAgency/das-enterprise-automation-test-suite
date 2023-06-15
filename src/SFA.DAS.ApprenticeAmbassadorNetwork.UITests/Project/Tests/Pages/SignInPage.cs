using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class SignInPage : AanBasePage
    {
        protected override string PageTitle => "Sign in to My apprenticeship";

        private static By EnterUsername => By.Id("Username");

        private static By EnterPassword => By.Id("Password");

        public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public BeforeYouStartPage SubmitValidUserDetails(NonAccountUser user)
        {
            SubmitUserDetails(user);
            
            return new BeforeYouStartPage(context);
        }

        public AccessDeniedPage NonPrivateBetaUserDetails(NonAccountUser user)
        {
            SubmitUserDetails(user);

            return new AccessDeniedPage(context);
        }

        public NetworkHubPage SubmitUserDetails_OnboardingJourneyComplete(NonAccountUser user)
        {
            SubmitUserDetails(user);

            return new NetworkHubPage(context);
        }

        private void SubmitUserDetails(NonAccountUser user)
        {
            formCompletionHelper.EnterText(EnterUsername, user.Username);

            formCompletionHelper.EnterText(EnterPassword, user.Password);

            if (tags.Any(x => x == "aanreset")) context.Get<AANSqlDataHelper>().ResetApprenticeOnboardingJourney(user.Username);

            objectContext.SetLoginCredentials(user);

            Continue();
        }
    }
}
