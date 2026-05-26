using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EditTaskStepDefinitions(ScenarioContext context)
    {
        private readonly TasksBasePage tasksBasePage = new(context);
        private readonly ScenarioContext scenarioContext = context;

        [When("the apprentice clicks on edit task, edits and confirms")]
        public void WhenTheApprenticeClicksOnEditTaskEditsAndConfirms()
        {
            string updatedName = TasksBasePage.GenerateTaskName();

            tasksBasePage.SetTaskTitle(updatedName);

            scenarioContext["UpdatedTaskName"] = updatedName;

            tasksBasePage.ClickSaveAndContinue();
        }
    }
}
