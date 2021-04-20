using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class StandardsIntendToDeliverPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What standards do you intend to deliver within the";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StandardsIntendToDeliverPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowManyStartsDoesYourOrgForecastPage EnterTextForWhatStandardsToDeliver()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.StandardIntendToDeliver);
            return new HowManyStartsDoesYourOrgForecastPage(_context);
        }
    }
}