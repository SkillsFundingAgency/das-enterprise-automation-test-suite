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

        [When("the apprentice clicks on the created task")]
        public string WhenTheApprenticeClicksOnTheCreatedTask()
        {
            string taskNameLookUp;

            if (context.ContainsKey("UpdatedTaskName"))
            {
                taskNameLookUp = context["UpdatedTaskName"].ToString();
            }
            else
            {
                taskNameLookUp = context["CurrentTaskName"].ToString();
            }

            taskTitle = tasksBasePage.OpenTaskByTitle(taskNameLookUp);

            return taskTitle;
        }

        [When("the apprentice clicks on delete and confirms")]
        public void ThenTheApprenticeClicksOnDeleteAndConfirms()
        {
            tasksBasePage.DeleteTask();
            tasksBasePage.Refresh();
        }

        [Then("the task is removed from the list")]
        public void ThenTheTaskIsRemovedFromTheList()
        {
            bool isRemoved = tasksBasePage.IsTaskRemoved(taskTitle);

            if (isRemoved)
            {
                Console.WriteLine($"Task '{taskTitle}' was removed from the list.");
            }
            else
            {
                Console.WriteLine($"Task '{taskTitle}' still appears in the list.");
            }
        }
    }
}