namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CommitmentsTrainingProviderHistorySteps : CommitmentsCohortDetailsBaseSteps
{
    public CommitmentsTrainingProviderHistorySteps(ScenarioContext context) : base(context) => cohortDetails = config.CohortWithTrainingProviderHistory;

    [When(@"the User searches for a Cohort with Training provider history")]
    public void WhenTheUserSearchesForACohortWithTrainingProviderHistory() => SearchesForACohort();

    [When(@"the User clicks on 'View this cohort' button with Training provider history")]
    public void WhenTheUserClicksOnButtonWithTrainingProviderHistory() => ViewThisCohort();

    [When(@"the ULN details page is displayed with Training provider history")]
    public void ThenTheULNDetailsPageIsDisplayedWithTrainingProviderHistory() => GetUlnDetailsPage().ClickTrainingProviderHistoryTab();

    [When(@"the user chooses to view Uln of the Cohort with Training provider history")]
    public void WhenTheUserChoosesToViewUlnOfTheCohortWithTrainingProviderHistory() => ViewCohortUln();

    [Then(@"the Training provider history is displayed")]
    public void TheTrainingProviderHistoryIsDisplayed() => GetUlnDetailsPage().TrainingProviderHistoryIsDisplayed();

    private UlnDetailsPageWithTrainingProviderHistory GetUlnDetailsPage() => new(_context, cohortDetails);
}