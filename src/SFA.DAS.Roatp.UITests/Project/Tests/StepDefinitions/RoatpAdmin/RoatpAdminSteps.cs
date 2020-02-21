using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpAdmin
{
    [Binding]
    public class RoatpAdminSteps
    {
        private readonly ScenarioContext _context;
        private RoatpAdminHomePage _roatpAdminHomePage;

        public RoatpAdminSteps(ScenarioContext context) => _context = context;

        [Then(@"the admin can download list of training providers")]
        public void ThenTheAdminCanDownloadListOfTrainingProviders() => GoToRoatpAdminHomePage().DownloadRegister();

        [Given(@"the admin initates an application as (Main provider|Employer provider|Supporting provider)")]
        public void GivenTheAdminInitatesAnApplication(string providerType) => InitatesAnApplication(providerType);

        [Then(@"Organisation is successfully Added to the Register")]
        public void ThenOrganisationIsSuccessfullyAddedToTheRegister() => _roatpAdminHomePage.VerifyNewProviderHasBeenAdded();

        [Then(@"the provider status should be set to On-Boarding")]
        public void ThenTheProviderStatusShouldBeSetToOn_Boarding() => _roatpAdminHomePage.SearchTrainingProvider().VerifyMainAndEmployerTypeStatus();

        [Then(@"the provider status should be set to Active")]
        public void ThenTheProviderStatusShouldBeSetToActive() => _roatpAdminHomePage.SearchTrainingProvider().VerifySupportingProviderTypeStatus();

        private void InitatesAnApplication(string providerType)
        {
            GoToRoatpAdminHomePage()
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

            return _roatpAdminHomePage = new SignInPage(_context).SignInWithValidDetails();
        }
    }
}
