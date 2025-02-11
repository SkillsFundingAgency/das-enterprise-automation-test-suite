using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Employer;


[Binding, Scope(Tag = "@aanemployer")]
public class Employer_Onboarding_Steps(ScenarioContext context) : Employer_BaseSteps(context)
{
    private EmployerAmbassadorApplicationPage employerAmbassadorApplicationPage;

    private RegistrationConfirmationPage RegistrationConfirmationPage;

    private RegistrationComplete_EmployerPage applicationSubmitted_EmployerPage;

    protected readonly AANSqlHelper aANSqlHelper = context.Get<AANSqlHelper>();

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
        RegistrationConfirmationPage = employerAmbassadorApplicationPage.StartEmployerAmbassadorApplication()
            .AcceptTermsAndConditions()
            .SelectNorthEastRegion_Continue()
            .ConfirmRegionalNetwork()
            .ConfirmYourAmbassadorProfile()
            .SelectHowYouWantToBeInvolved()
            .SelectReceiveNotifications()
            .SelectEventTypes()
            .AddLocation_And_Continue()
            .ConfirmEngagement();
    }

    [Then(@"the employer onboarding process should be successfully completed")]
    public void ThenTheEmployerOnboardingProcessShouldBeSuccessfullyCompleted()
    {
        applicationSubmitted_EmployerPage = RegistrationConfirmationPage.SubmitApplication();
    }

    [Then(@"the employer should be redirected to the employer Hub page")]
    public void ThenTheEmployerShouldBeRedirectedToTheEmployerHubPage()
    {
        applicationSubmitted_EmployerPage.ContinueToAmbassadorHub();
    }

    [When(@"the employer should be able to modify any of the provided answers")]
    public void WhenTheEmployerShouldBeAbleToModifyAnyOfTheProvidedAnswers()
    {
        RegistrationConfirmationPage = employerAmbassadorApplicationPage.StartEmployerAmbassadorApplication()
            .AcceptTermsAndConditions()
            .SelectNorthEastRegion_Continue()
            .ConfirmRegionalNetwork()
            .ConfirmYourAmbassadorProfile()
            .SelectHowYouWantToBeInvolved()
            .SelectReceiveNotifications()
            .SelectEventTypes()
            .AddLocation_And_Continue()
            .ConfirmEngagement()
            .ChangeWhatCanYouOffer()
            .Add1MoreSelection();
    }

    [Then(@"the user can sign back in to the AAN Employer platform to verify the hub page")]
    public void ThenTheUserCanSignBackInToTheAANEmployerPlatformToVerifyTheHubPage()
    {
        _restartWebDriverHelper.RestartWebDriver(UrlConfig.AAN_Employer_BaseUrl, "AAN_Employer_BaseUrl");

        var user = context.GetUser<AanEmployerUser>();

        EmployerSign(user);

        _ = new Employer_NetworkHubPage(context);
    }
    [Then(@"the users can reinstate their membership within fourteen days of leaving the network")]
    public void ThenTheUsersCanReinstateTheirMembershipWithinFourteenDaysOfLeavingTheNetwork()
    {
        applicationSubmitted_EmployerPage.ContinueToAmbassadorHub()
            .AccessProfileSettings()
            .AccessLeaveTheNetwork()
             .CompleteFeedbackAboutLeavingAndContinue()
             .ConfirmAndLeave()
             .AccessRestoreMember()
             .RestoreMember();
    }
}