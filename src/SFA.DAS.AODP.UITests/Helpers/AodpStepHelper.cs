using System.Threading.Tasks;
using SFA.DAS.AODP.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Helpers
{
    public class AodpStepsHelper(ScenarioContext context)
    {
       public void GoToAodpLandingPage() =>  new AodpLandingPage(context).Navigate();

    }
}