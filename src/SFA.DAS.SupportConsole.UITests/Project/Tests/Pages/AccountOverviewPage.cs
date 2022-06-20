namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class AccountOverviewPage : SupportConsoleBasePage
{
    protected override string PageTitle => config.AccountName;

    #region Locators
    protected override By PageHeader => By.CssSelector(".heading-large");
    private static By PageHeaderWithAccountDetails => By.CssSelector(".heading-secondary");
    #endregion

    public AccountOverviewPage(ScenarioContext context) : base(context)
    {
        RefreshPage(); //Doing this to refresh the page as the Header dissappears at times - known issue

        MultipleVerifyPage(new List<Func<bool>> {
            () => VerifyPage(),
            () => VerifyPage(PageHeaderWithAccountDetails, config.AccountDetails)
        });
    }

    public TeamMembersPage ClickTeamMembersLink()
    {
        formCompletionHelper.Click(TeamMembersLink);
        return new (context);
    }

    public CommitmentsSearchPage ClickCommitmentsMenuLink()
    {
        formCompletionHelper.Click(CommitmentsMenuLink);
        return new (context);
    }

    private void RefreshPage() => formCompletionHelper.Click(OrganisationsMenuLink);
}