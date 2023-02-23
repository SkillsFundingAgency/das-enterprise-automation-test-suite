namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private By SearchField = By.Id("SelectedLarsCode");
    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandard_ActuaryPage SelectAbbattoirAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByText(SearchField, "Abattoir worker (Level 2)");
        Continue();
        return new AddAstandard_ActuaryPage(context);
    }
}
