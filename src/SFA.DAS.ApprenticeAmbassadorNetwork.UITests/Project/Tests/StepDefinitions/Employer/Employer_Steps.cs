using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;


[Binding, Scope(Tag = "@aanemployer")]
public class Employer_Steps : Employer_BaseSteps
{
    private EmployerAmbassadorApplicationPage employerAmbassadorApplicationPage;

    private Employer_CheckTheInformationPage employer_CheckTheInformationPage;

    private RegistrationComplete_EmployerPage applicationSubmitted_EmployerPage;

    protected readonly AANSqlHelper aANSqlHelper;

    public Employer_Steps(ScenarioContext context) : base(context) => aANSqlHelper = context.Get<AANSqlHelper>();

    [Given(@"an employer without onboarding logs into the AAN portal")]
    public void AnEmployerWithoutOnboardingLogsIntoTheAANPortal()
    {
        var user = context.GetUser<AanEmployerUser>();

        aANSqlHelper.ResetEmployerOnboardingJourney(user.Username);

        EmployerSign(user);

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

    [Then(@"the user can sign back in to the AAN Employer platform to verify the hub page")]
    public void ThenTheUserCanSignBackInToTheAANEmployerPlatformToVerifyTheHubPage()
    {
        _restartWebDriverHelper.RestartWebDriver(UrlConfig.AAN_Employer_BaseUrl, "AAN_Employer_BaseUrl");

        var user = context.GetUser<AanEmployerUser>();

        EmployerSign(user);

        _ = new Employer_NetworkHubPage(context);
    }
}