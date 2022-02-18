using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AmendReasonPage : ConfirmReasonBasePage
    {
        protected override string PageTitle => "Are you sure this certificate needs amending?";

        public AmendReasonPage(ScenarioContext context) : base(context) { }
    }
}