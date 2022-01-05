using TechTalk.SpecFlow;


namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class InvitationRequestedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Invitation requested";

        public InvitationRequestedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
