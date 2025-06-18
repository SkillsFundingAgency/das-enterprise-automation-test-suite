using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class TypicalRatioOfStaffPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is the typical ratio of the staff who deliver training to the apprentices?";

        private static By OneTrainerBetween10OrLessAoorenticesRadio => By.Id("PAT-653");

        public TypicalRatioOfStaffPage(ScenarioContext context) : base(context) => VerifyPage();

        public LevleOfSupportProvidedPage SelectOneTrainerBetween10OrLessApprenticesAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OneTrainerBetween10OrLessAoorenticesRadio));
            Continue();
            return new LevleOfSupportProvidedPage(context);
        }
    }
}
