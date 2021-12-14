using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public abstract class EPAOApply_BasePage : EPAO_BasePage
    {

        public EPAOApply_BasePage(ScenarioContext context) : base(context) { }

        public AP_ApplicationOverviewPage ClickReturnToApplicationOverviewButton()
        {
            Continue();
            return new AP_ApplicationOverviewPage(context);
        }
    }
}
