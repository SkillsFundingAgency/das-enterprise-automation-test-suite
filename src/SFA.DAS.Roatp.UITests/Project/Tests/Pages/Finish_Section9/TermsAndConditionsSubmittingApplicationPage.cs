using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.Finish_Section9
{
    public class TermsAndConditionsSubmittingApplicationPage : RoatpBasePage
    {
        protected override string PageTitle => "Do you agree to the terms and conditions of joining and staying on the RoATP?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TermsAndConditionsSubmittingApplicationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesAgreeTermsAndContionsOfSubmittingAnApplicataionAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
