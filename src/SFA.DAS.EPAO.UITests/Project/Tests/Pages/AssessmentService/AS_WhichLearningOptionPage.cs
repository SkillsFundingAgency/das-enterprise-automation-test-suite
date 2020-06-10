using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : EPAOAssesment_BasePage
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
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Overhead Lines");
            Continue();
            return new AS_WhatGradePage(_context);
        }
        public AS_WhatGradePage SelectWhichLearningOptionAndContinue()
        {
            SelectRadioOptionByText("Managing Assets & Responding to Major Incidents in the Water Environment"); 
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}