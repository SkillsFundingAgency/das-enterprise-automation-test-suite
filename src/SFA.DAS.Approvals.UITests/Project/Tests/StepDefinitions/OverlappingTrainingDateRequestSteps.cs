using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class OverlappingTrainingDateRequestSteps
    {

        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly EmployerWithMultipleAccountsUser _changeOfEmployerLevyUser;

        private readonly string _oldEmployerName;
        private readonly string _newEmployerName;

        public OverlappingTrainingDateRequestSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _changeOfEmployerLevyUser = context.GetUser<EmployerWithMultipleAccountsUser>();
            _oldEmployerName = _changeOfEmployerLevyUser.OrganisationName;
            _newEmployerName = _changeOfEmployerLevyUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _changeOfEmployerLevyUser);

        }

        [Given(@"Employer and provider approve an apprentice")]
        public void GivenEmployerAndProviderApproveAnApprentice()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            _objectContext.SetStartDate("01-01-2021");
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
        }

        [When(@"provider creates a draft apprentice which has an overlap")]
        public void WhenProviderCreatesADraftApprenticeWhichHasAnOverlap()
        {
            throw new PendingStepException();
        }

        [When(@"provider selects all the information is correct")]
        public void WhenProviderSelectsAllTheInformationIsCorrect()
        {
            throw new PendingStepException();
        }

        [When(@"provider selects to contact the employer themselves")]
        public void WhenProviderSelectsToContactTheEmployerThemselves()
        {
            throw new PendingStepException();
        }

        [Then(@"Vaidate not information is stored in database")]
        public void ThenVaidateNotInformationIsStoredInDatabase()
        {
            throw new PendingStepException();
        }

    }
}
