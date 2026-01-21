namespace SFA.DAS.RoatpAdmin.Service.Project.StepDefinitions.RoatpAdmin;

[Binding]
public class RoatpAdminSteps(ScenarioContext context)
{
    private RoatpAdminHomePage _roatpAdminHomePage;
    private SearchPage _searchPage;
    private SuccessPage _successPage;
    private RoatpAdminMiniHomePage _roatpAdminMiniHomePage;
    private ResultsFoundPage _resultsFoundPage;
    private readonly OldRoatpAdminStepsHelper _roatpAdminStepsHelper = new(context);


    [When(@"the admin searches for a provider by provider name")]
    public void WhenTheAdminSearchesForAProviderByProviderName() => _resultsFoundPage =
        _roatpAdminStepsHelper.GoToRoatpAdminHomePage().
        GoTOMiniDashBoardPage().
        SearchForTrainingProvider().SearchTrainingProviderByName();


    [Then(@"the admin can acess all the Update links")]
    public void ThenTheAdminCanAcessAllTheUpdateLinks()
    {
        _resultsFoundPage = _resultsFoundPage.ClickChangeStatusLink()
        .ClickBackLink()
        .ClickChangeProviderTypeLink()
        .ClickBackLink()
        .ClickChangeOrganisationTypeLink()
        .ClickBackLink()
        .ClickChangeOfferApprenticeshipUnitLink()
        .ClickBackLink();
    }

    [Then(@"the admin can download list of training providers")]
    public void ThenTheAdminCanDownloadListOfTrainingProviders() => _roatpAdminStepsHelper.GoToRoatpAdminHomePage().DownloadRegister();

    [Given(@"the admin initates an application as (Main provider|Employer provider|Supporting provider)")]
    public void GivenTheAdminInitatesAnApplication(string providerType) => _roatpAdminMiniHomePage = _roatpAdminStepsHelper.InitatesAnApplication(providerType);

    [Given(@"the Provider is added to the register as (Main provider|Employer provider|Supporting provider)")]
    public void GivenTheProviderIsAddedToTheRegisterAsSupportingProvider(string providerType)
    {
        _roatpAdminMiniHomePage = _roatpAdminStepsHelper.
            InitatesAnApplication(providerType);
    }

    [When(@"the admin update the provider details")]
    public void WhenTheAdminUpdateTheProviderDetails()
    {
        _resultsFoundPage = _resultsFoundPage
            .ClickChangeProviderTypeLink()
            .ConfirmNewProviderTypeAsEmloyer()
            .ClickChangeOrganisationTypeLink()
            .ConfirmNewOrganisationType();
    }

    [Then(@"changes made are reflected on provider page")]
    public void ThenChangesMadeAreReflectedOnProviderPage()
    {
        _resultsFoundPage.VerifyProvideType("Employer");

        _resultsFoundPage.VerifyOrganisationType();

        _resultsFoundPage = _resultsFoundPage.ClickChangeProviderTypeLink().ConfirmNewProviderTypeAsMain();
    }

    [Then(@"Organisation is successfully Added to the Register")]
    public void ThenOrganisationIsSuccessfullyAddedToTheRegister() => _resultsFoundPage = _roatpAdminMiniHomePage.SearchForTrainingProvider()
        .SearchTrainingProviderByName();

    [Then(@"the provider status should be set to On-Boarding")]
    public void ThenTheProviderStatusShouldBeSetToOn_Boarding() => _resultsFoundPage.VerifyProviderStatusAsOnBoarding();
    //_roatpAdminHomePage.SearchForTrainingProvider().SearchTrainingProviderByName().VerifyProviderStatusAsOnBoarding();

    [Then(@"the provider status should be set to Active")]
    public void ThenTheProviderStatusShouldBeSetToActive() => _resultsFoundPage.VerifyProviderStatusAsActive();
    //_roatpAdminHomePage.SearchForTrainingProvider().SearchTrainingProviderByName().VerifyProviderStatusAsActive();
}
