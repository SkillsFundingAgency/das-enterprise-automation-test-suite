using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class PlanningApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Planning apprenticeship training";

        public PlanningApprenticeshipTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
