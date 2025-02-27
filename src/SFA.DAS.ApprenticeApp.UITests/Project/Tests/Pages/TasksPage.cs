using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class TasksPage(ScenarioContext context) : AppBasePage(context)
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
        protected override string PageTitle => "Tasks";
    
        public void AddTask(string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
            //_driver.FindElement(AddTaskButton).Click();

            EnterText(TaskTitleInput, title);
            EnterText(DateInput, date);
            EnterText(TimeInput, time);
            //_driver.FindElement(KsbButton).Click();
            SelectCategory(categoryValue);
            SelectKsb(ksbId, status);
            EnterText(NoteTextArea, note);

            //_driver.FindElement(SaveTaskButton).Click();
        }

        private void EnterText(By locator, string text)
        {
          
        }

        private void SelectCategory(string categoryValue)
        {
           
        }

        private void SelectKsb(string ksbId, string status)
        {
            
        }

        public void MoveToDone(string taskTitle)
        {
            
        }

        public void DeleteTask(string taskTitle)
        {
            
        }

        protected void EditTask()
        {
            
        }
    }
}
