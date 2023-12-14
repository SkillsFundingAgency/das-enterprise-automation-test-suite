using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EISteps
    {
        private readonly ScenarioContext _context;

        public EISteps(ScenarioContext context) => _context = context;

        [Then(@"View EI applications shutter page is diplayed to the Employer when navigating to View EI applications page with no applications")]
        public void ThenShutterPageIsDiplayed() => NavigateToEIHubPage().NavigateToEIViewApplicationsShutterPage();

        [Then(@"the Employer can withdraw the application")]
        public void ThenTheEmployerCanWithdrawTheApplication() => NavigateToEIHubPage().NavigateToEIViewApplicationsPage().CancelAnApplication().SelectApprenticeToCancel().ConfirmCancelApplications().ViewApplications();

        [Then(@"the Employer can add organisation and finance details")]
        public void ThenTheEmployerCanAddOrganisationAndFinanceDetails()
        {
            var email = GetEmail();

            NavigateToEIHubPage()
                .AddOrgAndFinDetails()
                .ContinueToVRFIntroductionTab1Page()
                .ContinueToVRFOrgDetailsTab2Page()
                .SubmitOrgDetails()
                .SubmitAddressDetails(email)
                .SubmitBankDetails()
                .SubmitSubmitterDetails(email)
                .AcknowledgeSummaryDetails()
                .ReturnToApplicationClosedPage();
        }

        [Then(@"the Employer is able to Amend bank details")]
        public void ThenTheEmployerIsAbleToAmendBankDetails()
        {
            var email = GetEmail();

            NavigateToEIHubPage()
                .NavigateToChangeBankDetailsPage()
                .ContinueToVRFIntroductionTab1Page()
                .ContinueToVRFOrgDetailsTab2Page()
                .SubmitOrgDetailsForAmendJourney(email)
                .SelectChangeNonBankingInfoOptionAndContinue()
                .SubmitNewRemittanceEmail(email)
                .SubmitSubmitterDetails(email)
                .AcknowledgeSummaryDetails()
                .ReturnToEIHubPage();
        }

        private string GetEmail() => _context.Get<LoginCredentialsHelper>().GetLoginCredentials().Username;

        private EIHubPage NavigateToEIHubPage() => new HomePageFinancesSection_EI(_context).NavigateToEIHubPage();
    }
}
