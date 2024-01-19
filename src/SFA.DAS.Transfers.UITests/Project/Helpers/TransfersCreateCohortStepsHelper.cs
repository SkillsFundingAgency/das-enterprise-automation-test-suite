using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersCreateCohortStepsHelper(ScenarioContext context) : EmployerCreateCohortStepsHelper(context)
    {
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper = new(context);
        private readonly EmployerStepsHelper _employerStepsHelper = new(context);

        public ApproveApprenticeDetailsPage OpenRejectedCohort() => _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage().ClickApprenticeRequestsLink().GoToReadyToReview().SelectViewCurrentCohortDetails();

        public void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        public void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

        public void ValidateWithTransferSendingEmployersCohortStatus(string status) => GoToApprenticeRequestsPage().GoToWithTransferSendingEmployers().SelectViewCurrentCohortDetails().ValidateCohortStatus(status);

        public void ValidateReadyToReviewCohortStatus(string status) => GoToApprenticeRequestsPage().GoToReadyToReview().SelectViewCurrentCohortDetails().ValidateCohortStatus(status);

        protected override Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsUsingTransfersFunc();

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage();

            return new FinancePage(context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }

        private ApprenticeRequestsPage GoToApprenticeRequestsPage() => _employerStepsHelper.GoToApprenticeRequestsPage();
    }
}