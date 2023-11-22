using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions.TestDataSteps;

[Binding, Scope(Tag = "@deletecohortviaproviderportal")]
public class DeleteCohortViaProviderPortalTestDataSteps
{
    private readonly ScenarioContext _context;
    private readonly DeleteCohortProviderConfig config;

    public DeleteCohortViaProviderPortalTestDataSteps(ScenarioContext context)
    {
        _context = context;

        config = _context.Get<DeleteCohortProviderConfig>();
    }

    [Then(@"A list of cohorts ready for review can be deleted using key '([^']*)'")]
    public void ThenAListOfCohortsReadyForReviewCanBeDeletedUsingKey(string key) => DeleteCohort((x) => x.GoToCohortsToReviewPage(), key);

    [Then(@"A list of cohorts in draft can be deleted using key '([^']*)'")]
    public void ThenAListOfCohortsInDraftCanBeDeletedUsingKey(string key) => DeleteCohort((x) => x.GoToDraftCohorts(), key);

    [Then(@"A list of cohorts ready for review can be deleted")]
    public void ThenAListOfCohortsReadyForReviewCanBeDeleted() => DeleteCohort((x) => x.GoToCohortsToReviewPage(), false);

    [Then(@"A list of cohorts in draft can be deleted")]
    public void ThenAListOfCohortsInDraftCanBeDeleted() => DeleteCohort((x) => x.GoToDraftCohorts(), true);

    private void DeleteCohort(Func<ProviderApprenticeRequestsPage, ProviderApprenticeRequestsSubPage> func, string key)
    {
        var providerApprenticeRequestsPage = GoToApprenticeRequestsPage();

        func(providerApprenticeRequestsPage);

        var listFromUi = func(providerApprenticeRequestsPage).GetAllCohorts(key);

        DeleteCohort(func, providerApprenticeRequestsPage, listFromUi);
    }


    private void DeleteCohort(Func<ProviderApprenticeRequestsPage, ProviderApprenticeRequestsSubPage> func, bool isDraft)
    {
        var providerApprenticeRequestsPage = GoToApprenticeRequestsPage();

        func(providerApprenticeRequestsPage);

        var listFromdb = _context.Get<CommitmentsSqlDataHelper>().GetCohortToDelete(config.Ukprn, isDraft);

        var listFromUi = func(providerApprenticeRequestsPage).GetAllCohorts();

        var listOfCohortToDelete = listFromdb.Intersect(listFromUi).ToList();

        DeleteCohort(func, providerApprenticeRequestsPage, listOfCohortToDelete);
    }

    private void DeleteCohort(Func<ProviderApprenticeRequestsPage, ProviderApprenticeRequestsSubPage> func, ProviderApprenticeRequestsPage providerApprenticeRequestsPage, List<string> listOfCohortToDelete)
    {
        var dfeTimeout = SetdfeTimeout();

        int noOfCohortToDelete = Math.Min(int.Parse(config.NoOfCohortToDelete), listOfCohortToDelete.Count);

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

    private ProviderApprenticeRequestsPage GoToApprenticeRequestsPage() => new ProviderCommonStepsHelper(_context).GoToProviderHomePage(config, false).GoToApprenticeRequestsPage();

    private DateTime SetdfeTimeout() => DateTime.Now.AddMinutes(config.DfeTimeOut);
}