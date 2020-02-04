using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmYourIdentityPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm your identity";

        public AS_ConfirmYourIdentityPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
