using OpenQA.Selenium;
using SFA.DAS.EsfaAdmin.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public partial class ApplicationOverviewPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Application overview";

        private By ApplicationDetailsSelector => By.CssSelector(".govuk-summary-list__row");

        protected override By TaskLists => By.CssSelector(".app-task-list > li");

        protected override By TaskItem => By.CssSelector(".app-task-list__item");

        protected override By TaskName => By.CssSelector(".app-task-list__task-name > .govuk-link");

        protected override By TaskStatus => By.CssSelector(".app-task-list__task-completed, .app-task-list__task-notrequired, .app-task-list__task-next, .app-task-list__task-inprogress");

        public ApplicationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyApplicationDetails()
        {
            VerifyElement(() => pageInteractionHelper.FindElements(ApplicationDetailsSelector), objectContext.GetProviderName());
            VerifyElement(() => pageInteractionHelper.FindElements(ApplicationDetailsSelector), objectContext.GetUkprn());
        }
    }
}
