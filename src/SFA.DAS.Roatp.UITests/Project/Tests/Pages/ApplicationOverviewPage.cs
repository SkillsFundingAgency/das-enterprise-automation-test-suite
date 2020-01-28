using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TaskLists => By.CssSelector(".app-task-list > li");

        private By TaskSection => By.CssSelector(".app-task-list__section");

        private By TaskItem => By.CssSelector(".app-task-list__item");

        private By TaskName => By.CssSelector(".app-task-list__task_name");

        private By TaskStatus => By.CssSelector(".govuk-tag");

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        private Func<IWebElement> GetTaskLinkElement(string sectionName, string taskName) => GetTaskElement(sectionName, taskName, TaskName);

        private Func<IWebElement> GetTaskStatusElement(string sectionName, string taskName) => GetTaskElement(sectionName, taskName, TaskStatus);

        private Func<IWebElement> GetTaskElement(string sectionName, string taskName, By childelement)
        {
            return () =>
            {
                var taskLists = pageInteractionHelper.FindElements(TaskLists);
                foreach(var tasklist in taskLists)
                {
                    if (tasklist.FindElement(TaskSection).Text.ContainsCompareCaseInsensitive(sectionName))
                    {
                        var tasks = tasklist.FindElements(TaskItem);
                        foreach (var task in tasks)
                        {
                            if (task.Text.ContainsCompareCaseInsensitive(taskName) && (childelement == TaskStatus ? true : !task.Text.ContainsCompareCaseInsensitive("COMPLETED")))
                            {
                                return task.FindElement(childelement);
                            }
                        }
                    }
                }
                throw new NotFoundException($"can not find task element inside '{sectionName}' with text '{taskName}'");
            };
        }
    }
}
