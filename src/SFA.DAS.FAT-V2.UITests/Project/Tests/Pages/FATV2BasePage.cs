namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public abstract class FATV2BasePage : VerifyBasePage
{
    #region Locators
    protected override By BackLink => By.CssSelector("a.link-back");
    protected static By SearchTextField => By.Id("Keyword");
    protected virtual By SearchButton => By.Id("filters-submit");
    protected virtual By FirstResultLink => By.ClassName("das-no-wrap");
    protected virtual By FirstProviderResultLink => By.ClassName("das-search-results__link");
    protected virtual By HomePageLink => By.LinkText("Home");
    protected virtual By ViewShortlistLink => By.Id("header-view-shortlist");
    #endregion

    protected FATV2BasePage(ScenarioContext context) : base(context) => VerifyPage();

    public void SearchApprenticeship(string searchTerm)
    {
        formCompletionHelper.EnterText(SearchTextField, searchTerm);
        formCompletionHelper.Click(SearchButton);
    }
    protected void NavigateToHomepage() => formCompletionHelper.Click(HomePageLink);

    protected void NavigateToShortlistPage() => formCompletionHelper.Click(ViewShortlistLink);
}
