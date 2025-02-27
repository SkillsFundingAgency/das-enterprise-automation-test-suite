using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Helpers
{
    public class AppStepsHelper(ScenarioContext context)
    {
        public HomePage GoToHomePage() => new CookiePage(context).AccessHomePage();
        public StubSignIn GoToStubSigin() => new HomePage(context).AppSignIn();
        public WelcomePage GoToWelcomePage() => new StubSignIn(context).SignIn();
        public TasksPage GoToTasksPage() => new WelcomePage(context).StartNow();

    }
}
