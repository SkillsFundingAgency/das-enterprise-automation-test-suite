namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private By LarsCode = By.Id("SelectedLarsCode");
    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandard_ActuaryPage SelectActuaryAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByText(LarsCode, "Actuary");
        Continue();
        return new AddAstandard_ActuaryPage(context);
    }
}
