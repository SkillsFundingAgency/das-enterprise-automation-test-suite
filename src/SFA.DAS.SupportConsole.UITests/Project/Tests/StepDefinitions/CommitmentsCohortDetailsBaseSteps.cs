namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

public abstract class CommitmentsCohortDetailsBaseSteps(ScenarioContext context)
{
    protected readonly ScenarioContext _context = context;
    private readonly StepsHelper _stepsHelper = new(context);
    private CohortSummaryPage cohortSummaryPage;
    private CohortDetailsPage cohortDetailsPage;
    protected SupportConsoleConfig config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
    protected CohortDetails cohortDetails;

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
