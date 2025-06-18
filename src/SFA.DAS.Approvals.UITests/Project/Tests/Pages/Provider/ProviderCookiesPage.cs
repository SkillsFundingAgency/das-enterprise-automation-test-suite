using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

public class ProviderCookiesPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "Cookies";
    protected static By ProviderHomeLink => By.LinkText("Home");

    public ApprovalsProviderHomePage GoToProviderHomePage()
    {
        formCompletionHelper.ClickElement(ProviderHomeLink);
        return new ApprovalsProviderHomePage(context);
    }
}
