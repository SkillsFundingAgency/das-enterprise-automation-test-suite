using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.EvaluatingApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.PlanningApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public partial class ApplicationAssessmentOverviewPage : AssessorBasePage
    {
        private void NavigateToTask(string linkText) => formCompletionHelper.ClickLinkByText(linkText);

        #region Section-1
        public ContinuityPlanForApprenticeshipTrainingPage Access_Section1_Link1()
        {
            NavigateToTask(Section1_Link1);
            return new ContinuityPlanForApprenticeshipTrainingPage(_context);
        }
        public EqualityAndDiversityPolicyPage Access_Section1_Link2()
        {
            NavigateToTask(Section1_Link2);
            return new EqualityAndDiversityPolicyPage(_context);
        }
        public SafeguardingAndPreventDutyPolicyPage Access_Section1_Link3()
        {
            NavigateToTask(Section1_Link3);
            return new SafeguardingAndPreventDutyPolicyPage(_context);
        }
        public HealthAndSafetyPolicyPage Access_Section1_Link4()
        {
            NavigateToTask(Section1_Link4);
            return new HealthAndSafetyPolicyPage(_context);
        }
        public ActingAsASubcontractorPage Access_Section1_Link5()
        {
            NavigateToTask(Section1_Link5);
            return new ActingAsASubcontractorPage(_context);
        }
        #endregion

        #region Section-2
        public EngagingWithEmployersPage Access_Section2_Link1()
        {
            NavigateToTask(Section2_Link1);
            return new EngagingWithEmployersPage(_context);
        }
        public ComplaintsPolicyPage Access_Section2_Link2()
        {
            NavigateToTask(Section2_Link2);
            return new ComplaintsPolicyPage(_context);
        }
        public ContractForServicesTemplatePage Access_Section2_Link3()
        {
            NavigateToTask(Section2_Link3);
            return new ContractForServicesTemplatePage(_context);
        }
        public CommitmentStatementTemplatePage Access_Section2_Link4()
        {
            NavigateToTask(Section2_Link4);
            return new CommitmentStatementTemplatePage(_context);
        }
        public PriorLearningOfApprenticesPage Access_Section2_Link5()
        {
            NavigateToTask(Section2_Link5);
            return new PriorLearningOfApprenticesPage(_context);
        }
        public WorkingWithSubcontractorsPage Access_Section2_Link6()
        {
            NavigateToTask(Section2_Link6);
            return new WorkingWithSubcontractorsPage(_context);
        }
        #endregion

        #region Section-3
        public TypeOfApprenticeshipTrainingPage Access_Section3_Link1()
        {
            NavigateToTask(Section3_Link1);
            return new TypeOfApprenticeshipTrainingPage(_context);
        }
        public ForecastingStartsPage Access_Section3_Link3()
        {
            NavigateToTask(Section3_Link3);
            return new ForecastingStartsPage(_context);
        }
        public OffTheJobTrainingPage Access_Section3_Link4()
        {
            NavigateToTask(Section3_Link4);
            return new OffTheJobTrainingPage(_context);
        }
        public WhereWillYourApprenticesBeTrainedPage Access_Section3_Link5()
        {
            NavigateToTask(Section3_Link5);
            return new WhereWillYourApprenticesBeTrainedPage(_context);
        }
        #endregion

        #region Section-4
        public OverallAccountabilityForApprenticeshipsPage Access_Section4_Link1()
        {
            NavigateToTask(Section4_Link1);
            return new OverallAccountabilityForApprenticeshipsPage(_context);
        }
        public ManagementHierarchyForApprenticeshipsPage Access_Section4_Link2()
        {
            NavigateToTask(Section4_Link2);
            return new ManagementHierarchyForApprenticeshipsPage(_context);
        }
        public QualityAndHighStandardsInApprenticeshipTrainingPage Access_Section4_Link3()
        {
            NavigateToTask(Section4_Link3);
            return new QualityAndHighStandardsInApprenticeshipTrainingPage(_context);
        }
        public DevelopingAndDeliveringTrainingPage Access_Section4_Link4()
        {
            NavigateToTask(Section4_Link4);
            return new DevelopingAndDeliveringTrainingPage(_context);
        }
        public YourSectorsAndEmployeesPage Access_Section4_Link5()
        {
            NavigateToTask(Section4_Link5);
            return new YourSectorsAndEmployeesPage(_context);
        }
        public PolicyForProfessionalDevelopmentOfEmployeesPage Access_Section4_Link6()
        {
            NavigateToTask(Section4_Link6);
            return new PolicyForProfessionalDevelopmentOfEmployeesPage(_context);
        }
        #endregion

        #region Section-5
        public ProcessForEvaluatingTheQualityOfTrainingDeliveredPage Access_Section5_Link1()
        {
            NavigateToTask(Section5_Link1);
            return new ProcessForEvaluatingTheQualityOfTrainingDeliveredPage(_context);
        }
        public ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage Access_Section5_Link2()
        {
            NavigateToTask(Section5_Link2);
            return new ProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage(_context);
        }
        public SystemsAndProcessesToCollectApprenticeshipDataPage Access_Section5_Link3()
        {
            NavigateToTask(Section5_Link3);
            return new SystemsAndProcessesToCollectApprenticeshipDataPage(_context);
        }
        #endregion

        #region Section-6
        public AreYouSureThisApplicationIsReadyForModerationPage Access_Section6_Link1()
        {
            NavigateToTask(Section6_Link1);
            return new AreYouSureThisApplicationIsReadyForModerationPage(_context);
        }
        #endregion
    }
}
