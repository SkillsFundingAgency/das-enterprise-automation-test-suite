using OpenQA.Selenium;
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
        private static By AddToDoTaskButton => By.CssSelector("a[data-status-id='0'].app-fab.add-btn");
        private static By AddToDoTaskButtonInitial => By.CssSelector("a.app-fab.add-btn.app-fab--highlight");
        private static By AddDoneTaskButton => By.CssSelector("a[data-status-id='1'].app-fab.add-btn");
        private static By AddDoneTaskButtonInitial => By.CssSelector("a.app-fab.add-btn.app-fab--highlight");
        private static By TaskTitleInput => By.Id("Task_Title");
        private static By DateInput => By.Id("date");
        private static By TimeInput => By.Id("time");
        private static By KsbButton => By.Id("ksb-popup-btn");
        private static By CategoryAssignment => By.XPath("//input[@id='category_1']");
        private static By CategoryCollapseButton => By.XPath("//button[@aria-controls='app-collapse-task-cat']");
        private static By NoteTextArea => By.Id("note");
        private static By SaveTaskButton => By.CssSelector("a.app-overlay-header__link.add-task");
        private static By Task => By.CssSelector("div.app-card");
        private static By TaskTitle => By.CssSelector("h2.app-card__heading");
        private static By ViewActions => By.CssSelector("button.app-dropdown__toggle[aria-expanded='false']");
        private static By DeleteButton => By.CssSelector("[class='app-dropdown__menu-link delete-task']");
        private static By ConfirmDelete => By.CssSelector("[class='app-button app-button--warning']");
        protected override string PageTitle => "Tasks";

        public TasksBasePage ClickToDoTab()
        {
            formCompletionHelper.Click(ToDoTab);
            return new TasksBasePage(context);
        }
        public void ClickDoneTab()
        {
            formCompletionHelper.Click(DoneTab);
        }
        public TasksBasePage AddTask(bool isToDo, string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            if (isToDo)
            {
                if (pageInteractionHelper.IsElementPresent(AddToDoTaskButtonInitial))
                {
                    formCompletionHelper.Click(AddToDoTaskButtonInitial);
                }
                else
                {
                    formCompletionHelper.Click(AddToDoTaskButton);
                }
            }
            else
            {
                if (pageInteractionHelper.IsElementPresent(AddToDoTaskButtonInitial))
                {
                    formCompletionHelper.Click(AddDoneTaskButtonInitial);
                }
                else
                {
                    formCompletionHelper.Click(AddDoneTaskButton);
                }
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
        public void DeleteAllTasks()
        {
            
        }
       
        public void DeleteTask()
        {
            formCompletionHelper.Click(DeleteButton);
            formCompletionHelper.Click(ConfirmDelete);
        }

        public void ClickViewActions()
        {
            var task = pageInteractionHelper.FindElements(Task).FirstOrDefault();
            task.FindElement(ViewActions).Click();
        }

        public string GetTaskTitle()
        {
            if (pageInteractionHelper.IsElementPresent(TaskTitle))
            {
                var taskTitles = pageInteractionHelper.FindElements(TaskTitle);
                return taskTitles.FirstOrDefault().Text;
            }
            else
            {
                return string.Empty;
            }
        }
        protected void EditTask()
        {

        }

        public bool IsTaskAdded(string Title)
        {
            
            var taskTitles = pageInteractionHelper.FindElements(TaskTitle);
            return taskTitles.Any(task => task.Text.Contains(Title));
            
        }

        internal string GenerateTaskName()
        {
            return $"Task {DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
