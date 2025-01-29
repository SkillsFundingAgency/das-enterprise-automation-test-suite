using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.Pages;

public class AodpLandingPage(ScenarioContext context) : AodpBasePage(context)
{
    protected override string PageTitle => "Landing Page";

    public void Navigate()
    {
        tabHelper.GoToUrl(UrlConfig.Aodp_BaseUrl);
    }
}