using OpenQA.Selenium;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Helpers
{
    public class AppStepsHelper(ScenarioContext context) : AppBasePage(context)
    {
        private static By TasksNavLink => By.CssSelector("a.app-navigation__link[href='/Tasks/Index");
        private static By ToDoTabNavLink => By.CssSelector("a.app-tabs__tab.todo[href=\"#tasks-todo\"][role=\"tab\"][aria-selected=\"false\"]");
        private static By DoneTabNavLink => By.CssSelector("a.app-tabs__tab.done[href=\"#tasks-done\"][role=\"tab\"][aria-selected=\"false\"]");
        private static By KsbNavLink => By.CssSelector("a.app-navigation__link[href='/Ksb/Index']");
        private static By SupportNavLink => By.CssSelector("a.app-navigation__link[href='/Support/Index']");
        private static By NotificationsNavLink => By.CssSelector("a.app-navigation__link[href='/Notifications/Index']");
        private static By AccountNavLink => By.CssSelector("a.app-navigation__link[href='/Account/YourAccount']");
        private static By YourProfileLink => By.CssSelector("a.app-stack__link[href='/Profile/Index']");
        private static By SettingsLink => By.CssSelector("a.app-stack__link[href='/Settings/Index']");

        protected override string PageTitle => throw new System.NotImplementedException();

        public HomePage GoToHomePage() => new CookiePage(context).AccessHomePage();
        public StubSignInPage GoToStubSigin() => new HomePage(context).AppSignIn();
        public WelcomePage GoToWelcomePage() => new StubSignInPage(context).SignIn();
        public TasksBasePage GoToTasksPage() => new WelcomePage(context).StartNow();

        public TasksBasePage NavigateToToDoTab()
        {
            formCompletionHelper.Click(TasksNavLink);
            return new TasksBasePage(context);
        }

        public DoneTasksPage NavigateToDoneTab()
        {
            formCompletionHelper.Click(DoneTabNavLink);
            return new DoneTasksPage(context);
        }
        
        public KsbPage NavigateToKsbPage()
        {
            formCompletionHelper.Click(KsbNavLink);
            return new KsbPage(context);
        }

        public SupportGuidancePage NavigateToSupportGuidancePage()
        {
            formCompletionHelper.Click(SupportNavLink);
            return new SupportGuidancePage(context);
        }

        public NotificationsPage NavigateToNotificationsPage()
        {
            formCompletionHelper.Click(NotificationsNavLink);
            return new NotificationsPage(context);
        }

        public AccountPage NavigateToAccountPage()
        {
            formCompletionHelper.Click(AccountNavLink);
            return new AccountPage(context);
        }
        public YourProfilePage NavigateToYourProfilePage()
        {
            formCompletionHelper.Click(YourProfileLink);
            return new YourProfilePage(context);
        }

        public SettingsPage NavigateToSettingsPage()
        {
            formCompletionHelper.Click(SettingsLink);
            return new SettingsPage(context);
        }

    }
}
