using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aodp")]
public class AODPHooks(ScenarioContext context) : AODPBaseHooks(context)
{
    [BeforeScenario(Order = 1)]
    public void NavigateToAodpServiceLandingPage() => tabHelper.GoToUrl(UrlConfig.Aodp_BaseUrl);
}
