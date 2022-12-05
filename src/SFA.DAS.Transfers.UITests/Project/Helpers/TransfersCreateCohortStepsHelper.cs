using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Transfers.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersCreateCohortStepsHelper : EmployerCreateCohortStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;

        public TransfersCreateCohortStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
        }

        public ApproveApprenticeDetailsPage OpenRejectedCohort() => _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage().ClickApprenticeRequestsLink().GoToReadyToReview().SelectViewCurrentCohortDetails();

        public void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        public void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

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