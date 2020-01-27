using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OrganisationsProcessForInitialAssessementsPage : RoatpBasePage
    {
        protected override string PageTitle => "What is your organisation's process for initial assessments to recognise prior learning?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.Id("RTE-60");

        public OrganisationsProcessForInitialAssessementsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ToAssessEnglishAndMathsPage EnterTextRegardingOrganisationProcessForInitialTraningAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.OrganisationProcessForInitialTraning);
            Continue();
            return new ToAssessEnglishAndMathsPage(_context);
        }
    }
}
