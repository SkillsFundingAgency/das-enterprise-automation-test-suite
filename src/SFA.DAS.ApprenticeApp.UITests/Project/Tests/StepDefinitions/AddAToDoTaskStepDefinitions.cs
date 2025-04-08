using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddAToDoTaskStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private readonly TasksBasePage tasksBasePage = new(context);
        private ToDoTasksPage toDoTasksPage;
        private string toDoTaskName;

        [When("the apprentice adds a new to do task")]
        public void WhenTheApprenticeAddsANewTask()
        {
            toDoTaskName = tasksBasePage.GenerateTaskName();
            tasksBasePage.AddTask(true, toDoTaskName, DateTime.Now.ToString("dd/MM/yyyy"), "12:00", "KSB", "1", "Assignment", "Status", "Note");
        }

        [Then("the task is added to the to do tasks list")]
        public void ThenTheTaskIsAddedToTheTaskList()
        {
            Assert.IsTrue(tasksBasePage.IsTaskAdded(toDoTaskName), "Task was not added successfully.");
        }

        [When("the apprentice attaches a KSB to the task")]
        public void WhenTheApprenticeAttachesAKSBToTheTask()
        {
            
        }
    }
}
