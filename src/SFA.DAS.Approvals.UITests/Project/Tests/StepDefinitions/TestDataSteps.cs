using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestDataSteps
    {
        private readonly ScenarioContext _context;

        public TestDataSteps(ScenarioContext context) => _context = context;

        [Then(@"A list of cohorts ready for review can be deleted")]
        public void ThenAListOfCohortsReadyForReviewCanBeDeleted() => DeleteCohort((x) => x.GoToCohortsToReviewPage(), false);

        [Then(@"A list of cohorts in draft can be deleted")]
        public void ThenAListOfCohortsInDraftCanBeDeleted() => DeleteCohort((x) => x.GoToDraftCohorts(), true);

        private void DeleteCohort(Func<ProviderApprenticeRequestsPage, ProviderApprenticeRequestsSubPage> func, bool isDraft)
        {
            var config = _context.Get<DeleteCohortProviderConfig>();

            ProviderApprenticeRequestsPage GoToApprenticeRequestsPage() => new ProviderCommonStepsHelper(_context).GoToProviderHomePage(config, false).GoToApprenticeRequestsPage();

            DateTime SetdfeTimeout() => DateTime.Now.AddMinutes(config.DfeTimeOut);

            var dfeTimeout = SetdfeTimeout();

            int noOfCohortToDelete = int.Parse(config.NoOfCohortToDelete);

            var providerApprenticeRequestsPage = GoToApprenticeRequestsPage();

            func(providerApprenticeRequestsPage);

            var listFromdb = _context.Get<CommitmentsSqlDataHelper>().GetCohortToDelete(config.Ukprn, isDraft);

            var listFromUi = func(providerApprenticeRequestsPage).GetAllCohorts();

            var listOfCohortToDelete = listFromdb.Intersect(listFromUi).ToList();

            noOfCohortToDelete = listOfCohortToDelete.Count > noOfCohortToDelete ? noOfCohortToDelete : listOfCohortToDelete.Count;

            int count = 0;

            for (int i = 0; i < noOfCohortToDelete; i++)
            {
                var key = listOfCohortToDelete[i];

                if (func(providerApprenticeRequestsPage).ViewDraftOrReadyToReviewCohortDetails(key))
                {
                    providerApprenticeRequestsPage = new ProviderApproveApprenticeDetailsPage(_context).SelectDeleteCohort().ConfirmDeleteAndSubmit();

                    count++;
                }
                else
                {
                    _context.Get<FormCompletionHelper>().SetDebugInformation($"'{key}' not found");
                }

                if (DateTime.Now > dfeTimeout)
                {
                    providerApprenticeRequestsPage.SignsOut();

                    new RestartWebDriverHelper(_context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Provider_BaseUrl");

                    providerApprenticeRequestsPage = GoToApprenticeRequestsPage();

                    dfeTimeout = SetdfeTimeout();
                }
            }

            _context.Get<FormCompletionHelper>().SetDebugInformation($"deleted '{count}' cohorts");
        }
    }
}