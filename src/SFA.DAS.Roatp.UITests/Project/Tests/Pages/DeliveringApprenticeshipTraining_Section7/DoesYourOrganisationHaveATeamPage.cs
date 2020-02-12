using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class DoesYourOrganisationHaveATeamPage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have a team responsible for developing and delivering training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoesYourOrganisationHaveATeamPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoHasTheTeamWorkedPage SelectYes()
        {
            SelectYesAndContinue();
            return new WhoHasTheTeamWorkedPage(_context);
        }
    }
}


