using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";
        
        private readonly ScenarioContext _context;

        protected override By RadioLabels => By.CssSelector(".govuk-radios__label[for*='standard']");

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhichVersionPage GoToWhichVersionPage(bool hasMultiStandards)
        {
            if (hasMultiStandards) SelectStandard();

            return new AS_WhichVersionPage(_context);
        }

        public AS_WhichLearningOptionPage GoToWhichLearningOptionPage()
        {
            SelectStandard();

            return new AS_WhichLearningOptionPage(_context);
        }

        private void SelectStandard()
        {
            var standardName = objectContext.GetLearnerStandardName();

            if (string.IsNullOrEmpty(standardName)) SelectRadioOptionByText(pageInteractionHelper.GetText(RadioLabels));

            else SelectRadioOptionByText(standardName);
        }
    }
}