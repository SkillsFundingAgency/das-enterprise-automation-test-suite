using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class TasksBasePage(ScenarioContext context) : AppBasePage(context)
    {
        #region Locators & Properties

        protected override string PageTitle => "Tasks";

        // Filter / Sort Overlays
        protected static By SortByDropdown => By.CssSelector("span.app-dropdown__toggle-sort-value#sortby");
        protected static By TaskFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");

        // Tabs
        private static By ToDoTab => By.CssSelector("a.app-tabs__tab.todo");
        private static By DoneTab => By.CssSelector("a.app-tabs__tab.done");

        // Unified Add Task Action Trigger (Matches new GOV.UK markup across both tabs)
        private static By AddTaskButton => By.CssSelector("a.govuk-button.app-fab[href='/Tasks/Add']");

        // Task Form Field Inputs
        private static By TaskTitleInput => By.CssSelector("input#title, input[id*='Title']");
        private static By DateDayInput => By.CssSelector("input[id$='day'], input[id*='date-day']");
        private static By DateMonthInput => By.CssSelector("input[id$='month'], input[id*='date-month']");
        private static By DateYearInput => By.CssSelector("input[id$='year'], input[id*='date-year']");
        private static By TimeInput => By.CssSelector("input#Time, input#time");
        private static By NoteTextArea => By.Id("note");
        private static By CategoryRadio(string option) => By.XPath($"//div[contains(@class, 'govuk-radios')]//label[normalize-space()='{option}']");
        private static By ReminderRadio(string option) => By.XPath($"//div[contains(@class, 'govuk-radios')]//label[normalize-space()='{option}']");

        // Action Buttons
        private static By SaveAndContinueButton => By.XPath("//button[contains(@class, 'govuk-button')][normalize-space()='Save and continue']");
        private static By DeleteButton => By.CssSelector("a[href*='/Tasks/ConfirmDelete/']");
        private static By ConfirmDelete => By.CssSelector("button.govuk-button--warning");

        // Task Cards Display Interactivity
        public static By TaskTitle => By.CssSelector("h2.app-card__heading");
        public static By TaskCardHeader(string taskTitle) => By.XPath($"//h2[@class='app-card__heading'][normalize-space()='{taskTitle}']");
        public static By TaskCardAnchor(string taskTitle) => By.XPath($"//a[contains(@class, 'app-card')][.//h2[normalize-space()='{taskTitle}']]");
        private static By AnyAutomatedTaskCard => By.XPath("//a[contains(@class, 'app-card')][.//h2[starts-with(normalize-space(), 'Task 202')]]");

        #endregion

        #region Setup / Common Framework Helpers

        internal static string GenerateTaskName()
        {
            return $"Task {DateTime.Now:yyyyMMddHHmmss}";
        }

        public void Refresh()
        {
            pageInteractionHelper.RefreshPage();
            pageInteractionHelper.WaitForPageToLoad();
        }

        public void WaitForNewAddToDoTaskButton()
        {
            pageInteractionHelper.WaitForElementToBeClickable(AddTaskButton);
        }

        public void WaitForNewAddDoneTaskButton()
        {
            pageInteractionHelper.WaitForElementToBeClickable(AddTaskButton);
        }

        #endregion

        #region Tab Navigation Context Controls

        public TasksBasePage ClickToDoTab()
        {
            if (!pageInteractionHelper.GetUrl().Contains("/Tasks/Index") && !pageInteractionHelper.GetUrl().EndsWith("/Tasks"))
            {
                Refresh();
            }

            formCompletionHelper.Click(ToDoTab);
            return new TasksBasePage(context);
        }

        public TasksBasePage ClickDoneTab()
        {
            if (!pageInteractionHelper.GetUrl().Contains("/Tasks/Index") && !pageInteractionHelper.GetUrl().EndsWith("/Tasks"))
            {
                pageInteractionHelper.RefreshPage();
            }

            formCompletionHelper.Click(DoneTab);
            return new TasksBasePage(context);
        }

        #endregion

        #region Action & Form Workflow Methods

        public TasksBasePage AddTask(bool isToDo, string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            // Both paths safely click the same unified button element now
            pageInteractionHelper.WaitForElementToBeClickable(AddTaskButton);
            formCompletionHelper.Click(AddTaskButton);

            formCompletionHelper.EnterText(TaskTitleInput, title);

            if (!string.IsNullOrEmpty(date) && date.Contains("/"))
            {
                var dateParts = date.Split('/');
                formCompletionHelper.EnterText(DateDayInput, dateParts[0]);
                formCompletionHelper.EnterText(DateMonthInput, dateParts[1]);
                formCompletionHelper.EnterText(DateYearInput, dateParts[2]);
            }
            else
            {
                formCompletionHelper.EnterText(DateDayInput, date);
            }

            formCompletionHelper.EnterText(TimeInput, time);
            formCompletionHelper.EnterText(NoteTextArea, note);
            formCompletionHelper.Click(ReminderRadio("None"));

            if (!string.IsNullOrEmpty(categoryValue))
            {
                formCompletionHelper.Click(CategoryRadio(categoryValue));
            }

            pageInteractionHelper.WaitForElementToBeClickable(SaveAndContinueButton);
            formCompletionHelper.Click(SaveAndContinueButton);

            // Safe Native URL Change Polling Synchronizer
            int maxWaitSeconds = 10;
            int elapsedSeconds = 0;
            while (elapsedSeconds < maxWaitSeconds)
            {
                string currentUrl = pageInteractionHelper.GetUrl();
                if (currentUrl.Contains("/Tasks/Index") || currentUrl.EndsWith("/Tasks") || currentUrl.Contains("status="))
                {
                    break;
                }
                Thread.Sleep(1000);
                elapsedSeconds++;
            }

            return new TasksBasePage(context);
        }

        public string OpenTaskByTitle(string generatedTaskTitle)
        {
            var titleElement = pageInteractionHelper.FindElement(TaskCardHeader(generatedTaskTitle));
            string actualTitleText = titleElement.Text;

            formCompletionHelper.Click(TaskCardAnchor(generatedTaskTitle));
            return actualTitleText;
        }

        public void SetTaskTitle(string updatedName)
        {
            formCompletionHelper.ClearText(TaskTitleInput);
            formCompletionHelper.EnterText(TaskTitleInput, updatedName);
        }

        public void ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
        }

        public void DeleteTask()
        {
            formCompletionHelper.Click(DeleteButton);
            formCompletionHelper.Click(ConfirmDelete);
        }

        #endregion

        #region Assertions & Verification Assays

        public bool IsTaskAdded(string Title)
        {
            var taskTitles = pageInteractionHelper.FindElements(TaskTitle);
            return taskTitles.Any(task => task.Text.Contains(Title));
        }

        public bool IsTaskRemoved(string title)
        {
            var taskLocator = TaskCardHeader(title);
            return !pageInteractionHelper.IsElementPresent(taskLocator);
        }

        #endregion

        #region Background Automated Teardown Sweepers

        public void CleanUpTaskByTitle(string taskTitle)
        {
            By taskCard = TaskCardAnchor(taskTitle);

            if (pageInteractionHelper.IsElementPresent(taskCard))
            {
                formCompletionHelper.Click(taskCard);
                formCompletionHelper.Click(DeleteButton);
                formCompletionHelper.Click(ConfirmDelete);

                Refresh();
            }
        }

        public void SweepOrphanedTasks()
        {
            int safetyMaxLoops = 100;
            int loopCount = 0;

            // --- PHASE 1: Clean out the active "To do" Tab ---
            Console.WriteLine("[CleanUp] Routing to 'To do' tab...");
            ClickToDoTab();

            int elapsedTodo = 0;
            while (!pageInteractionHelper.GetUrl().Contains("status=0") && !pageInteractionHelper.GetUrl().EndsWith("/Tasks") && elapsedTodo < 5)
            {
                Thread.Sleep(500);
                elapsedTodo++;
            }

            while (pageInteractionHelper.IsElementPresent(AnyAutomatedTaskCard) && loopCount < safetyMaxLoops)
            {
                try
                {
                    string targetedCardText = pageInteractionHelper.FindElement(AnyAutomatedTaskCard).Text;
                    string sanitizedText = targetedCardText.Replace("\r", "").Replace("\n", " ").Trim();
                    Console.WriteLine($"[CleanUp ToDo Run {loopCount + 1}] Target: '{sanitizedText}'");

                    formCompletionHelper.Click(AnyAutomatedTaskCard);

                    pageInteractionHelper.WaitForElementToBeClickable(DeleteButton);
                    formCompletionHelper.Click(DeleteButton);

                    pageInteractionHelper.WaitForElementToBeClickable(ConfirmDelete);
                    formCompletionHelper.Click(ConfirmDelete);

                    Refresh();
                    loopCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CleanUp Interrupted] Error on ToDo loop: {ex.Message}");
                    Refresh();
                    break;
                }
            }

            // --- PHASE 2: Switch to and clean out the "Done" Tab ---
            Console.WriteLine("[CleanUp] Switching to 'Done' tab...");
            ClickDoneTab();

            int elapsedDone = 0;
            while (!pageInteractionHelper.GetUrl().Contains("status=1") && elapsedDone < 10)
            {
                Thread.Sleep(500);
                elapsedDone++;
            }

            int doneLoopCount = 0;
            while (pageInteractionHelper.IsElementPresent(AnyAutomatedTaskCard) && loopCount < safetyMaxLoops)
            {
                try
                {
                    string targetedCardText = pageInteractionHelper.FindElement(AnyAutomatedTaskCard).Text;
                    string sanitizedText = targetedCardText.Replace("\r", "").Replace("\n", " ").Trim();
                    Console.WriteLine($"[CleanUp Done Run {doneLoopCount + 1}] Target: '{sanitizedText}'");

                    formCompletionHelper.Click(AnyAutomatedTaskCard);

                    pageInteractionHelper.WaitForElementToBeClickable(DeleteButton);
                    formCompletionHelper.Click(DeleteButton);

                    pageInteractionHelper.WaitForElementToBeClickable(ConfirmDelete);
                    formCompletionHelper.Click(ConfirmDelete);

                    Refresh();

                    ClickDoneTab();
                    int elapsedInner = 0;
                    while (!pageInteractionHelper.GetUrl().Contains("status=1") && elapsedInner < 6)
                    {
                        Thread.Sleep(500);
                        elapsedInner++;
                    }

                    loopCount++;
                    doneLoopCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CleanUp Interrupted] Error on Done loop: {ex.Message}");
                    Refresh();
                    break;
                }
            }

            // --- PHASE 3: Reset back to To do tab context for the next test scenario run ---
            Console.WriteLine("[CleanUp Reset] Returning session to 'To do' home tab context...");
            ClickToDoTab();
            Refresh();

            Console.WriteLine($"[CleanUp Complete] Total tasks swept this run: {loopCount}");
        }

        #endregion
    }
}