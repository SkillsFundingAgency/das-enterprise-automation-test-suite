using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransferEmployerStepsHelper(ScenarioContext context) : EmployerStepsHelper(context)
    {
        protected override Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsUsingTransfersFunc();

        public void AssertApprenticeChangeToReviewTaskLink(int numberOfTasks) => AssertTaskCount("ApprenticeChangeToReview", numberOfTasks);

        public void AssertCohortRequestReadyForApprovalTaskLink(int numberOfTasks) => AssertTaskCount("CohortRequestReadyForApproval", numberOfTasks);

        public void AssertReviewConnectionRequestTaskLink(int numberOfTasks) => AssertTaskCount("ReviewConnectionRequest", numberOfTasks);

        public void AssertTransferRequestReceivedTaskLink(int numberOfTasks) => AssertTaskCount("TransferRequestReceived", numberOfTasks);

        private void AssertTaskCount(string taskType, int numberOfTasks)
        {
            _apprenticeHomePageStepsHelper.GotoEmployerHomePage();

            new TasksHomePage(context).AssertTaskCount(taskType, numberOfTasks);
        }
    }
}