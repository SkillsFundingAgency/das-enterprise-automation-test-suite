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

        [BeforeScenario(Order = 40)]
        public void RoatpLaunchApplication()
        {
            if (_tags.Any(x => x == "roatpapply" || x == "roatpapplycreateaccount" || x == "roatpfulle2eviaapply" || IsAdminTestDataPrep(x)
            || x == "roatpapplyinprogressapplication" || x == "roatpapplychangeukprn" || x == "roatpapplytestdataprep")) GoToUrl(UrlConfig.Apply_BaseUrl);

            if (_tags.Any(x => x == "oldroatpadmin" || x == "newroatpadmin" || x == "roatpfulle2eviaadmin")) GoToUrl(UrlConfig.Admin_BaseUrl);

            if (_tags.Contains("roatpassessoradmin")) GoToUrl(UrlConfig.RoATPAssessor_BaseUrl);
        }

        private bool IsAdminTestDataPrep(string tag) => tag == "roatpadmintestdataprep";
    }
}
