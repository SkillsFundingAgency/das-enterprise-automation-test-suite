using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

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
        private By SaveTaskButton => By.CssSelector("a.app-overlay-header__link.add-task");

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public Tasks(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void AddTask(string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            _driver.FindElement(AddTaskButton).Click();

            EnterText(TaskTitleInput, title);
            EnterText(DateInput, date);
            EnterText(TimeInput, time);
            _driver.FindElement(KsbButton).Click();
            SelectCategory(categoryValue);
            SelectKsb(ksbId, status);
            EnterText(NoteTextArea, note);

            _driver.FindElement(SaveTaskButton).Click();
        }

        private void EnterText(By locator, string text)
        {
            var note = _driver.FindElement(locator);
            note.Clear();
            note.SendKeys(text);
        }

        private void SelectCategory(string categoryValue)
        {
            var categoryInput = _driver.FindElement(By.Id($"category_{categoryValue}"));
            categoryInput.Click();
        }

        private void SelectKsb(string ksbId, string status)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));
            var statusRadioButton = ksbElement.FindElement(By.Id($"ksb_{ksbId}_status_{status}"));
            statusRadioButton.Click();
        }

        public void MoveToDone(string taskTitle)
        {
            try
            {
                var taskElement = _wait.Until(ExpectedConditions.ElementExists(By.CssSelector($"[data-task-title='{taskTitle}']")));

                var dropdownToggle = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.app-dropdown__toggle")));
                dropdownToggle.Click();

                var moveToDoneLink = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.app-dropdown__menu-link.move-done")));

                _wait.Until(ExpectedConditions.ElementToBeClickable(moveToDoneLink));

                moveToDoneLink.Click();

            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for task '{taskTitle}', dropdown toggle, or 'Move to Done' link: {ex.Message}");
                throw;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Task with title '{taskTitle}', dropdown toggle, or 'Move to Done' link not found: {ex.Message}");
                throw;
            }
            //var taskElement = _driver.FindElement(By.CssSelector($"[data-task-title='{taskTitle}']"));
            //taskElement.FindElement(By.CssSelector("button.app-dropdown__toggle")).Click();
            //taskElement.FindElement(By.CssSelector("a.app-dropdown__menu-link.move-done")).Click();
        }

        public void DeleteTask(string taskTitle)
        {
            var taskElement = _driver.FindElement(By.CssSelector($"div:contains('{taskTitle}')"));
            taskElement.FindElement(By.CssSelector("button.app-dropdown__toggle")).Click();
            taskElement.FindElement(By.CssSelector("a.app-dropdown__menu-link.delete-task")).Click();
        }

        protected void EditTask()
        {
            // To be implemented
        }
    }
}
