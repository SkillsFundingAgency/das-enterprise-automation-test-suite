namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_ApplicationsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Your applications";

    private static By SuccessfulLink => By.CssSelector("a[href='/applications?tab=Successful']");

    private static By UnsuccessfulLink => By.CssSelector("a[href='/applications?tab=Unsuccessful']");
    private static By SubmittedlLink => By.CssSelector("a[href='/applications?tab=Submitted']");

    private static By SearchResultItem => By.CssSelector(".das-search-results__list-item");

    private static By ViewApplicationLink => By.CssSelector("a[href*='view']");

    public FAA_SuccessfulApplicationPage OpenSuccessfulApplicationPage()
    {
        formCompletionHelper.Click(SuccessfulLink);
        if(IsFoundationAdvert)
        {
            CheckFoundationTag();
        }
        return new(context);
    }

    public FAA_UnSuccessfulApplicationPage OpenUnSuccessfulApplicationPage()
    {
        formCompletionHelper.Click(UnsuccessfulLink);
        if (IsFoundationAdvert)
        {
            CheckFoundationTag();
        }
        return new(context);
    }
    public FAA_SubmittedApplicationPage OpenSubmittedlApplicationPage()
    {
        formCompletionHelper.Click(SubmittedlLink);
        if (IsFoundationAdvert)
        {
            CheckFoundationTag();
        }
        return new(context);
    }

    public void ViewApplication()
    {
        pageInteractionHelper.FindElements(SearchResultItem).Single(x => x.Text.ContainsCompareCaseInsensitive(vacancyTitleDataHelper.VacancyTitle)).FindElement(ViewApplicationLink).Click();
        if (IsFoundationAdvert)
        {
            CheckFoundationTag();
        }
    }
}
