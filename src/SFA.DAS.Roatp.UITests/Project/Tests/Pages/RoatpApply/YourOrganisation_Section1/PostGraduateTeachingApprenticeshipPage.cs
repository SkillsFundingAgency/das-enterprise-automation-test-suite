using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class PostGraduateTeachingApprenticeshipPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is the postgraduate teaching apprenticeship the only apprenticeship your organisation intends to deliver?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PostGraduateTeachingApprenticeshipPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public FullOfstedInspectionPage SelectNoForPGTAAndContinue()
        {
            SelectNoAndContinue();
            return new FullOfstedInspectionPage(_context);
        }
        public ApplicationOverviewPage SelectYesForPGTAAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
