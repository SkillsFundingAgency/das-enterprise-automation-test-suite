using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class HowExpectationsAreMonitoredPage : RoatpBasePage
    {
        protected override string PageTitle => "Tell us how these expectations for quality and high standards in apprenticeship training are monitored and evaluated";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector("textarea");

        public HowExpectationsAreMonitoredPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoIsResposibleToMaintainExpectationsPage EnterTextForHowExpectationsAreMonitored()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.HowExpectationsAreMonitored);
            Continue();
            return new WhoIsResposibleToMaintainExpectationsPage(_context);
        }
    }
}