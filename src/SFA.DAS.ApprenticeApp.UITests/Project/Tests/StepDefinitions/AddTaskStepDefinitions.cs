using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddTaskStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private TasksPage tasksPage;
        private string taskName;

        [When("the apprentice adds a new task")]
        public void WhenTheApprenticeAddsANewTask()
        {
            tasksPage = _stepsHelper.NavigateToTasksPage();
            taskName = tasksPage.GenerateTaskName();
            tasksPage.AddTask(taskName, DateTime.Now.AddDays(+2).ToString("dd/MM/yyyy"), TimeOnly.FromDateTime(DateTime.Now).ToString("hh:mm:ss"), "KSB", "1", "Assignment", "Status", "Note");
        }

        [Then("the task is added to the task list")]
        public void ThenTheTaskIsAddedToTheTaskList()
        {
            Assert.IsTrue(tasksPage.IsTaskAdded(taskName), "Task was not added successfully.");
        }

        [When("the apprentice attaches a KSB to the task")]
        public void WhenTheApprenticeAttachesAKSBToTheTask()
        {
            
        }
    }
}
