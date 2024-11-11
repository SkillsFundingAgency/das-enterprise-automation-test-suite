namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_ApprenticeSummaryPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".faa-vacancy__title");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    protected override string AccessibilityPageTitle => "FAA vacancy title page";

    private static By ApplyButton => By.CssSelector("button[class='govuk-button govuk-!-margin-bottom-0']");

    private static By ViewSubmittedApplicationLink => By.CssSelector("a[href*='Submitted']");

    private static By SaveVacancyLink => By.XPath("//span[normalize-space()='Save vacancy']");

    private static By SavedVacanciesNavBar => By.XPath("//a[normalize-space()='Saved vacancies']");
    private static By SavedVacancyLink => By.CssSelector(".govuk-link.govuk-link--no-visited-state");
    private static By VacancyName => By.CssSelector(".govuk-heading-l faa-vacancy__title");


    public FAA_ApplicationOverviewPage Apply()
    {
        formCompletionHelper.Click(ApplyButton);
        return new FAA_ApplicationOverviewPage(context);
    }

    public FAA_SubmittedApplicationPage ViewSubmittedApplications()
    {
        formCompletionHelper.Click(ViewSubmittedApplicationLink);
        return new FAA_SubmittedApplicationPage(context);
    }

    public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
    {
        pageInteractionHelper.VerifyText(ApplyButton, "Continue your application");
        return this;
    }

    public FAA_ApprenticeSummaryPage SaveAndApplyForVacancy()
    {
        formCompletionHelper.Click(SaveVacancyLink);
        formCompletionHelper.Click(SavedVacanciesNavBar);
        formCompletionHelper.ClickLinkByText(SavedVacancyLink, vacancyTitleDataHelper.VacancyTitle);
        return new FAA_ApprenticeSummaryPage(context);
    }
}
