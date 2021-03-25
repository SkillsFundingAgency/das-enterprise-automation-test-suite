using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class EnsureApprenticesSupportedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation ensure apprentices are supported during their apprenticeship training?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EnsureApprenticesSupportedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowOrganisationSupportApprenticesPage EnterTextForHowOrgEnsureApprenticesAreSupportedAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.HowApprenticesAreSupported);
            return new HowOrganisationSupportApprenticesPage(_context);
        }
        public ApplicationOverviewPage EnterTextForHowOrgEnsureApprenticesAreSupportedAndContinue_MainRoute()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.HowApprenticesAreSupported);
            return new ApplicationOverviewPage(_context);
        }
    }
}


