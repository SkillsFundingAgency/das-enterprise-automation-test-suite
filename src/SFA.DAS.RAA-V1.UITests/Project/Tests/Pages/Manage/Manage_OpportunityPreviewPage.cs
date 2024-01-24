using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_OpportunityPreviewPage(ScenarioContext context) : Manage_VacanacyPreviewPage(context)
    {
        protected override string PageTitle => "Opportunity preview";
    }

}
