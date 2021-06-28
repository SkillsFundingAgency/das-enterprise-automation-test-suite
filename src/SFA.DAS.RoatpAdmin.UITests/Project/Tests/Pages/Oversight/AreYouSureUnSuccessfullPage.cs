using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureUnSuccessfullPage : AreYouSureAboutApplicationOutcomePage
    {
        protected override string PageTitle => "Are you sure you want to mark this application as unsuccessful?";

        protected override string OversightAssessmentMessage => "Unsuccessful";

        public AreYouSureUnSuccessfullPage(ScenarioContext context) : base(context) { }
    }
}
