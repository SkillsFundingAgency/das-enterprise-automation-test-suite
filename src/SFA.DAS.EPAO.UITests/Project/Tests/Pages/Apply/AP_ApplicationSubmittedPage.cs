using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public class AP_ApplicationSubmittedPage : EPAO_BasePage
    {
        protected override string PageTitle => "Stage 1 of your application has been submitted";

        public AP_ApplicationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
