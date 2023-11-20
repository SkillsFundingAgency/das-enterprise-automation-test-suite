using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class TestDataSteps
    {
        private readonly ScenarioContext _context;

        public TestDataSteps(ScenarioContext context) => _context = context;

        [Then(@"A list of cohorts ready for review can be deleted")]
        public void ThenAListOfCohortsReadyForReviewCanBeDeleted() => DeleteCohort((x) => x.GoToCohortsToReviewPage(), "Apprentice F");

        [Then(@"A list of cohorts in draft can be deleted")]
        public void ThenAListOfCohortsInDraftCanBeDeleted() => DeleteCohort((x) => x.GoToDraftCohorts());

        private void DeleteCohort(Func<ProviderApprenticeRequestsPage, ProviderApprenticeRequestsSubPage> func, string key = null)
        {
            var config = _context.Get<DeleteCohortProviderConfig>();

            int defaultNoToDelete = int.Parse(config.NoOfCohortToDelete);

            var providerApprenticeRequestsPage = new ProviderCommonStepsHelper(_context).GoToProviderHomePage(config, false).GoToApprenticeRequestsPage();

            var list = new List<string>() { };

            int noOfCohorts;

            if (string.IsNullOrEmpty(key))
            {
                list = _context.Get<CommitmentsSqlDataHelper>().GetCohortToDelete(config.Ukprn);

                noOfCohorts = list.Count < defaultNoToDelete ? list.Count : defaultNoToDelete;
            }
            else
            {
                for (int i = 0; i < defaultNoToDelete; i++) list.Add(key);

                noOfCohorts = defaultNoToDelete;
            }

            int count = 0;

            for (int i = 0; i < noOfCohorts; i++)
            {
                if (string.IsNullOrEmpty(key)) key = list[i];

                if (func(providerApprenticeRequestsPage).ViewDraftOrReadyToReviewCohortDetails(key))
                {
                    providerApprenticeRequestsPage = new ProviderApproveApprenticeDetailsPage(_context).SelectDeleteCohort().ConfirmDeleteAndSubmit();

                    count++;
                }
            }

            _context.Get<FormCompletionHelper>().SetDebugInformation($"deleted {count} cohorts");
        }
    }
}