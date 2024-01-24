namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class ReinstateUsersPage(ScenarioContext context) : ToolSupportBasePage(context)
{
    protected override string PageTitle => "Reinstate users";

    #region Locators
    private static By ReinstateUsersbtn => By.Id("okButton");
    private static By StatusColumn => By.CssSelector("#usersResultsTable tr td:nth-child(3)");

    #endregion

    public ReinstateUsersPage ClickReinstateUsersbtn()
    {
        formCompletionHelper.Click(ReinstateUsersbtn);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
}
