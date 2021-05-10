using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class BanFromManagementOrGovernanceOfSchoolsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "subject to a ban from management or governance of schools?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public BanFromManagementOrGovernanceOfSchoolsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelecNoForBanFromManagementOrGovernanceOfSchoolsAndContinue()
        {
            SelectNoAndContinue();       
            return new ApplicationOverviewPage(_context);
        }
    }
}
