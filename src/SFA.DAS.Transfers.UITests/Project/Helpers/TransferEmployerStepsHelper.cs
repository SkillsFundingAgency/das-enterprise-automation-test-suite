using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransferEmployerStepsHelper : EmployerStepsHelper
    {
        private readonly TransfersUser _transfersUser;

        public TransferEmployerStepsHelper(ScenarioContext context) : base(context) => _transfersUser = context.GetUser<TransfersUser>();

        protected override Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => new AddTrainingProviderStepsHelper().AddTrainingProviderDetailsFunc(_transfersUser.OrganisationName);

        public void VerifyApprenticeChangeToReviewTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("ApprenticeChangeToReview", numberOfTasks);

        public void VerifyCohortRequestReadyForApprovalTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("CohortRequestReadyForApproval", numberOfTasks);

        public void VerifyReviewConnectionRequestTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("ReviewConnectionRequest", numberOfTasks);

        public void VerifyTransferRequestReceivedTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("TransferRequestReceived", numberOfTasks);
    }
}