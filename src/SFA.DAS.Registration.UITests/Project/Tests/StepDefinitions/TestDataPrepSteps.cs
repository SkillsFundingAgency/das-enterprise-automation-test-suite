using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestDataPrepSteps
    {
        private readonly ScenarioContext _context;

        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;

        private HomePage _homePage;

        public TestDataPrepSteps(ScenarioContext context)
        {
            _context = context;

            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        }

        [When(@"the Employer logins using existing AddMultiplePayeLevyUser Account")]
        public void WhenTheEmployerLoginsUsingExistingAddMultiplePayeLevyUserAccount()
        {
            _homePage = _employerPortalLoginHelper.Login(_context.GetUser<AddMultiplePayeLevyUser>(), true);
        }

        [Then(@"the Employer is able to Add multiple Levy PAYE scheme to the Account")]
        public void ThenTheEmployerIsAbleToAddMultipleLevyPAYESchemeToTheAccount()
        {
            int noOfPayeToAdd = int.Parse(_context.GetUser<AddMultiplePayeLevyUser>().NoOfPayeToAdd);

            var page = _homePage.GotoPAYESchemesPage().ClickAddNewSchemeButton();

            for (int i = 0; i < noOfPayeToAdd; i++)
            {
                page = page.ContinueToGGSignIn().EnterPayeDetailsAndContinue(i).ClickContinueInConfirmPAYESchemePage().SelectAddAnotherPAYEScheme();
            }
        }
    }
}
