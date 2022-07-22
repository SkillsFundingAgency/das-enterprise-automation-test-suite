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

    public ToolSupportHomePage ValidUserLogsinToSupportTools(bool openNewTab = false) => LoginToSupportTools(_context.GetUser<SupportToolsUser>(), openNewTab);

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

    void VerifyCohortSearchTextBoxHelpTextContent(CommitmentsSearchPage commitmentsSearchPage) => Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), CommitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

    private SearchHomePage LoginToSupportConsole(LoginUser loginUser)
    {
        new IdamsPage(_context).LoginToAccess1Staff();

        return new SignInPage(_context).SignInWithValidDetails(loginUser);
    }

    private ToolSupportHomePage LoginToSupportTools(LoginUser loginUser, bool openNewTab =  false)
    {
        var baseUrl = UrlConfig.SupportTools_BaseUrl;

        if (openNewTab)
            _tabHelper.OpenInNewTab(baseUrl);
        else
            _tabHelper.GoToUrl(baseUrl);

        var url = _context.Get<PageInteractionHelper>().GetUrl();

        if (url.Contains("wsignin1"))
        {
            new IdamsPage(_context).LoginToAccess1Staff();

            return new SignInPage(_context).SignIntoToolSupportWithValidDetails(loginUser);
        }
        else
        {
            return new ToolSupportHomePage(_context);
        }

        
    }


}