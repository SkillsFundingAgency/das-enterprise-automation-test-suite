using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class EvaluatingApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Evaluating apprenticeship training";

        public EvaluatingApprenticeshipTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
