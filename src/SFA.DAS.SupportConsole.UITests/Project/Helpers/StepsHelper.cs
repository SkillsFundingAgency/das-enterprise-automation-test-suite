using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;

    public StepsHelper(ScenarioContext context) => _context = context;

    public SearchHomePage Tier1LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier1User>());

    public SearchHomePage Tier2LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier2User>());

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

    private SearchHomePage LoginToSupportConsole(DfeAdminUser loginUser)
    {
        new DfeSignInPage(_context).SubmitValidLoginDetails(loginUser);

        return new(_context);
    }
}