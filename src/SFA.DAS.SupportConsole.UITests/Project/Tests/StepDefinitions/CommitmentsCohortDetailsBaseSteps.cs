namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

public abstract class CommitmentsCohortDetailsBaseSteps
{
    protected readonly ScenarioContext _context;
    private readonly StepsHelper _stepsHelper;
    private CohortSummaryPage cohortSummaryPage;
    private CohortDetailsPage cohortDetailsPage;
    protected SupportConsoleConfig config;
    protected CohortDetails cohortDetails;

    public CommitmentsCohortDetailsBaseSteps(ScenarioContext context)
    {
        _context = context;
        config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        _stepsHelper = new StepsHelper(context);
    }

    protected CohortSummaryPage SearchesForACohort() => cohortSummaryPage = _stepsHelper.SearchForCohort(cohortDetails.CohortRef);

    protected void ViewThisCohort()
    {
        AssertCohortSummaryPage();

        cohortDetailsPage = cohortSummaryPage.ClickViewThisCohortButton();
    }

    protected void ViewCohortUln()
    {
        AssertCohortDetailsPage();

        cohortDetailsPage.ClickViewUlnLink(cohortDetails.Uln);
    }

    private void AssertCohortSummaryPage() => AssertCohortRef(cohortSummaryPage.GetCohortRefNumber(), "Cohort reference mismatch in CohortSummaryPage");

    private void AssertCohortDetailsPage() => AssertCohortRef(cohortDetailsPage.GetCohortRefNumber(), "Cohort reference mismatch in CohortDetailsPage");

    private void AssertCohortRef(string actual, string message) => Assert.AreEqual(actual, cohortDetails.CohortRef, message);
}
