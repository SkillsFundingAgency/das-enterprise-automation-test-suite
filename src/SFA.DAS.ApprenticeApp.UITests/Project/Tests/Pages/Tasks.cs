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

        protected static By FiltersDropdown => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");

        private readonly IWebDriver _driver;

        public Tasks(IWebDriver driver)
        {
            _driver = driver;
        }

        //protected void EnterText(By locator, string text)
        //{
        //    var element = _driver.FindElement(locator);
        //    element.Clear();
        //    element.SendKeys(text);
        //}

        public void EnterDate(string date)
        {
            _driver.FindElement(By.Id("date")).SendKeys(date);
        }

        public void EnterTime(string time)
        {
            _driver.FindElement(By.Id("time")).SendKeys(time);
        }

        public void SelectCategory(string categoryValue)
        {
            var categoryInput = _driver.FindElement(By.Id($"category_{categoryValue}"));
            categoryInput.Click();
        }
        protected void ToDoAddATask()
        {
            // TBD
        }

        protected void DeleteTask()
        {
            // TBD
        }

        protected void EditTask()
        {
            // TBD
        }
    }
}
