using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class TasksPage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By YourTasks => By.CssSelector("h1.govuk-heading-xl.govuk-!-margin-bottom-2");
        protected static By PshNtfPopUp => By.CssSelector("button.govuk-button");
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
        private By TaskTitle => By.CssSelector("app-card__heading");
        protected override string PageTitle => "Tasks";

        public TasksPage AcceptNotifications()
        {
            formCompletionHelper.Click(PshNtfPopUp);
            return new TasksPage(context);
        }

        public void AddTask(string title, string date, string time, string ksb, string ksbId, string categoryValue, string status, string note)
        {
         
            formCompletionHelper.Click(AddTaskButton);
            formCompletionHelper.EnterText(TaskTitleInput, title);
            formCompletionHelper.EnterText(DateInput, date);
            formCompletionHelper.EnterText(TimeInput, time);
            //formCompletionHelper.Click(CategoryRadioButtons);
            //SelectKsb(ksbId, status);
            formCompletionHelper.EnterText(NoteTextArea, note);
            formCompletionHelper.Click(SaveTaskButton);


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

        public bool IsTaskAdded(string Title)
        {
            
            var tasks = pageInteractionHelper.FindElements(TaskTitle);
            return tasks.FindAll(task => task.Text.Contains(Title)).Count.Equals(1);
            
        }
    }
}
