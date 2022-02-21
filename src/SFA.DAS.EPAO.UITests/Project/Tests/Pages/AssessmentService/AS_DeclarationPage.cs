using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_DeclarationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Declaration";
        
        public AS_DeclarationPage(ScenarioContext context) : base(context) => VerifyPage();
        
        public void ClickConfirmInDeclarationPage() => Continue();
    }
}
