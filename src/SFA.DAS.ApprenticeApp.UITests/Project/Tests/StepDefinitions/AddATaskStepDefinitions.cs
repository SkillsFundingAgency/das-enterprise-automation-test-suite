using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddATaskStepDefinitions(ScenarioContext context)
    {
        private readonly TasksBasePage tasksBasePage = new(context);
        private string toDoTaskName;
        private string doneTaskName;

        [When("the apprentice adds a new to do task")]
        public void WhenTheApprenticeAddsANewTask()
        {
            toDoTaskName = tasksBasePage.GenerateTaskName();
            tasksBasePage.AddTask(true, toDoTaskName, DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"), "12:00p", "KSB", "1", "Assignment", "Status", "Note");
        }

        [When("the apprentice has clicked on the done tasks tab")]
        public void WhenTheApprenticeUserIsOnTheDoneTasksPage()
        {
            tasksBasePage.ClickDoneTab();

        }

        [When("the apprentice adds a new done task")]
        public void WhenTheApprenticeAddsANewDoneTask()
        {
            doneTaskName = tasksBasePage.GenerateTaskName();
            tasksBasePage.AddTask(false, doneTaskName, DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"), "12:00p", "KSB", "1", "Assignment", "Status", "Note");
            //Work around for the issue where the task added is not displayed sometimes
            tasksBasePage.Refresh();
        }

        [Then("the task is added to the to do tasks list")]
        public void ThenTheTaskIsAddedToTheTaskList()
        {
            Assert.IsTrue(tasksBasePage.IsTaskAdded(toDoTaskName), "Task was not added successfully.");
        }            

        [Then("the task is added to the done tasks list")]
        public void ThenTheTaskIsAddedToTheDoneTasksList()
        {
            Assert.IsTrue(tasksBasePage.IsTaskAdded(doneTaskName), "The task was not added to the done tasks list");
        }
    }
}
