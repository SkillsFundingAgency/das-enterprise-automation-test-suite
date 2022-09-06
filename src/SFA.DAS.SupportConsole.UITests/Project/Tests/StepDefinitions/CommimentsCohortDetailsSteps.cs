namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

[Binding]
public class CommimentsCohortDetailsSteps : CommitmentsCohortDetailsBaseSteps
{
    public CommimentsCohortDetailsSteps(ScenarioContext context) : base(context) => cohortDetails = config.CohortDetails;

    [When(@"the User searches for a Cohort")]
    public void WhenTheUserSearchesForACohort() => SearchesForACohort();

    [When(@"the User clicks on 'View this cohort' button")]
    public void WhenTheUserClicksOnButton() => ViewThisCohort();

    [When(@"the user chooses to view Uln of the Cohort")]
    public void WhenTheUserChoosesToViewUlnOfTheCohort() => ViewCohortUln();

    [Then(@"the ULN details page is displayed")]
    public void ThenTheULNDetailsPageIsDisplayed() => new UlnDetailsPage(_context, cohortDetails).VerifyUlnDetailsPageHeaders();
}