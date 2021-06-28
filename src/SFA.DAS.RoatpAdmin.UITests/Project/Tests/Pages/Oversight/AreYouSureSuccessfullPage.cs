using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureSuccessfullPage : AreYouSureAboutApplicationOutcomePage
    {
        protected override string PageTitle => "Are you sure you want to mark this application as successful?";

        protected override string OversightAssessmentMessage => "Successful";

        public AreYouSureSuccessfullPage(ScenarioContext context) : base(context) { }
    }
}
