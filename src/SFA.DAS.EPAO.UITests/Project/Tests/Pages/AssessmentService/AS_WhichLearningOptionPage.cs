using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "Choose the option for";

        private readonly ScenarioContext _context;

        protected override By RadioLabels => By.CssSelector(".govuk-radios__label[for*='options']");

        public AS_WhichLearningOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_DeclarationPage SelectLearningOptionAndContinue()
        {
            SelectRadioOptionByText(pageInteractionHelper.GetText(RadioLabels));
            Continue();
            return new AS_DeclarationPage(_context);
        }
    }
}