using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TermsAndConditionsOfJoiningRoatpPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you agree to the terms and conditions";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TermsAndConditionsOfJoiningRoatpPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesAgreeTermsAndContionsOfJoiingRoatpAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
