namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class AccountOverviewPage : SupportConsoleBasePage
{
    protected override string PageTitle => Config.AccountName;

    protected override string AccessibilityPageTitle => "Account overview page";

    #region Locators
    protected override By PageHeader => By.CssSelector(".heading-large");
    private static By PageHeaderWithAccountDetails => By.CssSelector(".heading-secondary");
    #endregion

    public AccountOverviewPage(ScenarioContext context) : base(context)
    {
        RefreshAccountOverviewPage(); //Doing this to refresh the page as the Header dissappears at times - known issue

        MultipleVerifyPage([
            () => VerifyPage(RefreshPage),
            () => VerifyPage(PageHeaderWithAccountDetails, Config.AccountDetails)
        ]);
    }

    public TeamMembersPage ClickTeamMembersLink()
    {
        formCompletionHelper.Click(TeamMembersLink);
        return new(context);
    }

    public CommitmentsSearchPage ClickCommitmentsMenuLink()
    {
        formCompletionHelper.Click(CommitmentsMenuLink);
        return new(context);
    }

    private void RefreshAccountOverviewPage() => formCompletionHelper.Click(OrganisationsMenuLink);
}