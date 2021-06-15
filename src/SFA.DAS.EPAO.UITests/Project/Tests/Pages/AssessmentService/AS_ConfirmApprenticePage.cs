using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";
        
        private readonly ScenarioContext _context;

        protected override By RadioLabels => By.CssSelector(".govuk-radios__label[for*='standard']");

        private By ViewCertificateHistorySelector => By.CssSelector(".govuk-details__summary-text");

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_AssesmentAlreadyRecorded GoToAssesmentAlreadyRecordedPage()
        {
            SelectStandard(true);

            return new AS_AssesmentAlreadyRecorded(_context);
        }

        public AS_ConfirmApprenticePage ViewCertificateHistory() 
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ViewCertificateHistorySelector));

            return new AS_ConfirmApprenticePage(_context);
        }

        public AS_WhichVersionPage GoToWhichVersionPage(bool hasMultiStandards)
        {
            SelectStandard(hasMultiStandards);

            return new AS_WhichVersionPage(_context);
        }

        public AS_WhichLearningOptionPage GoToWhichLearningOptionPage(bool hasMultiStandards)
        {
            SelectStandard(hasMultiStandards);

            return new AS_WhichLearningOptionPage(_context);
        }

        public AS_DeclarationPage GoToDeclarationPage(bool hasMultiStandards)
        {
            SelectStandard(hasMultiStandards);

            return new AS_DeclarationPage(_context);
        }

        private void SelectStandard(bool hasMultiStandards)
        {
            if (hasMultiStandards)
            {
                var standardName = objectContext.GetLearnerStandardName();

                if (string.IsNullOrEmpty(standardName)) SelectRadioOptionByText(pageInteractionHelper.GetText(RadioLabels));

                else SelectRadioOptionByText(standardName);

            }

            Continue();
        }
    }
}