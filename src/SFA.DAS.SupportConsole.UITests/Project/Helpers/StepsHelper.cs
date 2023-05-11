namespace SFA.DAS.SupportConsole.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;
    private readonly TabHelper _tabHelper;

    public StepsHelper(ScenarioContext context)
    {
        _context = context;
        _tabHelper = context.Get<TabHelper>();
    }

    public SearchHomePage Tier1LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier1User>());

    public SearchHomePage Tier2LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier2User>());

    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool openNewTab) => LoginToSupportTools(_context.GetUser<SupportToolsSCPUser>(), openNewTab);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools(bool openNewTab) => LoginToSupportTools(_context.GetUser<SupportToolsSCSUser>(), openNewTab);

    public AccountOverviewPage SearchAndViewAccount() => new SearchHomePage(_context).SearchByPublicAccountIdAndViewAccount();

    public UlnSearchResultsPage SearchForUln(string uln) => new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SearchForULN(uln);

    public void SearchWithInvalidUln(bool WithSpecialChars)
    {
        var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectUlnSearchTypeRadioButton();

        Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), CommitmentsSearchPage.UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

        if (WithSpecialChars)
            commitmentsSearchPage.SearchWithInvalidULNWithSpecialChars();
        else
            commitmentsSearchPage.SearchWithInvalidULN();
    }

    public void SearchWithInvalidCohort(bool WithSpecialChars)
    {
        var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

        VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

        if (WithSpecialChars)
            commitmentsSearchPage.SearchWithInvalidCohortWithSpecialChars();
        else
            commitmentsSearchPage.SearchWithInvalidCohort();
    }

    public void SearchWithUnauthorisedCohortAccess()
    {
        var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

        VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

        commitmentsSearchPage.SearchWithUnauthorisedCohortAccess();
    }

    public CohortSummaryPage SearchForCohort(string cohortRef) => new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SearchCohort(cohortRef);

    private void VerifyCohortSearchTextBoxHelpTextContent(CommitmentsSearchPage commitmentsSearchPage) => Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), CommitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

    private SearchHomePage LoginToSupportConsole(NonEasAccountUser loginUser) => GoToSignInPage().SignInWithValidDetails(loginUser);

    private ToolSupportHomePage LoginToSupportTools(NonEasAccountUser loginUser, bool openNewTab)
    {
        var baseUrl = UrlConfig.SupportTools_BaseUrl;

        if (openNewTab) _tabHelper.OpenInNewTab(baseUrl);

        else _tabHelper.GoToUrl(baseUrl);

        if (new CheckIdamsPage(_context).IsPageDisplayed()) return GoToSignInPage().SignIntoToolSupportWithValidDetails(loginUser);

        else return new ToolSupportHomePage(_context);
    }

    private SignInPage GoToSignInPage()
    {
        new IdamsPage(_context).LoginToAccess1Staff();

        return new(_context);
    }
}