using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public partial class ApplicationAssessmentOverviewPage : AssessorBasePage
    {
        protected override string PageTitle => "Application assessment overview";
        private readonly ScenarioContext _context;

        public ApplicationAssessmentOverviewPage(ScenarioContext context) : base(context) => _context = context;

        #region Section-1
        private string Section1_Link1 => "Continuity plan for apprenticeship training";
        #endregion
    }
}
