using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class PermissionFromOrganisationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you have permission from your organisation to submit this application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PermissionFromOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesForPermissionFromOrganisationAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
