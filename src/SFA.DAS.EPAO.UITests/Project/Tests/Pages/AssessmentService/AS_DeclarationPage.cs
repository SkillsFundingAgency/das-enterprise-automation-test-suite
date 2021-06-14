using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_DeclarationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Declaration";
        private readonly ScenarioContext _context;

        public AS_DeclarationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void ClickConfirmInDeclarationPage() => Continue();

        public AS_WhatGradePage ClickConfirmInDeclarationPageForPrivatelyFundedApprentice()
        {
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
