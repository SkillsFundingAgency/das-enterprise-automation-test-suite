namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASignedInLandingBasePage(ScenarioContext context, bool verifyPage = true) : FAABasePage(context, verifyPage)
{
    protected override By PageHeader => By.CssSelector(".one-login-header");

    protected override string PageTitle => "Sign out";

    private static By SearchHeader => By.CssSelector("[id='service-header__nav'] a[href='/apprenticeships']");

    private static By ApplicationsHeader => By.CssSelector("[id='service-header__nav'] a[href='/applications']");

    private static By What => By.CssSelector("[id='WhatSearchTerm']");

    private static By Where => By.CssSelector("[id='WhereSearchTerm']");

    private static By SearchFAA => By.XPath(".//button[text()='Search']");

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

    public FAASearchApprenticeLandingPage SearchByWhatWhere(string whatText, string whereText)
    {
        formCompletionHelper.EnterText(What, whatText);

        formCompletionHelper.EnterText(Where, whereText);

        formCompletionHelper.Click(SearchFAA);

        return new FAASearchApprenticeLandingPage(context);
    }

    public FAASearchApprenticeLandingPage SearchByWhat(string whatText)
    {
        formCompletionHelper.EnterText(What, whatText);

        formCompletionHelper.Click(SearchFAA);

        return new FAASearchApprenticeLandingPage(context);
    }
}
