using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{

    [Binding]
    public class FlexiPaymentTransferSteps
    {
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;
        private readonly ObjectContext _objectContext;
        private readonly TransfersCreateCohortStepsHelper _transfersCreateCohortStepsHelper;
        private readonly TransferEmployerStepsHelper _transferEmployerStepsHelper;
        private readonly TransfersUser _transfersUser;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;

        private readonly string _sender;
        private readonly string _receiver;

        private readonly ReadApprenticeDataHelper readApprenticeDataHelper;

        public FlexiPaymentTransferSteps(ScenarioContext context)
        {
            _transfersUser = context.GetUser<TransfersUser>();
            _sender = _transfersUser.OrganisationName;
            _receiver = _transfersUser.SecondOrganisationName;
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context, _transfersUser);
            _transfersCreateCohortStepsHelper = new TransfersCreateCohortStepsHelper(context);
            _transferEmployerStepsHelper = new TransferEmployerStepsHelper(context);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
            readApprenticeDataHelper = new ReadApprenticeDataHelper(context);
        }

        [Given(@"Receiver sends an approved cohort with (.*) apprentices to the provider")]
        public void GivenReceiverSendsAnApprovedCohortWithApprenticesToTheProvider(int numberOfApprentices)
        {
            LoginAsReceiver();

            var cohortReference = _transferEmployerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        [Given(@"Receiver sends an approved cohort with (.*) apprentices to the provider with the following details")]
        public void GivenReceiverSendsAnApprovedCohortWithApprenticesToTheProviderWithTheFollowingDetails(int numberOfApprentices, Table table)
        {
            LoginAsReceiver();

            readApprenticeDataHelper.ReadApprenticeData(table);

            var cohortReference = _transferEmployerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }


        [When(@"Sender rejects the cohort")]
        public void WhenSenderRejectsTheCohort()
        {
            UpdateOrganisationName(_sender);

            _transfersCreateCohortStepsHelper.RejectTransfersRequest();
        }

        [When(@"Receiver edits and sends an approved cohort to the provider")]
        public void WhenReceiverEditsAndSendsAnApprovedCohortToTheProvider()
        {
            UpdateOrganisationName(_receiver);

            _transfersCreateCohortStepsHelper.OpenRejectedCohort()
                .SelectEditApprentice()
                .EditApprenticePreApprovalAndSubmit()
                .EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [When(@"Receiver approves the cohort")]
        public void WhenReceiverApprovesTheCohort()
        {
            UpdateOrganisationName(_receiver);

            _transferEmployerStepsHelper.Approve();
        }

        [When(@"Receiver sends a cohort to the provider for review and approval")]
        public void WhenReceiverSendsACohortToTheProviderForReviewAndApproval()
        {
            UpdateOrganisationName(_receiver);

            _transfersCreateCohortStepsHelper.OpenRejectedCohort().EmployerSendsToTrainingProviderForReview();
        }

        [When(@"Sender approves the cohort")]
        public void WhenSenderApprovesTheCohort()
        {
            UpdateOrganisationName(_sender);

            _transfersCreateCohortStepsHelper.ApproveTransfersRequest();
        }

        [Then(@"Verify a new live apprenticeship record is created")]
        public void ThenVerifyANewLiveApprenticeshipRecordIsCreated()
        {
            UpdateOrganisationName(_receiver);

            var manageYourApprenticePage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage();

            manageYourApprenticePage.VerifyApprenticeExists();
        }

        private void LoginAsReceiver() => Login(_receiver);

        private void Login(string organisationName)
        {
            _multipleAccountsLoginHelper.OrganisationName = organisationName;

            _ = _multipleAccountsLoginHelper.Login(_transfersUser, true);
        }

        private void UpdateOrganisationName(string orgName) => _objectContext.UpdateOrganisationName(orgName);
    }
}
