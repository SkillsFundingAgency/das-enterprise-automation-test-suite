using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ApplicationOverviewPage : RoatpBasePage
    {
        protected override string PageTitle => "Application overview";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TaskListItem => By.CssSelector(".app-task-list__item");

        private By TaskListName => By.CssSelector(".app-task-list__task_name");

        private By TaskStatus => By.CssSelector(".govuk-tag");

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public bool VerifyIntroductionStatus(string status) => VerifyElement(GetTaskStatusElement("Introduction and what you'll need"), status);

        private Func<IWebElement> GetTaskListElement(string taskName) => GetTaskElement(taskName);

        private Func<IWebElement> GetTaskStatusElement(string taskName) => GetTaskElement(taskName, TaskStatus);

        private Func<IWebElement> GetTaskElement(string taskName, By childelement = null)
        {
            return () =>
            {
                var tasks = pageInteractionHelper.FindElements(TaskListItem);

                foreach (var task in tasks)
                {
                    var taskelement = task.FindElement(TaskListName);
                    if (taskelement.Text.ContainsCompareCaseInsensitive(taskName))
                    {
                        return childelement == null ? taskelement : task.FindElement(childelement);
                    }
                }
                throw new NotFoundException($"can not find task element with text '{taskName}'");
            };
        }
    }
}
