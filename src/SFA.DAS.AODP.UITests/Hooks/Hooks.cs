using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using SFA.DAS.AODP.UITests.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Hooks
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 1)]
        public Task SetUpHelpers()
        {
            return null;
        }

        [AfterScenario(Order = 1)]
        public Task TearDownUpHelpers()
        {
            return null;
        }
    }
}