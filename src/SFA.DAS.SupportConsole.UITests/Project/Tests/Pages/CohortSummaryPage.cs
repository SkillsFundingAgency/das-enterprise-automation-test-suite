namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class CohortSummaryPage : SupportConsoleBasePage
{
    protected override string PageTitle => "Cohort Summary";

    #region Locators
    private static By CohortRefNumber => By.XPath("//td[text()='Cohort reference']/following-sibling::td");
    private static By ViewThisCohortButton => By.Id("viewCohort");
    #endregion

    public CohortSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

    public CohortDetailsPage ClickViewThisCohortButton()
    {
        formCompletionHelper.Click(ViewThisCohortButton);
        return new (context);
    }

    public string GetCohortRefNumber() => pageInteractionHelper.GetText(CohortRefNumber);
}