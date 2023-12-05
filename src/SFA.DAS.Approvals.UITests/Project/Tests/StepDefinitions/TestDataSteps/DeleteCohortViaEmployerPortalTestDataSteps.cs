using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions.TestDataSteps;

[Binding, Scope(Tag = "@deletecohortviaemployerportal")]
public class DeleteCohortViaEmployerPortalTestDataSteps
{
    private readonly ScenarioContext _context;

    private readonly DeleteCohortLevyUser levyUser;

    private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
    public DeleteCohortViaEmployerPortalTestDataSteps(ScenarioContext context)
    {
        _context = context;

        levyUser = _context.GetUser<DeleteCohortLevyUser>();

        _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
    }

    [Then(@"A list of cohorts ready for review can be deleted using key '([^']*)'")]
    public void AListOfCohortsReadyForReviewCanBeDeletedUsingKey(string key) => DeleteCohort((x) => x.GoToReadyToReview(), key);

    [Then(@"A list of cohorts in draft can be deleted using key '([^']*)'")]
    public void AListOfCohortsInDraftCanBeDeletedUsingKey(string key) => DeleteCohort((x) => x.GoToDrafts(), key);

    private void DeleteCohort(Func<ApprenticeRequestsPage, ApprenticeRequestsSubPage> func, string key)
    {
        _employerPortalLoginHelper.Login(levyUser, true);

        var employerApprenticeRequestsPage = new ApprenticesHomePage(_context).ClickApprenticeRequestsLink();

        var apprenticeRequestsSubPage = func(employerApprenticeRequestsPage);

        var listFromUi = apprenticeRequestsSubPage.GetAllCohorts(key);

        int noOfCohortToDelete = Math.Min(int.Parse(levyUser.NoOfCohortToDelete), listFromUi.Count);

        int count = 0;

        for (int i = 0; i < noOfCohortToDelete; i++)
        {
            var refKey = listFromUi[i];

            if (apprenticeRequestsSubPage.ViewDraftOrReadyToReviewCohortDetails(refKey))
            {
                employerApprenticeRequestsPage = new ApproveApprenticeDetailsPage(_context, "Approve").SelectDeleteThisGroup().ConfirmDeleteAndSubmit();

                apprenticeRequestsSubPage = func(employerApprenticeRequestsPage);

                count++;
            }
            else
            {
                _context.Get<FormCompletionHelper>().SetDebugInformation($"'{refKey}' not found");
            }
        }

        _context.Get<FormCompletionHelper>().SetDebugInformation($"deleted '{count}' cohorts");
    }
}
