using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DeleteATaskStepDefinitions(ScenarioContext context)
    {
        private readonly TasksBasePage tasksBasePage = new(context);
        private string TaskTitle;
        private bool TaskExists = false;

        [When("the apprentice clicks on view actions")]
        public void WhenTheApprenticeClicksOnViewActions()
        {
            TaskTitle = tasksBasePage.GetTaskTitle();
            if (!string.IsNullOrEmpty(TaskTitle))
            {
                tasksBasePage.ClickViewActions();
                TaskExists = true;
            }
            else
            {
                Console.WriteLine("No task found to delete. Skipping further steps.");
            }
        }

        [When("the apprentice clicks on delete and confirms")]
        public void ThenTheApprenticeClicksOnDeleteAndConfirms()
        {
            if (TaskExists)
            {
                tasksBasePage.DeleteTask();
            }
            else
            {
                Console.WriteLine("Skipping delete action as no task exists.");
            }
        }

        [Then("the task is removed from the list")]
        public void ThenTheTaskIsRemovedFromTheList()
        {
            if (TaskExists)
            {
                Assert.IsFalse(tasksBasePage.IsTaskAdded(TaskTitle), "The task was not removed from the list");
            }
            else
            {
                Console.WriteLine("Skipping validation as no task existed to be deleted.");
            }
        }
    }
}
