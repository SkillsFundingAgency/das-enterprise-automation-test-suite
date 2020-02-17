using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class LevyPayingEmployerPage : RoatpBasePage
    {
        protected override string PageTitle => "Is your organisation a levy-paying employer?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public LevyPayingEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TermsConditionsMakingApplicationPage SelectYesForLevyPayingEmployerAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TermsConditionsMakingApplicationPage(_context);
        }
    }
}
