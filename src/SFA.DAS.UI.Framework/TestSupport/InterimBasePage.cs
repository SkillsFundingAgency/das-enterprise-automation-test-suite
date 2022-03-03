using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class InterimBasePage : BasePage
    {
        protected virtual By TaskLists => By.CssSelector(".das-task-list > li");

        protected virtual By TaskItem => By.CssSelector(".das-task-list__item");

        protected virtual By TaskName => By.CssSelector(".das-task-list__task-name > .govuk-link");

        protected virtual By TaskStatus => By.CssSelector(".das-task-list__task-tag");

        public InterimBasePage(ScenarioContext context) : base(context) { }

        protected bool VerifyElement(Func<IWebElement> func, string text, Action retryAction) => pageInteractionHelper.VerifyPage(func, text, retryAction);

        protected void VerifySections(string sectionName, string taskName, string status, int index, Action retryAction) => 
            VerifyElement(GetTaskStatusElement(sectionName, taskName, index), status, retryAction);

        protected void NavigateToTask(string sectionName, string taskName, int index , Action retryAction) => formCompletionHelper.ClickElement(GetTaskLinkElement(sectionName, taskName, index), retryAction);

        private Func<IWebElement> GetTaskLinkElement(string sectionName, string taskName, int index) => GetTaskElement(sectionName, taskName, TaskName, index);

        private Func<IWebElement> GetTaskStatusElement(string sectionName, string taskName, int index) => GetTaskElement(sectionName, taskName, TaskStatus, index);

        private Func<IWebElement> GetTaskElement(string sectionName, string taskName, By childelement, int index)
        {
            return () =>
            {
                var section = pageInteractionHelper.FindElements(TaskLists).Single(x => x.Text.StartsWith(sectionName));

                var tasks = section.FindElements(TaskItem);

                var task = tasks.Where(x => x.Text.StartsWith(taskName)).ElementAt(index);

                if (childelement == TaskStatus || (!task.Text.ContainsCompareCaseInsensitive("NOT REQUIRED"))) return task.FindElement(childelement);

                var mesage = $"Expected :{Environment.NewLine}'{childelement}' with task name - '{taskName}' under - '{sectionName}' section.{Environment.NewLine}" +
                             $"Actual :{Environment.NewLine}{string.Join($"{Environment.NewLine}", tasks.Select(x => x.Text))}";

                throw new NotFoundException(mesage);
            };
        }
    }
}