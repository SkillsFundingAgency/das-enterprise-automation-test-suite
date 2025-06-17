namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class CheckYourAnswersPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Check your answers";

    #region Locators
    private static By ClickChangeHowManyApprentices => By.CssSelector("a[id='NumberOfApprentices-change']");
    private static By ClickChangeOneApprenticeshipLocation => By.CssSelector("a[id='SameLocation-change']");
    private static By ClickChangeApprenticeshipLocations => By.CssSelector("a[id='MultipleLocations-change']");
    private static By ClickChangeTrainingOptions => By.CssSelector("a[id='AtApprenticesWorkplace-change']");
    #endregion

    public WeHaveSharedThisWithTrainingProvidersPage SubmitAnswers()
    {
        Continue();

        return new(context);
    }

    public HowManyAprenticesWouldDoThisApprenticeshipTrainingPage ChangeHowManyApprentices()
    {
        ClickChange(ClickChangeHowManyApprentices);

        return new(context);
    }

    public AreTheApprenticeshipsInTheSameLocationPage ChangeOneApprenticeshipLocation()
    {
        ClickChange(ClickChangeOneApprenticeshipLocation);

        return new(context);
    }

    public WhereIsTheApprenticeshipLocationPage ChangeApprenticeshipLocations()
    {
        ClickChange(ClickChangeApprenticeshipLocations);

        return new(context, true);
    }

    public SelectTrainingOptionsPage ChangeTrainingOptions()
    {
        ClickChange(ClickChangeTrainingOptions);

        return new(context);
    }

    private void ClickChange(By by) => formCompletionHelper.Click(by);
}
