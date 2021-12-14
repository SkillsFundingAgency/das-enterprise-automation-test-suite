using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class CommitmentStatementTemplateShutterPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "You do not agree to use ESFA's commitment statement template";

        public CommitmentStatementTemplateShutterPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
