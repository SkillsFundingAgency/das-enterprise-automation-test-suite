namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class CommitmentsSearchPage : SupportConsoleBasePage
{
    protected override string PageTitle => "Department for Education";
    public static string SearchSectionHeaderText => "Search";
    public static string UlnSearchTextBoxHelpTextContent => "Enter ULN number";
    public static string CohortSearchTextBoxHelpTextContent => "Enter Cohort Reference number";
    public static string InvalidUln => "1234567";
    public static string InvalidUlnWithSpecialChars => "!£$%^&*()@?|#";
    public static string InvalidCohort => "ABCD";
    public static string InvalidCohortWithSpecialChars => "!£$%^&*()@?|#";
    public static string UlnSearchErrorMessage => "Please enter a 10-digit unique learner number";
    public static string CohortSearchErrorMessage => "Please enter a 6-digit Cohort number";
    public static string UnauthorisedCohortSearchErrorMessage => "Account is unauthorised to access this Cohort.";

    #region Locators
    private static By SearchSectionHeader => By.CssSelector(".searchfield h1");
    private static By UlnRadioButton => By.CssSelector("label");
    private static By CohortRefRadioButton => By.CssSelector("label");
    private static By SearchTextBox => By.Id("search-main");
    private static By SearchButton => By.Id("searchButton");
    private static By SearchTextBoxHelpText => By.Id("search-main");
    private static By CommitmentsSearchPageErrorText => By.CssSelector(".error-message");

    public CommitmentsSqlDataHelper SqlDataHelper { get; }
    #endregion

    public CommitmentsSearchPage(ScenarioContext context) : base(context)
    {
        VerifyPage(SearchSectionHeader, SearchSectionHeaderText);
        SqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
    }

    private void EnterTextInSearchBox(string searchText) => formCompletionHelper.EnterText(SearchTextBox, searchText);

    public CommitmentsSearchPage SelectUlnSearchTypeRadioButton()
    {
        formCompletionHelper.SelectRadioOptionByForAttribute(UlnRadioButton, "UnlSearchType");
        return this;
    }

    private void ClickSearchButton() => formCompletionHelper.Click(SearchButton);

    public UlnSearchResultsPage SearchForULN()
    {
        SelectUlnSearchTypeRadioButton();
        Search(config.CohortDetails.Uln);
        return new(context);
    }

    public void SearchWithInvalidULN() => Search(InvalidUln);

    public void SearchWithInvalidULNWithSpecialChars() => Search(InvalidUlnWithSpecialChars);


    public CohortSummaryPage SearchForCohort() => SearchCohort(config.CohortDetails.CohortRef);
    
    public CohortSummaryPage SearchForCohortWithPendingChanges() => SearchCohort(config.CohortWithPendingChanges.CohortRef);

    public CohortSummaryPage SearchForCohortWithTrainingProviderHistory() => SearchCohort(config.CohortWithTrainingProviderHistory.CohortRef);

    public CommitmentsSearchPage SelectCohortRefSearchTypeRadioButton()
    {
        formCompletionHelper.SelectRadioOptionByForAttribute(CohortRefRadioButton, "CohortSearchType");
        return this;
    }

    public void SearchWithInvalidCohort() => Search(InvalidCohort);

    public void SearchWithUnauthorisedCohortAccess() => Search(config.CohortNotAssociatedToAccount.CohortRef);

    public void SearchWithInvalidCohortWithSpecialChars() => Search(InvalidCohortWithSpecialChars);

    public string GetCommitmentsSearchPageErrorText() => pageInteractionHelper.GetText(CommitmentsSearchPageErrorText);

    public string GetSearchTextBoxHelpText() => pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText);

    public CohortSummaryPage SearchCohort(string text)
    {
        SelectCohortRefSearchTypeRadioButton();
        Search(text);
        return new(context);
    }

    private void Search(string text) { EnterTextInSearchBox(text); ClickSearchButton(); }
}