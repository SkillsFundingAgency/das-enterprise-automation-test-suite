using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ConfirmOrganisationManagementHierarchy : RoatpBasePage
    {
        protected override string PageTitle => "Confirm your organisation's management hierarchy for apprenticeships";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmOrganisationManagementHierarchy(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ContinueToApplicationOverview()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }

    }
}


