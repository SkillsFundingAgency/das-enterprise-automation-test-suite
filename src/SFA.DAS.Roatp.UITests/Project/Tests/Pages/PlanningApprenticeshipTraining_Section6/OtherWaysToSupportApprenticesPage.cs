using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6
{
    public class OtherWaysToSupportApprenticesPage : RoatpBasePage
    {
        protected override string PageTitle => "What other ways will your organisation use to support its apprentices?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OtherWaysToSupportApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForOtherWaysToSupportApprenticesAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OtherWaysToSupportApprentices);
            return new ApplicationOverviewPage(_context);
        }
    }
}


