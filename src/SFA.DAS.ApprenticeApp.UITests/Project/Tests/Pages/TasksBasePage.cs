using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Input;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class TasksBasePage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By YourTasks => By.CssSelector("h1.govuk-heading-xl.govuk-!-margin-bottom-2");
        protected static By YearDropdown => By.CssSelector("button.app-dropdown__toggle[aria-expanded='false']");
        protected static By SortByDropdown => By.CssSelector("span.app-dropdown__toggle-sort-value#sortby");
        protected static By TaskFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");
        private static By ToDoTab => By.CssSelector("a.app-tabs__tab.todo[role='tab']");
        private static By DoneTab => By.CssSelector("a.app-tabs__tab.done[role='tab']");
        private static By AddTaskButton => By.CssSelector("a.app-fab.add-btn");
        private static By AddTaskButtonInitial => By.CssSelector("a.app-fab.add-btn.app-fab--highlight");
        private static By TaskTitleInput => By.Id("Task_Title");
        private static By DateInput => By.Id("date");
        private static By TimeInput => By.Id("time");
        private static By KsbButton => By.Id("ksb-popup-btn");
        private static By CategoryAssignment => By.XPath("//input[@id='category_1']");
        private static By CategoryCollapseButton => By.XPath("//button[@aria-controls='app-collapse-task-cat']");
        private static By NoteTextArea => By.Id("note");
        private static By SaveTaskButton => By.CssSelector("a.app-overlay-header__link.add-task");
        private static By TaskTitle => By.CssSelector("h2.app-card__heading");
        protected override string PageTitle => "Tasks";

        public TasksBasePage ClickToDoTab()
        {
            formCompletionHelper.Click(ToDoTab);
            return new TasksBasePage(context);
        }
        public void ClickDoneTab()
        {
            formCompletionHelper.Click(DoneTab);
            pageInteractionHelper.WaitforURLToChange("/Tasks/Index?status=1");
            pageInteractionHelper.WaitForElementToChange(ToDoTab, "hidden");
        }
        public TasksBasePage AddTask(bool isToDo, string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            if (pageInteractionHelper.IsElementPresent(AddTaskButtonInitial))
            {
                formCompletionHelper.Click(AddTaskButtonInitial);
            }
            else
            {
                formCompletionHelper.Click(AddTaskButton);
            }
            formCompletionHelper.EnterText(TaskTitleInput, title);
            formCompletionHelper.EnterText(DateInput, date);
            formCompletionHelper.EnterText(TimeInput, time);
            formCompletionHelper.Click(CategoryCollapseButton);
            //formCompletionHelper.Click(CategoryAssignment);
            formCompletionHelper.EnterText(NoteTextArea, note);
            formCompletionHelper.Click(SaveTaskButton);
            return new TasksBasePage(context);

        }
        public void DeleteTask(string taskTitle)
        {

        }

        protected void EditTask()
        {

        }

        public bool IsTaskAdded(string Title)
        {
            
            var tasks = pageInteractionHelper.FindElements(TaskTitle);
            return tasks.Any(task => task.Text.Contains(Title));
            
        }

        internal string GenerateTaskName()
        {
            return $"Task {DateTime.Now:yyyyMMddHHmmss}";
        }

        //public void SelectKsb(string ksbId, string status)
        //{
        //    var ksbElement = context.FindElement(By.Id($"ksb-{ksbId}"));
        //    var statusDropdown = ksbElement.FindElement(By.CssSelector("button.app-collapse__button"));
        //    statusDropdown.Click();
        //    var statusRadioButton = ksbElement.FindElement(By.Id($"ksbStatus_{status}"));
        //    if (!statusRadioButton.Selected)
        //    {
        //        statusRadioButton.Click();
        //    }
        //}
    }
}
