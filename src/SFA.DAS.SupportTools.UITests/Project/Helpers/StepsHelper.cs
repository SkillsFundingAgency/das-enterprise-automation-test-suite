using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.Login.Service.Project;

namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper(ScenarioContext context)
{
    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(context.GetUser<SupportToolScpUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools() => LoginToSupportTools(context.GetUser<SupportToolScsUser>(), false);

    private ToolSupportHomePage LoginToSupportTools(DfeAdminUser loginUser, bool reLogin)
    {
        LoginToDfeSignIn(loginUser, reLogin);

        return new ToolSupportHomePage(context);
    }

    public void LoginToDfeSignIn(DfeAdminUser loginUser, bool reLogin)
    {
        var helper = new DfeAdminLoginStepsHelper(context);

        if (reLogin)
        {
            context.Get<TabHelper>().OpenInNewTab(UrlConfig.SupportTools_BaseUrl);

            helper.CheckAndLoginToSupportTool(loginUser);
        }
        else
        {
            helper.LoginToSupportTool(loginUser);
        }
    }

    public SearchHomePage Tier1LoginToSupportConsole() => LoginToSupportConsole(context.GetUser<SupportConsoleTier1User>());

    public SearchHomePage Tier2LoginToSupportConsole() => LoginToSupportConsole(context.GetUser<SupportConsoleTier2User>());

    public AccountOverviewPage SearchAndViewAccount() => new SearchHomePage(context).SearchByPublicAccountIdAndViewAccount();

    public UlnSearchResultsPage SearchForUln(string uln) => new AccountOverviewPage(context).ClickCommitmentsMenuLink().SearchForULN(uln);

    public void SearchWithInvalidUln(bool WithSpecialChars)
    {
        var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectUlnSearchTypeRadioButton();

        Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), CommitmentsSearchPage.UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

        if (WithSpecialChars)
            commitmentsSearchPage.SearchWithInvalidULNWithSpecialChars();
        else
            commitmentsSearchPage.SearchWithInvalidULN();
    }

    public void SearchWithInvalidCohort(bool WithSpecialChars)
    {
        var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

        VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

        if (WithSpecialChars)
            commitmentsSearchPage.SearchWithInvalidCohortWithSpecialChars();
        else
            commitmentsSearchPage.SearchWithInvalidCohort();
    }

    public void SearchWithUnauthorisedCohortAccess()
    {
        var commitmentsSearchPage = new AccountOverviewPage(context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

        VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

        commitmentsSearchPage.SearchWithUnauthorisedCohortAccess();
    }

    public CohortSummaryPage SearchForCohort(string cohortRef) => new AccountOverviewPage(context).ClickCommitmentsMenuLink().SearchCohort(cohortRef);

    private static void VerifyCohortSearchTextBoxHelpTextContent(CommitmentsSearchPage commitmentsSearchPage) => Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), CommitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

    private SearchHomePage LoginToSupportConsole(DfeAdminUser loginUser)
    {
        new DfeAdminLoginStepsHelper(context).LoginToSupportConsole(loginUser);

        return new(context);
    }
}