using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CoeSteps : BaseSteps
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerWithMultipleAccountsUser _changeOfEmployerLevyUser;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper;

        public CoeSteps(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _changeOfEmployerLevyUser = context.GetUser<EmployerWithMultipleAccountsUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _changeOfEmployerLevyUser);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _providerApproveStepsHelper = new ProviderApproveStepsHelper(context);
            _context = context;
        }

        [Given(@"a new apprenticeship is CMAD created and fully confirmed that undergoes a Change of Employer")]
        public void GivenANewApprenticeshipIsCMADCreatedAndFullyConfirmedThatUndergoesAChangeOfEmployer()
        {
            _multipleAccountsLoginHelper.Login(_changeOfEmployerLevyUser, true);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            _cohortReferenceHelper.SetCohortReference(cohortReference);

            _providerApproveStepsHelper.EditAndApprove();
            createAccountStepsHelper.CreateAccountViaUIAndConfirmApprenticeshipViaDb().SignOutFromTheService();
            _employerStepsHelper.StopApprenticeThisMonth(StopApprentice.LeftEmployer);
            _providerStepsHelper.StartChangeOfEmployerJourney();
            _cohortReferenceHelper.UpdateCohortReference();

            _objectContext.UpdateOrganisationName(_changeOfEmployerLevyUser.SecondOrganisationName);
            _employerStepsHelper.Approve();
        }

        [Then(@"Home page has two cards with one each for current and previous confirmed apprenticeship details")]
        public void ThenHomePageHasTwoCardsWithOneEachForCurrentAndPreviousConfirmedApprenticeshipDetails()
        {
            new ApprenticeOverviewPage(_context).NavigateToHomePageFromTopNavigationLink().VerifyConfirmedCoCPageViewAndNavigateToOverviewPage();
        }
    }
}