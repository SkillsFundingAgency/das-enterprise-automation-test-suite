namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CommitmentsPendingChangingSteps
{
    private readonly ScenarioContext _context;
    private readonly StepsHelper _stepsHelper;
    private readonly SupportConsoleConfig _config;

    public CommitmentsPendingChangingSteps(ScenarioContext context)
    {
        _context = context;
        _stepsHelper = new StepsHelper(context);
        _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
    }

    #region Update Pending Changes

    [When(@"the User searches for a Cohort with pending changes")]
    public void WhenTheUserSearchesForACohortWithPendingChanges() => _stepsHelper.SearchForCohortWithPendingChanges();

    [When(@"the User clicks on 'View this cohort' button with pending changes")]
    public void WhenTheUserClicksOnButtonWithPendingChanges()
    {
        var cohortSummaryPage = new CohortSummaryPage(_context);
        Assert.AreEqual(cohortSummaryPage.GetCohortRefNumber(), _config.CohortRef, "Cohort reference mismatch in CohortSummaryPage");
        cohortSummaryPage.ClickViewThisCohortButton();
    }

    [When(@"the ULN details page is displayed with pending changes")]
    public void ThenTheULNDetailsPageIsDisplayedWithPendingChanges() => new UlnDetailsPageWithPendingChanges(_context).ClickPendingChangesTab();


    [When(@"the user chooses to view Uln of the Cohort with pending changes")]
    public void WhenTheUserChoosesToViewUlnOfTheCohortWithPendingChanges()
    {
        var cohortDetailsPage = new CohortDetailsPage(_context);
        Assert.AreEqual(cohortDetailsPage.GetCohortRefNumber(), _config.CohortRef, "Cohort reference mismatch in CohortDetailsPage");
        cohortDetailsPage.ClickViewUlnLinkWithPendingChanges(_config.Uln);
    }

    [Then(@"the pending changes are displayed")]
    public void ThePendingUpdateChangesAreDisplayed() => new UlnDetailsPageWithPendingChanges(_context).PendingChangesAreDisplayed();

    #endregion
}

