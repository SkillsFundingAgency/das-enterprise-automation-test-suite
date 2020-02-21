using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class FullOfstedInspectionPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation had a full Ofsted inspection in further education and skills?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FullOfstedInspectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MonitoringVisitPage SelectNoForFullOfstedInspectionAndContinue()
        {
            SelectNoAndContinue();
            return new MonitoringVisitPage(_context);
        }

        public GradeInOfstedInspectionPage SelectYesForFullOfstedInspectionAndContinue()
        {
            SelectYesAndContinue();
            return new GradeInOfstedInspectionPage(_context);
        }
    }
}
