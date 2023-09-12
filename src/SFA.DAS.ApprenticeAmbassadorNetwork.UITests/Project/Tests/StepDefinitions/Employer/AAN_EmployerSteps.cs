using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer
{

    [Binding, Scope(Tag = "@aanemployer")]
    public class AAN_EmployerSteps : AAN_E_BaseSteps
    {
        private EmployerAmbassadorApplicationPage employerAmbassadorApplicationPage;

        private Employer_CheckTheInformationPage employer_CheckTheInformationPage;

        private ApplicationSubmitted_EmployerPage applicationSubmitted_EmployerPage;

        public AAN_EmployerSteps(ScenarioContext context) : base(context) { }

        [Given(@"an employer without onboarding logs into the AAN portal")]
        public void AnEmployerWithoutOnboardingLogsIntoTheAANPortal()
        {
            var username = (context.GetUser<AanEmployerUser>());
            aANSqlHelper.ResetEmployerOnboardingJourney(username.Username);
            new StubSignInPage(context).Login(username).Continue();

            employerAmbassadorApplicationPage = new EmployerAmbassadorApplicationPage(context);
        }

        [When(@"the employer provides all the required details for the employer onboarding journey")]
        public void WhenTheEmployerProvidesAllTheRequiredDetailsForTheEmployerOnboardingJourney()
        {
            employer_CheckTheInformationPage = employerAmbassadorApplicationPage.StartEmployerAmbassadorApplication()
                .AcceptTermsAndConditions()
                .ConfirmAreasOfWorkAndContinue()
                .SelectMeetOtherEmployerAmbassador_BuildProfileAndContinue()
                .YesHaveEngagedWithAmbassadorAndContinue();
        }

        [Then(@"the employer onboarding process should be successfully completed")]
        public void ThenTheEmployerOnboardingProcessShouldBeSuccessfullyCompleted()
        {
            applicationSubmitted_EmployerPage = employer_CheckTheInformationPage.SubmitApplication();
        }

        [Then(@"the employer should be redirected to the employer Hub page")]
        public void ThenTheEmployerShouldBeRedirectedToTheEmployerHubPage()
        {
            applicationSubmitted_EmployerPage.ContinueToAmbassadorHub();
        }

        [When(@"the employer should be able to modify any of the provided answers")]
        public void WhenTheEmployerShouldBeAbleToModifyAnyOfTheProvidedAnswers()
        {
            employer_CheckTheInformationPage = employerAmbassadorApplicationPage.StartEmployerAmbassadorApplication()
                .AcceptTermsAndConditions()
                .ConfirmAreasOfWorkAndContinue()
                .SelectMeetOtherEmployerAmbassador_BuildProfileAndContinue()
                .YesHaveEngagedWithAmbassadorAndContinue()
                .ChangeRegionLocationAndPreferences()
                .Add3MoreRegionsAndContinue()
                .ChangeJourney_ConfirmLocalAsNorthEastAndContinue()
                .ChangeReasonsForApply()
                .Add_IncreasingEngagementWithSchoolsAndCollegesAndContinue()
                .ChangeSupportNeeded()
                .Add_ProjectManageAndContinue()
                .ChangePreviousEngagement()
                .NoHaveEngagedWithAmbassadorAndContinue();
        }
    }
}