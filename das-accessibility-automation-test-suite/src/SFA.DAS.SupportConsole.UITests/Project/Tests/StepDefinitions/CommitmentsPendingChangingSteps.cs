namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CommitmentsPendingChangingSteps : CommitmentsCohortDetailsBaseSteps
{
    public CommitmentsPendingChangingSteps(ScenarioContext context) : base(context) => cohortDetails = config.CohortWithPendingChanges;

    [When(@"the User searches for a Cohort with pending changes")]
    public void WhenTheUserSearchesForACohortWithPendingChanges() => SearchesForACohort();

    [When(@"the User clicks on 'View this cohort' button with pending changes")]
    public void WhenTheUserClicksOnButtonWithPendingChanges() => ViewThisCohort();

    [When(@"the ULN details page is displayed with pending changes")]
    public void ThenTheULNDetailsPageIsDisplayedWithPendingChanges() => GetUlnDetailsPage().ClickPendingChangesTab();

    [When(@"the user chooses to view Uln of the Cohort with pending changes")]
    public void WhenTheUserChoosesToViewUlnOfTheCohortWithPendingChanges() => ViewCohortUln();

    [Then(@"the pending changes are displayed")]
    public void ThePendingUpdateChangesAreDisplayed() => GetUlnDetailsPage().PendingChangesAreDisplayed();

    private UlnDetailsPageWithPendingChanges GetUlnDetailsPage() => new(_context, cohortDetails);
}

