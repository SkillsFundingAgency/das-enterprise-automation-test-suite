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
        private string Section1_Link2 => "Equality and diversity policy";
        private string Section1_Link3 => "Safeguarding and Prevent duty policy";
        private string Section1_Link4 => "Health and safety policy";
        private string Section1_Link5 => "Acting as a subcontractor";
        #endregion

        #region Section-2
        private string Section2_Link1 => "Engaging with employers";
        private string Section2_Link2 => "Complaints policy";
        private string Section2_Link3 => "Contract for services template";
        private string Section2_Link4 => "Commitment statement template";
        private string Section2_Link5 => "Prior learning of apprentices";
        private string Section2_Link6 => "Working with subcontractors";
        #endregion

        #region Section-3
        private string Section3_Link1 => "Type of apprenticeship training";
        private string Section3_Link2 => "Supporting apprentices";
        private string Section3_Link3 => "Forecasting starts";
        private string Section3_Link4 => "Off the job training";
        private string Section3_Link5 => "Where will your apprentices be trained";
        #endregion

        #region Section-4
        private string Section4_Link1 => "Engaging with employers";
        private string Section4_Link2 => "Complaints policy";
        private string Section4_Link3 => "Contract for services template";
        private string Section4_Link4 => "Commitment statement template";
        private string Section4_Link5 => "Prior learning of apprentices";
        private string Section4_Link6 => "Working with subcontractors";
        #endregion

        #region Section-5
        private string Section5_Link1 => "Process for evaluating the quality of training delivered";
        private string Section5_Link2 => "Process of evaluating the quality of apprenticeship training";
        private string Section5_Link3 => "Systems and processes to collect apprenticeship data";
        #endregion
    }
}
