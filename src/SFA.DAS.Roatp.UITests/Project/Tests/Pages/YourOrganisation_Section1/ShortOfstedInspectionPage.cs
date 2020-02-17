using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class ShortOfstedInspectionPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation had a short Ofsted inspection within the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ShortOfstedInspectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MaintainedTheGradeInOfsteadInspectionPage SelectYesForShortOFstedInspectionWithinThreeYearsAndContinue()
        {
            SelectYesAndContinue();
            return new MaintainedTheGradeInOfsteadInspectionPage(_context);
        }
    }
}
