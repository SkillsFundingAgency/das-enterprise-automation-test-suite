using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ConfrimWhosInControlPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm who's in control";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfrimWhosInControlPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ConfirmWhosInContorlAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public ConfirmTrusteesPage ConfirmWhosInContorlAndContinueToTrusteesPage()
        {
            Continue();
            return new ConfirmTrusteesPage(_context);
        }
    }
}
