namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_ApprenticeSummaryPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".faa-vacancy__title");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    protected override string AccessibilityPageTitle => "FAA vacancy title page";

    private static By ApplyButton => By.CssSelector("[id='main-content'] button.govuk-button");

    private static By ViewSubmittedApplicationLink => By.CssSelector("a[href*='Submitted']");

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
}
