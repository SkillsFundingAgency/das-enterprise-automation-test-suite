using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{

    [Binding]
    public class FlexiPaymentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly FlexiProviderStepsHelper _providerStepsHelper;
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper;

        private readonly ExistingAccountSteps _existingAccountSteps;
        private readonly FlexiPaymentProviderSteps _flexiPaymentProviderSteps;
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private readonly ReadApprenticeDataHelper readApprenticeDataHelper;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _providerStepsHelper = new FlexiProviderStepsHelper (_context);
            _nonLevyReservationStepsHelper = new NonLevyReservationStepsHelper(_context);

            _existingAccountSteps = new ExistingAccountSteps(_context);
            _flexiPaymentProviderSteps = new FlexiPaymentProviderSteps(_context);
            readApprenticeDataHelper = new ReadApprenticeDataHelper(context);

        }

        [Given(@"fully approved apprentices with the below data")]
        public void GivenFullyApprovedApprenticesWithTheBelowData(Table table)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount("Levy");

            _employerStepsHelper.EmployerAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            int i = 1;

            foreach (var row in table.Rows)
            {
                var inputData = row.CreateInstance<FlexiPaymentsInputDataModel>();

                ProviderAddsUln(inputData.PilotStatus, i++);
            }

            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }

        [Given(@"the Employer has an approved (Pilot|NonPilot) apprentice")]
        public void EmployerHasFullyApprovedPilotApprentice(string pilotStatus)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount("Levy");

            _employerStepsHelper.EmployerAddApprentice(1);

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            ProviderAddsUln(pilotStatus == "Pilot", 1);

            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }

        private void ProviderAddsUln(bool isPilot, int i)
        {
            if (isPilot) _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerIntoThePilot(i);
            else _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerOutOfThePilot(i);
        }

        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table) => _employerStepsHelper.EmployerAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));

        [Given(@"Pilot Provider adds apprentices to the cohort witht the following details")]
        public void GivenPilotProviderAddsApprenticesToTheCohortWithtTheFollowingDetails(Table table) => _providerStepsHelper.PilotProviderAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));

        [When(@"employer reviews and approves the cohort")]
        public void WhenEmployerReviewsAndApprovesTheCohort() => new EmployerStepsHelper(_context).EmployerReviewCohort().EmployerDoesSecondApproval();

        [Given(@"Employer changes the Total Price then approve the cohort and sends it to the training provider")]
        public void EmployerReviewsTheLearnersDetailsAndChangesTheTotalPrice() => new EmployerStepsHelper(_context).EmployerReviewCohort().SelectEditApprentice().UpdateTotalApprenticeshipPrice().EmployerSendsToTrainingProviderForReview();


        [Given(@"the Employer uses the reservation to create and approve apprentices with the following details")]
        public void WhenTheEmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(Table table) => _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(readApprenticeDataHelper.ReadApprenticeData(table), false);

        [When(@"Employer searches learner (.*) on Manage your apprentices page")]
        public void WhenEmployerSearchesLearnerOnManageYourApprenticesPage(int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage = _employerStepsHelper.ViewCurrentApprenticeDetails(true);
        }

        [Then(@"Employer (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenEmployerCannotMakeChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage.ValidateEmployerEditApprovedApprentice(action == "can");
        }
    }
}
