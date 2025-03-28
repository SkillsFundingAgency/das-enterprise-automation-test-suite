namespace SFA.DAS.SupportTools.UITests.Project.Tests.StepDefinitions;

public abstract class CommitmentsCohortDetailsBaseSteps(ScenarioContext context)
{
    protected readonly ScenarioContext Context = context;
    private readonly StepsHelper _stepsHelper = new(context);
    private CohortSummaryPage _cohortSummaryPage;
    private CohortDetailsPage _cohortDetailsPage;
    protected SupportConsoleConfig Config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
    protected CohortDetails CohortDetails;

    protected CohortSummaryPage SearchesForACohort() => _cohortSummaryPage = _stepsHelper.SearchForCohort(CohortDetails.CohortRef);

    protected void ViewThisCohort()
    {
        AssertCohortSummaryPage();

        _cohortDetailsPage = _cohortSummaryPage.ClickViewThisCohortButton();
    }

    protected void ViewCohortUln()
    {
        AssertCohortDetailsPage();

        _cohortDetailsPage.ClickViewUlnLink(CohortDetails.Uln);
    }

    private void AssertCohortSummaryPage() => AssertCohortRef(_cohortSummaryPage.GetCohortRefNumber(), "Cohort reference mismatch in CohortSummaryPage");

    private void AssertCohortDetailsPage() => AssertCohortRef(_cohortDetailsPage.GetCohortRefNumber(), "Cohort reference mismatch in CohortDetailsPage");

    private void AssertCohortRef(string actual, string message) => Assert.AreEqual(actual, CohortDetails.CohortRef, message);
}
