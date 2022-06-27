using SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions;

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
        EnterTextInSearchBox(config.Uln);
        ClickSearchButton();
        return new (context);
    }

    public void SearchWithInvalidULN()
    {
        EnterTextInSearchBox(InvalidUln);
        ClickSearchButton();
    }

    public void SearchWithInvalidULNWithSpecialChars()
    {
        EnterTextInSearchBox(InvalidUlnWithSpecialChars);
        ClickSearchButton();
    }

    public CohortSummaryPage SearchForCohort()
    {
        SelectCohortRefSearchTypeRadioButton();
        EnterTextInSearchBox(config.CohortRef);
        ClickSearchButton();
        return new (context);
    }

    public CohortSummaryPage SearchForCohortWithPendingChanges()
    {
        SelectCohortRefSearchTypeRadioButton();
        var cohortRef = SqlDataHelper.GetCohortWithPendingChanges(config.HashedAccountId);
        EnterTextInSearchBox(cohortRef);
        ClickSearchButton();
        context.Replace("CohortWithPendingChanges", cohortRef);
        return new(context);
    }

    public CohortSummaryPage SearchForCohortWithTrainingProviderHistory()
    {
        SelectCohortRefSearchTypeRadioButton();
        var cohortRef = SqlDataHelper.GetCohortWithTrainingProviderHistory(config.HashedAccountId);
        EnterTextInSearchBox(cohortRef);
        ClickSearchButton();
        context.Replace(CommitmentsTrainingProviderHistorySteps.CohortWithTrainingProviderHistory, cohortRef);
        return new(context);
    }

    public CommitmentsSearchPage SelectCohortRefSearchTypeRadioButton()
    {
        formCompletionHelper.SelectRadioOptionByForAttribute(CohortRefRadioButton, "CohortSearchType");
        return this;
    }

    public void SearchWithInvalidCohort()
    {
        EnterTextInSearchBox(InvalidCohort);
        ClickSearchButton();
    }

    public void SearchWithUnauthorisedCohortAccess()
    {
        EnterTextInSearchBox(config.CohortNotAssociatedToAccount);
        ClickSearchButton();
    }

    public void SearchWithInvalidCohortWithSpecialChars()
    {
        EnterTextInSearchBox(InvalidCohortWithSpecialChars);
        ClickSearchButton();
    }

    public string GetCommitmentsSearchPageErrorText() => pageInteractionHelper.GetText(CommitmentsSearchPageErrorText);

    public string GetSearchTextBoxHelpText() => pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText);
}