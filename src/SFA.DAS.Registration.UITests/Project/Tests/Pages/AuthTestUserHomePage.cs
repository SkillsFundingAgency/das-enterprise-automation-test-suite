using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AuthTestUserHomePage(ScenarioContext context) : HomePage(context)
    {
        protected override bool CaptureUrl => false;
    }
}