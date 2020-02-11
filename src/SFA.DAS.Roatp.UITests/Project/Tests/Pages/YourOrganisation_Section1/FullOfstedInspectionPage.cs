using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class FullOfstedInspectionPage : RoatpBasePage
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
            SelectRadioOptionByText("No");
            Continue();
            return new MonitoringVisitPage(_context);
        }
    }
}
