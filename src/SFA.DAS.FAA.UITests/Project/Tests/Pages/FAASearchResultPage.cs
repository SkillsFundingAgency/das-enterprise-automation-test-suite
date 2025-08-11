using SFA.DAS.FAA.UITests.Project.Tests.Pages.Delete;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchResultPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected By ResultsFound => By.CssSelector("h1.govuk-heading-l.govuk-!-margin-bottom-8");

    private static By VacancyName => By.ClassName("das-search-results__link");
    private static By FavouriteIcon => By.CssSelector("[data-add-favourite=true]");
    private static By SavedVacancyNavBarLink => By.LinkText("Saved vacancies");
    private static By ApplyNow => By.CssSelector(".das-button--inline-link");
    private static By FirstApplicationDisplayed => By.CssSelector("[id^='VAC'][id$='-vacancy-title']");
    private static By SignoutLink => By.LinkText("Sign out");
    private static By ClickFirstNHSLinkInResult => By.CssSelector("[id$='-vacancy-title']:first-of-type");


    public void VerifySuccessfulResults()
    {
        pageInteractionHelper.IsElementDisplayed(ResultsFound);
    }

    public void ClickSignout()
    {
        formCompletionHelper.Click(SignoutLink);
    }
    public FAA_ApplicationOverviewPage SaveFromSearchResultsAndApplyForVacancy()
    {
        var savedVacancyName = pageInteractionHelper.GetText(VacancyName);

        formCompletionHelper.Click(FavouriteIcon);
        formCompletionHelper.Click(SavedVacancyNavBarLink);
        formCompletionHelper.Click(ApplyNow);

        return new FAA_ApplicationOverviewPage(context);
    }

    public FAA_ApprenticeSummaryPage ClickFirstApprenticeshipThatCanBeAppliedFor()
    {
        var vacancyTitle = pageInteractionHelper.GetText(FirstApplicationDisplayed);

        objectContext.Set("vacancytitle", vacancyTitle);

        formCompletionHelper.Click(FirstApplicationDisplayed);

        return new FAA_ApprenticeSummaryPage(context);
    }

    public NHSJobsDetailsPage GoToNHSJobDetailsPageAndVerifyJobDisplayed()
    {
        formCompletionHelper.Click(ClickFirstNHSLinkInResult);

        return new NHSJobsDetailsPage(context);
    }
}
