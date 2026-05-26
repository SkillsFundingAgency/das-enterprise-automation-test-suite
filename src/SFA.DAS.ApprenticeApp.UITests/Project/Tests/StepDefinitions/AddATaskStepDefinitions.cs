using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddATaskStepDefinitions
    {
        private readonly TasksBasePage tasksBasePage;
        private readonly AppStepsHelper appStepsHelper;
        private readonly ScenarioContext context;
        private string toDoTaskName;
        private string doneTaskName;

        public AddATaskStepDefinitions(ScenarioContext context)
        {
            this.tasksBasePage = new TasksBasePage(context);
            this.appStepsHelper = new AppStepsHelper(context);
            this.context = context;
        }

        [When("the apprentice adds a new to do task")]
        public void WhenTheApprenticeAddsANewTask()
        {
            appStepsHelper.NavigateToTasksPage();
            tasksBasePage.Refresh();

            tasksBasePage.WaitForNewAddToDoTaskButton();

            toDoTaskName = TasksBasePage.GenerateTaskName();
            context["CurrentTaskName"] = toDoTaskName;

            tasksBasePage.AddTask(true, toDoTaskName, DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"), "12:00", "KSB", "1", "Assignment", "Status", "Note");

            tasksBasePage.Refresh();
        }

        [When("the apprentice has clicked on the done tasks tab")]
        public void WhenTheApprenticeUserIsOnTheDoneTasksPage()
        {
            appStepsHelper.NavigateToTasksPage();

            tasksBasePage.Refresh();

            tasksBasePage.ClickDoneTab();

            tasksBasePage.WaitForNewAddDoneTaskButton();
        }

        [When("the apprentice adds a new done task")]
        public void WhenTheApprenticeAddsANewDoneTask()
        {
            appStepsHelper.NavigateToTasksPage();
            tasksBasePage.Refresh();

            appStepsHelper.NavigateToDoneTab();

            doneTaskName = TasksBasePage.GenerateTaskName();
            context["CurrentTaskName"] = doneTaskName;

            tasksBasePage.AddTask(false, doneTaskName, DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"), "12:00", "KSB", "1", "Assignment", "Status", "Note");

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
