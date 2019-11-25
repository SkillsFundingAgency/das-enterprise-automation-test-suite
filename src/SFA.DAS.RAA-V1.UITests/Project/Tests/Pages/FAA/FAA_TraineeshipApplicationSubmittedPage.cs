using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_TraineeshipApplicationSubmittedPage : FAA_ApplicationSubmittedPage
    {
        protected override string PageTitle => "Traineeship application submitted";

        public FAA_TraineeshipApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }

}
