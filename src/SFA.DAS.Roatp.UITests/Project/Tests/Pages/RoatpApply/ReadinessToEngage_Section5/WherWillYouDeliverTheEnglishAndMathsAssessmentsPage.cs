using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class WherWillYouDeliverTheEnglishAndMathsAssessmentsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Where will you deliver the assessments in English and maths?";

        private By DigitalWorkPlaceAssessmentRadio => By.CssSelector("input[type='checkbox'][value='Digital workplace assessment']");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WherWillYouDeliverTheEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AssemmentIfThereIsASignificantEventPage SelectDigitalWorkplacAssessmentAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(DigitalWorkPlaceAssessmentRadio));
            Continue();
            return new AssemmentIfThereIsASignificantEventPage(_context);
        }
    }
}
