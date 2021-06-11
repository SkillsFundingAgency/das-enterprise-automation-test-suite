using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichVersionPage : EPAO_BasePage
    {
        protected override string PageTitle => "Which version";
        private readonly ScenarioContext _context;

        public AS_WhichVersionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }


        public AS_WhichLearningOptionPage ClickConfirmInConfirmVersionPage()
        {
            SelectRadioOptionByText("Version 1.0");
            Continue();
            return new AS_WhichLearningOptionPage(_context);
        }

        public AS_DeclarationPage ClickConfirmInConfirmVersionPageNoOption()
        {
            SelectRadioOptionByText("Version 1.0");
            Continue();
            return new AS_DeclarationPage(_context);
        }
    }
}