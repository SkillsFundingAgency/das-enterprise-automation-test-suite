using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class DoneTasksPage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By DoneTasksHeader => By.CssSelector("h1.govuk-heading-xl");
        protected override string PageTitle => "Your tasks";
        protected static By DoneTasksList => By.CssSelector("ul.govuk-list");
        protected static By YearDropdown => By.CssSelector("button.app-dropdown__toggle[aria-expanded='false']");
        protected static By SortByDropdown => By.CssSelector("span.app-dropdown__toggle-sort-value#sortby");
        protected static By TaskFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");
        private static By AddDoneTaskButton => By.CssSelector("a.app-fab.add-btn.app-fab--highlight[data-status-id='1']");
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
