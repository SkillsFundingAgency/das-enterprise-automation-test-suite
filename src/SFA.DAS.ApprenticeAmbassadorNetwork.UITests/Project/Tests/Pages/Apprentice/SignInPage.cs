using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SignInPage : AanBasePage
    {
        protected override string PageTitle => "Sign in to My apprenticeship";

        private static By EnterUsername => By.Id("Username");

        private static By EnterPassword => By.Id("Password");

        public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public BeforeYouStartPage SubmitValidUserDetails(AanBaseUser user)
        {
            SubmitUserDetails(user, true);

            return new BeforeYouStartPage(context);
        }

        public BeforeYouStartPage NonPrivateBetaUserDetails(AanBaseUser user)
        {
            SubmitUserDetails(user, true);

            return new BeforeYouStartPage(context);
        }

        public Apprentice_NetworkHubPage SubmitUserDetails_OnboardingJourneyComplete(AanBaseUser user)
        {
            SubmitUserDetails(user, false);

            return new Apprentice_NetworkHubPage(context);
        }

        private void SubmitUserDetails(AanBaseUser user, bool firstlogin)
        {
            formCompletionHelper.EnterText(EnterUsername, user.Username);

            formCompletionHelper.EnterText(EnterPassword, user.Password);

            if (firstlogin)
            {
                if (tags.Any(x => x == "aanapprenticeonboardingreset")) context.Get<AANSqlHelper>().ResetApprenticeOnboardingJourney(user.Username);
                objectContext.SetLoginCredentials(user);
            }

            Continue();
        }
    }
}
