using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks
{
    public class SafeguardingPolicyIncludePreventDutyPolicyPage : ModeratorBasePage
    {
        protected override string PageTitle => "Safeguarding policy include Prevent duty policy";

        public SafeguardingPolicyIncludePreventDutyPolicyPage(ScenarioContext context) : base(context) { objectContext.SetIsUploadFile(); }
    }
}
