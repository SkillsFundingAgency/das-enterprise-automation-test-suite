using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

public class ProviderEmployersAndPermissionsPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "View employers and manage permissions";
    protected static By ProviderHomeLink => By.LinkText("Home");

    public ApprovalsProviderHomePage GoToProviderHomePage()
    {
        formCompletionHelper.ClickElement(ProviderHomeLink);
        return new ApprovalsProviderHomePage(context);
    }
}
