namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class ApprenticeshipTrainingCourseSummaryPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => objectContext.GetTrainingCourseName();

    protected override string AccessibilityPageTitle => "Training course name Page";

    #region Locators
    private static By LocationTextBox => By.Id("search-location");
    private static By ViewProvidersForThisCourseButton => By.XPath("//a[contains(.,'View providers for this course')]");   
    private static By BackToCourseSearchPage => By.Id("courses-breadcrumb");
    private static By AutoCompleteMenu => By.ClassName("autocomplete__menu--visible");
    private static By ApprenticeTravel => By.XPath("//h3[@class='govuk-heading-s govuk-!-margin-bottom-6']");

    #endregion

    public FATIndexPage NavigateBackToHompage()
    {
        NavigateToHomepage();
        return new FATIndexPage(context);
    }

    public ProviderSearchResultsPage ViewProvidersForThisCourse() => ViewProvidersForThisCourse(false, string.Empty);

    public ProviderSearchResultsPage ViewProvidersForThisCourse(string location) => ViewProvidersForThisCourse(true, location);

    public ProviderSearchResultsPage ViewProvidersForThisCourse(bool filterByLocation, string location)
    {
        if (filterByLocation)
        {
            location = string.IsNullOrEmpty(location) ? RandomDataGenerator.RandomTown() : location;

            formCompletionHelper.EnterText(LocationTextBox, location);

            pageInteractionHelper.WaitForElementToBeDisplayed(AutoCompleteMenu);

            formCompletionHelper.Click(AutoCompleteMenu);

            pageInteractionHelper.WaitForElementToBeDisplayed(ApprenticeTravel);

        }

        formCompletionHelper.Click(ViewProvidersForThisCourseButton);

        return new ProviderSearchResultsPage(context);
    }

    public ApprenticeshipTrainingCoursesPage NavigateBackFromCourseSummaryPage()
    {
        NavigateBackToCourseSummary();
        return new ApprenticeshipTrainingCoursesPage(context);
    }

    public ApprenticeshipTrainingCoursesPage NavigateBackToCourseSummary()
    {
        formCompletionHelper.Click(BackToCourseSearchPage);
        return new ApprenticeshipTrainingCoursesPage(context);
    }
}
