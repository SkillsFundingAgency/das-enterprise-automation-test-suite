using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PortableFlexiJobSteps
    {
        #region context&Helpers
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper;
        #endregion

        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private AddApprenticeDetailsPage _addApprenticeDetailsPage;

        public PortableFlexiJobSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _providerApproveStepsHelper = new ProviderApproveStepsHelper(context);
        }

        [Given(@"an Employer initiates a portable flexi-job apprenticeship creation")]
        public void AnEmployerInitiatesAPortableFlexi_JobApprenticeshipCreation()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<EmployerConnectedToPortableFlexiJobProvider>(), true);
            _addApprenticeDetailsPage = _employerStepsHelper.AddsPortableFlexiJobCourseAndDeliveryModelForPilotProvider();
        }

        [Then(@"the Employer validates Portable flexi-job content on Add Apprentice Details page")]
        public void TheEmployerValidatesPortableFlexi_JobContentOnAddApprenticeDetailsPage()
        {
            _addApprenticeDetailsPage.ValidatePortableFlexiJobContent();

            _approveApprenticeDetailsPage = _addApprenticeDetailsPage.SubmitValidApprenticeDetails(false);
        }

        [Then(@"validates Portable flexi-job tag on Approve Apprentice Details and sends the cohort to the Provider for approval")]
        public void ValidatesPortableFlexi_JobTagOnApproveApprenticeDetailsAndSendsTheCohortToTheProviderForApproval()
        {
            _approveApprenticeDetailsPage.ValidatePortableFlexiJobTag();
            var cohortReference = _approveApprenticeDetailsPage.EmployerFirstApproveAndNotifyTrainingProvider().CohortReference();

            _objectContext.SetCohortReference(cohortReference);
            _objectContext.SetNoOfApprentices(1);
        }

        [Then(@"the Provider validates Portable flexi-job content and approves the cohort")]
        public void TheProviderValidatesPortableFlexi_JobContentAndApprovesTheCohort() => _providerApproveStepsHelper.ValidatePortableFlexiJobContentAndApproveCohort();

        [Given(@"the Employer creates a Portable flexi-job apprenticeship and the Provider approves it")]
        public void GivenTheEmployerCreatesAPortableFlexi_JobApprenticeshipAndTheProviderApprovesIt()
        {
            AnEmployerInitiatesAPortableFlexi_JobApprenticeshipCreation();
            TheEmployerValidatesPortableFlexi_JobContentOnAddApprenticeDetailsPage();
            ValidatesPortableFlexi_JobTagOnApproveApprenticeDetailsAndSendsTheCohortToTheProviderForApproval();
            TheProviderValidatesPortableFlexi_JobContentAndApprovesTheCohort();
        }
    }
}
