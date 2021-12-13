using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ConfrimWhosInControlPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm who's in control";

        #region Helpers and Context
        
        #endregion

        public ConfrimWhosInControlPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ConfirmWhosInContorlAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public ConfirmTrusteesPage ConfirmWhosInContorlAndContinueToTrusteesPage()
        {
            Continue();
            return new ConfirmTrusteesPage(_context);
        }
    }
}
