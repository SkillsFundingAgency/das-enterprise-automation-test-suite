using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class OfferingApprenticeshipFrameworksPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have a plan to transition from apprenticeship frameworks to apprenticeship standards?";

        public OfferingApprenticeshipFrameworksPage(ScenarioContext context) : base(context) => VerifyPage();

        public TransitionFromFrameworksToStandardPage SelectYesForTransitionFromFrameworksToStandardsAndContinue()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new TransitionFromFrameworksToStandardPage(context);
        }
    }
}
