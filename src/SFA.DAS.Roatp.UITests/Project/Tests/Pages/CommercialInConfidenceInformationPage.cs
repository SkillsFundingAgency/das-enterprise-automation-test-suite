using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class CommercialInConfidenceInformationPage : RoatpBasePage
    {
        protected override string PageTitle => "Is any of the information in this application 'commercial in confidence'?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CommercialInConfidenceInformationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage SelectYesForCommercialInConfidenceInformationAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
