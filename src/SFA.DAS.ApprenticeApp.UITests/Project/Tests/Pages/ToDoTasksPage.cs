using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class ToDoTasksPage(ScenarioContext context) : AppBasePage(context)
    {
        protected override string PageTitle => "Your tasks";
        protected static By ToDoTasksHeader => By.CssSelector("h1.govuk-heading-xl");

        private static By TaskTitleInput => By.Id("Task_Title");
        private static By DateInput => By.Id("date");
        private static By TimeInput => By.Id("time");
        private static By KsbButton => By.Id("ksb-popup-btn");
        private static By CategoryAssignment => By.XPath("//input[@id='category_1']");
        private static By CategoryCollapseButton => By.XPath("//button[@aria-controls='app-collapse-task-cat']");
        private static By NoteTextArea => By.Id("note");
        private static By SaveTaskButton => By.CssSelector("a.app-overlay-header__link.add-task");
        private static By TaskTitle => By.CssSelector("h2.app-card__heading");
    }
}
