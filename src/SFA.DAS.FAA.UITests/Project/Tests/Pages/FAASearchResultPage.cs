namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchResultPage : FAASignedInLandingBasePage
{
    protected override By PageHeader => By.CssSelector(".das-search-results__link");

    protected By ResultsFound => By.CssSelector("h1.govuk-heading-l.govuk-!-margin-bottom-8");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    private static By VacancyName => By.ClassName("das-search-results__link");
    private static By FavouriteIcon => By.CssSelector("[data-add-favourite=true]");
    private static By SavedVacancyNavBarLink => By.LinkText("Saved vacancies");
    private static By ApplyNow => By.CssSelector(".das-button--inline-link");



    public FAASearchResultPage(ScenarioContext context) : base(context, false)
    {
        
    }

    public void VerifySuccessfulResults()
    {
        pageInteractionHelper.IsElementDisplayed(ResultsFound);
    }
    public FAA_ApplicationOverviewPage SaveFromSearchResultsAndApplyForVacancy()
    {
        var savedVacancyName = pageInteractionHelper.GetText(VacancyName);

        formCompletionHelper.Click(FavouriteIcon);
        formCompletionHelper.Click(SavedVacancyNavBarLink);
        formCompletionHelper.Click(ApplyNow);

        return new FAA_ApplicationOverviewPage(context);
    }
}
