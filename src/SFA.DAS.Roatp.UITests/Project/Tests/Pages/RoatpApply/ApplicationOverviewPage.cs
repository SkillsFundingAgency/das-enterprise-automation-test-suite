using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public partial class ApplicationOverviewPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TaskLists => By.CssSelector(".app-task-list > li");

        private By TaskSection => By.CssSelector(".app-task-list__section");

        private By TaskItem => By.CssSelector(".app-task-list__item");

        private By TaskName => By.CssSelector(".app-task-list__task-name > .govuk-link");

        private By TaskStatus => By.CssSelector(".govuk-tag");

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        private Func<IWebElement> GetTaskLinkElement(string sectionName, string taskName, int index) => GetTaskElement(sectionName, taskName, TaskName, index);

        private Func<IWebElement> GetTaskStatusElement(string sectionName, string taskName, int index) => GetTaskElement(sectionName, taskName, TaskStatus, index);

        private Func<IWebElement> GetTaskElement(string sectionName, string taskName, By childelement, int index)
        {
            return () =>
            {
                var section = pageInteractionHelper.FindElements(TaskLists).Single(x => x.Text.StartsWith(sectionName));

                var tasks = section.FindElements(TaskItem);

                var task = tasks.Where(x => x.Text.ContainsCompareCaseInsensitive(taskName)).ElementAt(index);

                if (childelement == TaskStatus ? true : (!task.Text.ContainsCompareCaseInsensitive("NOT REQUIRED")))
                {
                    return task.FindElement(childelement);
                }

                var mesage = $"Expected :{Environment.NewLine}'{childelement}' with task name - '{taskName}' under - '{sectionName}' section.{Environment.NewLine}" +
                             $"Actual :{Environment.NewLine}{string.Join($"{Environment.NewLine}", tasks.Select(x => x.Text))}";
                throw new NotFoundException(mesage);
            };
        }
    }
}
