namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private static By SearchField => By.CssSelector("#SelectedLarsCode");

    private static By FirstStandard => By.CssSelector("ul#SelectedLarsCode__listbox > li");

    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandardPage SelectAStandardAndContinue(string standardName)
    {
        formCompletionHelper.EnterText(SearchField, standardName);

        formCompletionHelper.Click(FirstStandard);

        Continue();

        return new AddAstandardPage(context, standardName);
    }
}