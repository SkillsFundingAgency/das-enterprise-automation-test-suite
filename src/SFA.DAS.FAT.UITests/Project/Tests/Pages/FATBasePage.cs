namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public abstract class FATBasePage : VerifyBasePage
{
    #region Locators
    protected override By BackLink => By.CssSelector("a.link-back");
    protected static By SearchTextField => By.Id("keyword-input");
    protected virtual By SearchButton => By.Id("filters-submit");
    protected virtual By FirstProviderResultLink => By.ClassName("das-search-results__link");
    protected virtual By HomePageLink => By.LinkText("Home");
    protected virtual By ViewShortlistLink => By.Id("header-view-shortlist");
    #endregion

    protected FATBasePage(ScenarioContext context) : base(context) => VerifyPage(); 

    public void SearchApprenticeship(string searchTerm)
    {
        formCompletionHelper.EnterText(SearchTextField, searchTerm);
        formCompletionHelper.Click(SearchButton);
    }
    protected void NavigateToHomepage() => formCompletionHelper.Click(HomePageLink);

    protected void NavigateToShortlistPage() => formCompletionHelper.Click(ViewShortlistLink);
}
