using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class BanFromManagementOrGovernanceOfSchoolsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "subject to a ban from management or governance of schools?";

        public BanFromManagementOrGovernanceOfSchoolsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelecNoForBanFromManagementOrGovernanceOfSchoolsAndContinue()
        {
            SelectNoAndContinue();       
            return new ApplicationOverviewPage(_context);
        }
    }
}
