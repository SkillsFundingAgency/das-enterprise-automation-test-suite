using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class DoesYourOrganisationHaveSomeonePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have someone responsible for developing and delivering training?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoesYourOrganisationHaveSomeonePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectNo()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(_context);
        }

        public WhoHasThePersonWorkedPage SelectYes()
        {
            SelectYesAndContinue();
            return new WhoHasThePersonWorkedPage(_context);
        }
    }
}
