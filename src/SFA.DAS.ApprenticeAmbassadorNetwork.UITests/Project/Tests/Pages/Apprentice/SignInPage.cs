using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Threading;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class SignInPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => StubSignInApprenticeAccountsPage.StubSignInPageTitle;

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
            new StubSignInApprenticeAccountsPage(context).SubmitValidUserDetails(user).Continue();

            if (firstlogin)
            {
                if (tags.Any(x => x == "aanapprenticeonboardingreset")) context.Get<AANSqlHelper>().ResetApprenticeOnboardingJourney(user.Username);

                Thread.Sleep(2000);

                pageInteractionHelper.RefreshPage();

                objectContext.SetLoginCredentials(user);
            }
        }
    }
}
