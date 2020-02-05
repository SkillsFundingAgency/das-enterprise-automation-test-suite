using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6
{
    public class EnsureApprenticesSupportedPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation ensure apprentices are supported during their apprenticeship training?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_HowApprenticesAreSupported => By.Id("PAT-630");

        public EnsureApprenticesSupportedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowOrganisationSupportApprenticesPage EnterTextForHowOrgEnsureApprenticesAreSupportedAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_HowApprenticesAreSupported, applydataHelpers.LongTextArea_HowApprenticesAreSupported);
            Continue();
            return new HowOrganisationSupportApprenticesPage(_context);
        }
    }
}


