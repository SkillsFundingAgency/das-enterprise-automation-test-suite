using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_UserRemovedPage : EPAO_BasePage
    {
        protected override string PageTitle => "User removed";

        public AS_UserRemovedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
