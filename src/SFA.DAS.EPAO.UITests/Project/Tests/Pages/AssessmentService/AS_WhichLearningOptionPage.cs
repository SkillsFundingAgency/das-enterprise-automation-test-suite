using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : EPAO_BasePage
    {
        protected override string PageTitle => "Which learning option did the apprentice take?";
        private readonly ScenarioContext _context;

        public AS_WhichLearningOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatGradePage SelectLearningOptionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "options_Overheadlines");
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
