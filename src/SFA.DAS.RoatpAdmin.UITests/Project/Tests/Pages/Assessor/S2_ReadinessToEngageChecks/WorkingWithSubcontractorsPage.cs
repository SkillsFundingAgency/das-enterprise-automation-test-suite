using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class WorkingWithSubcontractorsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Using subcontractors in the first 12 months of joining the APAR";

        public DueDiligenceOnSubcontractorsPage SelectPassAndContinueInWorkingWithSubcontractorsPage()
        {
            SelectPassAndContinueToSubSection();
            return new DueDiligenceOnSubcontractorsPage(context);
        }
    }
}