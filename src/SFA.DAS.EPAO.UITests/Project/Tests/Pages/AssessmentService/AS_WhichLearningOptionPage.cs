using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "Which learning option did the apprentice take?";
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        public AS_WhichLearningOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_WhatGradePage SelectLearningOptionAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByText(RadioLabels, "Overhead Lines");
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}