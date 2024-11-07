namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchResultPage : FAASignedInLandingBasePage
{
    protected override By PageHeader => By.CssSelector(".das-search-results__link");

    protected By ResultsFound => By.CssSelector(".das-search-results__link");

    protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

    public FAASearchResultPage(ScenarioContext context) : base(context, false)
    {
        VerifyPage(RefreshPage);     
    }

    public void VerifySuccessfulResults() 
    {
        pageInteractionHelper.IsElementDisplayed(ResultsFound);
    }
}
