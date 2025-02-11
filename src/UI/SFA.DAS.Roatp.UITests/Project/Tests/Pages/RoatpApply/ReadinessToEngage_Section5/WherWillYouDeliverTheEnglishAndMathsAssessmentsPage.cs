using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class WherWillYouDeliverTheEnglishAndMathsAssessmentsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Where will you deliver the assessments in English and maths?";

        private static By DigitalWorkPlaceAssessmentRadio => By.CssSelector("input[type='checkbox'][value='Digital workplace assessment']");

        public WherWillYouDeliverTheEnglishAndMathsAssessmentsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AssemmentIfThereIsASignificantEventPage SelectDigitalWorkplacAssessmentAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(DigitalWorkPlaceAssessmentRadio));
            Continue();
            return new AssemmentIfThereIsASignificantEventPage(context);
        }
    }
}
