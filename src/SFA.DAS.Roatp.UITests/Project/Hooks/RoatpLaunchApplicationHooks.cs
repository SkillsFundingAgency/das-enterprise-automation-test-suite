using SFA.DAS.UI.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding]
    public class RoatpLaunchApplicationHooks : RoatpBaseHooks
    {
        private readonly string[] _tags;

        public RoatpLaunchApplicationHooks(ScenarioContext context) : base(context) { _tags = context.ScenarioInfo.Tags; }

        [BeforeScenario(Order = 39)]
        public void NavigateToRoatpApply()
        {
            if (_tags.Any(x => x == "roatpapply" || x == "roatpapplycreateaccount" || x == "roatpfulle2e")) GoToUrl(UrlConfig.Apply_BaseUrl);

            if (_tags.Contains("roatpadmin")) GoToUrl(UrlConfig.Admin_BaseUrl);

            if (_tags.Contains("roatpassessoradmin")) GoToUrl(UrlConfig.RoATPAssessor_BaseUrl);
        }
    }
}
