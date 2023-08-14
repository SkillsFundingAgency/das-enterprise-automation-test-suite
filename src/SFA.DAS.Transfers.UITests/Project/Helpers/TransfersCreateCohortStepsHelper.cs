using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersCreateCohortStepsHelper : EmployerCreateCohortStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;

        public TransfersCreateCohortStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        public ApproveApprenticeDetailsPage OpenRejectedCohort() => _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage().ClickApprenticeRequestsLink().GoToReadyToReview().SelectViewCurrentCohortDetails();

        public void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        public void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

        public void ValidateWithTransferSendingEmployersCohortStatus(string status)
        {
            var apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            var approveApprenticeDetailsPage = apprenticeRequestsPage.GoToWithTransferSendingEmployers().SelectViewCurrentCohortDetails();
            approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        public void ValidateReadyToReviewCohortStatus(string status)
        {
            var apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            var approveApprenticeDetailsPage = apprenticeRequestsPage.GoToReadyToReview().SelectViewCurrentCohortDetails();
            approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        protected override Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => new AddTrainingProviderStepsHelper().AddTrainingProviderDetailsUsingTransfersFunc();

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage();

            return new FinancePage(_context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }
    }
}