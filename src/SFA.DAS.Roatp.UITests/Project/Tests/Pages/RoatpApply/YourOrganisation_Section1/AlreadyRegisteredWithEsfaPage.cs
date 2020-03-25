using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class AlreadyRegisteredWithEsfaPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AlreadyRegisteredWithEsfaPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public TrainApprenticesPage SelectYesForOrgAlreadyRegisteredAndContinueRouteEmployer()
        {
            SelectYesAndContinue();
            return new TrainApprenticesPage(_context);
        }

        public DescribeYourOrganisationPage SelectYesForOrgAlreadyRegisteredAndContinue()
        {
            SelectYesAndContinue();
            return new DescribeYourOrganisationPage(_context);
        }
    }
}
