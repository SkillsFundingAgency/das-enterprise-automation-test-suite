using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.PlanningApprenticeshipTrainingChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ProtectingYourApprenticesChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ReadinessToEngageChecks;

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
    }
}
