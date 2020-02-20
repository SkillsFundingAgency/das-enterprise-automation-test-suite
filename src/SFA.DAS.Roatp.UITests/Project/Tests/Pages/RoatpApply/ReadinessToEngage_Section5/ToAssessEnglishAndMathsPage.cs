using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class ToAssessEnglishAndMathsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation's process to assess English and maths qualifications for apprentices?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ToAssessEnglishAndMathsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingProcessToAssessEnglishAndMathsAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ProcessToAssessEnglishAndMaths);
            return new ApplicationOverviewPage(_context);
        }
    }
}
