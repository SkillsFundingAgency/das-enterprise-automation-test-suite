namespace SFA.DAS.RoatpAdmin.Service.Project.StepDefinitions.RoatpAdmin;

[Binding]
public class RoatpAdminSteps
{
    private RoatpAdminHomePage _roatpAdminHomePage;
    private SearchPage _searchPage;
    private ResultsFoundPage _resultsFoundPage;
    private readonly OldRoatpAdminStepsHelper _roatpAdminStepsHelper;


    public RoatpAdminSteps(ScenarioContext context) => _roatpAdminStepsHelper = new OldRoatpAdminStepsHelper(context);

    [When(@"the admin searches for a provider by partial provider name")]
    public void WhenTheAdminSearchesForAProviderByPartialProviderName() => _resultsFoundPage = _resultsFoundPage.GoToSearchPage().SearchTrainingProvider("PEOPLE");

    [Then(@"the admin should be taken to multiple results found page")]
    public void ThenTheAdminShouldBeTakenToMultipleResultsFoundPage() => _resultsFoundPage.VerifyMultipleMatchingResults();

    [When(@"the admin searches for a provider by provider name")]
    public void WhenTheAdminSearchesForAProviderByProviderName() => _resultsFoundPage = _roatpAdminStepsHelper.GoToRoatpAdminHomePage().SearchForTrainingProvider().SearchTrainingProviderByName();

    [When(@"the admin searches for a provider by ukprn")]
    public void WhenTheAdminSearchesForAProviderByUkprn() => _resultsFoundPage = _resultsFoundPage.GoToSearchPage().SearchTrainingProviderByUkprn();

    [Then(@"the admin should be taken to one provider name result found page")]
    public void ThenTheAdminShouldBeTakenToOneProviderNameResultFoundPage() => _resultsFoundPage.VerifyOneProviderNameResultFound();

    [Then(@"the admin should be taken to one provider ukprn result found page")]
    public void ThenTheAdminShouldBeTakenToOneProviderUkprnResultFoundPage() => _resultsFoundPage.VerifyOneProviderUkprnResultFound();

    [Then(@"the admin can acess all the Update links")]
    public void ThenTheAdminCanAcessAllTheUpdateLinks()
    {
        _resultsFoundPage = _resultsFoundPage.ClickChangeLegalNameLink()
        .ClickBackLink()
        .ClickChangeUkprnLink()
        .ClickBackLink()
        .ClickChangeStatusLink()
        .ClickBackLink()
        .ClickChangeProviderTypeLink()
        .ClickBackLink()
        .ClickChangeOrganisationTypeLink()
        .ClickBackLink()
        .ClickChangeTradingNameLink()
        .ClickBackLink()
        .ClickChangeCompanyNumberLink()
        .ClickBackLink()
        .ClickChangeCharityNumberLink()
        .ClickBackLink()
        .ClickChangeApplicationDateDeterminedLink()
        .ClickBackLink();
    }

    [Then(@"the admin can download list of training providers")]
    public void ThenTheAdminCanDownloadListOfTrainingProviders() => _roatpAdminStepsHelper.GoToRoatpAdminHomePage().DownloadRegister();

    [Given(@"the admin initates an application as (Main provider|Employer provider|Supporting provider)")]
    public void GivenTheAdminInitatesAnApplication(string providerType) => _searchPage = _roatpAdminStepsHelper.InitatesAnApplication(providerType);

    [Given(@"the Provider is added to the register as (Main provider|Employer provider|Supporting provider)")]
    public void GivenTheProviderIsAddedToTheRegisterAsSupportingProvider(string providerType)
    {
        _searchPage = _roatpAdminStepsHelper.
            InitatesAnApplication(providerType)
            .VerifyNewProviderHasBeenAdded();
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
    public void ThenOrganisationIsSuccessfullyAddedToTheRegister() => _roatpAdminHomePage = _searchPage.VerifyNewProviderHasBeenAdded().ReturnToDahsboard();

    [Then(@"the provider status should be set to On-Boarding")]
    public void ThenTheProviderStatusShouldBeSetToOn_Boarding() => _roatpAdminHomePage.SearchForTrainingProvider().SearchTrainingProviderByName().VerifyProviderStatusAsOnBoarding();

    [Then(@"the provider status should be set to Active")]
    public void ThenTheProviderStatusShouldBeSetToActive() => _roatpAdminHomePage.SearchForTrainingProvider().SearchTrainingProviderByName().VerifyProviderStatusAsActive();
}
