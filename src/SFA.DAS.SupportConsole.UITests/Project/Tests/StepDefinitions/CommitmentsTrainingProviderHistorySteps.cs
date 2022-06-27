namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CommitmentsTrainingProviderHistorySteps
{
    public const string CohortWithTrainingProviderHistory = "CohortWithTrainingProviderHistory";
    private readonly ScenarioContext _context;
    private readonly StepsHelper _stepsHelper;

    public CommitmentsTrainingProviderHistorySteps(ScenarioContext context)
    {
        _context = context;
        _stepsHelper = new StepsHelper(context);
    }

    [When(@"the User searches for a Cohort with Training provider history")]
    public void WhenTheUserSearchesForACohortWithTrainingProviderHistory() => _stepsHelper.SearchForCohortWithTraingProviderHistory();

    [When(@"the User clicks on 'View this cohort' button with Training provider history")]
    public void WhenTheUserClicksOnButtonWithTrainingProviderHistory()
    {
        var cohortSummaryPage = new CohortSummaryPage(_context);
        var cohortRef = _context.Get<string>(CohortWithTrainingProviderHistory);
        Assert.AreEqual(cohortSummaryPage.GetCohortRefNumber(), cohortRef, "Cohort reference mismatch in CohortSummaryPage");
        cohortSummaryPage.ClickViewThisCohortButton();
    }

    [When(@"the ULN details page is displayed with Training provider history")]
    public void ThenTheULNDetailsPageIsDisplayedWithTrainingProviderHistory() => new UlnDetailsPageWithTrainingProviderHistory(_context).ClickPTrainingProviderHistoryTab();


    [When(@"the user chooses to view Uln of the Cohort with Training provider history")]
    public void WhenTheUserChoosesToViewUlnOfTheCohortWithTrainingProviderHistory()
    {
        var cohortDetailsPage = new CohortDetailsPage(_context);
        var cohortRef = _context.Get<string>(CohortWithTrainingProviderHistory);
        Assert.AreEqual(cohortDetailsPage.GetCohortRefNumber(), cohortRef, "Cohort reference mismatch in CohortDetailsPage");
        cohortDetailsPage.ClickViewUlnLinkWithTrainingProviderHistory(cohortRef);
    }

    [Then(@"the Training provider history is displayed")]
    public void TheTrainingProviderHistoryIsDisplayed() => new UlnDetailsPageWithTrainingProviderHistory(_context).TrainingProviderHistoryIsDisplayed();
}

