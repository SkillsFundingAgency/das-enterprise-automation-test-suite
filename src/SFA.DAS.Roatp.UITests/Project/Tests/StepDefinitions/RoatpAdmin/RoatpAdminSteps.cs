using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpAdmin
{
    [Binding]
    public class RoatpAdminSteps
    {
        private readonly ScenarioContext _context;
        private RoatpAdminHomePage _roatpAdminHomePage;
        private ResultsFoundPage _resultsFoundPage;

        public RoatpAdminSteps(ScenarioContext context) => _context = context;

        [When(@"the admin searches for a provider by partial provider name")]
        public void WhenTheAdminSearchesForAProviderByPartialProviderName() => _resultsFoundPage = GoToRoatpAdminHomePage(_resultsFoundPage).SearchTrainingProvider("PEOPLE");

        [Then(@"the admin should be taken to multiple results found page")]
        public void ThenTheAdminShouldBeTakenToMultipleResultsFoundPage() => _resultsFoundPage.VerifyMultipleMatchingResults();

        [When(@"the admin searches for a provider by provider name")]
        public void WhenTheAdminSearchesForAProviderByProviderName() => _resultsFoundPage = GoToRoatpAdminHomePage().SearchTrainingProviderByName();

        [When(@"the admin searches for a provider by ukprn")]
        public void WhenTheAdminSearchesForAProviderByUkprn() => _resultsFoundPage = GoToRoatpAdminHomePage(_resultsFoundPage).SearchTrainingProviderByUkprn();

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
        public void ThenTheAdminCanDownloadListOfTrainingProviders() => GoToRoatpAdminHomePage().DownloadRegister();

        [Given(@"the admin initates an application as (Main provider|Employer provider|Supporting provider)")]
        public void GivenTheAdminInitatesAnApplication(string providerType) => _roatpAdminHomePage = InitatesAnApplication(providerType);

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
        public void ThenOrganisationIsSuccessfullyAddedToTheRegister() => _roatpAdminHomePage.VerifyNewProviderHasBeenAdded();

        [Then(@"the provider status should be set to On-Boarding")]
        public void ThenTheProviderStatusShouldBeSetToOn_Boarding() => _roatpAdminHomePage.SearchTrainingProviderByName().VerifyMainAndEmployerTypeStatus();

        [Then(@"the provider status should be set to Active")]
        public void ThenTheProviderStatusShouldBeSetToActive() => _roatpAdminHomePage.SearchTrainingProviderByName().VerifySupportingProviderTypeStatus();

        private RoatpAdminHomePage InitatesAnApplication(string providerType)
        {
            return GoToRoatpAdminHomePage()
                .AddANewTrainingProvider()
                .EnterUkprn()
                .ConfirmOrganisationsDetails()
                .SubmitProviderType(providerType)
                .SubmitOrganisationType()
                .EnterDob()
                .ConfirmOrganisationsDetails();
        }

        private RoatpAdminHomePage GoToRoatpAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }

        private RoatpAdminHomePage GoToRoatpAdminHomePage(ResultsFoundPage resultsFoundPage) => resultsFoundPage.GetRoatpAdminHomePage();

    }
}
