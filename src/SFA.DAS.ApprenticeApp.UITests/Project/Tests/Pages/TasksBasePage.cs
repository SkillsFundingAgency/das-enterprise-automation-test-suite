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
        public static By TaskTitle => By.CssSelector("h2.app-card__heading");
        private static By ViewActions => By.CssSelector("button.app-dropdown__toggle[aria-expanded='false']");
        private static By DeleteButton => By.CssSelector("[class='app-dropdown__menu-link delete-task']");
        private static By ConfirmDelete => By.CssSelector("[class='app-button app-button--warning']");
        private static By DonePanel => By.CssSelector("div.app-tabs__panel#tasks-done");
        private static By ToDoPanel => By.CssSelector("div.app-tabs__panel#tasks-todo");
        protected override string PageTitle => "Tasks";


        public TasksBasePage ClickToDoTab()
        {
            formCompletionHelper.Click(ToDoTab);
            return new TasksBasePage(context);
        }
        public TasksBasePage ClickDoneTab()
        {
            formCompletionHelper.Click(DoneTab);
            return new TasksBasePage(context);
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
            IWebElement taskCard = GetTask();

            if (taskCard == null)
            {
                Console.WriteLine("No task available to delete.");
                return;
            }

            IWebElement deleteButton = null;
            try
            {
                deleteButton = taskCard.FindElement(DeleteButton);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Delete button not found on the task card.");
                return;
            }

            formCompletionHelper.ClickElement(deleteButton);

            try
            {
                formCompletionHelper.Click(ConfirmDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to confirm deletion: " + ex.Message);
            }
        }

        public bool IsTaskAvailable()
        {
            return GetTask() != null;
        }

        public void ClickViewActions()
        {
            IWebElement taskCard = GetTask();

            if (taskCard == null)
            {
                Console.WriteLine("No task available to click view actions.");
                return;
            }

            IWebElement selectedOption = null;
            try
            {
                selectedOption = taskCard.FindElement(ViewActions);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("ViewActions element not found on task card.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while finding ViewActions: " + ex.Message);
                return;
            }

            try
            {
                formCompletionHelper.ClickElement(selectedOption);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to click ViewActions: " + ex.Message);
            }
        }

        public IWebElement GetTask()
        {
            var todoTiles = pageInteractionHelper.FindElements(ToDoPanel)?.SelectMany(panel => panel.FindElements(Task)) ?? Enumerable.Empty<IWebElement>();
            var doneTiles = pageInteractionHelper.FindElements(DonePanel)?.SelectMany(panel => panel.FindElements(Task)) ?? Enumerable.Empty<IWebElement>();
            var url = pageInteractionHelper.GetUrl();

            Console.WriteLine($"Current URL: {url}");
            Console.WriteLine($"ToDo tasks: {todoTiles.Count()}, Done tasks: {doneTiles.Count()}");

            return url switch
            {
                "https://pp-apprentice-app.apprenticeships.education.gov.uk/Tasks/Index?status=0" or
                "https://pp-apprentice-app.apprenticeships.education.gov.uk/Tasks/Index" => todoTiles.FirstOrDefault(),
                "https://pp-apprentice-app.apprenticeships.education.gov.uk/Tasks/Index?status=1" => doneTiles.FirstOrDefault(),
                _ => null
            };
        }
        protected void EditTask()
        {

        }

        public bool IsTaskAdded(string title)
        {
            title = title?.Trim();

            var timeoutSeconds = 10;
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < timeoutSeconds)
            {
                var taskTitles = pageInteractionHelper.FindElements(TaskTitle);
                foreach (var task in taskTitles)
                {
                    var taskText = task.Text.Trim();
                    Console.WriteLine($"Found task title: '{taskText}'");

                    if (taskText.Contains(title, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
            return false;
        }

        internal string GenerateTaskName()
        {
            return $"Task {DateTime.Now:yyyyMMddHHmmss}";
        }
        public void Refresh()
        {
            var  _ = pageInteractionHelper.GetUrl();
            pageInteractionHelper.RefreshPage();
            pageInteractionHelper.WaitForPageToLoad();
        }
    }
}
