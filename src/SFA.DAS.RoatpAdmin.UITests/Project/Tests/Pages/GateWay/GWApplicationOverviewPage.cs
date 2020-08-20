using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Application assessment overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TaskLists => By.CssSelector(".das-task-list > li");

        private By TaskSection => By.CssSelector(".das-task-list__section");

        private By TaskItem => By.CssSelector(".das-task-list__item");

        private By TaskName => By.CssSelector(".das-task-list__task-name > .govuk-link");

        private By TaskStatus => By.CssSelector(".das-task-list__task-tag");

        public GWApplicationOverviewPage(ScenarioContext context) : base(context)
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

                var task = tasks.Where(x => x.Text.StartsWith(taskName)).ElementAt(index);

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
