using OpenQA.Selenium;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class Tasks
    {
        protected static By YourTasks => By.CssSelector("h1.govuk-heading-xl.govuk-!-margin-bottom-2");

        protected static By YearDropdown => By.CssSelector("button.app-dropdown__toggle[aria-expanded='false']");

        protected static By Todo => By.CssSelector("a.app-tabs__tab.todo[role='tab'][aria-selected='true']");

        protected static By Done => By.CssSelector("a.app-tabs__tab.done[role='tab'][aria-selected='true']");

        protected static By SortByDropdown => By.CssSelector("span.app-dropdown__toggle-sort-value#sortby");

        protected static By TaskFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");

        private By AddTaskButton => By.CssSelector("a.app-fab.add-btn");
        private By TaskTitleInput => By.Id("Task_Title");
        private By DateInput => By.Id("date");
        private By TimeInput => By.Id("time");
        private By CategoryRadioButtons => By.CssSelector("input.app-radios__input.task-category");
        private By KsbButton => By.Id("ksb-popup-btn");
        private By NoteTextArea => By.Id("note");
        private By SaveTask => By.CssSelector("a.app-overlay-header__link.add-task");


        private readonly IWebDriver _driver;

        public Tasks(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddTask(string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            _driver.FindElement(AddTaskButton).Click();

            EnterText(TaskTitleInput, title);
            EnterText(DateInput, date);
            EnterText(TimeInput, time);
            ClickKsbButton();
            SelectCategory(categoryValue);
            SelectKsb(ksbId, status);
            EnterNote(note);

            _driver.FindElement(SaveTask).Click();
        }

        private void EnterText(By locator, string text)
        {
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text);

        }
        private void SelectCategory(string categoryValue)
        {
            var categoryInput = _driver.FindElement(By.Id($"category_{categoryValue}"));
            categoryInput.Click();
        }
        private void ClickKsbButton()
        {
            _driver.FindElement(KsbButton).Click();
        }
        private void SelectKsb(string ksbId, string status)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));
            var statusRadioButton = ksbElement.FindElement(By.Id($"ksb_{ksbId}_status_{status}"));
            statusRadioButton.Click();
        }
        private void EnterNote(string noteText)
        {
            _driver.FindElement(NoteTextArea).SendKeys(noteText);
        }
        public void MoveToDone(string taskTitle)
        {
            var taskElement = _driver.FindElement(By.XPath("//div[contains(text(), '" + taskTitle + "')]"));

            var viewActionsButton = taskElement.FindElement(By.CssSelector("button.app-dropdown__toggle"));
            viewActionsButton.Click();

            var moveToDoneLink = taskElement.FindElement(By.CssSelector("a.app-dropdown__menu-link.move-done"));
            moveToDoneLink.Click();

        }
        public void DeleteTask(string taskTitle)
        {
            var taskElement = _driver.FindElement(By.CssSelector($"div:contains('{taskTitle}')"));

            var viewActionsButton = taskElement.FindElement(By.CssSelector("button.app-dropdown__toggle"));
            viewActionsButton.Click();

            var deleteLink = taskElement.FindElement(By.CssSelector("a.app-dropdown__menu-link.delete-task"));
            deleteLink.Click();

        }

        protected void EditTask()
        {
            // TBD
        }
    }
}
