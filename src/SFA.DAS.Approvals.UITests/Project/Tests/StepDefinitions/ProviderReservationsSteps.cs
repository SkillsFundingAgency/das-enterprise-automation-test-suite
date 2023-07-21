using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderReservationsSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderReservationStepsHelper _providerReservationStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ProviderConfig _config;
        private readonly ProviderLoginUser _login;
        private ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage;
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        private ApprovalsProviderHomePage _approvalsProviderHomePage;

        public ProviderReservationsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetProviderConfig<ProviderConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _providerReservationStepsHelper = new ProviderReservationStepsHelper();
            _login = new ProviderLoginUser { UserId = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        [Given(@"An Employer has given create reservation permission to a provider")]
        public void GivenAnEmployerHasGivenCreateReservationPermissionToAProvider()
        {
            var homePage = _loginHelper.Login(_context.GetUser<NonLevyUser>());

            _objectContext.SetProviderMakesReservationForNonLevyEmployers();

            homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickViewAgreementLink()
                .SetAgreementId();
        }

        [Given(@"the Provider with create reservation permission logs in")]
        public void GivenTheProviderWithCreateReservationPermissionLogsIn() => _approvalsProviderHomePage = _providerStepsHelper.Login(_login, true);

        [When(@"the Provider creates a reservation")]
        public void WhenThenProviderCreatesAReservation() => _providerReservationStepsHelper.StartCreateReservationAndGoToStartTrainingPage(_approvalsProviderHomePage);

        [Then(@"the Provider is told that funding can be reserved from (.*)")]
        public void ThenTheEmployerIsPresentedWithFirstMonthSecondMonthAndThirdMonthForTheApprenticeshipStart(string monthReserveFrom) =>
            _providerReservationStepsHelper.VerifyReserveFromMonth(ParseMonth(monthReserveFrom));

        [Then(@"the Provider is given options (.*), (.*) and (.*) to select start date")]
        public void ThenGivenOptionsToSelectStartDate(string firstMonth, string secondMonth, string thirdMonth) =>
            _providerReservationStepsHelper.VerifySuggestedStartMonthOptions(ParseMonth(firstMonth), ParseMonth(secondMonth), ParseMonth(thirdMonth));

        [Then(@"the Provider is (able|not able) to reserve funding for an apprenticeship course")]
        public void ThenTheEmployerCanOrCannotReserveFundingForAnApprenticeshipCourse(string ableOrNotAble)
        {
            if (ableOrNotAble == "able") _providerReservationStepsHelper.CompleteCreateReservationFromStartTrainingPage();
            else if (ableOrNotAble == "not able") _providerReservationStepsHelper.VerifyCreateReservationCannotBeCompleted();
        }

        [When(@"Provider creates a reservation and adds (.*) apprentices and approves the cohort and sends to Employer to approve")]
        public void WhenProviderCreatesAReservationAndAddsApprenticeSAndApprovesTheCohortAndSendsToEmployerToApprove(int numberOfApprentices)
        {
            _providerAddApprenticeDetailsPage = _providerStepsHelper.ProviderMakeReservationThenGotoAddApprenticeDetails(_login);
            _providerStepsHelper.AddApprentice(_providerAddApprenticeDetailsPage, numberOfApprentices).SubmitApprove();
        }

        [Then(@"Provider can make a reservation")]
        public void ThenProviderCanMakeAReservation() => _providerAddApprenticeDetailsPage = _providerStepsHelper.ProviderMakeReservationThenGotoAddApprenticeDetails(_login);

        [Then(@"Provider can add an apprentice")]
        public void ThenProviderCanAddAnApprentice() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.AddApprentice(_providerAddApprenticeDetailsPage, 1);

        [Then(@"Provider can edit an apprentice")]
        public void ThenProviderCanEditAnApprentice() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.EditApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider can delete an apprentice")]
        public void ThenProviderCanDeleteAnApprentice() => _providerStepsHelper.DeleteApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider can delete the funding")]
        public void ThenProvidercanDeleteTheFunding() => _providerStepsHelper
            .NavigateToProviderHomePage().GoToManageYourFunding().DeleteTheReservedFunding().YesDeleteThisReservation();

        [Then(@"the Provider can access Manage Funding Page to reserve more funding")]
        public void ThenTheProviderCanAccessManageFundingPageToReserveMoreFunding() => _providerStepsHelper
            .NavigateToProviderHomePage().GoToManageYourFunding().ClickReserveMoreFundingLink();
    }
}
