using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class AuthTestUserHomePage : HomePage
    {
        protected override bool CaptureUrl => false;

        public AuthTestUserHomePage(ScenarioContext context) : base(context) { }
    }
}