using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ReadinessToEngage_Section5
{
    public class OrganisationsProcessForInitialAssessementsPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's process for initial assessments to recognise prior learning?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationsProcessForInitialAssessementsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ToAssessEnglishAndMathsPage EnterTextRegardingOrganisationProcessForInitialTraningAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OrganisationProcessForInitialTraning);
            return new ToAssessEnglishAndMathsPage(_context);
        }
    }
}
