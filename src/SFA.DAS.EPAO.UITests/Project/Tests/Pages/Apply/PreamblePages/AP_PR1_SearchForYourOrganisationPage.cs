namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;

public class AP_PR1_SearchForYourOrganisationPage : EPAO_BasePage
{
    protected override string PageTitle => "Search for your organisation";

    #region Locators
    private static By SearchTextBox => By.Id("search-string");
    #endregion

    public AP_PR1_SearchForYourOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_PR2_SearchResultsForPage EnterOrgNameAndSearchInSearchForYourOrgPage()
    {
        formCompletionHelper.EnterText(SearchTextBox, objectContext.GetApplyOrganisationName());
        Continue();
        return new(context);
    }

    public AP_PR2_SearchResultsForPage EnterInvalidOrgNameAndSearchInSearchForYourOrgPage(string searchTerm)
    {
        formCompletionHelper.EnterText(SearchTextBox, searchTerm);
        Continue();
        return new(context);
    }
}