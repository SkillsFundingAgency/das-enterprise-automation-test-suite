using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ReadinessToEngage_Section5
{
    public class PromoteApprentcieshipsToEmployersPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation promote apprenticeships to employers?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PromoteApprentcieshipsToEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextRegardingOrganisationPromoteApprenticeshipsToEmployerAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OrganisationPromoteApprenticeships);
            return new ApplicationOverviewPage(_context);
        }
    }
}
