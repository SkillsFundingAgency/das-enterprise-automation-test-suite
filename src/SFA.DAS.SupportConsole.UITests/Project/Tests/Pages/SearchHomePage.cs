namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class SearchHomePage : SupportConsoleBasePage
{
    protected override string PageTitle => "Search";

    #region Locators
    protected override By PageHeader => By.CssSelector(".heading-large");
    private static By SearchOptionsLabels => By.CssSelector("label");
    private static By SearchButton => By.Id("searchButton");
    private static By SearchTextBox => By.Id("search-main");
    private static By NextPage => By.CssSelector(".page-navigation .next");
    private static By NoOfPages => By.CssSelector(".page-navigation .next .counter");
    #endregion

    private static string AccountSearchHint => "Enter account name, account ID or PAYE scheme";
    private static string UserSearchHint => "Enter name or email address";
    private static By StartNowButton => By.CssSelector(".govuk-button--start");

    public SearchHomePage(ScenarioContext context) : base(context)
    {
        if (pageInteractionHelper.IsElementPresent(StartNowButton))
            formCompletionHelper.Click(StartNowButton);
        
        VerifyPage();
    }

    public UserInformationOverviewPage SearchByNameAndView() => SearchAndViewUserInformation(config.Name);

    public UserInformationOverviewPage SearchByEmailAddressAndView() => SearchAndViewUserInformation(config.EmailAddress);

    public AccountOverviewPage SearchByPublicAccountIdAndViewAccount() => SearchAndViewAccount(config.PublicAccountId);

    public AccountOverviewPage SearchByHashedAccountIdAndViewAccount() => SearchAndViewAccount(config.HashedAccountId);

    public AccountOverviewPage SearchByAccountNameAndViewAccount() => SearchAndViewAccount(config.AccountName);

    public AccountOverviewPage SearchByPayeSchemeAndViewAccount() => SearchAndViewAccount(config.PayeScheme);

    private AccountOverviewPage SearchAndViewAccount(string criteria)
    {
        formCompletionHelper.SelectRadioOptionByForAttribute(SearchOptionsLabels, "AccountSearchType");
        pageInteractionHelper.WaitForElementToChange(SearchTextBox, "placeholder", AccountSearchHint);
        formCompletionHelper.EnterText(SearchTextBox, criteria);
        formCompletionHelper.Click(SearchButton);
        tableRowHelper.SelectRowFromTable("view", config.PublicAccountId, NextPage, NoOfPages);
        return new (context);
    }

    private UserInformationOverviewPage SearchAndViewUserInformation(string criteria)
    {
        formCompletionHelper.SelectRadioOptionByForAttribute(SearchOptionsLabels, "UserSearchType");
        pageInteractionHelper.WaitForElementToChange(SearchTextBox, "placeholder", UserSearchHint);
        formCompletionHelper.EnterText(SearchTextBox, criteria);
        formCompletionHelper.Click(SearchButton);
        tableRowHelper.SelectRowFromTable("view", config.EmailAddress, NextPage, NoOfPages);
        return new (context);
    }
}