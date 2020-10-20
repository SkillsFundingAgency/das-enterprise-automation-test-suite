using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapply"), Scope(Tag = "roatpapplycreateaccount")]
    public class RoatpCommonHooks : RoatpBaseHooks
    {
        public RoatpCommonHooks(ScenarioContext context) : base(context) { }
    
        [BeforeScenario(Order = 36)]
        public void NavigateToRoatpApply() => GoToUrl(UrlConfig.Apply_BaseUrl);
    }
}
