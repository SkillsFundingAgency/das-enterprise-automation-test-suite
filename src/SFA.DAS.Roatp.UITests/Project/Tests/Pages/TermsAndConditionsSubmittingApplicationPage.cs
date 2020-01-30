using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TermsAndConditionsSubmittingApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you agree to the terms and conditions of submitting an application?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TermsAndConditionsSubmittingApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TermsAndConditionsOfJoiningRoatpPage SelectYesAgreeTermsAndContionsOfSubmittingAnApplicataionAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TermsAndConditionsOfJoiningRoatpPage(_context);
        }
    }
}
