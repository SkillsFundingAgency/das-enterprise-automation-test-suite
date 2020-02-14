using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class NotAcceptTermsConditionsPage : RoatpBasePage
    {
        protected override string PageTitle => "You do not agree to the terms and conditions of making an application";

        public NotAcceptTermsConditionsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
