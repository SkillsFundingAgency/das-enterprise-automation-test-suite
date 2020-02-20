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

        public NewProviderSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the admin initates an application as main route company")]
        public void GivenTheAdminInitatesAnApplicationAsMainRouteCompany()
        {
            GotoRoatpAdminHomePage()
                .AddANewTrainingProvider()
                .EnterUkprn()
                .ConfirmOrganisationsDetails()
                .SubmitProviderTypeMain()
                .SubmitIndependentTrainingProvider()
                .EnterDob()
                .ConfirmOrganisationsDetails();
        }

        [Then(@"Organisation is successfully Added to the Register")]
        public void ThenOrganisationIsSuccessfullyAddedToTheRegister() => _roatpAdminHomePage.VerifyNewProviderHasBeenAdded();

        [Then(@"the provider status should be set to On-Boarding")]
        public void ThenTheProviderStatusShouldBeSetToOn_Boarding() => _roatpAdminHomePage.SearchTrainingProvider().VerifyMainAndEmployerTypeStatus();

        private RoatpAdminHomePage GotoRoatpAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return _roatpAdminHomePage = new SignInPage(_context).SignInWithValidDetails();
        }
    }
}
