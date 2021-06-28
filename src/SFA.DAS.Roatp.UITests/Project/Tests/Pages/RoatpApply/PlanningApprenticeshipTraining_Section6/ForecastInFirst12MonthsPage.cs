using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class ForecastInFirst12MonthsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How many starts does your organisation forecast in the first 12 months of joining the RoATP?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OneTo49CheckRadio => By.Id("PAT-650");

        public ForecastInFirst12MonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public DeliverTrainingAgainstForecastPage SelectOneTo49ForecastAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OneTo49CheckRadio));
            Continue();
            return new DeliverTrainingAgainstForecastPage(_context);
        }
    }
}
