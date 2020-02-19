using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class IsAnyOneControlOfRemovedTrusteePage : RoatpBasePage
    {
        protected override string PageTitle => "Register of Removed Trustees?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public IsAnyOneControlOfRemovedTrusteePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlBankruptInLastThreeYearsPage SelectNo()
        {
            SelectNoAndContinue();
            return new WhosInControlBankruptInLastThreeYearsPage(_context);
        }
    }
}
