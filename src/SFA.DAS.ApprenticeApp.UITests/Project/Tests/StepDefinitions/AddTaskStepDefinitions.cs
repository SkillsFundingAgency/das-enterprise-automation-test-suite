using Polly;
using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AddTaskStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        
        [When("the apprentice adds a new task")]
        public void WhenTheApprenticeAddsANewTask()
        {
            var tasksPage = _stepsHelper.GoToTasksPage();
            tasksPage.AddTask("Test Task", "01/01/2022", "12:00", "KSB", "1", "Category", "Status", "Note");
        }

        [Then("the task is added to the task list")]
        public void ThenTheTaskIsAddedToTheTaskList()
        {
            new TasksPage(context).IsTaskAdded("Test Task");
        }

    }
}
