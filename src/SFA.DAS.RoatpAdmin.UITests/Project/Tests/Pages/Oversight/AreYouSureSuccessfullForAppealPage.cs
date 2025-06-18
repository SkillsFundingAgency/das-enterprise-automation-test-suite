using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureSuccessfullForAppealPage(ScenarioContext context) : AreYouSureAboutApplicationOutcomePage(context)
    {
        protected override string PageTitle => "Are you sure you want to mark this appeal as Successful";

        protected override string OversightAssessmentMessage => "Successful";
    }
}
