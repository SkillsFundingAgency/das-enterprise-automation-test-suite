namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class SelectAStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Select a standard";

    private By SearchField = By.Id("SelectedLarsCode");
    private By LarsCode274 = By.XPath("//li[text()='Abattoir worker (Level 2)']"); 
    public SelectAStandardPage(ScenarioContext context) : base(context) { }

    public AddAstandard_ActuaryPage SelectAbbattoirAndContinue()
    {
        formCompletionHelper.ClickElement(SearchField);
        formCompletionHelper.ClickElement(LarsCode274);
        Continue();
        return new AddAstandard_ActuaryPage(context);
    }
}
