using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class MaintainedTheGradeInOfsteadInspectionPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation maintained the grade it got in its full Ofsted inspection in its short Ofsted inspection?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public MaintainedTheGradeInOfsteadInspectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public MaintainedFundingFromAnEducationAgencyPage SelectYesForGradeMaintainedAndContinue()
        {
            SelectYesAndContinue();
            return new MaintainedFundingFromAnEducationAgencyPage(_context);
        }
    }
}
