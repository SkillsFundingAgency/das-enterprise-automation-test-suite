using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class NotAcceptTermsConditionsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "You do not accept the conditions of acceptance for the RoATP";

        public NotAcceptTermsConditionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
