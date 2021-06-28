using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ChangeUkprnPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Change UKPRN";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChangeUkprnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterUkprnPage SelectYesToChangeUkprnAndContinue()
        {
            SelectYesAndContinue();
            return new EnterUkprnPage(_context);
        }

        public ApplicationOverviewPage SelectNoToChangeUkprnAndContinue()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}