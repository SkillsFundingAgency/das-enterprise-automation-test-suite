using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class CoeSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ApprenticeDataHelper _apprenticeDataHelper;
        private readonly EditedApprenticeDataHelper _editedApprenticeDataHelper;
        private readonly EditedApprenticeCourseDataHelper _editedApprenticeCourseDataHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly ApprenticeCommitmentsSqlDbHelper _aComtSqlDbHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ASCoCEmployerUser _user;

        private CoCConfirmMyApprenticeDetailsPage coCConfirmMyApprenticeDetailsPage;

        private readonly ChangeOfEmployerLevyUser _changeOfEmployerLevyUser;

        private readonly string _oldEmployerName;
        private readonly string _newEmployerName;

        public CoeSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _aComtSqlDbHelper = context.Get<ApprenticeCommitmentsSqlDbHelper>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _apprenticeDataHelper = context.Get<ApprenticeDataHelper>();
            _editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();
            _editedApprenticeCourseDataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            _user = _context.GetUser<ASCoCEmployerUser>();
            _changeOfEmployerLevyUser = context.GetUser<ChangeOfEmployerLevyUser>();
            _oldEmployerName = _changeOfEmployerLevyUser.OrganisationName;
            _newEmployerName = _changeOfEmployerLevyUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _changeOfEmployerLevyUser);
        }

        [Given(@"an apprenticeship has new employer")]
        public void GivenAnApprenticeshipHasNewEmployer()
        {
            _multipleAccountsLoginHelper.Login(_changeOfEmployerLevyUser, true);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);

            _employerStepsHelper.SetCohortReference(cohortReference);

            _providerStepsHelper.Approve();

            createAccountStepsHelper.CreateAccountAndConfirmApprenticeshipViaDb().SignOutFromTheService();

            _employerStepsHelper.StopApprenticeThisMonth();

            _providerStepsHelper.StartChangeOfEmployerJourney();

            _employerStepsHelper.UpdateNewCohortReference();

            _objectContext.UpdateOrganisationName(_newEmployerName);

            _employerStepsHelper.Approve();
        }
    }
}