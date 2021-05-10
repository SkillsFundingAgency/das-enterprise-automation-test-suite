using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "Choose the option for";
        private readonly ScenarioContext _context;

        public AS_WhichLearningOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_DeclarationPage SelectLearningOptionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Specific Architectural Joiner");
            Continue();
            return new AS_DeclarationPage(_context);
        }
        public AS_DeclarationPage SelectWhichLearningOptionAndContinue()
        {
            SelectRadioOptionByText("Managing Assets & Responding to Major Incidents in the Water Environment"); 
            Continue();
            return new AS_DeclarationPage(_context);
        }

        public AS_WhatGradePage ClickConfirmInDeclarationPage()
        {
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}