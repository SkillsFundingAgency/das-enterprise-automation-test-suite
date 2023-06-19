namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private static By SearchField => By.CssSelector("#SelectedLarsCode");

    private static By FirstStandard => By.CssSelector("ul#SelectedLarsCode__listbox > li");

    private static By AddStandardsDDL => By.CssSelector("#SelectedLarsCode");

    private static By FirstItemInTheList => By.CssSelector("#SelectedLarsCode__option--0");

    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandardPage SelectAStandardAndContinue(string standardName)
    {
        formCompletionHelper.EnterText(SearchField, standardName);

        formCompletionHelper.Click(FirstStandard);

        return GoToAddAstandardPage(standardName);
    }

    //this method is used to add test data (standard) to the provider. Should not be used in the regression tests
    public (AddAstandardPage addAstandardPage, string standardName) AddFirstStandard()
    {
        formCompletionHelper.Click(AddStandardsDDL);

        var standardName = pageInteractionHelper.GetText(FirstStandard);

        formCompletionHelper.Click(FirstItemInTheList);

        return (GoToAddAstandardPage(standardName), standardName);
    }

    private AddAstandardPage GoToAddAstandardPage(string standardName)
    {
        Continue();

        return new AddAstandardPage(context, standardName);
    }
}