using OpenQA.Selenium;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class Ksb(IWebDriver driver)
    {
        protected static By KsbHeader => By.CssSelector("h1.govuk-heading-xl");
        protected static By KnowledgeTab => By.CssSelector("a.app-tabs__tab.tab-knowledge");
        protected static By SkillsTab => By.CssSelector("a.app-tabs__tab.tab-skills");
        protected static By BehavioursTab => By.CssSelector("a.app-tabs__tab.tab-behaviours");
        protected static By KsbFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");

        private static By CancelKsbEditButton => By.CssSelector("a.app-overlay-header__link[href='/Ksb']");
        private static By ConfirmKsbEditButton => By.CssSelector("a.app-overlay-header__link.save-ksb");


        private readonly IWebDriver _driver = driver;

        public void EditKsb(string ksbId)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));

            var editLink = ksbElement.FindElement(By.CssSelector("a.app-link"));
            editLink.Click();
        }

        public void AddNoteToKsb(string ksbId, string note)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));

            var noteTextArea = ksbElement.FindElement(By.Id("KsbProgress_Note"));

            noteTextArea.Clear();
            noteTextArea.SendKeys(note);
        }

        public void SelectKsbStatus(string ksbId, string status)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));

            var statusDropdown = ksbElement.FindElement(By.CssSelector("button.app-collapse__button"));
            statusDropdown.Click();

            var statusRadioButton = ksbElement.FindElement(By.Id($"ksbStatus_{status}"));

            if (!statusRadioButton.Selected)
            {
                statusRadioButton.Click();
            }
        }

        public void RemoveKsbFromTask(string ksbId, string taskId)
        {
            var ksbElement = _driver.FindElement(By.Id($"ksb-{ksbId}"));

            var viewActionsButton = ksbElement.FindElement(By.CssSelector("button.app-dropdown__toggle"));
            viewActionsButton.Click();

            var removeLink = ksbElement.FindElement(By.CssSelector($"a.app-dropdown__menu-link.remove-ksb-task[data-taskid='{taskId}']"));
            removeLink.Click();
        }

        public void ConfirmKsbEdit()
        {
            _driver.FindElement(ConfirmKsbEditButton).Click();
        }

        public void CancelKsbEdit()
        {
            _driver.FindElement(CancelKsbEditButton).Click();
        }

    }
}
