using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecordAGradePage : BasePage
    {
        protected override string PageTitle => "Record a grade";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAOConfig _ePAOConfig;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;
        #endregion

        #region Locators
        private By FamilyNameTextBox => By.Name("Surname");
        private By ULNTextBox => By.Name("Uln");
        #endregion

        public AS_RecordAGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
            VerifyPage();
        }

        public AS_ConfirmApprenticePage SearchApprentice(string enrolledStandard)
        {
            string familyName=null, uLN=null;

            switch (enrolledStandard)
            {
                case "single":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.EPAOApprenticeUlnWithSingleStandard);
                    familyName = _ePAOConfig.EPAOApprenticeNameWithSingleStandard; 
                    uLN = _ePAOConfig.EPAOApprenticeUlnWithSingleStandard;
                    break;
                case "more than one":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.EPAOApprenticeUlnWithMultipleStandards);
                    familyName = _ePAOConfig.EPAOApprenticeNameWithMultipleStandards; 
                    uLN = _ePAOConfig.EPAOApprenticeUlnWithMultipleStandards;
                    break;
                case "additional learning option":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.EPAOApprenticeUlnWithAStandardHavingLearningOption);
                    familyName = _ePAOConfig.EPAOApprenticeNameWithAStandardHavingLearningOption; 
                    uLN = _ePAOConfig.EPAOApprenticeUlnWithAStandardHavingLearningOption;
                    break;
            }

            _formCompletionHelper.EnterText(FamilyNameTextBox, familyName);
            _formCompletionHelper.EnterText(ULNTextBox, uLN);
            Continue();

            return new AS_ConfirmApprenticePage(_context);
        }
    }
}
