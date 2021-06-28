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
            return new ContinuityPlanForApprenticeshipTrainingPage(_context);
        }
        public EqualityAndDiversityPolicyPage Access_Section1_EqualityAndDiversityPolicy()
        {
            NavigateToTask(Section1_Link2);
            return new EqualityAndDiversityPolicyPage(_context);
        }
        public SafeguardingAndPreventDutyPolicyPage Access_Section1_SafeguardingAndPreventDutyPolicy()
        {
            NavigateToTask(Section1_Link3);
            return new SafeguardingAndPreventDutyPolicyPage(_context);
        }
        public HealthAndSafetyPolicyPage Access_Section1_HealthAndSafetyPolicy()
        {
            NavigateToTask(Section1_Link4);
            return new HealthAndSafetyPolicyPage(_context);
        }
        public ActingAsASubcontractorPage Access_Section1_ActingAsASubcontractor()
        {
            NavigateToTask(Section1_Link5);
            return new ActingAsASubcontractorPage(_context);
        }
        #endregion

        #region Section-2
        public EngagingWithEmployersPage Access_Section2_EngagingWithEmployers()
        {
            NavigateToTask(Section2_Link1);
            return new EngagingWithEmployersPage(_context);
        }
        public ComplaintsPolicyPage Access_Section2_ComplaintsPolicy()
        {
            NavigateToTask(Section2_Link2);
            return new ComplaintsPolicyPage(_context);
        }
        public ContractForServicesTemplatePage Access_Section2_ContractForServicesTemplate()
        {
            NavigateToTask(Section2_Link3);
            return new ContractForServicesTemplatePage(_context);
        }
        public CommitmentStatementTemplatePage Access_Section2_CommitmentStatementTemplate()
        {
            NavigateToTask(Section2_Link4);
            return new CommitmentStatementTemplatePage(_context);
        }
        public PriorLearningOfApprenticesPage Access_Section2_PriorLearningOfApprentices()
        {
            NavigateToTask(Section2_Link5);
            return new PriorLearningOfApprenticesPage(_context);
        }
        public EnglishAndMathsAssessmentsPage Access_Section2_EnglishAndMathsAssessment()
        {
            NavigateToTask(Section2_Link6);
            return new EnglishAndMathsAssessmentsPage(_context);
        }
        public WorkingWithSubcontractorsPage Access_Section2_WorkingWithSubcontractors()
        {
            NavigateToTask(Section2_Link7);
            return new WorkingWithSubcontractorsPage(_context);
        }
        #endregion

        #region Section-3
        public TypeOfApprenticeshipTrainingPage Access_Section3_TypeOfApprenticeshipTraining()
        {
            NavigateToTask(Section3_Link1);
            return new TypeOfApprenticeshipTrainingPage(_context);
        }
        public TrainingApprenticesPage Access_Section3_TrainingApprentices()
        {
            NavigateToTask(Section3_Link2);
            return new TrainingApprenticesPage(_context);
        }
        public SupportingApprenticesPage Access_Section3_SupportingApprentices()
        {
            NavigateToTask(Section3_Link3);
            return new SupportingApprenticesPage(_context);
        }
        public ForecastingStartsPage Access_Section3_ForecastingStarts()
        {
            NavigateToTask(Section3_Link4);
            return new ForecastingStartsPage(_context);
        }
        public OffTheJobTrainingPage Access_Section3_OffTheJobTraining()
        {
            NavigateToTask(Section3_Link5);
            return new OffTheJobTrainingPage(_context);
        }
        public WhereWillYourApprenticesBeTrainedPage Access_Section3_WhereWillYourApprenticesBeTrained()
        {
            NavigateToTask(Section3_Link6);
            return new WhereWillYourApprenticesBeTrainedPage(_context);
        }
        #endregion

        #region Section-4
        public OverallAccountabilityForApprenticeshipsPage Access_Section4_OverallAccountabilityForApprenticeships()
        {
            NavigateToTask(Section4_Link1);
            return new OverallAccountabilityForApprenticeshipsPage(_context);
        }
        public ManagementHierarchyForApprenticeshipsPage Access_Section4_ManagementHierarchyForApprenticeships()
        {
            NavigateToTask(Section4_Link2);
            return new ManagementHierarchyForApprenticeshipsPage(_context);
        }
        public QualityAndHighStandardsInApprenticeshipTrainingPage Access_Section4_QualityAndHighStandardsInApprenticeshipTraining()
        {
            NavigateToTask(Section4_Link3);
            return new QualityAndHighStandardsInApprenticeshipTrainingPage(_context);
        }
        public DevelopingAndDeliveringTrainingPage Access_Section4_DevelopingAndDeliveringTraining_ForMainProviderRoute()
        {
            NavigateToTask(Section4_Link4);
            return new DevelopingAndDeliveringTrainingPage(_context);
        }
        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage Access_Section4_DevelopingAndDeliveringTraining_ForSupportingProviderRoute()
        {
            NavigateToTask(Section4_Link4);
            return new SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(_context);
        }
        public YourSectorsAndEmployeesPage Access_Section4_YourSectorsAndEmployees()
        {
            NavigateToTask(Section4_Link5);
            return new YourSectorsAndEmployeesPage(_context);
        }
        public PolicyForProfessionalDevelopmentOfEmployeesPage Access_Section4_PolicyForProfessionalDevelopmentOfEmployees()
        {
            NavigateToTask(Section4_Link6);
            return new PolicyForProfessionalDevelopmentOfEmployeesPage(_context);
        }
        #endregion

        #region Section-5
        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
        {
            NavigateToTask(Section5_Link1);
            return new ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(_context);
        }
        public ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
        {
            NavigateToTask(Section5_Link2);
            return new ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(_context);
        }
        public SystemsAndProcessesToCollectApprenticeshipDataPage Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
        {
            NavigateToTask(Section5_Link3);
            return new SystemsAndProcessesToCollectApprenticeshipDataPage(_context);
        }
        #endregion

        #region Section-6
        public WhatIsTheOutcomeForThisApplicationPage Access_Section6_ReadyForModeration()
        {
            NavigateToTask(Section6_Link1);
            return new WhatIsTheOutcomeForThisApplicationPage(_context);
        }
        #endregion
    }
}
