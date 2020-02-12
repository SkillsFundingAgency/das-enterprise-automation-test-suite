using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class GradeWithin3YearsPage : RoatpBasePage
    {
        protected override string PageTitle => "Did your organisation get this grade within the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GradeWithin3YearsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ShortOfstedInspectionPage SelectNoForGradeWithinThreeYearsAndContinue()
        {
            SelectNoAndContinue();
            return new ShortOfstedInspectionPage(_context);
        }
    }
}
