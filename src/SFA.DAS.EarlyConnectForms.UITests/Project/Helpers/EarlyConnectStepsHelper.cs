using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectStepsHelper(ScenarioContext context)
    {
        public EarlyConnectHomePage GoToEarlyConnectHomePage()
        {
            return new EarlyConnectHomePage(context).AcceptCookieAndAlert();
        }

        public EarlyConnectHomePage GoToEarlyConnectAdvisorPage()
        {
            return new EarlyConnectHomePage(context).SelectNorthEast();
        }

        public GetApprenticeshipAdviserPage GoToEarlyConnectEmailPage()
        {
            return new GetApprenticeshipAdviserPage(context).GoToEmailAddressPage();
        }
    }
}
