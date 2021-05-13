using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersEmployerStepsHelper : EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TransfersUser _transfersUser;

        public TransfersEmployerStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
            _transfersUser = _context.GetUser<TransfersUser>();
        }

        public ReviewYourCohortPage OpenRejectedCohort() =>
         GoToEmployerApprenticesHomePage()
         .ClickApprenticeRequestsLink()
         .GoToReadyToReview()
         .SelectViewCurrentCohortDetails();

        public void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        public void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

        protected override AddTrainingProviderDetailsPage AddTrainingProviderDetails(AddAnApprenitcePage addAnApprenitcePage)
        {
            return addAnApprenitcePage.StartNowToCreateApprenticeViaTransfersFunds().SelectYesIWantToUseTransferFunds(_transfersUser.OrganisationName);
        }

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            GoToEmployerApprenticesHomePage();
            return new FinancePage(_context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }
    }
}