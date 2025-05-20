namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationOverview;

public class ApplicationSubmittedPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Application submitted";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

    private static By SignoutLink => By.LinkText("Sign out");

    public void ClickSignOut()
    {
        formCompletionHelper.Click(SignoutLink);
      
    }
}

