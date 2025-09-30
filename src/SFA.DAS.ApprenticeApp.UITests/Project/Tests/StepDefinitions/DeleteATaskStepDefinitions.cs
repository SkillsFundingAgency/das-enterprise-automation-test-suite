using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DeleteATaskStepDefinitions(ScenarioContext context)
    {
        private readonly TasksBasePage tasksBasePage = new(context);
        private string taskTitle;
        private bool TaskExists = false;

        [When("the apprentice clicks on view actions")]
        public string WhenTheApprenticeClicksOnViewActions()
        {
            var taskElement = tasksBasePage.GetTask();

            if (taskElement == null)
            {
                Console.WriteLine("No task found to delete. Skipping further steps.");
                TaskExists = false;
                return string.Empty;
            }

            var titleElement = taskElement.FindElement(TasksBasePage.TaskTitle);
            taskTitle = titleElement?.Text;

            if (!string.IsNullOrEmpty(taskTitle))
            {
                tasksBasePage.ClickViewActions();
                TaskExists = true;
            }
            else
            {
                Console.WriteLine("Task title is empty. Skipping further steps.");
                TaskExists = false;
            }

            return taskTitle;
        }

        [When("the apprentice clicks on delete and confirms")]
        public void ThenTheApprenticeClicksOnDeleteAndConfirms()
        {
            if (TaskExists)
            {
                tasksBasePage.DeleteTask();
                tasksBasePage.Refresh();
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
                Assert.IsFalse(tasksBasePage.IsTaskAdded(taskTitle), "The task was not removed from the list");
            }
            else
            {
                Console.WriteLine("Skipping validation as no task existed to be deleted.");
            }
        }
    }
}
