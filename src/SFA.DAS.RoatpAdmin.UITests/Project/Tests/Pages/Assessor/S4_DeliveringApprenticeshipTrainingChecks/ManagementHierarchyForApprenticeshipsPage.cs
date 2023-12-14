using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class ManagementHierarchyForApprenticeshipsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Management hierarchy for apprenticeships";

        public AnnualTurnOverFTEPage SelectPassAndContinueInManagementHierarchyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AnnualTurnOverFTEPage(context);
        }
    }
}