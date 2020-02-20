using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class MaintainedFundingFromAnEducationAgencyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation maintained funding from an education agency since its full Ofsted inspection?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public MaintainedFundingFromAnEducationAgencyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesForGradeMaintainedFromEducationAgencyAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
