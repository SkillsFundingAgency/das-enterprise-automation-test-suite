using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ReprintReasonPage : ConfirmReasonBasePage
    {
        protected override string PageTitle => "Are you sure this certificate needs reprinting?";

        public ReprintReasonPage(ScenarioContext context) : base(context) { }
    }
}