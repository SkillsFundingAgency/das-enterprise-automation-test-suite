using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class HowWillYouDeliverEnglishAndMathsAssessmentsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will you deliver the assessments in English and maths?";


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowWillYouDeliverEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WherWillYouDeliverTheEnglishAndMathsAssessmentsPage SelectDigitallyAndContinue()
        {
            SelectRadioOptionByText("Digitally");
            Continue();
            return new WherWillYouDeliverTheEnglishAndMathsAssessmentsPage(_context);
        }
    }
}
