using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions
{

    [Binding]
    public class AAN_Onboarding_Steps
    {
        private readonly ScenarioContext context;

        private readonly ObjectContext objectContext;

        private readonly RestartWebDriverHelper _restartWebDriverHelper;

        private BeforeYouStartPage beforeYouStartPage;

        private CheckYourAnswersPage checkYourAnswersPage;

        private ApplicationSubmittedPage applicationSubmittedPage;

        private ShutterPage shutterPage;

        public AAN_Onboarding_Steps(ScenarioContext context)
        {
            this.context = context;

            objectContext = context.Get<ObjectContext>();

           _restartWebDriverHelper = new RestartWebDriverHelper(context);
        }

        [Given(@"an apprentice logs into the AAN portal")]
        public void GivenAnApprenticeLogsIntoTheAANPortal()
        {
            beforeYouStartPage = GetSignInPage().SubmitValidUserDetails(context.Get<AanUser>());
        }

        [When(@"the user provides all the required details for the onboarding journey")]
        public void WhenUserProvidesAllRequiredDetails()
        {
            checkYourAnswersPage = beforeYouStartPage.StartApprenticeOnboardingJourney()
                .AcceptTermsAndConditions()
                .YesHaveApprovalFromMaanagerAndContinue()
                .EnterAddressManually()
                .EnterFullEmployersDetailsAndContinue()
                .ConfirmJobtitleAndContinue()
                .ConfirmRegionAndContinue()
                .EnterInformationToJoinNetwork()
                .SelectEventsAndPromotions()
                .YesHaveEngagedWithAnAmbassadaorAndContinue();             
        }

        [Then(@"the Apprentice onboarding process should be successfully completed")]
        public void ThenApprenticeOnboardingProcessShouldBeCompleted() => applicationSubmittedPage = checkYourAnswersPage.AcceptAndSubmitApplication();

        [Then(@"the user should be redirected to the Hub page")]
        public void ThenUserShouldBeRedirectedToHubPage() => applicationSubmittedPage.ContinueToAmbassadorHub();

        [When(@"the user does not have manager permission")]
        public void WhenUserDoesNotHaveManagerPermission()
        {
            shutterPage = beforeYouStartPage.StartApprenticeOnboardingJourney().AcceptTermsAndConditions().NoHaveApprovalFromMaanagerAndContinue();
        }

        [Then(@"a shutter page should be displayed")]
        public void ThenShutterPageShouldBeDisplayed() => shutterPage.VerifyApprenticePortalLink();

        [When(@"the user should be able to modify any of the provided answers")]
        public void WhenUserShouldBeAbleToModifyAnswers()
        {
            checkYourAnswersPage.AccessChangeCurrentEmployerAndContinue()
                .EnterAddressManually()
                .ChangeVenueNameAndContinue()
                .AccessChangeCurrentJobTitleAndContinue()
                .ChangeJobtitleAndContinue()
                .AccessChangeCurrentRegionAndContinue()
                .AddOneMoreRegionAndContinue()
                .AccessChangeCurrentAreasOfInterestAndContinue()
                .AddMoreEventsAndPromotions()
                .AccessChangePreviousEngagementToNoAndContinue()
                .NoHaveEngagedWithAnAmbassadaorAndContinue();
        }

        [Then(@"the user can sign back in to the AAN platform")]
        public void ThenTheUserCanSignBackInToTheAANPlatform()
        {
            _restartWebDriverHelper.RestartWebDriver(UrlConfig.AAN_BaseUrl, "AANbaseurl");

            GetSignInPage().SubmitUserDetails_OnboardingJourneyComplete(objectContext.GetLoginCredentials());
        }

        private SignInPage GetSignInPage() => new(context);
    }
}
