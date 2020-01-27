using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class PreventDutyPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation's safeguarding policy include its responsibilities towards the Prevent duty?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PreventDutyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesForPreventDutyPageAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
