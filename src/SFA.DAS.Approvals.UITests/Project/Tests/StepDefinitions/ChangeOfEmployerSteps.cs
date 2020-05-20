using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using System;
using System.Linq;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AP_COE_01_HappyPathSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        private HomePage _homePage;

        private readonly string _oldEmployer;
        private readonly string _newEmployer;

        public AP_COE_01_HappyPathSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.GetApprovalsConfig<ApprovalsConfig>());
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context);
            _oldEmployer = context.GetRegistrationConfig<RegistrationConfig>().RE_OrganisationName;
            _newEmployer = context.GetTransfersConfig<TransfersConfig>().ReceiverOrganisationName;

        }


        [Given(@"the provider has an apprentice with a stopped status")]
        public void GivenTheProviderHasAnApprenticeWithAStoppedStatus()
        {         
            _objectContext.UpdateOrganisationName(_oldEmployer);
            Login();

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);

            _employerStepsHelper.SetCohortReference(cohortReference);

            _providerStepsHelper.Approve();

            _employerStepsHelper.StopApprenticeThisMonth();
        }

        [When(@"provider sends COE request to new employer")]
        public void WhenProviderSendsCOERequestToNewEmployer()
        {
            _providerStepsHelper.StartChangeOfEmployerJourney();

            //_providerStepsHelper.ValidateBanner(text, lockedCohort);

            var _newcohortReference = _commitmentsSqlDataHelper.GetNewcohortReference(Convert.ToString(_dataHelper.Ulns.First()));

            _employerStepsHelper.UpdateCohortReference(_newcohortReference);
        }

        [When(@"new employer aproves the cohort")]
        public void WhenNewEmployerAprovesTheCohort()
        {
            _objectContext.UpdateOrganisationName(_newEmployer);
            _employerStepsHelper.Approve();
        }


        [Then(@"a new live apprenticeship record is created")]
        public void ThenANewLiveApprenticeshipRecordIsCreated()
        {
            var manageYourApprenticePage = _employerStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }

        private void Login() => _homePage = _multipleAccountsLoginHelper.Login(_context.GetUser<TransfersUser>(), true);
    }
}
