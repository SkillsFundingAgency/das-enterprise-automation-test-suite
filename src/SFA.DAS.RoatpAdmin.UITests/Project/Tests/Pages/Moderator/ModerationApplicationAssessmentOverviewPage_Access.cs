using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S5_EvaluatingApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public partial class ModerationApplicationAssessmentOverviewPage : ModeratorBasePage
    {
        private void NavigateToTask(string linkText) => formCompletionHelper.ClickLinkByText(linkText);

        #region Section-1
        public ContinuityPlanForApprenticeshipTrainingPage Access_Section1_ContinuityPlanForApprenticeshipTraining()
        {
            NavigateToTask(Section1_Link1);
            return new ContinuityPlanForApprenticeshipTrainingPage(context);
        }
        public EqualityAndDiversityPolicyPage Access_Section1_EqualityAndDiversityPolicy()
        {
            NavigateToTask(Section1_Link2);
            return new EqualityAndDiversityPolicyPage(context);
        }
        public SafeguardingAndPreventDutyPolicyPage Access_Section1_SafeguardingAndPreventDutyPolicy()
        {
            NavigateToTask(Section1_Link3);
            return new SafeguardingAndPreventDutyPolicyPage(context);
        }
        public HealthAndSafetyPolicyPage Access_Section1_HealthAndSafetyPolicy()
        {
            NavigateToTask(Section1_Link4);
            return new HealthAndSafetyPolicyPage(context);
        }
        public ActingAsASubcontractorPage Access_Section1_ActingAsASubcontractor()
        {
            NavigateToTask(Section1_Link5);
            return new ActingAsASubcontractorPage(context);
        }
        #endregion

        #region Section-2
        public EngagingWithEmployersPage Access_Section2_EngagingWithEmployers()
        {
            NavigateToTask(Section2_Link1);
            return new EngagingWithEmployersPage(context);
        }
        public ComplaintsPolicyPage Access_Section2_ComplaintsPolicy()
        {
            NavigateToTask(Section2_Link2);
            return new ComplaintsPolicyPage(context);
        }
        public ContractForServicesTemplatePage Access_Section2_ContractForServicesTemplate()
        {
            NavigateToTask(Section2_Link3);
            return new ContractForServicesTemplatePage(context);
        }
        public CommitmentStatementTemplatePage Access_Section2_CommitmentStatementTemplate()
        {
            NavigateToTask(Section2_Link4);
            return new CommitmentStatementTemplatePage(context);
        }
        public PriorLearningOfApprenticesPage Access_Section2_PriorLearningOfApprentices()
        {
            NavigateToTask(Section2_Link5);
            return new PriorLearningOfApprenticesPage(context);
        }
        public EnglishAndMathsAssessmentsPage Access_Section2_EnglishAndMathsAssessment()
        {
            NavigateToTask(Section2_Link6);
            return new EnglishAndMathsAssessmentsPage(context);
        }
        public WorkingWithSubcontractorsPage Access_Section2_WorkingWithSubcontractors()
        {
            NavigateToTask(Section2_Link7);
            return new WorkingWithSubcontractorsPage(context);
        }
        #endregion

        #region Section-3
        public TypeOfApprenticeshipTrainingPage Access_Section3_TypeOfApprenticeshipTraining()
        {
            NavigateToTask(Section3_Link1);
            return new TypeOfApprenticeshipTrainingPage(context);
        }
        public DeliveringTrainingInApprenticeshipStandardsPage Access_Section3_TypeOfApprenticeshipTraining_New_Main_Employer()
        {
            NavigateToTask(Section3_Link1);
            return new DeliveringTrainingInApprenticeshipStandardsPage(context);
        }
        public TrainingApprenticesPage Access_Section3_TrainingApprentices()
        {
            NavigateToTask(Section3_Link2);
            return new TrainingApprenticesPage(context);
        }
        public SupportingApprenticesPage Access_Section3_SupportingApprentices()
        {
            NavigateToTask(Section3_Link3);
            return new SupportingApprenticesPage(context);
        }
        public ForecastingStartsPage Access_Section3_ForecastingStarts()
        {
            NavigateToTask(Section3_Link4);
            return new ForecastingStartsPage(context);
        }
        public OffTheJobTrainingPage Access_Section3_OffTheJobTraining()
        {
            NavigateToTask(Section3_Link5);
            return new OffTheJobTrainingPage(context);
        }
        public WhereWillYourApprenticesBeTrainedPage Access_Section3_WhereWillYourApprenticesBeTrained()
        {
            NavigateToTask(Section3_Link6);
            return new WhereWillYourApprenticesBeTrainedPage(context);
        }
        #endregion

        #region Section-4
        public OverallAccountabilityForApprenticeshipsPage Access_Section4_OverallAccountabilityForApprenticeships()
        {
            NavigateToTask(Section4_Link1);
            return new OverallAccountabilityForApprenticeshipsPage(context);
        }
        public ManagementHierarchyForApprenticeshipsPage Access_Section4_ManagementHierarchyForApprenticeships()
        {
            NavigateToTask(Section4_Link2);
            return new ManagementHierarchyForApprenticeshipsPage(context);
        }
        public QualityAndHighStandardsInApprenticeshipTrainingPage Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
        {
            NavigateToTask(Section4_Link3);
            return new QualityAndHighStandardsInApprenticeshipTrainingPage(context);
        }
        public DevelopingAndDeliveringTrainingPage Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
        {
            NavigateToTask(Section4_Link4);
            return new DevelopingAndDeliveringTrainingPage(context);
        }
        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
        {
            NavigateToTask(Section4_Link4);
            return new SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(context);
        }
        public YourSectorsAndEmployeesPage Access_Section4_YourSectorsAndEmployees()
        {
            NavigateToTask(Section4_Link5);
            return new YourSectorsAndEmployeesPage(context);
        }
        public PolicyForProfessionalDevelopmentOfEmployeesPage Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
        {
            NavigateToTask(Section4_Link6);
            return new PolicyForProfessionalDevelopmentOfEmployeesPage(context);
        }
        #endregion

        #region Section-5
        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
        {
            NavigateToTask(Section5_Link1);
            return new ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(context);
        }
        public ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
        {
            NavigateToTask(Section5_Link2);
            return new ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(context);
        }
        public SystemsAndProcessesToCollectApprenticeshipDataPage Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
        {
            NavigateToTask(Section5_Link3);
            return new SystemsAndProcessesToCollectApprenticeshipDataPage(context);
        }
        #endregion

        #region Section-6
        public WhatIsTheOutcomeForThisApplicationPage Access_Section6_ReadyForModeration()
        {
            NavigateToTask(Section6_Link1);
            return new WhatIsTheOutcomeForThisApplicationPage(context);
        }
        #endregion
    }
}
