namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;


[Binding]
public class CommitmentsSteps(ScenarioContext context)
{
    private readonly StepsHelper _stepsHelper = new(context);

    private readonly SupportConsoleConfig _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();

    [When(@"the User searches for an ULN")]
    public void WhenTheUserSearchesForAnULN() => _stepsHelper.SearchForUln(_config.CohortDetails.Uln);

    [Then(@"the ULN details are displayed")]
    public void ThenTheULNDetailsAreDisplayed() => new UlnSearchResultsPage(context).SelectULN(_config.CohortDetails).VerifyUlnDetailsPageHeaders();

    [When(@"the User searches with a invalid ULN")]
    public void WhenTheUserSearchesWithAInvalidULN() => _stepsHelper.SearchWithInvalidUln(false);

    [When(@"the User searches with a invalid ULN having special characters")]
    public void WhenTheUserSearchesWithAInvalidULNHavingSpecialCharacters() => _stepsHelper.SearchWithInvalidUln(true);

    [Then(@"appropriate ULN error message is shown to the user")]
    public void ThenAppropriateUlnErrorMessageIsShownToTheUser() =>
        Assert.AreEqual(new CommitmentsSearchPage(context).GetCommitmentsSearchPageErrorText(), CommitmentsSearchPage.UlnSearchErrorMessage, "Uln search Error message mismatch in CommitmentsSearchPage");

    [When(@"the User searches with a invalid Cohort Ref")]
    public void WhenTheUserSearchesWithAInvalidCohortRef() => _stepsHelper.SearchWithInvalidCohort(false);

    [Then(@"appropriate Cohort error message is shown to the user")]
    public void ThenAppropriateCohortErrorMessageIsShownToTheUser() =>
        Assert.AreEqual(new CommitmentsSearchPage(context).GetCommitmentsSearchPageErrorText(), CommitmentsSearchPage.CohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");

    [When(@"the User searches with a invalid Cohort Ref having special characters")]
    public void WhenTheUserSearchesWithAInvalidCohortRefHavingSpecialCharacters() => _stepsHelper.SearchWithInvalidCohort(true);

    [When(@"the user tries to view another Employer's Cohort Ref")]
    public void WhenTheUserTriesToViewAnotherEmployerSCohortRef() => _stepsHelper.SearchWithUnauthorisedCohortAccess();

    [Then(@"unauthorised Cohort access error message is shown to the user")]
    public void ThenUnauthorisedCohortAccessErrorMessageIsShownToTheUser() =>
        Assert.AreEqual(new CommitmentsSearchPage(context).GetCommitmentsSearchPageErrorText(), CommitmentsSearchPage.UnauthorisedCohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");


}