namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class ReinstateUsersPage : ToolSupportBasePage
{
    protected override string PageTitle => "Reinstate users";

    #region Locators
    private static By ReinstateUsersbtn => By.Id("okButton");
    private static By StatusColumn => By.CssSelector("#usersResultsTable tr td:nth-child(3)");
    #endregion

    public ReinstateUsersPage(ScenarioContext context) : base(context) { }

    public ReinstateUsersPage ClickReinstateUsersbtn()
    {
        formCompletionHelper.Click(ReinstateUsersbtn);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
}
