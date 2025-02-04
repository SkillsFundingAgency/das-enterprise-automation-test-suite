using SFA.DAS.AODP.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Helpers
{
    public class AodpStepsHelper(ScenarioContext context)
    {
        public void verifyAodpLandingPage() => new AodpLandingPage(context).verifyLandingPage();

    }
}