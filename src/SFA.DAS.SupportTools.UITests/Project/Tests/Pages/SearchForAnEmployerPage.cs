namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class SearchForAnEmployerPage : ToolSupportBasePage
{
    protected override string PageTitle => "Search for an Employer.";

    #region Locators
    private static By InternalAccountId => By.Id("internalAccountId");
    private static By HashedAccountId => By.Id("hashedAccountId");
    private static By PaginationInfo => By.ClassName("pagination-info");
    private static By PageSelector => By.ClassName("page-link");
    private static By SelectAllChkBox => By.Name("btSelectAll");
    private static By SubmitButton => By.Id("submitSearchFormButton");
    private static By SuspendUserButton => By.XPath("//button[contains(text(),'Suspend user(s)')]");
    private static By ReinstateUserButton => By.XPath("//button[contains(text(),'Reinstate user(s)')]");
    #endregion

    public SearchForAnEmployerPage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage) { }

    public SearchForAnEmployerPage EnterInternalAccountId(string internalAccountId)
    {
        formCompletionHelper.EnterText(InternalAccountId, internalAccountId);
        return this;
    }

    public SearchForAnEmployerPage EnterHashedAccountId(string hashedAccountId)
    {
        formCompletionHelper.EnterText(HashedAccountId, hashedAccountId);
        return this;
    }

    public SearchForAnEmployerPage SelectAllRecords()
    {
        pageInteractionHelper.WaitForElementToBeClickable(PaginationInfo);
        formCompletionHelper.ClickElement(SelectAllChkBox);

        var isChecked = pageInteractionHelper.FindElement(SelectAllChkBox).GetAttribute("checked");

        if (isChecked == "false" || isChecked == null)
        {
            pageInteractionHelper.WaitForElementToBeClickable(PaginationInfo);
            formCompletionHelper.ClickElement(SelectAllChkBox);
        }

        return this;
    }

    public SearchForAnEmployerPage ClickSubmitButton()
    {
        formCompletionHelper.Click(SubmitButton);
        return new(context);
    }

    public SuspendUsersPage ClickSuspendUserButton()
    {
        pageInteractionHelper.WaitForElementToBeDisplayed(PaginationInfo);
        javaScriptHelper.ScrollToTheBottom();
        formCompletionHelper.Click(SuspendUserButton);
        return new(context);
    }

    public ReinstateUsersPage ClickReinstateUserButton()
    {
        pageInteractionHelper.WaitForElementToBeDisplayed(PaginationInfo);
        javaScriptHelper.ScrollToTheBottom();
        formCompletionHelper.Click(ReinstateUserButton);
        return new(context);
    }

}
