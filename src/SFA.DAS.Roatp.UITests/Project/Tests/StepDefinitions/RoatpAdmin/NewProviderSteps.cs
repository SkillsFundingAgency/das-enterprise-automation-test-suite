using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpAdmin
{
    [Binding]
    public class NewProviderSteps
    {
        private readonly ScenarioContext _context;
        private RoatpAdminHomePage _roatpAdminHomePage;

        public NewProviderSteps(ScenarioContext context) => _context = context;

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
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            _roatpAdminHomePage = new SignInPage(_context).SignInWithValidDetails();

            _roatpAdminHomePage
                .AddANewTrainingProvider()
                .EnterUkprn()
                .ConfirmOrganisationsDetails()
                .SubmitProviderType(providerType)
                .SubmitOrganisationType()
                .EnterDob()
                .ConfirmOrganisationsDetails();
        }
    }
}
