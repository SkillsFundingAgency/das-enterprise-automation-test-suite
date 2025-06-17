using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

public class ApimAccessDeniedPage(ScenarioContext context) : ApprovalsBasePage(context)
{
    protected override string PageTitle => "To continue, you'll need to get your role for this service changed.";
    private static By GoBackToHomePage => By.LinkText("homepage of this service.");

    public ApprovalsProviderHomePage GoBackToTheServiceHomePage()
    {
        formCompletionHelper.ClickElement(GoBackToHomePage);
        return new ApprovalsProviderHomePage(context);
    }
}
