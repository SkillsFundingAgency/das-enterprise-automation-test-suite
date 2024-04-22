namespace SFA.DAS.Live.SmokeTests.Project.Tests.Steps;

[Binding]
public class Steps(ScenarioContext context)
{
    private LiveHomePage _homePage;

    [Given(@"the Employer logins using existing Levy Account")]
    public void TheEmployerLoginsUsingExistingLevyAccount()
    {
        _homePage = new SignInToYourApprenticeshipServiceAccountPage(context)
            .SignInToYourApprenticeshipServiceAccount()
            .SignInToGovUkLogin()
            .EnterUsername()
            .EnterPassword()
            .EnterCode();
    }

    [Then(@"the standard header should be displayed")]
    public void ThenTheStandardHeaderShouldBeDisplayed()
    {
        _homePage.VerifyHeaders();
    }

    [Then(@"the help widget can be accessed")]
    public void TheHelpWidgetCanBeAccessed()
    {
        _homePage.AccessHelpLauncher();
    }

    [Then(@"Apprentices link should direct user to Apprentices page")]
    public void ApprenticesLinkShouldDirectUserToApprenticesPage()
    {
        new ApprenticesHomePage(context).GoToHomePage();
    }

    [Then(@"Your apprenticeship adverts link should direct user to Create an advert page")]
    public void YourApprenticeshipAdvertsLinkShouldDirectUserToCreateAnAdvertPage()
    {
        _ = new YourApprenticeshipAdvertsHomePage(context, true, false).GoToHomePage();
    }

    [Then(@"Your training providers link should direct user to Your training providers page")]
    public void YourTrainingProvidersLinkShouldDirectUserToYourTrainingProvidersPage()
    {
        new YourTrainingProvidersLinkHomePage(context).OpenProviderPermissions().GoToHomePage();
    }

    [Then(@"Find apprenticeship training link should direct user to Apprenticeship training courses page")]
    public void FindApprenticeshipTrainingLinkShouldDirectUserToApprenticeshipTrainingCoursesPage()
    {

    }

    [Then(@"Your finances link should direct user to Finance page")]
    public void YourFinancesLinkShouldDirectUserToFinancePage()
    {
        new HomePageFinancesSection_YourFinance(context).NavigateToFinancePage().GoToHomePage();
    }

    [Then(@"Your transfers link should direct user to Manage transfers page")]
    public void YourTransfersLinkShouldDirectUserToManageTransfersPage()
    {
        new HomePageFinancesSection_YourTransfers(context).NavigateToTransferMatchingPage().GoToAccountHomePage();
    }

    [Then(@"Your organisations and agreements link should direct user to Your organisations and agreements page")]
    public void YourOrganisationsAndAgreementsLinkShouldDirectUserToYourOrganisationsAndAgreementsPage()
    {
        new YourOrganisationsAndAgreementsPage(context, true).GoToHomePage();
    }

    [Then(@"Your team link should direct user to Your team page")]
    public void YourTeamLinkShouldDirectUserToYourTeamPage()
    {
        new YourTeamPage(context, true).GoToHomePage();
    }

    [Then(@"PAYE schemes link should direct user to PAYE schemes page")]
    public void PAYESchemesLinkShouldDirectUserToPAYESchemesPage()
    {
        new PAYESchemesPage(context, true).GoToHomePage();
    }
}


