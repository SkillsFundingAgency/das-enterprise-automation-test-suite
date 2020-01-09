using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipApplicationSubmittedPage : FAA_ApplicationSubmittedPage
    {
        protected override string PageTitle => "Traineeship application submitted";

        public FAA_TraineeshipApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }

}
