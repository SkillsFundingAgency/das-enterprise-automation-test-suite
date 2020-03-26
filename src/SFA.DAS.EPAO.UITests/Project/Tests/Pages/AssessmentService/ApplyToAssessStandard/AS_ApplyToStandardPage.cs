using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_EnterYourWebAddressPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Enter your web address";

        private readonly ScenarioContext _context;

        public AS_EnterYourWebAddressPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplyToStandardPage EnterWebAddress()
        {
            formCompletionHelper.EnterText(InputText, standardDataHelper.RandomWebsiteAddress);
            Continue();
            return new AS_ApplyToStandardPage(_context);
        }

    }

    public class AS_RecordingAssessmentResultsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Recording assessment results";

        private readonly ScenarioContext _context;

        public AS_RecordingAssessmentResultsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_EnterYourWebAddressPage EnterAssessmentResutls()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_EnterYourWebAddressPage(_context);
        }
    }

    public class AS_ConfirmationOfAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Collation and confirmation of assessment outcomes";

        private readonly ScenarioContext _context;

        public AS_ConfirmationOfAssessmentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_RecordingAssessmentResultsPage EnterCollationOutcome()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_RecordingAssessmentResultsPage(_context);
        }
    }

    public class AS_AssessmentContentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment content";

        private readonly ScenarioContext _context;

        public AS_AssessmentContentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConfirmationOfAssessmentPage EnterAssessmentContent()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ConfirmationOfAssessmentPage(_context);
        }

    }

    public class AS_AssessmentProductsAndToolsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment products and tools";

        private readonly ScenarioContext _context;

        public AS_AssessmentProductsAndToolsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_AssessmentContentPage EnterAssessmentProduct()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentContentPage(_context);
        }

    }

    public class AS_AssessmentAdministrationPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment administration";

        private readonly ScenarioContext _context;

        public AS_AssessmentAdministrationPage(ScenarioContext context) : base(context) => _context = context;
        
        public AS_AssessmentProductsAndToolsPage EnterAssessmentAdministration()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentProductsAndToolsPage(_context);
        }
    }

    public class AS_SecureITInfrastructurePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Secure IT infrastructure";

        private readonly ScenarioContext _context;

        public AS_SecureITInfrastructurePage(ScenarioContext context) : base(context) => _context = context;

        public AS_AssessmentAdministrationPage EnterSecureITInfrastructurePlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentAdministrationPage(_context);
        }

    }

    public class AS_ReviewAndMaintainPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you continuously review and maintain the required resources and assessment tools?";

        private readonly ScenarioContext _context;

        public AS_ReviewAndMaintainPage(ScenarioContext context) : base(context) => _context = context;

        public AS_SecureITInfrastructurePage EnterReviewAndMaintainPlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_SecureITInfrastructurePage(_context);
        }
    }

    public class AS_AssessmentPlanPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you undertake the individual elements of the assessment plan?";

        private readonly ScenarioContext _context;

        public AS_AssessmentPlanPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ReviewAndMaintainPage EnterAssessmentPlan()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ReviewAndMaintainPage(_context);
        }
    }

    public class AS_ChooseDayPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "If your application is successful, can you start an end-point assessment on the day you join the register?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        private readonly ScenarioContext _context;

        public AS_ChooseDayPage(ScenarioContext context) : base(context) => _context = context;

        public AS_AssessmentPlanPage EnterDayToStart()
        {
            SelectYesAndContinue();
            return new AS_AssessmentPlanPage(_context);
        }
    }

    public class AS_WhereWillYouDeliverEndPointAssessmentsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Where will you deliver end-point assessments?";

        private readonly ScenarioContext _context;

        protected By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input");

        public AS_WhereWillYouDeliverEndPointAssessmentsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ChooseDayPage ChooseLocation()
        {
            ClickRandomElement(DeliveryAreas);
            Continue();
            return new AS_ChooseDayPage(_context);
        }
    }


    public class AS_ManageAnyPotentialConflictPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you manage any potential conflict of interest, particular to other functions your organisation may have?";

        private readonly ScenarioContext _context;

        public AS_ManageAnyPotentialConflictPage(ScenarioContext context) : base(context) => _context = context;

        public AS_WhereWillYouDeliverEndPointAssessmentsPage EnterManageAnyPotentialConflict()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_WhereWillYouDeliverEndPointAssessmentsPage(_context);
        }

    }

    public class AS_EngageWithEmployersPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you engage with employers and training organisations?";

        private readonly ScenarioContext _context;

        public AS_EngageWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ManageAnyPotentialConflictPage EnterEngageWithEmployers()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ManageAnyPotentialConflictPage(_context);
        }
    }

    public class AS_IntendToOutsourcePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Do you intend to outsource any of your end-point assessments?";

        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        private readonly ScenarioContext _context;

        public AS_IntendToOutsourcePage(ScenarioContext context) : base(context) => _context = context;

        public AS_EngageWithEmployersPage EnterIntendToOutsource()
        {
            SelectNoAndContinue();
            return new AS_EngageWithEmployersPage(_context);
        }
    }

    public class AS_DeliverEndPointPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you deliver an end-point assessment for this standard?";

        private readonly ScenarioContext _context;

        public AS_DeliverEndPointPage(ScenarioContext context) : base(context) => _context = context;

        public AS_IntendToOutsourcePage EnterDeliverEndPoint()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_IntendToOutsourcePage(_context);
        }
    }

    public class AS_OccupationalExpertisePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you ensure your assessors' occupational expertise is maintained and kept current?";

        private readonly ScenarioContext _context;

        public AS_OccupationalExpertisePage(ScenarioContext context) : base(context) => _context = context;

        public AS_DeliverEndPointPage EnterOccupationalExpertise()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_DeliverEndPointPage(_context);
        }
    }

    public class AS_ExperiencePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "What experience, skills and qualifications will your assessors have?";

        private readonly ScenarioContext _context;

        public AS_ExperiencePage(ScenarioContext context) : base(context) => _context = context;

        public AS_OccupationalExpertisePage EnterExperience()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_OccupationalExpertisePage(_context);
        }
    }

    public class AS_HowRecruitAndTrainAssessorsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How do you recruit and train assessors?";

        private readonly ScenarioContext _context;

        public AS_HowRecruitAndTrainAssessorsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ExperiencePage EnterHowRecruitAndTrainAssessors()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ExperiencePage(_context);
        }
    }

    public class AS_VolumeEndPointAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will the volume of end-point assessments be achieved with the number of assessors you will have?";

        private readonly ScenarioContext _context;

        public AS_VolumeEndPointAssessmentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_HowRecruitAndTrainAssessorsPage EnterVolume()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_HowRecruitAndTrainAssessorsPage(_context);
        }
    }

    public class AS_HowManyEndPointAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How many end-point assessments will you be able to deliver annually?";

        private readonly ScenarioContext _context;

        public AS_HowManyEndPointAssessmentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_VolumeEndPointAssessmentPage EnterHowManyEndPointAssessment()
        {
            formCompletionHelper.EnterText(InputNumber, standardDataHelper.GenerateRandomWholeNumber(1));
            Continue();
            return new AS_VolumeEndPointAssessmentPage(_context);
        }
    }

    public class AS_HowManyAssessorsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How many assessors will you have?";

        private readonly ScenarioContext _context;

        private By InputNumber => By.CssSelector(".govuk-input[type='number']");

        public AS_HowManyAssessorsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_HowManyEndPointAssessmentPage EnterHowManyAssessors()
        {
            formCompletionHelper.EnterText(InputNumber, standardDataHelper.GenerateRandomWholeNumber(1));
            Continue();
            return new AS_HowManyEndPointAssessmentPage(_context);
        }
    }

    public class AS_MembershipProfessionalPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Give details of membership of professional organisations";

        private readonly ScenarioContext _context;

        public AS_MembershipProfessionalPage(ScenarioContext context) : base(context) => _context = context;

        public AS_HowManyAssessorsPage EnterMembershipDetails()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_HowManyAssessorsPage(_context);
        }
    }

    public class AS_EngagementWithTrailblazersAndEmployersPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Engagement with trailblazers and employers";

        private readonly ScenarioContext _context;

        public AS_EngagementWithTrailblazersAndEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public AS_MembershipProfessionalPage EnterEngagement()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_MembershipProfessionalPage(_context);
        }
    }

    public class AS_ImproveTheQualityPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How do you continuously improve the quality of your assessment practice?";

        private readonly ScenarioContext _context;

        public AS_ImproveTheQualityPage(ScenarioContext context) : base(context) => _context = context;

        public AS_EngagementWithTrailblazersAndEmployersPage EnterImproveTheQuality()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_EngagementWithTrailblazersAndEmployersPage(_context);
        }

    }

    public class AS_ConsistencyAssurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Consistency assurance";

        private readonly ScenarioContext _context;

        public AS_ConsistencyAssurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_ImproveTheQualityPage UploadConsistencyAssurance()
        {
            UploadFile();
            return new AS_ImproveTheQualityPage(_context);
        }
    }

    public class AS_FairAccessPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Fair access";

        private readonly ScenarioContext _context;

        public AS_FairAccessPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConsistencyAssurancePage UploadFairAccess()
        {
            UploadFile();
            return new AS_ConsistencyAssurancePage(_context);
        }

    }

    public class AS_ComplaintsAndAppealsPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Complaints and appeals policy";

        private readonly ScenarioContext _context;

        public AS_ComplaintsAndAppealsPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_FairAccessPage UploadComplaintsPolicy()
        {
            UploadFile();
            return new AS_FairAccessPage(_context);
        }

    }

    public class AS_ModerationProcessesPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Moderation processes";

        private readonly ScenarioContext _context;

        public AS_ModerationProcessesPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ComplaintsAndAppealsPolicyPage UploadModerationProcesses()
        {
            UploadFile();
            return new AS_ComplaintsAndAppealsPolicyPage(_context);
        }
    }

    public class AS_MonitoringProceduresPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Monitoring procedures";

        private readonly ScenarioContext _context;

        public AS_MonitoringProceduresPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ModerationProcessesPage UploadMonitoringProcedure()
        {
            UploadFile();
            return new AS_ModerationProcessesPage(_context);
        }

    }

    public class AS_ConflictOfinterestPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Conflict of interest policy";

        private readonly ScenarioContext _context;

        public AS_ConflictOfinterestPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_MonitoringProceduresPage UploadConflictOfinterestPolicy()
        {
            UploadFile();
            return new AS_MonitoringProceduresPage(_context);
        }
    }

    public class AS_PreventAgendaPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Prevent agenda policy";

        private readonly ScenarioContext _context;

        public AS_PreventAgendaPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConflictOfinterestPolicyPage UploadPreventAgendaPolicy()
        {
            UploadFile();
            return new AS_ConflictOfinterestPolicyPage(_context);
        }
    }

    public class AS_SafeguardingPolicyPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Safeguarding policy";

        private readonly ScenarioContext _context;

        public AS_SafeguardingPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AS_PreventAgendaPolicyPage UploadSafeguardingPolicy()
        {
            UploadFile();
            return new AS_PreventAgendaPolicyPage(_context);
        }
    }

    public class AS_EmployersLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Employers liability insurance";

        private readonly ScenarioContext _context;

        public AS_EmployersLiabilityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_SafeguardingPolicyPage UploadEmployersLiabilityInsurance()
        {
            UploadFile();
            return new AS_SafeguardingPolicyPage(_context);
        }
    }

    public class AS_IndemnityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Professional indemnity insurance";

        private readonly ScenarioContext _context;

        public AS_IndemnityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_EmployersLiabilityInsurancePage UploadProfessionalIndemnityInsurance()
        {
            UploadFile();
            return new AS_EmployersLiabilityInsurancePage(_context);
        }
    }
    public class AS_PublicLiabilityInsurancePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Public liability insurance";

        private readonly ScenarioContext _context;

        public AS_PublicLiabilityInsurancePage(ScenarioContext context) : base(context) => _context = context;

        public AS_IndemnityInsurancePage UploadPublicLiabilityInsurance()
        {
            UploadFile();
            return new AS_IndemnityInsurancePage(_context);
        }
    }

    public class AS_InternalAuditPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Internal audit policy";

        private readonly ScenarioContext _context;

        public AS_InternalAuditPage(ScenarioContext context) : base(context) => _context = context;

        public AS_PublicLiabilityInsurancePage UploadAuditPolicy()
        {
            UploadFile();
            return new AS_PublicLiabilityInsurancePage(_context);
        }
    }

    public class AS_InformationCommissionerPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Information commissioner's office (ICO) registration number";

        private readonly ScenarioContext _context;

        public AS_InformationCommissionerPage(ScenarioContext context) : base(context) => _context = context;

        public AS_InternalAuditPage EnterRegNumber()
        {
            formCompletionHelper.EnterText(InputText, standardDataHelper.GenerateRandomAlphanumericString(8));
            Continue();
            return new AS_InternalAuditPage(_context);
        }
    }

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
