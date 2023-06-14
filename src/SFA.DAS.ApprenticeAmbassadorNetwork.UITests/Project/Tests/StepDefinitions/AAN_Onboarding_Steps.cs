using NUnit.Framework;
using Polly;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AAN_Onboarding_Steps
    {
        private readonly ScenarioContext context;
        private readonly AANConfig config;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;

        public AAN_Onboarding_Steps(ScenarioContext context)
        {
            this.context = context;
            config = context.GetAANConfig<AANConfig>();
           _restartWebDriverHelper = new RestartWebDriverHelper(context);
        }

        [Given(@"the provider logs into AAN portal")]
        public void GivenTheProviderLogsIntoAANPortal()
        {
            context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_BaseUrl);
            new SignInPage(context).SubmitValidUserDetails(config.AANUserName, config.AANPassword);
        }

        [Given(@"the non Private beta provider logs into AAN portal")]
        public void GivenThNonPrivateBetaProviderLogsIntoAANPortal()
        {
            context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_BaseUrl);
            new SignInPage(context).NonPrivateBetaUserDetails(config.AANPassword);

        }

        [When(@"the user provides all the required details for the onboarding journey")]
        public void WhenUserProvidesAllRequiredDetails()
        {
            new BeforeYouStartPage(context).StartApprenticeOnboardingJourney()
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
        public void ThenApprenticeOnboardingProcessShouldBeCompleted()
        {
            new CheckYourAnswersPage(context).AcceptAndSubmitApplication();
        }

        [Then(@"the user should be redirected to the Hub page")]
        public void ThenUserShouldBeRedirectedToHubPage()
        {
            new ApplicationSubmittedPage(context).ContinueToAmbassadorHub();
        }

        [When(@"the user does not have manager permission")]
        public void WhenUserDoesNotHaveManagerPermission()
        {
            new BeforeYouStartPage(context).StartApprenticeOnboardingJourney()
                .AcceptTermsAndConditions().
                NoHaveApprovalFromMaanagerAndContinue();
        }

        [Then(@"a shutter page should be displayed")]
        public void ThenShutterPageShouldBeDisplayed()
        {
            new ShutterPage(context).VerifyApprenticePortalLink();
        }

        [When(@"the user should be able to modify any of the provided answers")]
        public void WhenUserShouldBeAbleToModifyAnswers()
        {
            new CheckYourAnswersPage(context).AccessChangeCurrentEmployerAndContinue()
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

        [Then(@"an Access Denied page should be displayed")]
        public void ThenAccessDeniedPageShouldBeDisplayed()
        {
            new AccessDeniedPage(context).VerifyHomeLink();
        }

        [When(@"the user signs back in to the AAN platform")]
        public void WhenUserSignsBackInToAANPlatform()
        {
            _restartWebDriverHelper.RestartWebDriver(UrlConfig.AAN_BaseUrl, "AANbaseurl");
            new SignInPage(context).SubmitUserDetails_OnboardingJourneyComplete(config.AANUserName, config.AANPassword);
        }
        [Then(@"the user should land on AAN Hub page")]
        public void ThenUserShouldLandOnAANHubPage()
        {

        }
    }
}
