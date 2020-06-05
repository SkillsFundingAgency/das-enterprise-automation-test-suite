using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class GradeWithin3YearsPage : RoatpApplyBasePage
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
        public MaintainedFundingFromAnEducationAgencyPage SelectYesForGradeWithinThreeYearsAndContinue()
        {
            SelectYesAndContinue();
            return new MaintainedFundingFromAnEducationAgencyPage(_context);
        }
        public NotEligiblePage SelectYesForInadequateGradeWithinThreeYearsAndContinue()
        {
            SelectYesAndContinue();
            return new NotEligiblePage(_context);
        }
    }
}
