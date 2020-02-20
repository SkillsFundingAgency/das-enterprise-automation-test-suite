using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class OfferingApprenticeshipFrameworksPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Offering apprenticeship frameworks";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OfferingApprenticeshipFrameworksPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TransitionFromFrameworksToStandardPage SelectYesForTransitionFromFrameworksToStandardsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TransitionFromFrameworksToStandardPage(_context);
        }
    }
}
