using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ReadinessToEngage_Section5
{
    public class CarryOutDueDiligencePage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation carry out due diligence on its subcontractors?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CarryOutDueDiligencePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForManagingRelationshipWithEmployersAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ManagingRelationshipWithEmployers);
            return new ApplicationOverviewPage(_context);
        }
    }
}
