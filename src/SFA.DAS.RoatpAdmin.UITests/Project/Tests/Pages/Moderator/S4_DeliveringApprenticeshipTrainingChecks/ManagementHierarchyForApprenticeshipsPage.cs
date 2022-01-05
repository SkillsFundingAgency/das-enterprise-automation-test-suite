using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class ManagementHierarchyForApprenticeshipsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Management hierarchy for apprenticeships";
        
        public ManagementHierarchyForApprenticeshipsPage(ScenarioContext context) : base(context) { }

        public AnnualTurnOverFTEPage SelectPassAndContinueInManagementHierarchyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AnnualTurnOverFTEPage(context);
        }
        public AnnualTurnOverFTEPage SelectFailAndContinueInManagementHierarchyPage()
        {
            SelectFailAndContinueToSubSection();
            return new AnnualTurnOverFTEPage(context);
        }
    }
}