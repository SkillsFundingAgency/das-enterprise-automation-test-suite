namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;

public class AP_PR2_SearchResultsForPage : EPAO_BasePage
{
    protected override string PageTitle => "Search results for";

    #region Locators
    private static By InvalidSearchResultText => By.CssSelector("#main-content .govuk-heading-m");

    private static By SearchTextBox => By.Id("SearchString");
    #endregion

    public AP_PR2_SearchResultsForPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_PR3_SelectOrganisationTypePage ClickOrgLinkFromSearchResultsForPage()
    {
        formCompletionHelper.ClickButtonByText(ContinueButton, objectContext.GetApplyOrganisationName());
        return new(context);
    }

    public AP_PR2_SearchResultsForPage VerifyInvalidSearchResultText()
    {
        pageInteractionHelper.VerifyText(InvalidSearchResultText, "We cannot find your organisation details");
        return this;
    }

    public AP_PR2_SearchResultsForPage EnterInvalidOrgNameAndSearchInSearchResultsForPage(string searchTerm)
    {
        formCompletionHelper.EnterText(SearchTextBox, searchTerm);
        Continue();
        return this;
    }
}
