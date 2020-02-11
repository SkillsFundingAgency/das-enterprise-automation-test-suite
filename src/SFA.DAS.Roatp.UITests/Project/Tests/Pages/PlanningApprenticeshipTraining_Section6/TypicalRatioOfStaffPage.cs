using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6
{
    public class TypicalRatioOfStaffPage : RoatpBasePage
    {
        protected override string PageTitle => "What is the typical ratio of the staff who deliver training to the apprentices?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OneTrainerBetween10OrLessAoorenticesRadio => By.Id("PAT-643");

        public TypicalRatioOfStaffPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectOneTrainerBetween10OrLessApprenticesAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OneTrainerBetween10OrLessAoorenticesRadio));
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
