using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersEmployerStepsHelper : EmployerStepsHelper
    {
        private readonly ScenarioContext _context;

        public TransfersEmployerStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ReviewYourCohortPage OpenRejectedCohort() =>
         GoToEmployerApprenticesHomePage()
         .ClickApprenticeRequestsLink()
         .GoToReadyToReview()
         .SelectViewCurrentCohortDetails();

        public void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        public void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            GoToEmployerApprenticesHomePage();
            return new FinancePage(_context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }
    }
}