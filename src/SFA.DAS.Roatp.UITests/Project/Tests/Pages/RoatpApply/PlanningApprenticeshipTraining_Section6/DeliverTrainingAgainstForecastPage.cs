using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class DeliverTrainingAgainstForecastPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "When will your organisation be ready to deliver training against this forecast?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By WithinFirstThreeMonthsRadio => By.Id("PAT-641");

        public DeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RecruitNewStaffPage SelectWithinTheFirstThreeMonthAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(WithinFirstThreeMonthsRadio));
            Continue();
            return new RecruitNewStaffPage(_context);
        }
    }

}
