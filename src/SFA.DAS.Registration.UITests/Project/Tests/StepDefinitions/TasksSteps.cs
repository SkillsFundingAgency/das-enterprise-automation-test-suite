using System;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TasksSteps
    {
        private readonly ScenarioContext _context;
        private readonly TasksHelper _tasksHelper;
        private HomePage _homePage;

        private const string TaskQueryResultKey = nameof(TaskQueryResult);
        private readonly DateTime _currentDate = DateTime.UtcNow;

        public TasksSteps(ScenarioContext context)
        {
            _context = context;
            _tasksHelper = new TasksHelper(context);
            _homePage = new HomePage(context);
            InitializeTaskQueryResult();
        }

        private void InitializeTaskQueryResult()
        {
            _context.Set(new TaskQueryResult(), TaskQueryResultKey);
        }

        private TaskQueryResult GetTaskQueryResult()
        {
            return _context.Get<TaskQueryResult>(TaskQueryResultKey);
        }

        private void SetTaskQueryResult(TaskQueryResult taskQueryResult)
        {
            _context.Set(taskQueryResult, TaskQueryResultKey);
        }

        [When("the current date is in range 16 - 19")]
        public void WhenTheCurrentDateIsInRange()
        {
            var tasks = GetTaskQueryResult();
            var currentDay = _currentDate.Day;
            tasks.ShowLevyDeclarationTask = currentDay >= 16 && currentDay <= 19;
            SetTaskQueryResult(tasks);
        }

        [Then("display task: Levy declaration due by 19 MMMM")]
        public void ThenDisplayTaskLevyDeclarationDueBy()
        {
            var tasks = GetTaskQueryResult();

            if (tasks.ShowLevyDeclarationTask)
            {
                _homePage.VerifyLevyDeclarationDueTaskMessageShown();
            }
        }

        [When("there are X apprentice changes to review")]
        public void WhenThereAreApprenticeChangesToReview()
        {
            var tasks = GetTaskQueryResult();
            tasks.NumberOfApprenticesToReview = _tasksHelper.GetNumberOfApprenticesToReview();
            SetTaskQueryResult(tasks);
        }

        [Then("display task: X apprentice changes to review")]
        public void ThenDisplayApprenticeChangesToReview()
        {
            var tasks = GetTaskQueryResult();
            _homePage.VerifyApprenticeChangeToReviewMessageShown(tasks.NumberOfApprenticesToReview);
        }

        [Then("View changes link should navigate user to Manage your apprentices page")]
        public void ThenViewApprenticeChangesNavigatesToManageYourApprenticesPage()
        {
            var tasks = GetTaskQueryResult();

            _homePage = TasksHelper.ClickViewApprenticeChangesLink(_homePage, tasks.NumberOfApprenticesToReview);
        }

        [When("there are X cohorts ready for approval")]
        public void WhenThereAreCohortsReadyToReview()
        {
            var tasks = GetTaskQueryResult();
            tasks.NumberOfCohortsReadyToReview = _tasksHelper.GetNumberOfCohortsReadyToReview();
            SetTaskQueryResult(tasks);
        }

        [Then("display task: X cohorts ready for approval")]
        public void ThenDisplayNumberOfCohortsReadyToReview()
        {
            var tasks = GetTaskQueryResult();
            _homePage.VerifyCohortsReadyToReviewMessageShown(tasks.NumberOfCohortsReadyToReview);
        }

        [Then("'View cohorts' link should navigate user to 'Apprentice Requests' page")]
        public void ThenViewCohortsReadyToReviewNavigatesToApprenticeRequestsPage()
        {
            var tasks = GetTaskQueryResult();

            _homePage = TasksHelper.ClickViewCohortsToReviewLink(_homePage, tasks.NumberOfCohortsReadyToReview);
        }

        [When("there is pending Transfer request ready for approval")]
        public void WhenThereIsAPendingTransferRequestReadyForApproval()
        {
            var tasks = GetTaskQueryResult();
            tasks.NumberOfTransferRequestToReview = _tasksHelper.GetNumberOfTransferRequestToReview();
            SetTaskQueryResult(tasks);
        }

        [Then("display task: Transfer request received'")]
        public void ThenDisplayTransferRequestReceived()
        {
            _homePage.VerifyTransferRequestReceivedMessageShown();
        }

        [Then("'View details' for Transfer Request link should navigate user to 'Transfers (../transfers/connections)' page")]
        public void ThenViewTransferRequestDetailsNavigatesToTransferConnectionsPage()
        {
            _homePage = TasksHelper.ClickViewDetailsForTransferRequestsLink(_homePage);
        }

        [When("there are X transfer connection request(s) to review")]
        public void WhenThereAreTransferConnectionRequestsToReview()
        {
            var tasks = GetTaskQueryResult();
            tasks.NumberOfPendingTransferConnections = _tasksHelper.GetNumberOfPendingTransferConnections();
            SetTaskQueryResult(tasks);
        }

        [Then("display task: 'X connection request(s) to review'")]
        public void ThenDisplayTransferConnectionRequests()
        {
            var tasks = GetTaskQueryResult();
            _homePage.VerifyTransferConnectionRequestsMessageShown(tasks.NumberOfPendingTransferConnections);
        }

        [Then("'View details' for Transfer Connection link should navigate user to 'Transfers (../transfers/connections)' page")]
        public void ThenViewTransferConnectionRequestDetailsNavigatesToTransferConnectionsPage()
        {
            _homePage = TasksHelper.ClickViewDetailsForTransferConnectionRequestsLink(_homePage);
        }

        [When("there are X transfer pledge applications awaiting your approval")]
        public void WhenThereAreTransferPledgeApplicationsToReview()
        {
            var tasks = GetTaskQueryResult();
            tasks.NumberTransferPledgeApplicationsToReview = _tasksHelper.GetNumberTransferPledgeApplicationsToReview();
            SetTaskQueryResult(tasks);
        }

        [Then("display task: 'X transfer pledge applications awaiting your approval'")]
        public void ThenDisplayNumberTransferPledgeApplicationsToReview()
        {
            var tasks = GetTaskQueryResult();
            _homePage.VerifyTransferPledgeApplicationsToReviewMessageShown(tasks.NumberTransferPledgeApplicationsToReview);
        }

        [Then("'View applications(s)' link should navigate user to ‘My Transfer Pledges’ page")]
        public void ThenViewTransferPledgeApplicationsNavigatesToMyTransfersPage()
        {
            var tasks = GetTaskQueryResult();

            _homePage = TasksHelper.ClickTransferPledgeApplicationsLink(_homePage, tasks.NumberOfCohortsReadyToReview);
        }

    }
}
