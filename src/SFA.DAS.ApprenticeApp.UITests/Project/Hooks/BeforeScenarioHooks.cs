using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void AppSetupHelpers()
        {
            context.SetApprenticeAccountsPortalUser([_configSection.GetConfigSection<ApprenticeAppUser>()]);
        }

        [AfterScenario(Order = 1)]
        public void CleanUpTestData()
        {
            try
            {
                var tasksBasePage = new TasksBasePage(context);
                var appStepsHelper = new AppStepsHelper(context);

                appStepsHelper.NavigateToTasksPage();

                string taskToDelete = null;

                if (context.ContainsKey("UpdatedTaskName"))
                {
                    taskToDelete = context["UpdatedTaskName"].ToString();
                }
                else if (context.ContainsKey("CurrentTaskName"))
                {
                    taskToDelete = context["CurrentTaskName"].ToString();
                }

                if (!string.IsNullOrEmpty(taskToDelete))
                {
                    Console.WriteLine($"[CleanUp] Targeting main scenario task: '{taskToDelete}'");
                    tasksBasePage.CleanUpTaskByTitle(taskToDelete);
                }

                tasksBasePage.SweepOrphanedTasks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CleanUp Warning] Automated sweeper encountered an issue: {ex.Message}");
            }
        }
    }
}