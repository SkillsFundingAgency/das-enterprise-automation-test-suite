namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASignedInLandingBasePage(ScenarioContext context, bool verifyPage = true) : FAABasePage(context, verifyPage)
{
    protected override By PageHeader => By.CssSelector(".one-login-header");

    protected override string PageTitle => "Sign out";

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/apprenticeships']");

    private static By ApplicationsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");

    private static By What => By.CssSelector("[id='WhatSearchTerm']");

    private static By Where => By.CssSelector("[id='WhereSearchTerm']");

    private static By SearchFAA => By.CssSelector(".form button");
    private static By VacancyName => By.CssSelector("span[itemprop='title']");

    private static By SavedVacancyLink => By.CssSelector(".govuk-link.govuk-link--no-visited-state");
    private static By FirstApplicationDisplayed => By.CssSelector("[id^='VAC'][id$='-vacancy-title']");

    public FAA_ApplicationsPage GoToApplications()
    {
        formCompletionHelper.Click(ApplicationsHeader);

        return new(context);
    }

    public FAASearchApprenticeLandingPage GoToSearch()
    {
        formCompletionHelper.Click(SearchHeader);

        return new(context);
    }

    public FAA_ApprenticeSummaryPage SearchByReferenceNumber()
    {
        SearchUsingVacancyTitle();

        GoToVacancyInFAA();

        return new FAA_ApprenticeSummaryPage(context);
    }

    public void SearchByWhatWhere(string whatText, string whereText)
    {
        formCompletionHelper.EnterText(What, whatText);

        formCompletionHelper.EnterText(Where, whereText);

        formCompletionHelper.Click(SearchFAA);
    }

    public void SearchByWhat(string whatText)
    {
        formCompletionHelper.EnterText(What, whatText);

        formCompletionHelper.Click(SearchFAA);
    }

    public void SearchByWhere(string whereText)
    {
        formCompletionHelper.EnterText(Where, whereText);

        formCompletionHelper.Click(SearchFAA);
    }

    public FAASearchResultPage SearchAtRandom()
    {
        formCompletionHelper.Click(SearchFAA);

        return new FAASearchResultPage(context);
    }

    public FAASearchResultPage SearchRandomVacancyAndGetVacancyTitle()
    {
        formCompletionHelper.Click(SearchFAA);

        var vacancyTitle = pageInteractionHelper.GetText(FirstApplicationDisplayed);

        objectContext.Set("vacancyTitle", vacancyTitle);

        var contextVacancyTitle = objectContext.Get("vacancyTitle");

        return new FAASearchResultPage(context);
    }

    public FAASearchResultPage SearchAndSaveVacancyByReferenceNumber()
    {
        SearchUsingVacancyTitle();

        return new FAASearchResultPage(context);
    }
}
