using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class EndPointAssesmentOrganisationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation engage with end-point assessment organisations (EPAOs)?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EndPointAssesmentOrganisationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AwardingBodiesPage EnterTextRegardingEngageWithEPAOandContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithEPAO);
            return new AwardingBodiesPage(_context);
        }
    }
}
