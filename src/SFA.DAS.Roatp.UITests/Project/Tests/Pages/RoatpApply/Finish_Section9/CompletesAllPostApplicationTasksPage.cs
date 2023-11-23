
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class CompletesAllPostApplicationTasksPage: RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you understand that your organisation will not join the APAR until it completes all post application tasks?";

        public CompletesAllPostApplicationTasksPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage SelectYesToCompletesAllPostApplicationTasksAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(context);
        }

        public FinishSectionShutterPage SelectNoToCompletesAllPostApplicationTasksAndContinue()
        {
            SelectNoAndContinue();
            return new FinishSectionShutterPage(context);
        }
    }
}
