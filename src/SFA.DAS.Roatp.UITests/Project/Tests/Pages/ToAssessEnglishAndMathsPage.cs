using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ToAssessEnglishAndMathsPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's process to assess English and maths qualifications for apprentices?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.Id("RTE-61");

        public ToAssessEnglishAndMathsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage EnterTextRegardingProcessToAssessEnglishAndMathsAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.ProcessToAssessEnglishAndMaths);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
