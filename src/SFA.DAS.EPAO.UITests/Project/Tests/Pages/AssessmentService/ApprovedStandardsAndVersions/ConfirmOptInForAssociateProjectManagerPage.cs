using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class ConfirmOptInForAssociateProjectManagerPage : EPAO_BasePage
    {
        protected override string PageTitle => "Associate project manager";

        public ConfirmOptInForAssociateProjectManagerPage(ScenarioContext context) : base(context) => VerifyPage();

        public OptInConfirmationPage ConfirmOptIn()
        {
            Continue();
            return new OptInConfirmationPage(context);
        }
    }
}