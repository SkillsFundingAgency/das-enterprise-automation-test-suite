using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class NotAcceptTermsConditionsPage : RoatpBasePage
    {
        protected override string PageTitle => "You do not accept the conditions of acceptance for the RoATP";

        public NotAcceptTermsConditionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
