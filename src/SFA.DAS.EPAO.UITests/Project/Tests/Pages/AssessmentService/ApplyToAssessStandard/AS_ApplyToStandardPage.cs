using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplyToStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apply to assess a standard";

        private readonly ScenarioContext _context;

        #region Links 

        #region Your policies and procedures
        private string YourPolicies_01 => "Information commissioner's office registration";
        private string YourPolicies_02 => "Internal audit policy";
        private string YourPolicies_03 => "Public liability insurance";
        private string YourPolicies_04 => "Professional indemnity insurance";
        private string YourPolicies_05 => "Employers liability insurance";
        private string YourPolicies_06 => "Safeguarding policy";
        private string YourPolicies_07 => "Prevent agenda policy";
        private string YourPolicies_08 => "Conflict of interest policy";
        private string YourPolicies_09 => "Monitoring procedures";
        private string YourPolicies_10 => "Monitoring processes";
        private string YourPolicies_11 => "Complaints and appeals policy";
        private string YourPolicies_12 => "Fair access";
        private string YourPolicies_13 => "Consistency assurance";
        private string YourPolicies_14 => "Continuous quality assurance";
        #endregion

        #region Your occupational competence
        private string YourOccupational_01 => "Engagement with trailblazers and employers";
        private string YourOccupational_02 => "Professional organisation membership";
        #endregion

        #region Your assessors
        private string YourAssessors_01 => "Number of assessors";
        private string YourAssessors_02 => "Assessment capacity";
        private string YourAssessors_03 => "Ability to deliver assessments";
        #endregion

        #region Your professional standards
        private string YourStandards_01 => "Recruitment and training";
        private string YourStandards_02 => "Skills and qualifications";
        private string YourStandards_03 => "Continuous professional development";
        #endregion

        #region Your end-point assessment delivery model
        private string YourDevileryModel_01 => "End-point assessment delivery model";
        private string YourDevileryModel_02 => "Outsourcing of end-point assessments";
        private string YourDevileryModel_03 => "Engaging with employers and training providers";
        private string YourDevileryModel_04 => "Managing conflicts of interest";
        private string YourDevileryModel_05 => "Assessment locations";
        private string YourDevileryModel_06 => "Providing services straight away";
        private string YourDevileryModel_07 => "Assessment methods";
        private string YourDevileryModel_08 => "Continuous resource development";
        #endregion

        #region Your end-point assessment competence
        private string YourAssesment_01 => "Secure IT infrastructure";
        private string YourAssesment_02 => "Assessment administration";
        private string YourAssesment_03 => "Assessment products and tools";
        private string YourAssesment_04 => "Assessment content";
        private string YourAssesment_05 => "Collation and confirmation of assessment outcomes";
        private string YourAssesment_06 => "Recording assessment results";
        #endregion

        #region Your online information
        private string YourOnline_01 => "Web address";
        #endregion

        #endregion

        public AS_ApplyToStandardPage(ScenarioContext context) : base(context) => _context = context;

        public AS_InformationCommissionerPage AccessYourPolicies_01()
        {
            formCompletionHelper.ClickLinkByText(YourPolicies_01);
            return new AS_InformationCommissionerPage(_context);
        }

        public AS_ApplicationOverviewPage ReturnToApplicationOverview()
        {
            formCompletionHelper.ClickLinkByText("Return to application overview");
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}
