using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public partial class ModerationApplicationAssessmentOverviewPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Application moderation overview";

        #region Section-1
        private static string Section1_Link1 => "Continuity plan for apprenticeship training";
        private static string Section1_Link2 => "Equality and diversity policy";
        private static string Section1_Link3 => "Safeguarding and Prevent duty policy";
        private static string Section1_Link4 => "Health and safety policy";
        private static string Section1_Link5 => "Acting as a subcontractor";
        #endregion

        #region Section-2
        private static string Section2_Link1 => "Engaging with employers";
        private static string Section2_Link2 => "Complaints policy";
        private static string Section2_Link3 => "Contract for services template";
        private static string Section2_Link4 => "Commitment statement template";
        private static string Section2_Link5 => "Prior learning of apprentices";
        private static string Section2_Link6 => "English and maths assessments";
        private static string Section2_Link7 => "Working with subcontractors";
        #endregion

        #region Section-3
        private static string Section3_Link1 => "Type of apprenticeship training";
        private static string Section3_Link2 => "Training apprentices";
        private static string Section3_Link3 => "Supporting apprentices";
        private static string Section3_Link4 => "Forecasting starts";
        private static string Section3_Link5 => "Off the job training";
        private static string Section3_Link6 => "Where will your apprentices be trained";
        #endregion

        #region Section-4
        private static string Section4_Link1 => "Overall accountability for apprenticeships";
        private static string Section4_Link2 => "Management hierarchy for apprenticeships";
        private static string Section4_Link3 => "Quality and high standards in apprenticeship training";
        private static string Section4_Link4 => "Developing and delivering training";
        private static string Section4_Link5 => "Sectors and employee experience";
        private static string Section4_Link6 => "Policy for professional development of employees";
        #endregion

        #region Section-5
        private static string Section5_Link1 => "Process for evaluating the quality of training delivered";
        private static string Section5_Link2 => "Process of evaluating the quality of apprenticeship training";
        private static string Section5_Link3 => "Systems and processes to collect apprenticeship data";
        #endregion

        #region Section-6
        private static string Section6_Link1 => "Confirm moderation outcome";
        #endregion
    }
}
