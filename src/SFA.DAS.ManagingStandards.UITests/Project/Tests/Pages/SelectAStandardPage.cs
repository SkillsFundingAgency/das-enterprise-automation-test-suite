namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private By SearchField = By.Id("SelectedLarsCode");
    private By LarsCode4 = By.Id("SelectedLarsCode__option--4"); 
    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandard_ActuaryPage SelectActuaryAndContinue()
    {
        //formCompletionHelper.ClickElement(SearchField);
        //formCompletionHelper.ClickElement(LarsCode4);
        formCompletionHelper.SelectFromDropDownByText(SearchField, "Actuary (Level 7)");
        Continue();
        return new AddAstandard_ActuaryPage(context);
    }
}
