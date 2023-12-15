namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class SuspendUsersPage(ScenarioContext context) : ToolSupportBasePage(context)
{
    protected override string PageTitle => "Suspend users";

    #region Locators
    private static By SuspendUsersbtn => By.Id("okButton");
    private static By StatusColumn => By.CssSelector("#usersResultsTable tr td:nth-child(3)");

    #endregion

    public SuspendUsersPage ClicSuspendUsersbtn()
    {
        formCompletionHelper.Click(SuspendUsersbtn);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
}
