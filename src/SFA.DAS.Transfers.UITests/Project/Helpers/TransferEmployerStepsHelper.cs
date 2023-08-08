using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransferEmployerStepsHelper : EmployerStepsHelper
    {

        public TransferEmployerStepsHelper(ScenarioContext context) : base(context) { }

        protected override Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => new AddTrainingProviderStepsHelper().AddTrainingProviderDetailsUsingTransfersFunc();

        public void VerifyApprenticeChangeToReviewTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("ApprenticeChangeToReview", numberOfTasks);

        public void VerifyCohortRequestReadyForApprovalTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("CohortRequestReadyForApproval", numberOfTasks);

        public void VerifyReviewConnectionRequestTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("ReviewConnectionRequest", numberOfTasks);

        public void VerifyTransferRequestReceivedTaskLink(int numberOfTasks) => _apprenticeHomePageStepsHelper.GotoEmployerHomePage().VerifyTaskCount("TransferRequestReceived", numberOfTasks);
    }
}