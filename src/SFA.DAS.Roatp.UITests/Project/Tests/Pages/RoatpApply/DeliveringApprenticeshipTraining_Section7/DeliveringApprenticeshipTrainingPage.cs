using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class DeliveringApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Delivering apprenticeship training";

        public DeliveringApprenticeshipTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
