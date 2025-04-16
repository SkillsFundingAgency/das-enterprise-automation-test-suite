using System;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddADoneTaskStepDefinitions(ScenarioContext context)
    {
        private readonly TasksBasePage tasksBasePage = new(context);
        private string doneTaskName;

        [When("the apprentice has clicked on the done tasks tab")]
        public void WhenTheApprenticeUserIsOnTheDoneTasksPage()
        {
            tasksBasePage.ClickDoneTab();
        }

        [When("the apprentice adds a new done task")]
        public void WhenTheApprenticeAddsANewDoneTask()
        {
            doneTaskName = tasksBasePage.GenerateTaskName();
            tasksBasePage.AddTask(false, doneTaskName, DateTime.Now.ToString("dd/MM/yyyy"), "12:00", "KSB", "1", "Assignment", "Status", "Note").ClickToDoTab().ClickDoneTab();
        }

        [Then("the task is added to the done tasks list")]
        public void ThenTheTaskIsAddedToTheDoneTasksList()
        {
            Assert.IsTrue(tasksBasePage.IsTaskAdded(doneTaskName), "The task was not added to the done tasks list");
        }
    }
}
