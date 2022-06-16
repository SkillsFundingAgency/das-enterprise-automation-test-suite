namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class SearchForApprenticeshipPage : ToolSupportBasePage
{
    protected override string PageTitle => "Search for an apprenticeship.";

    #region Locators
    private static By EmployerName => By.Id("employerName");
    private static By ProviderName => By.Id("providerName");
    private static By Ukprn => By.Id("ukprn");
    private static By CourseName => By.Id("courseName");
    private static By ApprenticeNameOrUln => By.Id("apprenticeNameOrUln");
    private static By EndDate => By.Id("endDate");
    private static By ApprenticeshipStatus => By.Id("SelectedStatus");
    private static By DataTable => By.Id("apprenticeshipResultsTable");
    private static By PaginationInfo => By.ClassName("pagination-info");
    private static By PageSelector => By.ClassName("page-link");
    private static By SelectAllChkBox => By.Name("btSelectAll");
    private static By SubmitButton => By.Id("submitSearchFormButton");
    private static By PauseButton => By.CssSelector("#searchResultsForm .govuk-button");
    private static By ResumeButton => By.XPath("//button[contains(text(),'Resume apprenticeship(s)')]");
    private static By StopButton => By.XPath("//button[contains(text(),'Stop apprenticeship(s)')]");
    private static By UlnColumn => By.CssSelector("#apprenticeshipResultsTable tr td:nth-child(3)");
    #endregion

    public SearchForApprenticeshipPage(ScenarioContext context, bool verifyPage = true) : base(context, verifyPage) { }

    public SearchForApprenticeshipPage EnterEmployerName(string employerName)
    {
        formCompletionHelper.EnterText(EmployerName, employerName);
        return this;
    }

    public SearchForApprenticeshipPage EnterProviderName(string providerName)
    {
        formCompletionHelper.EnterText(ProviderName, providerName);
        return this;
    }

    public SearchForApprenticeshipPage EnterUkprn(string ukprn)
    {
        formCompletionHelper.EnterText(Ukprn, ukprn);
        return this;
    }

    public SearchForApprenticeshipPage EnterCourseName(string courseName)
    {
        formCompletionHelper.EnterText(CourseName, courseName);
        return this;
    }

    public SearchForApprenticeshipPage EnterEndDate(string endDate)
    {
        formCompletionHelper.EnterText(EndDate, endDate);
        return this;
    }

    public SearchForApprenticeshipPage EnterULNorApprenticeName(string apprenticeNameOrUln)
    {
        formCompletionHelper.EnterText(ApprenticeNameOrUln, apprenticeNameOrUln);
        return this;
    }
    public SearchForApprenticeshipPage SelectStatus(string status)
    {
        status = (status == "" ? "Any" : status);
        formCompletionHelper.SelectFromDropDownByText(ApprenticeshipStatus, status);
        return this;
    }

    public SearchForApprenticeshipPage SelectAllRecords()
    {
        pageInteractionHelper.WaitForElementToBeClickable(PageSelector);
        formCompletionHelper.ClickElement(SelectAllChkBox);

        var isChecked = pageInteractionHelper.FindElement(SelectAllChkBox).GetAttribute("checked");

        if (isChecked == "false" || isChecked == null)
        {
            pageInteractionHelper.WaitForElementToBeClickable(PageSelector);
            formCompletionHelper.ClickElement(SelectAllChkBox);
        }


        return this;
    }


    public SearchForApprenticeshipPage ClickSubmitButton()
    {
        formCompletionHelper.Click(SubmitButton);
        return new (context);
    }

    public PauseApprenticeshipsPage ClickPauseButton()
    {
        pageInteractionHelper.WaitForElementToBeDisplayed(PaginationInfo);
        javaScriptHelper.ScrollToTheBottom();
        formCompletionHelper.Click(PauseButton);
        return new (context);
    }

    public ResumeApprenticeshipsPage ClickResumeButton()
    {
        formCompletionHelper.Click(ResumeButton);
        return new (context);
    }

    public StopApprenticeshipsPage ClickStopButton()
    {
        formCompletionHelper.Click(StopButton);
        return new (context);
    }

    public int GetNumberOfRecordsFound()
    {
        pageInteractionHelper.WaitForElementToBeDisplayed(DataTable);
        var paginationInfo = pageInteractionHelper.GetText(PaginationInfo);
        var arrPaginationInfo = paginationInfo.Split(" ");

        if (arrPaginationInfo.Length < 5)
            return 0;
        else
            return (Convert.ToInt32(arrPaginationInfo[5]));
    }

    public List<IWebElement> GetULNsFromApprenticeshipTable() => pageInteractionHelper.FindElements(UlnColumn);

}
