using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class HowManyStartsDoesYourOrgForecastPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How many starts does your organisation forecast ";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");
        private By NumberOfStart => By.CssSelector(".govuk-input");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowManyStartsDoesYourOrgForecastPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowManyEmployeesWillDeliverTrainingPage EnterNumberOfStartsAndContinue()
        {
            formCompletionHelper.EnterText(NumberOfStart, "12");
            Continue();
            return new HowManyEmployeesWillDeliverTrainingPage(_context);
        }
    }
}