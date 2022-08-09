using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
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
        #endregion

        private ApprenticeRequestsPage _apprenticeRequestsPage;
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private ApprenticeDetailsPage _apprenticeDetailsPage;

        public PortableFlexiJobSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Given(@"an Employer initiates a portable flexi-job apprenticeship creation")]
        public void GivenAnEmployerInitiatesAPortableFlexi_JobApprenticeshipCreation()
        {
            throw new PendingStepException();
        }

        [Then(@"the Employer validates Portable flexi-job content on Add Apprentice Details page")]
        public void ThenTheEmployerValidatesPortableFlexi_JobContentOnAddApprenticeDetailsPage()
        {
            throw new PendingStepException();
        }

        [Then(@"validates Portable flexi-job tag on Approve Apprentice Details and sends the cohort to the Provider for approval")]
        public void ThenValidatesPortableFlexi_JobTagOnApproveApprenticeDetailsAndSendsTheCohortToTheProviderForApproval()
        {
            throw new PendingStepException();
        }

        [Then(@"the Provider validates Flexi-job content and approves the cohort")]
        public void ThenTheProviderValidatesFlexi_JobContentAndApprovesTheCohort()
        {
            throw new PendingStepException();
        }
    }
}
