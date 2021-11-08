using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ConfigurationBuilder;
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

        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ChangeOfEmployerLevyUser _changeOfEmployerLevyUser;

        public CoeSteps(ScenarioContext context) : base(context)
        {
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
            _changeOfEmployerLevyUser = context.GetUser<ChangeOfEmployerLevyUser>();
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _changeOfEmployerLevyUser);
        }

        [Given(@"an apprenticeship has new employer")]
        public void GivenAnApprenticeshipHasNewEmployer()
        {
            _multipleAccountsLoginHelper.Login(_changeOfEmployerLevyUser, true);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);

            _employerStepsHelper.SetCohortReference(cohortReference);

            _providerStepsHelper.Approve();

            createAccountStepsHelper.CreateAccountViaUIAndConfirmApprenticeshipViaDb().SignOutFromTheService();

            _employerStepsHelper.StopApprenticeThisMonth();

            _providerStepsHelper.StartChangeOfEmployerJourney();

            _employerStepsHelper.UpdateNewCohortReference();

            _objectContext.UpdateOrganisationName(_changeOfEmployerLevyUser.SecondOrganisationName);

            _employerStepsHelper.Approve();
        }
    }
}