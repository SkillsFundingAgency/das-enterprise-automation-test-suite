using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class ManagementHierarchyForApprenticeshipsPage : AssessorBasePage
    {
        protected override string PageTitle => "Management hierarchy for apprenticeships";
        private readonly ScenarioContext _context;

        public ManagementHierarchyForApprenticeshipsPage(ScenarioContext context) : base(context) => _context = context;

        public AnnualTurnOverFTEPage SelectPassAndContinueInManagementHierarchyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AnnualTurnOverFTEPage(_context);
        }
    }
}